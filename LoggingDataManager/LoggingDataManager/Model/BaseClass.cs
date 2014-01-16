using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Reflection;

namespace LoggingDataManager.Model
{
    public class BaseObject
    {
        Guid id = Guid.NewGuid();

        [RealName(RealName = "Id")]
        public Guid Id { get { return id; } set { id = value; } }

        public void SetValue(string propertyName, object value)
        {
            this.GetType().GetField(propertyName).SetValue(this, value);
        }
        public object GetValue(string propertyName)
        {
            return this.GetType().GetField(propertyName).GetValue(this);
        }
        public void SetProperties(SQLiteDataReader sdr)
        {
            System.Reflection.PropertyInfo[] fields = this.GetType().GetProperties();
            for (int i = 0; i < fields.Length; i++)
            {
                if (sdr[fields[i].Name] != null)
                {
                    fields[i].SetValue(this, sdr[fields[i].Name], null);
                }
            }
        }
        public static string GetRealName(PropertyInfo info)
        {
            try
            {
                object[] objAttrs = info.GetCustomAttributes(typeof(RealNameAttribute), true);
                if (objAttrs.Length > 0)
                {
                    RealNameAttribute attr = objAttrs[0] as RealNameAttribute;
                    return attr.RealName;
                }
                return "未定义";
            }
            catch
            {
                return "未定义";
            }
        }
        
    }
    public class RealNameAttribute : Attribute
    {
        public string RealName { get; set; }
    }
}
