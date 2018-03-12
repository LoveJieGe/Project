Ext.define('SSJT.store.main.Menu', {
    extend: 'Ext.data.TreeStore',
    alias: 'store.mainmenu',
    model:'SSJT.model.MainMenu',
    data:{
        items:[
            {id:'home',text:'桌面',mtype:'home',iconCls:'x-fa fa-home',parentId:'root',leaf:true},
        {id:'office',text:'个人办公',mtype:'office',iconCls:'x-fa fa-user',parentId:'root',leaf:false},
        {id:'office/mine',text:'个人工作',mtype:'office/mine',iconCls:'',leaf:false,parentId:'office'},
        {id:'office/mine_notes',text:'我的便签',mtype:'mine_work_note',iconCls:'',parentId:'office/mine',leaf:true},
        {id:'office/mine_schedule',text:'日程安排',mtype:'',iconCls:'',parentId:'office/mine',leaf:true},
        {id:'office/info',text:'信息中心',mtype:'office/info',leaf:false,iconCls:'',parentId:'office'},
        {id:'office/info_news',text:'新闻',mtype:'office/info/news',iconCls:'',parentId:'office/info',leaf:true},
        {id:'office/info_announcement',text:'公告',mtype:'office/info/announcement',iconCls:'',parentId:'office/info',leaf:true},
        {id:'recycle',text:'回收站',mtype:'crm/recycle',iconCls:'x-fa fa-trash',parentId:'root',leaf:true}
    ]},
    parentIdProperty: 'parentId',
    //autoLoad: true,
    proxy: {
        type: 'memory',
        reader: {
            type: 'json',
            rootProperty: 'items'
        }
    },
    handleData(id,data){
        if(Ext.isArray(data)&&data.length>0){
            let datas = data.filter(item=>{
                return item.parentId==id;
            })
            var me = this,result = result||[];
            datas.forEach(item => {
                let obj = {
                    text:item.text,
                    iconCls:item.icon,
                    id:item.id,
                    leaf:item.leaf
                };
                let d = data.filter(e=>{
                    return e.parentId==item.id;
                })
                if(d.length>0){
                    obj.children=obj.children?obj.children:[];
                    obj.children=me.handleData(item.id,data);
                    result.push(obj);
                }else{
                    result.push(obj);
                }
            });
            return result;
        }
        return [];
    },
    constructor(config) {
        config = config || {};
        // var me = this,data = me.rootData.items,root = {
        //     expanded: true,
        //     children:[]
        // },result=[];
        
        //  root.children = me.handleData('root',data);
        //  config.root = root;
        this.callParent([
            config
        ]);
    }
});

/**
 * config.root = {
            expanded: true,
            children: [{
                text:'桌面',
                iconCls:'x-fa fa-home',
                id:'home',
                leaf:true
            },{
                text: '个人办公',
                iconCls: 'x-fa fa-user',
                id: 'office',
                //expanded: false,
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
 */