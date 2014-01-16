using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggingDataManager.GlobalTable
{
    public class GlobalTables
    {
        #region Priavte
        private GlobalTables() { }
        static GlobalTables tables = new GlobalTables();

        Dictionary<Guid, LoggingDataManager.Model.Curve> CurveTable = new Dictionary<Guid, LoggingDataManager.Model.Curve>();
        Dictionary<Guid, LoggingDataManager.Data.DataFetcher> SourceTable = new Dictionary<Guid, LoggingDataManager.Data.DataFetcher>();
        Dictionary<Guid, LoggingDataManager.Model.Device> DeviceTable = new Dictionary<Guid, LoggingDataManager.Model.Device>();
        Dictionary<Guid, LoggingDataManager.Data.CurveData> DataTable = new Dictionary<Guid, LoggingDataManager.Data.CurveData>();

        private void RegisterCurve(Guid curveId)
        {
            Model.Curve curve = LoggingDataManager.Model.DataHelper.GetObjectById<Model.Curve>(curveId);
            if (CurveTable.ContainsKey(curve.Id))
            {
                CurveTable[curve.Id] = curve;
            }
            else
            {
                CurveTable.Add(curveId, curve);
            }
            LoggingDataManager.Model.Device device = LoggingDataManager.Model.DataHelper.GetObject<LoggingDataManager.Model.Device>("CurveId", curveId);
            if (device != null)
            {
                if (DeviceTable.ContainsKey(curveId))
                {
                    DeviceTable[curveId] = device;
                }
                else
                {
                    DeviceTable.Add(curveId, device);
                }
            }
        }
        private void RegisterFetcher(Guid curveId, Data.DataFetcher fetcher)
        {
            if (SourceTable.ContainsKey(curveId))
            {
                SourceTable[curveId] = fetcher;
            }
            else
            {
                SourceTable.Add(curveId, fetcher);
            }
            //fetcher.AddRegisteredId(curveId);
        }
        private void RegisterDataCache(Guid curveId, LoggingDataManager.Data.CurveData data)
        {
            if (DataTable.ContainsKey(curveId))
            {
                DataTable[curveId] = data;
            }
            else
            {
                DataTable.Add(curveId, data);
            }
            data.CurveId = curveId;
        } 
        #endregion

        public static GlobalTables Instance
        {
            get { return GlobalTables.tables; }
        }
        public LoggingDataManager.Data.DataFetcher GetFetcher(Guid curveId)
        {
            if (SourceTable.Keys.Contains<Guid>(curveId))
                return SourceTable[curveId];
            return null;
        }
        public LoggingDataManager.Model.Device GetDevice(Guid curveId)
        {
            if (DeviceTable.Keys.Contains<Guid>(curveId))
                return DeviceTable[curveId];
            return null;
        }
        public LoggingDataManager.Model.Curve GetCurve(Guid curveId)
        {
            if (CurveTable.Keys.Contains<Guid>(curveId))
                return CurveTable[curveId];
            return null;
        }
        public LoggingDataManager.Data.CurveData GetDataCatche(Guid curveId)
        {
            if (DataTable.Keys.Contains<Guid>(curveId))
                return DataTable[curveId];
            else
                DataTable.Add(curveId,new Data.CurveData());
            return DataTable[curveId];
        }
        public void ResetAll()
        {
            CurveTable.Clear();
            DataTable.Clear();
            SourceTable.Clear();
            DeviceTable.Clear();
        }
        public void CreateConnection(Guid curveId, Data.DataFetcher fetcher)
        {
            RegisterCurve(curveId);
            RegisterFetcher(curveId, fetcher);
            RegisterDataCache(curveId, new Data.CurveData());
        }
        public static Data.DataFetcher GetFetcherByName(string fetcherName)
        {
            if (fetcherName == Data.NetDataFetcher.Instance.ToString())
            {
                return Data.NetDataFetcher.Instance;
            }
            return null;
        }
    }
}
