using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PublicProtocal;

namespace LoggingDataManager.Data
{
    public class CurveData
    {
        public Guid CurveId { get; set; }

        SortedList<double, double> sortedDataList = new SortedList<double, double>();

        public void AddCoordinate(Coordinate coordinate)
        {
            lock (sortedDataList)
            {
                if (sortedDataList.ContainsKey(coordinate.X))
                {
                    sortedDataList[coordinate.X] = coordinate.Y;
                }
                else
                {
                    sortedDataList.Add(coordinate.X, coordinate.Y);
                }
            }
        }

        public void AddCoordinates(IEnumerable<Coordinate> coordinates)
        {
            lock (sortedDataList)
            {
                IEnumerator<Coordinate> enumerator = coordinates.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (sortedDataList.ContainsKey(enumerator.Current.X))
                    {
                        sortedDataList[enumerator.Current.X] = enumerator.Current.Y;
                    }
                    else
                    {
                        sortedDataList.Add(enumerator.Current.X, enumerator.Current.Y);
                    }
                }
            }
            //Model.CurveDataManager.Instance.AddTaskCollection(this.CurveId,coordinates);
        }

        public int GetIndexByDownBound(double downBound)
        {
            return   sortedDataList.Keys.ToList<double>().FindIndex(new Predicate<double>((x) => { return x > downBound; }));
        }

        public int GetIndexByUpBound(double upBound)
        {
            return sortedDataList.Keys.ToList<double>().FindLastIndex(new Predicate<double>((x) => { return x < upBound; }));
        }

        public int Count
        {
            get { return sortedDataList.Count; }
        }

        public void SetValueTo(double x, double y)
        {
            if (sortedDataList.ContainsKey(x))
            {
                sortedDataList[x] = y;
            }
            else
            {
            }
        }

        public double ValueAt(double x)
        {
            if (sortedDataList.ContainsKey(x))
            {
                return sortedDataList[x];
            }
            else
            {
                throw new Exception();
            }
        }

        public List<double> GetListRange(double BaseOffset, double EndOffset)
        {
            try
            {
                List<double> keys = sortedDataList.Keys.ToList();
                int startIndex = keys.FindIndex(new Predicate<double>((x) => { return x >= BaseOffset; }));
                int endIndex = keys.FindLastIndex(new Predicate<double>((x) => { return x <= EndOffset; }));
                if (startIndex == -1) { startIndex = 0; }
                if (endIndex == -1) { endIndex = 0; }
                if (endIndex == startIndex) { }
                return keys.GetRange(startIndex, endIndex - startIndex + 1);
            }
            catch { return new List<double>(); }
            //List<double> keys = sortedDataList.Keys.
        }

        public static CurveData CreateSample()
        {
            CurveData data = new CurveData();
            for (int i = 0; i < 10000; i++)
            {
                double x=i/100.0;
                data.AddCoordinate(new Coordinate(x, 70 * Math.Sin(x * Math.PI / 5.0)));
            }
            return data;
        }

        public int GetRangePointsCount(double currentHeight, double xRange)
        {
            return GetListRange(currentHeight,currentHeight+xRange).Count;
        }

        public List<Coordinate> GetList()
        {
            List<double> list = sortedDataList.Keys.ToList();
            List<Coordinate> colist = new List<Coordinate>();
            list.ForEach((x) => 
            {
                colist.Add(new Coordinate(x, sortedDataList[x]));
            });
            return colist;
        }

        public void XYMove(double deltaX,double deltaY)
        {
            lock(sortedDataList)
            {
                List<Coordinate> list = GetList();
                sortedDataList.Clear();
                list.ForEach((co) => 
                {
                    co.X += deltaX;
                    co.Y += deltaY;
                    sortedDataList.Add(co.X, co.Y);
                });
            }
        }

        public void DeleleRange(double up, double down)
        {
            lock (sortedDataList)
            {
                List<double> xs = GetListRange(up, down);
                for (int i = 0; i < xs.Count; i++)
                {
                    sortedDataList.Remove(xs[i]);
                }
            }
        }
    }
}
