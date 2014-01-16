using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LoggingDataManager.Model
{
    public class CurveDataManager
    {
        #region SI
        private CurveDataManager()
        {
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = false;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            //worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            //worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
        }
        BackgroundWorker worker = new BackgroundWorker();
        static CurveDataManager instance = new CurveDataManager();
        public static CurveDataManager Instance
        {
            get { return CurveDataManager.instance; }
        } 
        #endregion

        Dictionary<Guid, List<PublicProtocal.Coordinate>> table = new Dictionary<Guid, List<PublicProtocal.Coordinate>>();

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                foreach (Guid id in table.Keys)
                {
                    List<PublicProtocal.Coordinate> queue = table[id];
                    DataHelper.InsertRangeData(id, queue);
                    insertedNumber += queue.Count;
                    lock (queue)
                    {
                        queue.Clear();
                    }
                }
                System.Threading.Thread.Sleep(500);
            }
        }

        int insertedNumber = 0;

        int QueueSum
        {
            get
            {
                int sum = 0;
                foreach (Guid id in table.Keys)
                {
                    List<PublicProtocal.Coordinate> queue = table[id];
                    sum += queue.Count;
                }
                return sum;
            }
        }

        public void AddTaskCollection(Guid id, IEnumerable<PublicProtocal.Coordinate> coordinates)
        {
            if (!table.ContainsKey(id))
            {
                lock (table)
                {
                    table.Add(id, new List<PublicProtocal.Coordinate>());
                }
            }
            List<PublicProtocal.Coordinate> queue = table[id];
            lock (queue)
            {
                queue.AddRange(coordinates);
            }

        }

        public string Message
        {
            get { return "Data Inserted Rows: " + insertedNumber + ", Data In Queue Rows: " + insertedNumber; }
        }
    }
}
