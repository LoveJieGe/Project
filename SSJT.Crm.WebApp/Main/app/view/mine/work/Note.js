Ext.define('SSJT.view.mine.work.Note',{
    extend:'SSJT.view.widgets.Browse',
    // fields:{
    //     country:{
    //         property:'country'
    //     }
    // }
    requires:[
        'Ext.Progress',
        'Ext.grid.plugin.PagingToolbar'
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
        columnLines:true,
        selectable: {
            disabled: true
        },

        plugins: {
            gridpagingtoolbar:true
        },
        userCls:'SSJT-x-gridrow',
        sortable: false,
        columns: [{
            text: '编号',
            dataIndex: 'NoteID',
            align:'center',
            width:85,
            groupable:false,
            tpl: '<a class="item-title" href="javascript:void(0)">{NoteID}</a>'
            
        }, {
            text: '内容',
            dataIndex: 'NoteContent',
            flex: 1,
            groupable:false,
        }, {
            text: '纸张颜色',
            groupable:false,
            align:'center',
            width:75,
            dataIndex: 'NoteColor',
            tpl:'<span class="Span-ConType" style="background-color:{NoteColor};"></span>'
        },{
            text: '重要程度',
            groupable:false,
            dataIndex: 'Priority',
            width:75,
            align:'center',
            renderer:function(value,record,dataIndex,cell,column){
                let row = cell.row;
                if(value=='H'){
                    row.addCls('crm-gridrow-color');
                }else{
                    row.removeCls('crm-gridrow-color');
                }
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
        },{
            text:'编辑',
            hideable:false,
            sortable:false,
            width:20,
            cell:{
                tools:{
                    edit:{
                        handler:'onEditNote',
                        iconCls:'x-fa fa-edit',
                        tooltip:'编辑'
                    }
                }
            }
        },{
            text:'删除',
            hideable:false,
            sortable:false,
            width:20,
            cell:{
                tools:{
                    delete:{
                        handler:'onDeleteNote',
                        iconCls:'x-fa fa-remove',
                        tooltip:'删除'
                    }
                }
            }
        }],

        listeners: {
            childtap: 'onChildTap',
            // childdoubletap: 'onChildActivate'
        }
    }]
});