using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Model
{
    public class BaseModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
        public object this[string name]
        {
            get
            {
                object propertyValue = this.GetPropertyValue(name);
                return propertyValue;
            }
            set
            {
                object propertyValue = this.GetPropertyValue(name);
                this.SetProperty(ref propertyValue, value,name);
            }
        }
        protected void SetProperty<T>(ref T prop, T value, [CallerMemberName] string propertyName = "")
        {
           
            if (!EqualityComparer<T>.Default.Equals(prop, value))
            {
                PropertyInfo property = this.GetType().GetProperty(propertyName);
                property.SetValue(this, value);
                OnPropertyChanged(propertyName);
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        private object GetPropertyValue(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                PropertyInfo property = this.GetType().GetProperty(name);
                if (property != null)
                {
                    return property.GetValue(this, null);
                }
            }
            return null;
        }
    }
}
