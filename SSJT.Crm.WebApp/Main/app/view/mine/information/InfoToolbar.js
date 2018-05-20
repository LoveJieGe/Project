Ext.define('SSJT.view.mine.information.InfoToolbar',{
    extend:'Ext.Toolbar',
    xtype:'info_toolbar',
    requires:[
        'Ext.field.Date'
    ],
    ui:'tools',
    weighted:true,
    defaultButtonUI:'action',
    shadow:true,
    items:{
        added:{
            xtype:'button',
            text:'新增',
            handler:'onCreate',
            iconCls:'x-fa fa-plus',
        },
        datefrom:{
            xtype:'datefield',
            label:'时间:',
            name:'DateFrom',
            bodyWidth:150,
            labelWidth:'auto'
        },
        dateto:{
            xtype:'datefield',
            label:'-',
            name:'DateTo',
            bodyWidth:150,
            labelWidth:'auto'
        },
        search:{
            xtype: 'textfield',
            label: '搜索',
            name: 'Search',
            labelWidth: 'auto',
            placeholder:'编号',
            triggers: {
                search: {
                    type: 'search',
                    handler: 'onSearch'
                }
            },
        },
    }
})