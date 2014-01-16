using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LoggingDataManager.Depth
{
    //public class DepthServer
    //{
    //    public static double DefautDropSpeed = 0.01;
    //    public static double ContinusRate = 500;
    //    public static double DefaultStartHeight = 0;
    //    public static double DefaultEndHeight = 100;
    //    #region Propertys
    //    static double currentHeight = 0;
    //    static double currentSpeed = 0.01;
    //    static double startHeight = 0;
    //    static double endHeight = 100;
    //    #endregion
    //    static DepthServer instance = new DepthServer();
    //    public static DepthServer Instance
    //    {
    //        get { return DepthServer.instance; }
    //    }
    //    DepthServer()
    //    {
    //        #region InitHeight
    //        Thread heightThread = new Thread(() =>
    //        {
    //            int timeSleep = (int)(1000 / ContinusRate);
    //            while (true)
    //            {
    //                currentHeight += currentSpeed / ContinusRate;
    //                Thread.Sleep(timeSleep);
    //                if (currentHeight >= endHeight)
    //                {
    //                    break;
    //                }
    //            }
    //        }) { IsBackground = true };
    //        heightThread.Start();
    //        #endregion
    //    }
    //}
}
