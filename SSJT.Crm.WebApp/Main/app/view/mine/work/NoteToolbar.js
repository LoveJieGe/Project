Ext.define('SSJT.view.mine.work.NoteToolbar',{
    extend:'SSJT.view.widgets.BrowseToolbar',
    xtype:'notetoolbar',
    items:{
        create:{
            xtype:'button',
            iconCls:'x-fa fa-plus',
            handler:'onCreate',
            text:'新增',
        }
    }
})