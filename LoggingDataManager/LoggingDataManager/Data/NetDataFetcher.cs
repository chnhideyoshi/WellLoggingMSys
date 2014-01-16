using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using PublicProtocal;
using System.ComponentModel;

namespace LoggingDataManager.Data
{
    public class NetDataFetcher : DataFetcher
    {
        public static readonly int Port = 8500;

        public static readonly string IntransferStateDescription = "传输中";
        public static readonly string PausedStateDescription = "就绪/已暂停";
        public static readonly string UnknownStateDescription = "未启动";
        #region SingleInstance
        private static NetDataFetcher instance = new NetDataFetcher();
        private TcpListener listener = null;
        public static NetDataFetcher Instance
        {
            get { return NetDataFetcher.instance; }
        }
       
        #endregion

        #region Events
        
        private void ThreadOnCompleted(string message,Guid curveId)
        {
            SetDescription(curveId, "已完成");
            NotifyEventArgs args = new NotifyEventArgs();
            args.Id = curveId;
            args.Message = message;
            worker.ReportProgress(3, args);
        }
        private void ThreadOnErrorOccured(string message, Guid curveId)
        {
           
            NotifyEventArgs args = new NotifyEventArgs();
            args.Id = curveId;
            args.Message = message;
            worker.ReportProgress(2, args);
        }
        private void ThreadOnProgressChanged(IPAddress address,ResponsePackage p)
        {
            NotifyEventArgs args = new NotifyEventArgs();
            args.Options = new object[2] { p.Response, address };
            args.Points = p.Points;
            args.Id = p.Id;
            args.Tag = p.Tag;
            int count = p.Points == null ? 0 : p.Points.Length;
            CurveData data = GetCurveData(args.Id);
            if (data != null)
            {
                data.AddCoordinates(args.Points);
            }
            worker.ReportProgress(0, args);
        }
        private void ThreadOnPackReceived(IPAddress address, ResponsePackage p)
        {
            NotifyEventArgs args = new NotifyEventArgs();
            args.Id = p.Id;
            args.Tag = p.Tag;
            args.Options = new object[2] { p.Response, address };
            worker.ReportProgress(4, args);
        }
        private void ThreadOnLoggingEventsFired(string message)
        {
            NotifyEventArgs args = new NotifyEventArgs();
            args.Message = message;
            worker.ReportProgress(1, args);
        }

        #endregion

        #region Properties
        public bool IsActive
        {
            get { return worker.IsBusy; }
        } 
        #endregion

        #region Priavte
        BackgroundWorker worker = null;
        //Dictionary<Guid, Thread> threadTable = new Dictionary<Guid, Thread>();
        //Dictionary<Guid, DataSourceState> dataStateTable = new Dictionary<Guid, DataSourceState>();
        Dictionary<Guid, ThreadContextData> dataStateInfoTable = new Dictionary<Guid, ThreadContextData>();
        #endregion

        public override void AddRegisteredId(Guid id)
        {
            base.AddRegisteredId(id);
            ThreadContextData data = new ThreadContextData();
            data.CurrentId = id;
            dataStateInfoTable.Add(id,data);
            SetState(id,DataSourceState.Paused);
        }

        public override void RemoveRegisteredId(Guid id)
        {
            base.RemoveRegisteredId(id);
            dataStateInfoTable.Remove(id);
        }

        public override void ClearAllRegisteredIds()
        {
            base.ClearAllRegisteredIds();
            dataStateInfoTable.Clear();
        }

        public override void BeginGetData()
        {
            StartListener();
            base.BeginGetData();
        }

        public void Start(Guid id)
        {
            SetState(id, DataSourceState.InTransfer);
        }

        public void Pause(Guid id)
        {
            SetState(id, DataSourceState.Paused);
        }

        public void PauseAll()
        {
            foreach (Guid id in registeredIdList)
            {
                SetState(id, DataSourceState.Paused);
            }
        }

        public string GetFetcherState(Guid id)
        {
            if (dataStateInfoTable.ContainsKey(id))
            {
                return dataStateInfoTable[id].StateDescription;
            }
            else
            {
                return UnknownStateDescription;
            }
        }

        private NetDataFetcher()
        {
            InitListener();
            BeginGetData();
        }

        public override string ToString()
        {
            return "网络端口"+Port;
        }

