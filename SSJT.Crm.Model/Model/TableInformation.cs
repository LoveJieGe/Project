using System;
using System.Collections.Generic;
using System.Text;

namespace SSJT.Crm.Model
{
    public class TableInformation
    {
        public TableInformation(string tableName)
        {
            this.tableName = tableName;
        }
        private string tableName;
        public string TableName
        {
            get
            {
                return tableName;
            }
        }
        public virtual string Key
        {
            get { return string.Empty; }
        }
    }
}
