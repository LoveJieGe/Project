Ext.define('Common.grid.column.DateTime',{
    extend:'Ext.grid.column.Date',
    requires:[
        'Common.grid.cell.DateTime'
    ],
    xtype: 'com_datetimecolumn',
    config:{
        cell:{
            xtype:'com_datetimecell'
        }
    }
    
})