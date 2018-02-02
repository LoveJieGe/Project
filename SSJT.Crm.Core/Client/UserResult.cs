using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core.Client
{
    public class UserResult
    {
        private string _userid;
        private string _username;
        private string _avatar;
        private DateTime _expires;
        public string UserID
        {
            get { return this._userid; }
            set { this._userid = value; } 
        }
        public string UserName
        {
            get { return this._username; }
            set {this._username = value;  } 
        }
        public string Avatar
        {
            get { return this._avatar; }
            set { this._avatar = value; }
        }
        public DateTime Expires
        {
            get { return this._expires; }
            set { this._expires = value; }
        }
    }
}
