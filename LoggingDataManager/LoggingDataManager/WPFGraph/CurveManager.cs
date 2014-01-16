using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
namespace LoggingDataManager.WPFGraph
{
    public class CurveViewManager
    {
        private IGraph BaseGraph = null;
        public CurveViewManager(Model.Curve curve, IGraph graph)
        {
            Curve = curve;
            BaseOffsetPercentage = 0;
            BaseGraph = graph;
        }
        private Model.Curve Curve { get; set; }
        public Data.CurveData CurveData { get; set; }
        public Guid CurveId { get { return Curve.Id; } }
        public double ViewHeight { get { return BaseGraph.ViewHeight; } }
        public double ViewWidth { get { return BaseGraph.ViewWidth; } }
        public double UnitLength { get { return BaseGraph.UnitLength; } }
        public double RowCount { get { return BaseGraph.VerticalCellsCount; } }
        public double BaseOffsetPercentage { get; set; }
        public int CachePointMaxCount { get { return (int)ViewHeight; } }
        public double BaseOffset { get { return Curve.XMinValue + XRange * BaseOffsetPercentage; } }
        public double EndOffset { get { return BaseOffset + XPresentRange; } }
        public double XRange { get { return Curve.XMaxValue - Curve.XMinValue; } }
        public double YRange { get { return Curve.YMaxValue - Curve.YMinValue; } }
        public double XPresentRange { get { return RowCount * UnitLength; } }
        public PointCollection PointCacheList { get; set; }
        public void RePaint()
        {
            cacheTable.Clear();
            List<double> coList = CurveData.GetListRange(BaseOffset, EndOffset);
            AdjustCount(PointCacheList, coList.Count);
            for (int i = 0; i < coList.Count; i++)
            {
                Point temp = ConvertToViewPoint(coList[i], CurveData.ValueAt(coList[i]));
                PointCacheList[i] = temp;
                AddToCache(coList[i], temp.Y);
            }
        }
        public static void AdjustCount<T>(IList<T> list, int p) where T : new()
        {
            if (list == null) { return; }
            if (p <= 0) { list.Clear(); }
            if (list.Count < p)
            {
                int cha = p - list.Count;
                for (int i = 0; i < cha; i++)
                {
                    list.Add(new T());
                }
            }
            else
            {
                try
                {
                    int cha = list.Count - p;
                    for (int i = 0; i < cha; i++)
                    {
                        list.RemoveAt(0);
                    }
                }
                catch { return; }
            }
        }
        private int GetXMappedIndex(double x)
        {
            return (int)((x - Curve.XMinValue) / XRange);
        }
        private void AddToCache(double cox, double py)
        {
            if (cacheTable.ContainsKey(py))
            {
                cacheTable[py] = cox;
            }
            else
            {
                cacheTable.Add(py, cox);
            }
        }
        private Point ConvertToViewPoint(double x, double y)
        {
            temp.X = ViewWidth * (y - Curve.YMinValue) / YRange;
            temp.Y = ViewHeight * (x - BaseOffset) / XPresentRange;
            return temp;
        }
        #region private
        Point temp = new Point();
        private Dictionary<double, double> cacheTable = new Dictionary<double, double>();
        #endregion
        public List<Point> GetRangePoints(double currentHeight, double xRange)
        {
            List<Point> plist = new List<Point>();
            List<double> coList = CurveData.GetListRange(BaseOffset, EndOffset);
            for (int i = 0; i < coList.Count; i++)
            {
                Point temp = ConvertToViewPoint(coList[i], CurveData.ValueAt(coList[i]));
                plist.Add(temp);
            }
            return plist;
        }

        public void GetOriginCoodinate(ref double fcox, ref double fcoy, Point from)
        {
            if (cacheTable.ContainsKey(from.Y))
            {
                fcox = cacheTable[from.Y];
                fcoy = CurveData.ValueAt(fcox);
            }
            else
            {
                fcoy = from.X * YRange / ViewWidth + Curve.YMinValue;
                fcox = from.Y * XPresentRange / ViewHeight + BaseOffset;
            }
        }
    }
}
