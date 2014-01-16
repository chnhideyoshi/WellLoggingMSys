using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace LoggingDataManager.RTL
{
    public static class ProcessManager
    {
        public static void StartDataSourceProccess(StartInfo info)
        {
            Start(FilePath, info.ToString());
        }
        static readonly string FilePath = "VirtualDataSource.exe";
        private static void Start(string path, string args)
        {
            if (File.Exists(path))
            {
                Process p = new Process();
                //p.StartInfo.UseShellExecute = false;
                //p.StartInfo.RedirectStandardInput = true;
                //p.StartInfo.RedirectStandardOutput = true;
                //p.StartInfo.RedirectStandardError = true;
                //p.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
                //p.StartInfo.CreateNoWindow = false;
                p.StartInfo.FileName = path;
               // p.EnableRaisingEvents = true;
                p.StartInfo.Arguments = args;
                p.Start();
                //p.WaitForExit();
                // this.Dispatcher.BeginInvoke(new Action(() => { //textBox1.Text = }));
                //string Result = p.StandardOutput.ReadToEnd();
                //p.Close();
                //return Result;
            }
            //return "error";
        }
        public static string ArgumentBuilder(Guid id, string tag, int samplingRate)
        {
            return id + "&" + tag + "&" + samplingRate;
        }
        public class StartInfo
        {
            public override string ToString()
            {
                //InitParams();
                StringBuilder sb = new StringBuilder();
                if (IdList != null)
                {
                    sb.Append(StartHeight+" ");
                    sb.Append(EndHeight + " ");
                    sb.Append(Speed + " ");
                    sb.Append(IdList.Count + " ");
                    for (int i = 0; i < IdList.Count; i++)
                    {
                        sb.Append(IdList[i].ToString());
                        sb.Append("&");
                        Model.Curve curve = curveList.Find((c) => { return c.Id == IdList[i]; });
                        Model.Device device = deviceList.Find((d) => { return d.CurveId == IdList[i]; });
                        sb.Append(curve.CurveName);
                        sb.Append("&");
                        sb.Append(device.SamplingRate);
                        sb.Append(" ");
                    }
                    return sb.ToString().Trim();
                }
                return "0 ";
            }

            private void InitParams()
            {
                if(IdList.Count==0){return;}
                StartHeight = double.MaxValue;
                EndHeight = double.MinValue;
                for (int i = 0; i < IdList.Count; i++)
                {
                    Model.Curve curve = curveList.Find((c) => { return c.Id == IdList[i]; });
                    if (curve.XMinValue < StartHeight)
                    {
                        StartHeight = curve.XMinValue;
                    }
                    if (curve.XMaxValue > EndHeight)
                    {
                        EndHeight = curve.XMaxValue;
                    }
                }
                if (StartHeight == double.MaxValue) { StartHeight = 0; }
                if (EndHeight == double.MinValue) { EndHeight = StartHeight + 100; }

            }
            public List<Guid> IdList { get; set; }
            public double StartHeight { get; set; }
            public double EndHeight { get; set; }
            public double Speed { get; set; }
            public List<Model.Curve> curveList { get; set; }
            public List<Model.Device> deviceList { get; set; }
        }

        public static bool CheckSourceProcessRunning()
        {
            Process[] prc = Process.GetProcesses();
            foreach (Process pr in prc) //遍历整个进程
            {
                if (pr.ProcessName == FilePath)
                    return true;
            }
            return false;
        }
    }
    
}
