Ext.define('SSJT.store.main.Menu', {
    extend: 'Ext.data.TreeStore',

    alias: 'store.mainmenu',

    fields: [{
        name: 'text'
    }],

    constructor(config) {
        config = config || {};

        config.root = {
            expanded: true,
            children: [{
                text:'桌面',
                iconCls:'x-fa fa-home',
                id:'main',
                leaf:true
            },{
                text: '个人办公',
                iconCls: 'x-fa fa-user',
                id: 'office',
                expanded: false,
                //selectable: false,
                children: [{
                    text: '个人工作',
                    id: 'office/mine',
                    children:[{
                        text:'我的便签',
                        id:'office/mine/notes',
                        leaf:true
                    },{
                        text:'日程安排',
                        id:'office/mine/schedule',
                        leaf:true
                    }]
                }, {
                    text: '信息中心',
                    id: 'office/info',
                    children:[{
                        text:'新闻',
                        id: 'office/info/news',
                        leaf:true
                    },{
                        text:'公告',
                        id: 'office/info/announcement',
                        leaf:true
                    }]
                }]
            }, {
                text: '客户管理',
                id: 'customer/management',
                iconCls: 'x-fa  fa-address-book-o',
                children:[{
                    text:'客户列表',
                    id:'customer/list',
                    leaf:true
                },{
                    text:'联系人管理',
                    id:'customer/contact',
                    leaf:true
                },{
                    text:'跟进管理',
                    id:'customer/follow',
                    leaf:true
                }]
            },{
                text: '财务管理',
                id: 'financial/management',
                iconCls: 'x-fa fa-money',
                children:[{
                    text:'收款管理',
                    id:'financial/credit',
                    leaf:true
                },{
                    text:'收款流水',
                    id:'financial/receiving',
                    leaf:true
                },{
                    text:'开票管理',
                    id:'financial/billing',
                    leaf:true
                },{
                    text:'开票列表',
                    id:'financial/billing',
                    leaf:true
                },{
                    text:'应收与未收',
                    id:'financial/receive',
                    leaf:true
                }]
            },{
                text: '产品管理',
                id: 'product/management',
                iconCls: 'x-fa fa-th-large',
                children:[{
                    text:'产品类别',
                    id:'product/category',
                    leaf:true
                },{
                    text:'产品列表',
                    id:'product/list',
                    leaf:true
                }]
            }, {
                text: '人事管理',
                iconCls: 'x-fa fa-group',
                expanded: false,
                selectable: false,
                children: [{
                    text: '组织结构',
                    id: 'personnel/organizational',
                    leaf: true
                }, {
                    text: '职位管理',
                    id: 'personnel/post',
                    leaf: true
                }, {
                    text: '岗位管理',
                    id: 'personnel/job', //'completereport',
                    leaf: true
                }, {
                    text: '员工管理',
                    id: 'personnel/staff', //'completereport',
                    leaf: true
                }]
            },{
                text: '系统管理',
                iconCls: 'x-fa fa-cogs',
                expanded: false,
                selectable: false,
                children: [{
                    text: '角色授权',
                    id: 'system/role',
                    leaf: true
                }, {
                    text: '日志管理',
                    id: 'system/log',
                    leaf: true
                }, {
                    text: '参数配置',
                    id: 'system/param', //'completereport',
                    leaf: true
                }, {
                    text: '城市管理',
                    id: 'system/city', //'completereport',
                    leaf: true
                }]
            }, {
                text: '回收站',
                id: 'crm/recycle',
                iconCls: 'x-fa fa-trash',
                leaf: true
            }]
        };

        this.callParent([
            config
        ]);
    }
});