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
                text: '个人办公',
                iconCls: 'x-fa fa-list-ul',
                expanded: false,
                selectable: false,
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
                iconCls: 'x-fa fa-commenting-o',
                children:[{
                    text:'客户列表',
                    id:'customer/list',
                    leaf:true
                },{
                    text:'联系人管理',
                    id:'contact/management',
                    leaf:true
                },{
                    text:'跟进管理',
                    id:'follow/management',
                    leaf:true
                }]
            },{
                text: '财务管理',
                id: 'financial/management',
                iconCls: 'x-fa fa-commenting-o',
                children:[{
                    text:'收款管理',
                    id:'credit/management',
                    leaf:true
                },{
                    text:'收款流水',
                    id:'receiving/water',
                    leaf:true
                },{
                    text:'开票管理',
                    id:'billing/management',
                    leaf:true
                },{
                    text:'开票列表',
                    id:'billing/list',
                    leaf:true
                },{
                    text:'应收与未收',
                    id:'receive/uncollected',
                    leaf:true
                }]
            },{
                text: '产品管理',
                id: 'product/management',
                iconCls: 'x-fa fa-commenting-o',
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
                iconCls: 'x-fa fa-bar-chart',
                expanded: false,
                selectable: false,
                children: [{
                    text: '组织结构',
                    id: 'organizational/structure',
                    leaf: true
                }, {
                    text: '职位管理',
                    id: 'post/management',
                    leaf: true
                }, {
                    text: '岗位管理',
                    id: 'job/management', //'completereport',
                    leaf: true
                }, {
                    text: '员工管理',
                    id: 'staff/management', //'completereport',
                    leaf: true
                }]
            },{
                text: '系统管理',
                iconCls: 'x-fa fa-bar-chart',
                expanded: false,
                selectable: false,
                children: [{
                    text: '角色授权',
                    id: 'role/authorization',
                    leaf: true
                }, {
                    text: '日志管理',
                    id: 'log/management',
                    leaf: true
                }, {
                    text: '参数配置',
                    id: 'param/config', //'completereport',
                    leaf: true
                }, {
                    text: '城市管理',
                    id: 'city/management', //'completereport',
                    leaf: true
                }]
            }, {
                text: '回收站',
                id: 'tasks/recycle',
                iconCls: 'x-fa fa-trash',
                leaf: true
            }]
        };

        this.callParent([
            config
        ]);
    }
});