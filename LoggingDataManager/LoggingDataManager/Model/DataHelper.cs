using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Reflection;
namespace LoggingDataManager.Model
{
    public static class  DataHelper
    {
        #region BasicOperation
        static string DbFileName = @"DBFile.db";
        static SQLiteConnection commonConnection = null;
        public static T GetObjectById<T>(Guid id) where T : BaseObject
        {
            T obj = Activator.CreateInstance<T>();
            string tableName = obj.GetType().Name;//.Substring(obj.GetType().Name.LastIndexOf('.'));
            if (commonConnection == null)
            {
                commonConnection = new SQLiteConnection();
                SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
                connstr.DataSource = DbFileName;
                commonConnection.ConnectionString = connstr.ToString();
            }
            try
            {
                commonConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand(commonConnection);
                cmd.CommandText = "Select * from " + tableName + " where Id='" + id.ToString() + "'";
                SQLiteDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    obj.SetProperties(sdr);
                }
                commonConnection.Close();
            }
            catch//(Exception ex)
            {
                commonConnection.Close();
                return null;
            }
            return obj;
        }
        public static T GetObject<T>(string key,object value) where T : BaseObject
        {
            T obj = Activator.CreateInstance<T>();
            string tableName = obj.GetType().Name;//.Substring(obj.GetType().Name.LastIndexOf('.'));
            if (commonConnection == null)
            {
                commonConnection = new SQLiteConnection();
                SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
                connstr.DataSource = DbFileName;
                commonConnection.ConnectionString = connstr.ToString();
            }
            try
            {
                commonConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand(commonConnection);
                cmd.CommandText = "Select * from " + tableName + " where "+key+"='" + value.ToString() + "'";
                SQLiteDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    obj.SetProperties(sdr);
                }
                commonConnection.Close();
            }
            catch//(Exception ex)
            {
                commonConnection.Close();
                return null;
            }
            return obj;
        }
        public static List<T> GetAllObject<T>() where T : BaseObject
        {
            List<T> list = new List<T>();
            string tableName = typeof(T).Name;//.Substring(typeof(T).Name.LastIndexOf('.'));
            if (commonConnection == null)
            {
                commonConnection = new SQLiteConnection();
                SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
                connstr.DataSource = DbFileName;
                commonConnection.ConnectionString = connstr.ToString();
            }
            try
            {
                commonConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand(commonConnection);
                cmd.CommandText = "Select * from " + tableName + "";
                SQLiteDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    T obj = Activator.CreateInstance<T>();
                    obj.SetProperties(sdr);
                    list.Add(obj);
                }
                commonConnection.Close();
            }
            catch (Exception e)
            {
                commonConnection.Close();
                throw e;
            }
            return list;
        }
        public static void InsertObject<T>(T instance) where T : BaseObject
        {
            try
            {
                string tableName = typeof(T).Name;//;.Substring(typeof(T).Name.LastIndexOf('.'));
                if (commonConnection == null)
                {
                    commonConnection = new SQLiteConnection();
                    SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
                    connstr.DataSource = DbFileName;
                    commonConnection.ConnectionString = connstr.ToString();
                }
                commonConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand(commonConnection);
                cmd.CommandText = BuildInsertCommand(tableName, instance);
                cmd.ExecuteNonQuery();
                commonConnection.Close();
            }
            catch (Exception e)
            {
                commonConnection.Close();
                throw e;
            }
        }
        public static void DeleteObjectById<T>(Guid id)
        {
            try
            {
                string tableName = typeof(T).Name;
                if (commonConnection == null)
                {
                    commonConnection = new SQLiteConnection();
                    SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
                    connstr.DataSource = DbFileName;
                    commonConnection.ConnectionString = connstr.ToString();
                }
                commonConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand(commonConnection);
                cmd.CommandText = "Delete  from " + tableName + " where id='" + id.ToString() + "'";
                cmd.ExecuteNonQuery();
                commonConnection.Close();
            }
            catch (Exception e)
            {
                commonConnection.Close();
                throw e;
            }
        }
        public static void UpdataObjectById<T>(T newInstance) where T : BaseObject
        {
            SQLiteTransaction transaction = null;
            string tableName = typeof(T).Name;
            try
            {
                if (commonConnection == null)
                {
                    commonConnection = new SQLiteConnection();
                    SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
                    connstr.DataSource = DbFileName;
                    commonConnection.ConnectionString = connstr.ToString();
                }
                commonConnection.Open();
                transaction = commonConnection.BeginTransaction();
                SQLiteCommand cmd = new SQLiteCommand(commonConnection);
                cmd.Transaction = transaction;
                cmd.CommandText = "Delete  from " + tableName + " where id='" + newInstance.Id.ToString() + "'"; ;
                cmd.ExecuteNonQuery();
                cmd.CommandText = BuildInsertCommand(tableName, newInstance); ;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                commonConnection.Close();
            }
            catch (Exception e)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                commonConnection.Close();
                throw e;
            }
        }
        private static string BuildInsertCommand(string tableName, BaseObject instance)
        {
            StringBuilder text = new StringBuilder("Insert into " + tableName);
            text.Append("(");
            PropertyInfo[] fis = instance.GetType().GetProperties();
            for (int i = 0; i < fis.Length; i++)
            {
                if (fis[i].GetValue(instance, null) != null)
                {
                    text.Append("[");
                    text.Append(fis[i].Name);
                    text.Append("]");
                    text.Append(",");
                }
            }
            text.Remove(text.Length - 1, 1);
            text.Append(")");
            text.Append(" Values(");
            for (int i = 0; i < fis.Length; i++)
            {
                if (fis[i].GetValue(instance, null) != null)
                {
                    text.Append("'");
                    text.Append(fis[i].GetValue(instance, null));
                    text.Append("'");
                    text.Append(",");
                }
            }
            text.Remove(text.Length - 1, 1);
            text.Append(")");
            return text.ToString();
        } 
        #endregion
        #region ExpandedOperation
        public static Guid GetDeviceId(Guid id)
        {
            Device device = GetObject<Device>("CurveId",id);
            return device.Id;
        }
        #endregion

        static SQLiteConnection dataConnection = null;
        public static void InsertRangeData(Guid id, List<PublicProtocal.Coordinate> queue)
        {
            if (dataConnection == null)
            {
                dataConnection = new SQLiteConnection();
                SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
                connstr.DataSource = DbFileName;
                dataConnection.ConnectionString = connstr.ToString();
            }
            try
            {
                commonConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand(commonConnection);
                cmd.CommandText = string.Format("Insert into CurveData([X],[Y],[id]) values(@p0,@p1,@p2)");
                cmd.Parameters.Add("@p0", System.Data.DbType.Decimal);
                cmd.Parameters.Add("@p1", System.Data.DbType.Decimal);
                cmd.Parameters.Add("@p2", System.Data.DbType.Decimal);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                for (int i = 0; i < queue.Count; i++)
                {
                    try
                    {
                        cmd.Parameters["@p0"].Value = queue[i].X;
                        cmd.Parameters["@p1"].Value = queue[i].Y;
                        cmd.Parameters["@p2"].Value = id;
                        cmd.ExecuteNonQuery();
                    }
                    catch { continue; }
                }
            }
            catch { return; }
            finally
            {
                commonConnection.Close();
            }
        }
    }
}
