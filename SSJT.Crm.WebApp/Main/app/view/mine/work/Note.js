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
            flex: 2,
            cell: {
                encodeHtml: false
            },
            groupable:false,
            tpl: '<a class="item-title" href="#">{NoteID}</a>'
            
        }, {
            text: '内容',
            dataIndex: 'NoteContent',
            flex: 2,
            groupable:false,
            cell: {
                encodeHtml: false
            },
        }, {
            text: '纸张颜色',
            groupable:false,
            dataIndex: 'NoteColor',
            flex: 1,
        },{
            text: '重要程度',
            groupable:false,
            dataIndex: 'Priority',
            flex: 1,
        },{
            text: '创建者',
            groupable:false,
            dataIndex: 'CreatorName',
            flex: 1,
        },{
            text: '创建日期',
            groupable:false,
            width:76,
            dataIndex: 'CreateDate',
        },{
            text: '更新者',
            groupable:false,
            dataIndex: 'UpdaterName',
            flex: 1,
        },{
            text: '更新日期',
            groupable:false,
            width:76,
            dataIndex: 'UpdateDate',
        },{
            text: '完成',
            groupable:false,
            dataIndex: 'IsFinish',
            width:60
        },{
            text: '完成日期',
            groupable:false,
            width:76,
            dataIndex: 'FinishDate',
        }],

        listeners: {
            childdoubletap: 'onChildActivate'
        }
    }]
});