using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSJT.Crm.Model;

namespace SSJT.Crm.Core.Server
{
    public class SessionMode:ISessionMode
    {
        private Hashtable session;
        public SessionMode()
        {
            session = Hashtable.Synchronized(new Hashtable());
        }
        public string SessionID
        {
            get
            {
                return (string)this.session[(object)"SSJT.Crm.SessionID"];
            }
            internal set
            {
                this.session[(object)"SSJT.Crm.SessionID"] = (object)value;
            }
        }

        public HrEmploy HrEmployee
        {
            get
            {
                if (this.session.ContainsKey((object)"SSJT.Crm.Model.HrEmployee"))
                    return (HrEmploy)this.session[(object)"SSJT.Crm.Model.HrEmployee"];
                return new HrEmploy();
            }
            internal set
            {
                this.session[(object)"SSJT.Crm.Model.HrEmployee"] = (object)value;
            }
        }
       
    }
}
