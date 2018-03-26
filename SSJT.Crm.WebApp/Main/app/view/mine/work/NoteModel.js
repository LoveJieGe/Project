Ext.define('SSJT.view.mine.work.NoteModel', {
    extend: 'Ext.app.ViewModel',
    alias: 'viewmodel.mine_work_note',
    stores: {
        notes: {
            type: 'personalnote',
            //用于对数据存储进行分组的grouper。也可以由groupField配置指定，但是它们不应该一起使用?
            grouper: {
                groupFn: function(record) {
                    return record&&record.get('name')[0];
                }
            }
        }
    }
});
