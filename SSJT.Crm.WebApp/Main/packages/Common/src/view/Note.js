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
            record:null,
            statusType:'add',
            Width:0,
            Height:0,
        },
        formulas:{
            Priority:{
                get:function(get){
                    let r = get('record');
                    if(r&&r.get('Priority')){
                        let value = r.get('Priority');
                        return !(value==='H')?!(value==='M')?
                        'i-common-priority-one':
                        'i-common-priority-two':
                        'i-common-priority-three';
                    }
                    return 'i-common-priority-three';
                }
            },
            NoteColor:{
                get:function(get){
                    let view = this.getView(),r = get('record');
                    if(r&&r.get('NoteColor')){
                        return r.get('NoteColor');
                    }
                    return 'rgb(255, 230, 111)';
                },
                set:function(value){
                    let me = this,
                        view = me.getView(),
                        record = me.get('record');
                    if(record){
                        record.set('NoteColor',value);
                    }
                    const  toolRgba = view.setRgba(value,0.9),
                        textRgba = view.setRgba(value,0.6);
                    me.set({
                        'ToolColor':toolRgba,
                        'TextColor':textRgba,
                        'Color':value
                    });
                }
            },
            Color:{
                bind:{
                    d:'{NoteColor}',
                },
                get:function(data){
                    return data.d;
                }
            },
            ToolColor:{
                bind:{
                    d:'{NoteColor}',
                },
                get:function(data){
                    let me = this,
                        view = me.getView();
                    return view.setRgba(data.d,0.9);
                }
            },
            TextColor:{
                bind:{
                    d:'{NoteColor}',
                },
                get:function(data){
                    let me = this,
                        view = me.getView();
                    return view.setRgba(data.d,0.6);
                }
            },
            IsHideBBar:{
                bind:{
                    d:'{statusType}'
                },
                get:function(data){
                    return data.d.toString().toLowerCase()=='view';
                }
            }
        }
    },
    actionMsg:'确定要隐藏该控件?',
    bind:{
        width:'{Width}',
        height:'{Height}',
        x:'{X}',
        y:'{Y}'
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
        bind:{
            style:{
                'background-color':'{ToolColor}'
            }
        },
        defaults:{
            border:false,
            xtype: 'button',
            ui:'headbtn',
        },
        items:[{
            bind:{
                iconCls:'{Priority}',
            },
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
                    text: '低',
                    value:'L'
                },{
                    iconCls:'i-common-priority-two',
                    text: '中',
                    value:'M'
                },{
                    iconCls:'i-common-priority-three',
                    text: '高',
                    value:'H'
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
        padding:0,
        bind:{
            style:{
                'background-color':'{TextColor}'
            },
            value:'{record.NoteContent}'
        }
    },{
        xtype:'container',
        docked: 'bottom',
        reference:'bottomTool',
        height:30,
        bind:{
            style:{
                'background-color':'{ToolColor}'
            },
            hidden:'{IsHideBBar}'
        },
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
            bind:{
                style:{
                    'background-color':'{Color}'
                }
            },
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
    listeners:{
        beforeshow:'onBeforeShow'
    },
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
        if(record){
            const me = this,
                vm = me.getViewModel();
            vm.set('record', record);
            if(record.get('LocationX')>0){
                vm.set('X',record.get('LocationX'));
            }
            if(record.get('LocationY')>0){
                vm.set('Y',record.get('LocationY'));
            }
            vm.set('NoteColor',record.get('NoteColor'));
            vm.set('Width',record.get('Width'));
            vm.set('Height',record.get('Height'));
            if(!record.phantom){
                vm.set('statusType','view');
            }
        }
    },
    setRgba(rgba,alpha){
        rgba = rgba&&rgba.match(/(\d(\.\d+)?)+/g);
        if(rgba&&rgba.length==4){
            rgba[3] = alpha;
            return 'rgba('+rgba.join(',')+')';
        }else if(rgba&&rgba.length==3){
            rgba.push(alpha);
            return 'rgba('+rgba.join(',')+')';
        }
    },
   
})