        private void StartListener()
        {
            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        private void InitListener()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        #region Thread
        private DataSourceState GetState(Guid id)
        {
            //lock (dataStateInfoTable)
            //{
                if (!dataStateInfoTable.ContainsKey(id))
                {
                    return DataSourceState.Paused;
                }
                else
                {
                    return dataStateInfoTable[id].State;
                }
            //}
        }

        private void SetDescription(Guid id, string description)
        {
            if (dataStateInfoTable.ContainsKey(id))
            {
                dataStateInfoTable[id].StateDescription = description;
            }
        }

        private void SetState(Guid id, DataSourceState state)
        {
            //lock (dataStateInfoTable)
            //{
                if (dataStateInfoTable.ContainsKey(id))
                {
                    dataStateInfoTable[id].State = state;
                    if (state == DataSourceState.InTransfer)
                    {
                        dataStateInfoTable[id].StateDescription = IntransferStateDescription;
                    }
                    if (state == DataSourceState.Paused)
                    {
                        dataStateInfoTable[id].StateDescription = PausedStateDescription;
                    }
                }
                else
                {
                    //dataStateTable.Add(id, state);
                }
            //}
        }

        private void RegisterThread(Guid id, Thread thread)
        {
            if (dataStateInfoTable.ContainsKey(id))
            {
                if (dataStateInfoTable[id] != null)
                {
                    dataStateInfoTable[id].CurrentThread = thread;
                }
            }
            else
            {
               // threadTable.Add(id, thread);
            }
        }

        private void RegisterCurrentThread(Guid id)
        {
            RegisterThread(id, Thread.CurrentThread);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnCompleted(new NotifyEventArgs() 
            {
                Message="Listerning Stopped",
            });
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            NotifyEventArgs args=e.UserState as NotifyEventArgs;
            switch (e.ProgressPercentage)
            {
                case 0: { base.OnProgressChanged(args); } break;//progress
                case 1: { base.OnLoggingEventsFired(args); } break;//log
                case 2: { base.OnErrorOccured(args); } break;//error
                case 3: { base.OnCompleted(args); } break;//completed
                case 4: { base.OnDataFetchingPackReceived(args); } break;
                default: { throw new Exception(); }
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                TcpListener lis = new TcpListener(IPAddress.Parse("127.0.0.1"), Port);
                listener = lis;
                lis.Start();
                ThreadOnLoggingEventsFired("message from class: NetDataFetcher : listening started.");
                while (true)
                {
                    TcpClient client = lis.AcceptTcpClient();
                    ThreadOnLoggingEventsFired("message from class: NetDataFetcher : accepted client.");
                    Thread thread = new Thread((args) =>
                    {
                        TcpClient tcpClient = args as TcpClient;
                        if (tcpClient != null && tcpClient.Connected)
                        {
                            DispatchThread(client);
                        }
                    });
                    thread.IsBackground = true;
                    thread.Start(client);
                    ThreadOnLoggingEventsFired("message from class: NetDataFetcher : new thread started.");
                }
            }
            catch (Exception ex)
            {
                ThreadOnErrorOccured(ex.Message, Guid.Empty);
                return;
            }
        } 
        #endregion

        private void DispatchThread(TcpClient client)
        {
            #region GetIp
            IPAddress address = null;
            IPEndPoint ep = client.Client.RemoteEndPoint as IPEndPoint;
            if (ep != null)
            {
                address = ep.Address;
            }
            else { throw new Exception("没有IP？"); }
            #endregion
            Guid currentId = Guid.Empty;
            BinaryFormatter formatter = new BinaryFormatter();

            NetworkStream ns = client.GetStream();
            while (true)
            {
                #region ReceivePackage
                ResponsePackage p = null;
                try
                {
                    p = formatter.Deserialize(ns) as ResponsePackage;
                    if (p == null)
                    {
                        throw new Exception("error break circle: pack deserialize failed");
                    }
                    currentId = p.Id;
                    ThreadOnPackReceived(address, p);
                    RegisterCurrentThread(p.Id);
                }
                catch (Exception ex)
                {
                    ThreadOnLoggingEventsFired("error break circle: exception : " + ex.Message);
                    if (currentId != Guid.Empty)
                    {
                        SetDescription(currentId, "异常终止");
                        ThreadOnErrorOccured(ex.Message, currentId);
                    }
                    return;
                }
                #endregion
                #region IfReady
                try
                {
                    if (p.Response == Responses.Ready)
                    {
                        ThreadOnLoggingEventsFired(string.Format("receive ready pack '{0}' from {1}", p.Tag, address));
                        if (registeredIdList.Contains(p.Id))
                        {
                            if (GetState(p.Id) == DataSourceState.InTransfer)
                            {
                                SendCommand(client, p, Commands.DataRequired);
                            }
                            if (GetState(p.Id) == DataSourceState.Paused)
                            {
                                SendCommand(client, p, Commands.Surpress);
                            }
                        }
                        else
                        {
                            SendCommand(client, p, Commands.Surpress);

                        }
                    }
                }
                catch { continue; }
                #endregion
                #region  IfData
                try
                {
                    if (p.Response == Responses.Data)
                    {
                        //ThreadOnLoggingEventsFired(string.Format("receive data pack '{0}' from {1}", p.Tag, address));
                        if (registeredIdList.Contains(p.Id))
                        {
                            if (GetState(p.Id) == DataSourceState.InTransfer)
                            {
                                SendCommand(client, p, Commands.DataRequired);
                            }
                            if (GetState(p.Id) == DataSourceState.Paused)
                            {
                                SendCommand(client, p, Commands.Surpress);
                            }
                        }
                        else
                        {
                            SendCommand(client, p, Commands.Surpress);
                        }
                        ThreadOnProgressChanged(address, p);
                    }
                }
                catch { continue; }
                #endregion
            }
        }

        private void SendCommand(TcpClient client, ResponsePackage refPackage,Commands commands)
        {
            BinaryFormatter formater = new BinaryFormatter();
            NetworkStream ns = client.GetStream();
            CommandPackage cp=new CommandPackage();
            cp.Command=commands;
            lock (ns)
            {
                formater.Serialize(ns, cp);
            }
            ThreadOnLoggingEventsFired(string.Format("send commands '{0}' to {1}", commands, refPackage.Tag));
        }
        
        public enum DataSourceState
        {
            InTransfer=1,
            Paused=2,
        }
        public class ThreadContextData
        {
            public Guid CurrentId { get; set; }
            public IPAddress CurrentIpAddress { get; set; }
            public string StateDescription { get; set; }
            public DataSourceState State { get; set; }
            public Thread CurrentThread { get; set; }
        }

        public void CloseConnection()
        {
            try
            {
                if (listener != null)
                    listener.Stop();
            }
            catch { return; }
        }
    }
    

}
