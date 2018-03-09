Ext.define('SSJT.view.mine.work.Note',{
    extend:'SSJT.view.widgets.Browse',
    // fields:{
    //     country:{
    //         property:'country'
    //     }
    // }
    xtype:'mine_work_note',
    controller:'mine_work_note',
    viewModel:{
        type:'mine_work_note'
    },
    bind:{
        store:'{notes}'
    },
    tbar: {
        xtype: 'notetoolbar'
    },
    items: [{
        xtype: 'grid',
        emptyText: '暂无数据',
        bind: '{notes}',
        ui: 'listing',
        rowNumbers:{
            text:'#'
        },
        infinite:false,
        selectable: {
            disabled: true
        },

        // plugins: [{
        //     type: 'listpaging',
        //     autoPaging: true
        // }],

        columns: [{
            text: '编号',
            dataIndex: 'NoteID',
            flex: 2,
            cell: {
                encodeHtml: false
            },
            tpl: '<a class="item-title" href="#">{NoteID}</a>'
        }, {
            text: '内容',
            dataIndex: 'NoteContent',
            flex: 2,
            cell: {
                encodeHtml: false
            },
        }, {
            text: '纸张颜色',
            dataIndex: 'NoteColor',
            flex: 1,
        },{
            text: '重要程度',
            dataIndex: 'Priority',
            flex: 1,
        },{
            text: '创建者',
            dataIndex: 'CreatorName',
            flex: 1,
        },{
            text: '创建日期',
            dataIndex: 'CreateDate',
            flex: 1,
        },{
            text: '更新者',
            dataIndex: 'UpdaterName',
            flex: 1,
        },{
            text: '更新日期',
            dataIndex: 'UpdateDate',
            flex: 1,
        },{
            text: '完成',
            dataIndex: 'IsFinish',
            flex: 1,
        },{
            text: '完成日期',
            dataIndex: 'FinishDate',
            flex: 1,
        }],

        listeners: {
            childdoubletap: 'onChildActivate'
        }
    }]
});