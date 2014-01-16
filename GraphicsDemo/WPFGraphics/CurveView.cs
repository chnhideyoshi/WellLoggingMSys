using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace WPFGraphics
{
    public struct Range
    {
        public double XMin;
        public double XMax;
        public double YMin;
        public double YMax;
    }
    public class Curve
    {
        Guid Id = new Guid();
        public Guid ID { get { return Id; } }
        public string CurveName { get; set; }
        public string CurveUnit { get; set; }
        public List<Point> PointList { get { return pointList; } set { pointList = value; } }
        List<Point> pointList = new List<Point>();
    }
    public class CurveView
    {
        public CurveView(Curve curve,Range gridMapViewRange)
        {
            ViewRange=gridMapViewRange;
            RepresentCurve = curve;
            CurrentSeekBase = 0;
            PointCacheList = new PointCollection((int)(gridMapViewRange.XMax - gridMapViewRange.XMin));
        }
        public Range CurveRange { get; set; }
        public Range ViewRange { get; set; }
        public double YMaxiumn { get; set; }
        public double YMiniumn { get; set; }
        public bool IsDashed { get; set; }
        public Color CurveColor { get; set; }
        public Curve RepresentCurve { get; set; }
        public double CurrentSeekBase { get; set; }
        public PointCollection PointCacheList { get; set; }
        public event CurveViewSeekedEventHandler CurveViewSeeked;
    }
    public delegate void CurveViewSeekedEventHandler(CurveView sender,double seekedValue);
}
