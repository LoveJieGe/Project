using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Model
{
    [Serializable]
    public partial class SessionInfo
    {
        private string sessionId;
        private string userSign;
        private string userName;
        private string language;
        private string isSuperUser;
        private string loginOnce;
        private string ipAddress;
        private string macAddress;
        private string machineName;
        private string appVersion;
        private DateTime loginDate;
        private DateTime lastLoginDate;

        public string SessionID
        {
            get
            {
                return this.sessionId;
            }
            set
            {
                this.sessionId = value;
            }
        }
        public string UserSign
        {
            get
            {
                return this.userSign;
            }
            set
            {
                this.userSign = value;
            }
        }
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }
        public string Language
        {
            get
            {
                return this.language;
            }
            set
            {
                this.language = value;
            }
        }

        public string IsSuperUser
        {
            get
            {
                return this.isSuperUser;
            }
            set
            {
                this.isSuperUser = value;
            }
        }

        public string LoginOnce
        {
            get
            {
                return this.loginOnce;
            }
            set
            {
                this.loginOnce = value;
            }
        }

        public string IPAddress
        {
            get
            {
                return this.ipAddress;
            }
            set
            {
                this.ipAddress = value;
            }
        }
        public string MacAddress
        {
            get
            {
                return this.macAddress;
            }
            set
            {
                this.macAddress = value;
            }
        }

        public string MachineName
        {
            get
            {
                return this.machineName;
            }
            set
            {
                this.machineName = value;
            }
        }

        public string AppVersion
        {
            get
            {
                return this.appVersion;
            }
            set
            {
                this.appVersion = value;
            }
        }

        public DateTime LoginDate
        {
            get
            {
                return this.loginDate;
            }
            set
            {
                this.loginDate = value;
            }
        }

        public DateTime LastLoginDate
        {
            get
            {
                return this.lastLoginDate;
            }
            set
            {
                this.lastLoginDate = value;
            }
        }
    }
}
