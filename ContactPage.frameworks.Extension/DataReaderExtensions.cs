using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.frameworks.Extension
{
    public static class DataReaderExtensions
    {
        public static List<T> DataReaderMapToList<T>( this  IDataReader dr)
        {
            List<T> list = new();
            while (dr.Read()) {

                T obj = Activator.CreateInstance<T>();
                foreach(PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(dr[prop.Name], obj, null);
                    }
                }
            }
            return list;
        }

    }
}
