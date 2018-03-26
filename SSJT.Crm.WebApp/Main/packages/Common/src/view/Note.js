Ext.define('Common.view.Note',{
    extend:'Ext.Dialog',
    xtype:'note',
    requires:[
        'Ext.panel.Resizer',
        'Common.view.NoteController'
    ],
    controller:'note',
    viewModel:{
        data:{
            record:null
        }
    },
    action:'add',//edit或者view
    actionMsg:'确定要隐藏该控件?',
    bind:{
        width:'{record.Width}',
        height:'{record.Height}',
    },
    modal:false,
    border:false,
    minWidth:260,
    minHeight:200,
    cls:'note',
    header:{
        //html:'<span class="i-common-priority-one"></span><span class="x-fa fa-eye-slash"></span>',
        height:30,
        minHeight:30,
        innerCls:'header-inner',
        cls:'default-tool-color',
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
        reference:'textarea',
        border:false,
        height:'100%',
        cls:'default-text-color',
        padding:0,
        bind:{
            value:'{record.NoteContent}'
        }
    },{
        xtype:'container',
        docked: 'bottom',
        reference:'bottomTool',
        height:30,
        cls:'default-tool-color',
        defaultType:'button',
        defaults:{
            ui:'round raised',
            margin:'0 0 0 2',
            height:25,
            width:25,
            bottom:3,
            border:false,
            handler:'onColorTap'
        },
        items:[{
            width:60,
            reference:'btnsave',
            top:2,
            cls:'default-color',
            text:'保存',
            weight:-10,
            bottom:0,
            left:2,
            handler:'onBtnSave'
        },{
            right:175,
            style:{
                'background-color':'rgba(207, 158, 158,1)'
            }
        },{
            right:145,
            cls:'default-color'
        },{
            right:116,
            style:{
                'background-color':'rgba(255, 204, 204,1)'
            }
        },{
            right:87,
            style:{
                'background-color':'rgba(153, 204, 153,1)'
            }
        },{
            right:59,
            style:{
                'background-color':'rgba(149, 202, 202,1)'
            }
        },{
            right:31,
            style:{
                'background-color':'rgba(132, 193, 255,1)'
            }
        },{
            right:2,
            style:{
                'background-color':'rgba(128, 128, 192,1)'
            }
        }]
    }],
    resizable:{
        edges:'all',
        minSize:[250,200]
    },
    initialize(){
        var me = this,
            btns = me.query('button'),
            textarea = me.lookup('textarea');
        // btns.forEach(function(item){
        //     if(item&&item.innerElement){
        //         item.innerElement.setStyle('background-color','rgb(255, 230, 111)')
        //     }
        // })
        if(textarea&&textarea.inputWrapElement){
            textarea.inputWrapElement.setStyle('background','none');
        }
        me.callParent();
    },
    setRecord: function(record) {
        debugger
        this.getViewModel().set('record', record);
    }
   
})