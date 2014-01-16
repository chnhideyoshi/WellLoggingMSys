using System;
using System.Collections.Generic;
using System.Text;
using PublicProtocal;

namespace VirtualDataSource
{
    public class ParamsExtractor
    {
        Config.ConfigReader reader=null;
        bool usingConfig = false;
        string[] arguments;
        public ParamsExtractor(string[] args)
        {
            arguments = args;
            if (args == null || args.Length == 0)
            {
                usingConfig = true;
                reader = new Config.ConfigReader("config.xml");
            }
            else
            {
                usingConfig = false;
            }
        }
        public int GetDeviceNumber()
        {
            if (usingConfig)
            {
                return reader.GetChildItemCount("DefaultDeviceInfo");
            }
            else
            {
                try
                {
                    return int.Parse(arguments[3]);
                }
                catch { Console.WriteLine("arguments format error!"); return 0; }
            }
        }
        public string GetHostIp()
        {
            if (usingConfig)
            {
                return reader.GetStringSettingItem("HostIp", "127.0.0.1");
            }
            else
            {
                return "127.0.0.1";
            }
        }
        public int GetHostPort()
        {
            if (usingConfig)
            {
                return reader.GetIntSettingItem("HostPort", PublicProtocal.PublicParms.Port);
            }
            else
            {
                return PublicProtocal.PublicParms.Port;
            }
        }
        internal List<CurveInfo> GetCurveList()
        {
            List<CurveInfo> list = new List<CurveInfo>();
            if (usingConfig)
            {
                #region UsingConfig
                List<System.Xml.XmlElement> elist = reader.GetUnDefinedElement("DefaultDeviceInfo");
                elist.ForEach((element) =>
                {
                    CurveInfo ci = new CurveInfo();
                    ci.Id = new Guid(element.Attributes["id"].Value);
                    ci.Tag = element.Attributes["name"].Value;
                    ci.SamplingRate = Convert.ToInt32(element.Attributes["samplingrate"].Value);
                    list.Add(ci);
                }); 
                #endregion
            }
            else
            {
                #region extract
                for (int i = 4; i < arguments.Length; i++)
                {
                    CurveInfo info = CurveInfo.CreateObjectFromString(arguments[i]);
                    if (info != null)
                    {
                        list.Add(info);
                    }
                }
                #endregion
            }
            return list;
        }

        internal double GetCurrentSpeed(double defaultValue)
        {
            try
            {
                return double.Parse(arguments[2]);
            }
            catch { return defaultValue; }
        }

        internal double GetStartHeight(double defaultValue)
        {
            try
            {
                return double.Parse(arguments[0]);
            }
            catch { return defaultValue; }
        }

        internal double GetEndHeight(double defaultValue)
        {
            try
            {
               return  double.Parse(arguments[1]);
            }
            catch { return defaultValue; }
        }
    }
    public class CurveInfo
    {
        public Guid Id { get; set; }
        public string Tag { get; set; }
        public int SamplingRate { get; set; }
        public static CurveInfo CreateObjectFromString(string args)
        {
            CurveInfo info = new CurveInfo();
            string[] s = args.Split('&');
            if (s.Length != 3)
            {
                Console.WriteLine("bad conversion :"+args);
                return null;
            }
            else
            {
                try
                {
                    Guid id = new Guid(s[0]);
                    int rate = int.Parse(s[2]);
                    info.Id = id;
                    info.SamplingRate = rate;
                    info.Tag = s[1];
                    return info;
                }
                catch
                {
                    Console.WriteLine("bad conversion :" + args);
                    return null;
                }
            }
        }
    }
    public class CurveAnalogData
    {
        //public CurveAnalogData(CurveInfo info)
        //{
        //    Info = info;
        //}
        //CurveInfo Info { get; set; }
        //public List<Coordinate> GetDataList()
        //{
        //    List<Coordinate> list = new List<Coordinate>();
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        list.Add(new Coordinate(i/100.0,70*Math.Sin(i*Math.PI/100.0)));
        //    }
        //    return list;
        //}
        //public static List<Package> GetPackageListUsingDefaultSize(List<Coordinate> coList, CurveInfo info)
        //{
        //    List<Package> plist = new List<Package>();
        //    int currentIndex=0;
        //    for (int i = 0; i < 2000; i++)
        //    {
        //        Package p = new Package();
        //        p.Id = info.Id;
        //        p.Tag = info.Tag;
        //        p.Points = new Coordinate[5];
        //        if (currentIndex < 10000)
        //        {
        //            p.Points[0] = coList[currentIndex];
        //            p.Points[1] = coList[currentIndex + 1];
        //            p.Points[2] = coList[currentIndex + 2];
        //            p.Points[3] = coList[currentIndex + 3];
        //            p.Points[4] = coList[currentIndex + 4];
        //            currentIndex += 5;
        //        }
        //        plist.Add(p);
        //    }
        //    return plist;
        //}

        public static Coordinate GetCoordinateByHeight(double currentHeight)
        {
            return new Coordinate(currentHeight,70*Math.Sin(currentHeight*Math.PI/5.0));
        }
    }
}
