using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core.Client
{
    public class UserResult
    {
        private string _uid;
        private string _uname;
        private string _avatar;
        public string Uid
        {
            get { return this._uid; }
            set { this._uid = value; } 
        }
        public string UName
        {
            get { return this._uname; }
            set {this._uname = value;  } 
        }
        public string Avatar
        {
            get { return this._avatar; }
            set { this._avatar = value; }
        }
    }
}
