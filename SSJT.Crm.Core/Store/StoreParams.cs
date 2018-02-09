using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core.Store
{
    [Serializable]
    public class StoreParams 
    {
        public int page;
        public int start;
        public int limit;
        public string query;
        public List<GroupParam> group;
        public List<SortParam> sort;
        public List<FilterParam> filter;
    }
}
