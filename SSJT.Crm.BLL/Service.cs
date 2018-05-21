using System;
using SSJT.Crm.IBLL;
using SSJT.Crm.IDAL;
namespace SSJT.Crm.BLL
{
    public partial class CrmContactService:BaseService<Model.CrmContact,DAL.CrmContactDal>,ICrmContactService
	{

	}
    public partial class CrmContractService:BaseService<Model.CrmContract,DAL.CrmContractDal>,ICrmContractService
	{

	}
    public partial class CrmContractAttachmentService:BaseService<Model.CrmContractAttachment,DAL.CrmContractAttachmentDal>,ICrmContractAttachmentService
	{

	}
    public partial class CrmCustomerService:BaseService<Model.CrmCustomer,DAL.CrmCustomerDal>,ICrmCustomerService
	{

	}
    public partial class CrmFollowService:BaseService<Model.CrmFollow,DAL.CrmFollowDal>,ICrmFollowService
	{

	}
    public partial class CrmInvoiceService:BaseService<Model.CrmInvoice,DAL.CrmInvoiceDal>,ICrmInvoiceService
	{

	}
    public partial class CrmOrderService:BaseService<Model.CrmOrder,DAL.CrmOrderDal>,ICrmOrderService
	{

	}
    public partial class CrmOrderDetailsService:BaseService<Model.CrmOrderDetails,DAL.CrmOrderDetailsDal>,ICrmOrderDetailsService
	{

	}
    public partial class CrmProductService:BaseService<Model.CrmProduct,DAL.CrmProductDal>,ICrmProductService
	{

	}
    public partial class CrmProductCategoryService:BaseService<Model.CrmProductCategory,DAL.CrmProductCategoryDal>,ICrmProductCategoryService
	{

	}
    public partial class CrmReceiveService:BaseService<Model.CrmReceive,DAL.CrmReceiveDal>,ICrmReceiveService
	{

	}
    public partial class HrDepartmentService:BaseService<Model.HrDepartment,DAL.HrDepartmentDal>,IHrDepartmentService
	{

	}
    public partial class HrEmployService:BaseService<Model.HrEmploy,DAL.HrEmployeeDal>,IHrEmployService
	{

	}
    public partial class HrPositionService:BaseService<Model.HrPosition,DAL.HrPositionDal>,IHrPositionService
	{

	}
    public partial class HrPostService:BaseService<Model.HrPost,DAL.HrPostDal>,IHrPostService
	{

	}
    public partial class ParamCityService:BaseService<Model.ParamCity,DAL.ParamCityDal>,IParamCityService
	{

	}
    public partial class ParamSysParamService:BaseService<Model.ParamSysParam,DAL.ParamSysParamDal>,IParamSysParamService
	{

	}
    public partial class ParamSysParamTypeService:BaseService<Model.ParamSysParamType,DAL.ParamSysParamTypeDal>,IParamSysParamTypeService
	{

	}
    public partial class PersonalCalendarService:BaseService<Model.PersonalCalendar,DAL.PersonalCalendarDal>,IPersonalCalendarService
	{

	}
    public partial class PersonalNoteService:BaseService<Model.PersonalNote,DAL.PersonalNoteDal>,IPersonalNoteService
	{

	}
    public partial class PublicNewsService:BaseService<Model.News,DAL.PublicNewsDal>,IPublicNewsService
	{

	}
    public partial class PublicNoticeService:BaseService<Model.PublicNotice,DAL.PublicNoticeDal>,IPublicNoticeService
	{

	}
    public partial class SessionInfoService:BaseService<Model.SessionInfo,DAL.SessionInfoDal>,ISessionInfoService
	{

	}
    public partial class SysAppService:BaseService<Model.SysApp,DAL.SysAppDal>,ISysAppService
	{

	}
    public partial class SysAuthorityService:BaseService<Model.SysAuthority,DAL.SysAuthorityDal>,ISysAuthorityService
	{

	}
    public partial class SysButtonService:BaseService<Model.SysButton,DAL.SysButtonDal>,ISysButtonService
	{

	}
    public partial class SysDataAuthorityService:BaseService<Model.SysDataAuthority,DAL.SysDataAuthorityDal>,ISysDataAuthorityService
	{

	}
    public partial class SysInfoService:BaseService<Model.SysInfo,DAL.SysInfoDal>,ISysInfoService
	{

	}
    public partial class SysLogService:BaseService<Model.SysLog,DAL.SysLogDal>,ISysLogService
	{

	}
    public partial class SysLogErrService:BaseService<Model.SysLogErr,DAL.SysLogErrDal>,ISysLogErrService
	{

	}
    public partial class SysMenuService:BaseService<Model.SysMenu,DAL.SysMenuDal>,ISysMenuService
	{

	}
    public partial class SysOnlineService:BaseService<Model.SysOnline,DAL.SysOnlineDal>,ISysOnlineService
	{

	}
    public partial class SysRoleService:BaseService<Model.SysRole,DAL.SysRoleDal>,ISysRoleService
	{

	}
    public partial class SysRoleEmpService:BaseService<Model.SysRoleEmp,DAL.SysRoleEmpDal>,ISysRoleEmpService
	{

	}
    public partial class ToolBatchService:BaseService<Model.ToolBatch,DAL.ToolBatchDal>,IToolBatchService
	{

	}
}