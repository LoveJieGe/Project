using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SSJT.Crm.DBUtility;
using SSJT.Crm.IDAL;

//Please add references
namespace SSJT.Crm.DAL
{
	/// <summary>
	/// 数据访问类:CrmContact
	/// </summary>
	public partial class CrmContact:BaseDal<Model.CrmContact>, ICrmContactDal
    {
		public CrmContact()
		{}
	}
}

