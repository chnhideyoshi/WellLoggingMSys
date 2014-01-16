    using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using PublicProtocal;
using System.Net;

namespace VirtualDataSource
{
    class Program
    {
        #region DefaultSettings
        public static string DefaultIpAddress = "127.0.0.1";
        public static int DefaultPort = 8500;
        public static int DefaultRequestInterval = 1000;
        public static double DefautDropSpeed = 0.01;
        public static double ContinusRate = 500;
        public static double DefaultStartHeight = 0;
        public static double DefaultEndHeight = 100;
        public static int DefaultPackSize = 10;
        #endregion

        #region Propertys
        static double currentHeight = 0;
        static double currentSpeed = 0.01;
        static double startHeight = 0;
        static double endHeight = 100;
        #endregion

        static Dictionary<Guid, bool> dataStopPendingTable = new Dictionary<Guid, bool>();

        static void Main(string[] args)
        {
            try
            {
                #region InitParms
                ParamsExtractor pe = new ParamsExtractor(args);
                currentSpeed = pe.GetCurrentSpeed(DefautDropSpeed);
                startHeight = pe.GetStartHeight(DefaultStartHeight);
                endHeight = pe.GetEndHeight(DefaultEndHeight);
                int count = pe.GetDeviceNumber();
                List<CurveInfo> curveList = pe.GetCurveList();
                Console.WriteLine("speed: " + currentSpeed);
                Console.WriteLine("start height: " + startHeight);
                Console.WriteLine("end height: " + endHeight);
                Console.WriteLine("curve count: " + curveList.Count);
                #endregion

                #region InitHeight
                Thread heightThread = new Thread(() =>
                        {
                            int timeSleep = (int)(1000 / ContinusRate);
                            while (true)
                            {
                                currentHeight += currentSpeed / ContinusRate;

                                Thread.Sleep(timeSleep);
                                if (currentHeight >= endHeight)
                                {
                                    break;
                                }
                            }
                        }) { IsBackground = true };
                heightThread.Start();
                #endregion

                #region InitHeight2

                #endregion

                #region InitDevice
                curveList.ForEach(curveInfo =>
                      {
                          Thread thread = CreateCommandManagerThread();
                          thread.IsBackground = true;
                          thread.Start(curveInfo);
                          Console.WriteLine("thread start : curve info :" + curveInfo.Tag);
                      });
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }

        static Thread CreateCommandManagerThread()
        {
            Thread thread = new Thread((info) =>
            {
                CurveInfo curveInfo = info as CurveInfo;
                if (info == null) { return; }
                while (true)
                {
                    try
                    {
                        TcpClient client = new TcpClient();
                        while (true)
                        {
                            try
                            {
                                client.Connect(new System.Net.IPEndPoint(IPAddress.Parse(DefaultIpAddress), DefaultPort));
                                Console.WriteLine("connected success!");
                                break;
                            }
                            catch
                            {
                                Thread.Sleep(2000);
                                Console.WriteLine("can't connected to server! try again");
                            }
                        }
                        Thread dataThread = null;
                        Commands command = Commands.Surpress;
                        SendResponse(client, curveInfo, Responses.Ready);
                        while (true)
                        {
                            command = GetCommand(client);
                            #region Surpress
                            if (command == Commands.Surpress)
                            {
                                SetState(curveInfo.Id, false);
                                Thread.Sleep(DefaultRequestInterval);
                                SendResponse(client, curveInfo, Responses.Ready);
                            }
                            #endregion
                            #region DataRequired
                            if (command == Commands.DataRequired)
                            {
                                SetState(curveInfo.Id, true);
                                if (dataThread == null || !dataThread.IsAlive)
                                {
                                    dataThread = CreateDataTransferThread(info, client, command);
                                    dataThread.IsBackground = true;
                                    dataThread.Start(info);
                                    Console.WriteLine("thread started : dataThread");
                                }
                                else
                                {
                                    Console.WriteLine("continue send data");
                                }
                            }
                            #endregion
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            });
            return thread;
        }

        static Thread CreateDataTransferThread(object info, TcpClient client, Commands command)
        {
            Thread thread = new Thread((curveInfo) =>
            {
                try
                {
                    CurveInfo threadCurveInfo = curveInfo as CurveInfo;
                    int timeSleep = 1000 / threadCurveInfo.SamplingRate;
                    while (true)
                    {
                        ResponsePackage p = new ResponsePackage();
                        p.Points = new Coordinate[DefaultPackSize];
                        for (int i = 0; i < DefaultPackSize; i++)
                        {
                            Coordinate co = CurveAnalogData.GetCoordinateByHeight(currentHeight);
                            p.Points[i] = co;
                            if (timeSleep != 0)
                            {
                                Thread.Sleep(timeSleep);
                            }
                            if (!GetState(threadCurveInfo.Id)) { return; }
                        }
                        Console.WriteLine("send response data for " + threadCurveInfo.Tag + " , count:" + p.Points.Length + ", current height : " + currentHeight.ToString("0.00"));
                        if (!GetState(threadCurveInfo.Id)) { return; }
                        SendResponse(client, threadCurveInfo, Responses.Data, p);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error occured : " + ex.Message);
                    return;
                }
            });
            return thread;
        }

        static void SendResponse(TcpClient client, CurveInfo info, Responses responses, ResponsePackage pack)
        {
            pack.Response = responses;
            pack.Id = info.Id;
            pack.Tag = info.Tag;
            BinaryFormatter formatter = new BinaryFormatter();
            NetworkStream ns = client.GetStream();
            lock (ns)
            {
                formatter.Serialize(ns, pack);
            }
        }

        static void SendResponse(TcpClient client, CurveInfo info, Responses responses)
        {
            ResponsePackage p = new ResponsePackage();
            p.Response = responses;
            p.Id = info.Id;
            p.Tag = info.Tag;
            BinaryFormatter formatter = new BinaryFormatter();
            NetworkStream ns = client.GetStream();
            lock (ns)
            {
                formatter.Serialize(ns, p);
            }
            Console.WriteLine("send response for " + info.Tag + " , " + responses);
        }

        static Commands GetCommand(TcpClient client)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            NetworkStream ns = client.GetStream();
            CommandPackage cp = formatter.Deserialize(ns) as CommandPackage;
            if (cp != null)
            {
                Console.WriteLine("get command: " + cp.Command);
                return cp.Command;
            }
            Console.WriteLine("get null command, treat as surpress");
            return Commands.Surpress;
        }

        static void SetState(Guid id, bool acceptData)
        {
            lock (dataStopPendingTable)
            {
                if (dataStopPendingTable.ContainsKey(id))
                {
                    dataStopPendingTable[id] = acceptData;
                }
                else
                {
                    dataStopPendingTable.Add(id, acceptData);
                }
            }
        }

        static bool GetState(Guid id)
        {
            if (dataStopPendingTable.ContainsKey(id))
            {
                return dataStopPendingTable[id];
            }
            else
            {
                dataStopPendingTable.Add(id, true);
                return true;
            }
        }
    }
}
