Ext.define('Common.view.Note',{
    extend:'Ext.Dialog',
    requires:[
        'Ext.panel.Resizer'
    ],
    action:'view',//true或者false
    actionMsg:'确定要隐藏该控件?',
    width:250,
    height:200,
    modal:false,
    border:false,
    cls:'note',
    header:{
        //html:'<span class="i-common-priority-one"></span><span class="x-fa fa-eye-slash"></span>',
        height:30,
        minHeight:30,
        style:{
            backgroundColor:'rgb(255, 230, 111)'
        },
        innerCls:'header-inner',
        defaults:{
            border:false,
            xtype: 'button',
            ui:'headbtn',
        },
        items:[{
            iconCls:'i-common-priority-one',
            tooltip:'设置优先级',
            
        },{
            iconCls:'x-fa fa-eye-slash',
            tooltip:'隐藏',
            handler:'onHideNote'
        }]
    },
    // items:[{
    //     xtype:'container',
    //     docked:'top',
    //     items: [{
    //         xtype: 'button',
    //         iconCls:'i-common-priority-one'
    //     }]
    // }],
    resizable:{
        edges:'all',
        minSize:[250,200]
    },
    initialize(){
        debugger
        var me = this,
            btns = me.query('button');
        btns.forEach(function(item){
            if(item&&item.innerElement){
                item.innerElement.setStyle('background-color','rgb(255, 230, 111)')
            }
        })
        me.callParent();
    },
    onHideNote(){
        var me = this;
        ComUtils.confirm(me.actionMsg,function(){
            if(me.action){
                let action = Ext.util.Format.lowercase(me.action);
                if(action=='add'){
                    me.destroy();
                }
            }
        })
    }
})