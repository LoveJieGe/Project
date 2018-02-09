using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Model
{
    public class BaseModel
    {
        public DataTable ToAjaxResult()
        {
            Type type = this.GetType();
            DataTable table = new DataTable();
            DataRow row = table.NewRow();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                IEnumerable<AjaxPropertyAttribute> attr = prop.GetCustomAttributes<AjaxPropertyAttribute>(true);
                if(attr.Count()>0)
                {
                    table.Columns.Add(StoreDataColumn(prop.Name, prop.PropertyType));
                    row[prop.Name] = GetSqlParam(prop.GetValue(this, null));
                }
                
            }
            table.Rows.Add(row);
            return table;
        }
        protected static DataColumn StoreDataColumn(string propName, Type propType)
        {
            if (propType == typeof(int?))
                return new DataColumn(propName, typeof(int));
            if (propType == typeof(DateTime?))
                return new DataColumn(propName, typeof(DateTime));
            if (propType == typeof(decimal?))
                return new DataColumn(propName, typeof(decimal));
            return new DataColumn(propName, propType);
        }
        protected  object GetSqlParam(object paramValue)
        {
            return paramValue != null ? paramValue : (object)DBNull.Value;
        }
    }
}
