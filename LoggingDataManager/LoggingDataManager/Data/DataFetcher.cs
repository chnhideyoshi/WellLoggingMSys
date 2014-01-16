using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LoggingDataManager.Model;

namespace LoggingDataManager.Data
{
    public class DataFetcher
    {
        public DataFetcher() 
        {
        }
        protected List<Guid> registeredIdList = new List<Guid>();
        public virtual void AddRegisteredId(Guid id)
        {
            registeredIdList.Add(id);
        }
        public virtual void RemoveRegisteredId(Guid id)
        {
            registeredIdList.Remove(id);
        }
        public virtual void ClearAllRegisteredIds()
        {
            registeredIdList.Clear();
        }
        protected CurveData GetCurveData(Guid curveid)
        {
            return LoggingDataManager.GlobalTable.GlobalTables.Instance.GetDataCatche(curveid);
        }
        public virtual void BeginGetData()
        {
        }

        public event DataFetchingProgressChangedEventHandler ProgressChanged;
        protected virtual void OnProgressChanged(NotifyEventArgs args)
        {
            if (this.ProgressChanged != null)
                this.ProgressChanged(this, args);
        }

        public event DataFetchingCompletedEventHandler Completed;
        protected virtual void OnCompleted(NotifyEventArgs args)
        {
            if (this.Completed != null)
                this.Completed(this, args);
        }

        public event ErrorOccuredEventHandler ErrorOccured;
        protected virtual void OnErrorOccured(NotifyEventArgs args)
        {
            if (this.ErrorOccured != null)
                this.ErrorOccured(this, args);
        }

        public event LoggingEventsFiredEventHandler LoggingEventsFired;
        protected virtual void OnLoggingEventsFired(NotifyEventArgs args)
        {
            if (this.LoggingEventsFired != null)
                this.LoggingEventsFired(this,args);
        }

        public event DataFetchingPackReceivedEventHandler DataFetchingPackReceived;
        protected virtual void OnDataFetchingPackReceived(NotifyEventArgs args)
        {
            if (this.DataFetchingPackReceived != null)
                this.DataFetchingPackReceived(this, args);
        }
    }
    public delegate void ErrorOccuredEventHandler(object sender, NotifyEventArgs args);
    public delegate void DataFetchingProgressChangedEventHandler(object sender, NotifyEventArgs args);
    public delegate void DataFetchingCompletedEventHandler(object sender, NotifyEventArgs args);
    public delegate void LoggingEventsFiredEventHandler(object sender, NotifyEventArgs args);
    public delegate void DataFetchingPackReceivedEventHandler(object sender,NotifyEventArgs args);

    public class NotifyEventArgs
    {
        public PublicProtocal.Coordinate[] Points { get; set; }
        public object[] Options { get; set; }
        public string Tag { get; set; }
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
    //public class SampleDataFetcher:DataFetcher
    //{
    //    #region SingleInstance
    //    static SampleDataFetcher instance = new SampleDataFetcher();
    //    public static SampleDataFetcher Instance
    //    {
    //        get { return SampleDataFetcher.instance; }
    //    }
    //    SampleDataFetcher() { } 
    //    #endregion
    //    public override void BeginGetData()
    //    {
    //        //PackageGenerator pg = new PackageGenerator(registeredIdList.Count);
    //        //registeredIdList.ForEach(id => pg.RegisterId(id));
    //        //pg.CreateAllData();
    //        //pg.BeginSendAllPackage();
    //        //registeredIdList.ForEach((id) =>
    //        //{
    //        //    Thread thread = new Thread(() => 
    //        //    {

    //        //    });
    //        //    thread.IsBackground = true;
    //        //    thread.Start();
    //        //});
    //    }
    //}
   

}
