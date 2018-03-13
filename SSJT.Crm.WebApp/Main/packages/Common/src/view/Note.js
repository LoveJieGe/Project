Ext.define('Common.view.Note',{
    extend:'Ext.Dialog',
    xtype:'note',
    requires:[
        'Ext.panel.Resizer',
        'Common.view.NoteController'
    ],
    controller:'note',
    action:'add',//true或者false
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
            iconCls:'i-common-priority-three',
            tooltip:'设置优先级',
            arrow:false,
            reference:'prioritymenu',
            menu:{
                xtype: 'menu',
                floated: false,
                docked: 'left',
                defaults:{
                    handler:'onMenuItemTap'
                },
                items: [{
                    iconCls:'i-common-priority-one',
                    text: '低'
                },{
                    iconCls:'i-common-priority-two',
                    text: '中'
                },{
                    iconCls:'i-common-priority-three',
                    text: '高'
                }]
            }
        },{
            iconCls:'x-fa fa-eye-slash',
            tooltip:'隐藏',
            handler:'onHideNote'
        }]
    },
    items:[{
        xtype:'textareafield',
        border:false,
        height:'100%',
        padding:0
    }],
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
   
})