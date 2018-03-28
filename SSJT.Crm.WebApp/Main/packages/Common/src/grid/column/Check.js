Ext.define('Common.grid.column.Check',{
    extend:'Ext.grid.column.Check',
    isCheckColumn:false,
    requires:[
        'Common.grid.cell.Check'
    ],
    xtype:'com_checkcolumn',
    valueChecked:'Y',
    valueUnChecked:'N',
    cell:{
        xtype:'com_checkcell'
    },
    doSetRecordChecked(record,checked){
        const dataIndex = this.getDataIndex();

        // Only proceed if we NEED to change
        const v = checked ? this.valueChecked : this.valueUnChecked;
        if (record.get(dataIndex) !== v) {
            record.set(dataIndex, v);
        }
    },
    isRecordChecked(record){
        return record.get(this.getDataIndex()) === this.valueChecked;
    },
    onColumnTap(e) {
        const me = this;

        if (me.getEditable()) {
            me.callParent(arguments);
        }
    }
})