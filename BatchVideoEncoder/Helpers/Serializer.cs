using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BatchVideoEncoder.Helpers
{
    public class Serializer
    {
        public static bool Serialize(object obj, string filePath)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(obj.GetType());
                StringWriter sww = new StringWriter();
                xs.Serialize(sww, obj);
                using (var sw = new StreamWriter(filePath, false))
                {
                    sw.Write(sww.ToString());
                }
                sww.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Serialize(object obj, string filePath, out string exception)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(obj.GetType());
                StringWriter sww = new StringWriter();
                xs.Serialize(sww, obj);
                using (var sw = new StreamWriter(filePath, false))
                {
                    sw.Write(sww.ToString());
                }
                sww.Dispose();
                exception = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                exception = ex.ToString();
                return false;
            }
        }

        public static T Deserialize<T>(string filePath) where T : class
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                object obj;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    obj = xs.Deserialize(sr);
                }

                return (T)obj;
            }
            catch
            {
                return default(T);
            }

        }
    }
}
