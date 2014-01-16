using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggingDataManager.Model
{
    public class Curve : BaseObject
    {
        [RealName(RealName = "曲线名")]
        public string CurveName { get; set; }

        [RealName(RealName = "单位")]
        public string CurveUnit { get; set; }

        [RealName(RealName = "分组")]
        public int CurveGroupIndex { get; set; }

        [RealName(RealName = "颜色")]
        public string CurveColor { get; set; }

        [RealName(RealName = "粗细")]
        public int CurveThickness { get; set; }

        [RealName(RealName = "虚线")]
        public int IsDashed { get; set; }

        [RealName(RealName = "值域左界")]
        public double YMaxValue { get; set; }

        [RealName(RealName = "值域右界")]
        public double YMinValue { get; set; }

        [RealName(RealName = "定义域左界")]
        public double XMaxValue { get; set; }

        [RealName(RealName = "定义域右界")]
        public double XMinValue { get; set; }

        [RealName(RealName = "所属项目Id")]
        public Guid ProjectId { get; set; }

        #region StaticMethods

        public static Curve CreateNew()
        {
            Curve curve = new Curve()
            {
                CurveUnit = "M",
                CurveGroupIndex = 0,
                CurveThickness = 2,
                IsDashed = 0,
                YMaxValue = 100,
                YMinValue = -100,
                XMaxValue = 100,
                XMinValue = 0,
                CurveColor = "ffcf7b79",
                ProjectId = Guid.Empty,
            };
            curve.CurveName = "曲线" + curve.Id.ToString().Substring(0, 3);
            return curve;
        }
        //public CurveData CreateDataObject()
        //{
        //    CurveData data = new CurveData();
        //    data.CurveId = this.Id;
        //    return data;
        //} 
        #endregion
    }
    public class Project : BaseObject
    {
        [RealName(RealName = "项目名")]
        public string ProjectName { get; set; }
    }
    public class Device : BaseObject
    {
        [RealName(RealName = "设备名")]
        public string Name { get; set; }

        [RealName(RealName = "设备编号")]
        public int Number { get; set; }

        [RealName(RealName = "设备长度")]
        public double Length { get; set; }

        [RealName(RealName = "生产厂家")]
        public string Producer { get; set; }

        [RealName(RealName = "生产系列")]
        public string Series { get; set; }

        [RealName(RealName = "对应曲线")]
        public Guid CurveId { get; set; }

        [RealName(RealName = "对应项目")]
        public Guid ProjectId { get; set; }

        [RealName(RealName = "采样率")]
        public int SamplingRate { get; set; }
    }
}
