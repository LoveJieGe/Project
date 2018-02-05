using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core.Client
{
    public class UserResult
    {
        private string _avatar;
        private DateTime _expires;
        private object _user;

        public object User
        {
            get { return this._user; }
            set { this._user = value; }
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

        public string id { get; set; }
    }
}
