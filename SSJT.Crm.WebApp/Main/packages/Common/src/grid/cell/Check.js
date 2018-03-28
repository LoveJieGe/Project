Ext.define('Common.grid.cell.Check',{
    extend:'Ext.grid.cell.Check',
    xtype:'com_checkcell',
    valueChecked:null,
    valueUnChecked:null,
    applyValue(value) {
        return value === this.valueChecked;
    },
    updateColumn(column,oldColumn){
        this.callParent([column,oldColumn]);
        if(column){
            this.valueChecked = column.valueChecked;
            this.valueUnChecked = column.valueUnChecked;
        }
    },
    onTap(e) {
        const me = this,
            column = me.getColumn();
        if (column.getEditable()) {
            me.callParent(arguments);
        }
    }
})