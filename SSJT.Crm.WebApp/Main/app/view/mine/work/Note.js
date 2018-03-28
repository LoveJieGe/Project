Ext.define('SSJT.view.mine.work.Note',{
    extend:'SSJT.view.widgets.Browse',
    // fields:{
    //     country:{
    //         property:'country'
    //     }
    // }
    requires:[
        'Ext.Progress'
    ],
    xtype:'mine_work_note',
    controller:'mine_work_note',
    // viewModel:{
    //     type:'mine_work_note'
    // },
    tbar: {
        xtype: 'notetoolbar'
    },
    ui: 'block',
    items: [{
        xtype: 'grid',
        itemId:'grid',
        emptyText: '暂无数据',
        store:{
            type:'personalnote'
        },
        ui: 'listing',
        rowNumbers:{
            text:'#'
        },
        titleBar: null,
        //infinite:false,
        selectable: {
            disabled: true
        },

        // plugins: [{
        //     type: 'listpaging',
        //     autoPaging: true
        // }],
        //sortable: false,
        columns: [{
            text: '编号',
            dataIndex: 'NoteID',
            align:'center',
            width:80,
            cell: {
                encodeHtml: false
            },
            groupable:false,
            tpl: '<a class="item-title" href="#">{NoteID}</a>'
            
        }, {
            text: '内容',
            dataIndex: 'NoteContent',
            flex: 1,
            groupable:false,
            cell: {
                encodeHtml: false
            },
        }, {
            text: '纸张颜色',
            groupable:false,
            align:'center',
            width:75,
            cell: {
                encodeHtml: false
            },
            dataIndex: 'NoteColor',
            tpl:'<span class="Span-ConType" style="background-color:{NoteColor};"></span>'
        },{
            text: '重要程度',
            groupable:false,
            dataIndex: 'Priority',
            width:75,
            align:'center',
            renderer:function(value){
                return !(value==='H')?!(value==='M')?'低':'中':'高';
            }
        },{
            text: '创建者',
            groupable:false,
            dataIndex: 'CreatorName',
            width:60
        },{
            xtype:'com_datetimecolumn',
            text: '创建日期',
            groupable:false,
            align:'center',
            width:125,
            dataIndex: 'CreateDate',
        },{
            text: '更新者',
            groupable:false,
            dataIndex: 'UpdaterName',
            width:60
        },{
            xtype:'com_datetimecolumn',
            text: '更新日期',
            groupable:false,
            width:125,
            dataIndex: 'UpdateDate',
            align:'center'
        },{
            xtype:'com_checkcolumn',
            text: '完成',
            headerCheckbox:false,
            groupable:false,
            dataIndex: 'IsFinish',
            width:60,
        },{
            xtype:'com_datetimecolumn',
            text: '完成日期',
            groupable:false,
            align:'center',
            width:125,
            dataIndex: 'FinishDate',
        }],

        // listeners: {
        //     childdoubletap: 'onChildActivate'
        // }
    }]
});