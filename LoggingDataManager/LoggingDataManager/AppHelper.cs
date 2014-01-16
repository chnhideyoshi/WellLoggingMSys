using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace LoggingDataManager
{
    public static class AppHelper
    {
        public static object Clone(object obj)
        {
            object copy = null;
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            copy = formatter.Deserialize(ms) as object;
            ms.Close();
            return copy;
        }

        public static byte[] Serialize(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, obj);
            byte[] data = ms.GetBuffer();
            ms.Close();
            return data;
        }

        public static object Deserialize(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(data);
            object r = formatter.Deserialize(ms);
            ms.Close();
            return r;
        }

        public static string Encript(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(key);//将字符编码为一个字节序列 
            byte[] md5data = md5.ComputeHash(data);//计算data字节数组的哈希值 
            md5.Clear();
            string str = "";
            for (int i = 0; i < md5data.Length - 1; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');
            }
            return str;

        }

        public static void RunProccess(string path)
        {
            System.Diagnostics.Process.Start(path);
        }
    }
}
