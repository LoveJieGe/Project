Ext.define('Common.grid.cell.DateTime',{
    extend:'Ext.grid.cell.Date',
    xtype:'com_datetimecell',
    applyFormat:function(format){
        return format || `${Ext.Date.defaultFormat} h:i`;
    }
})