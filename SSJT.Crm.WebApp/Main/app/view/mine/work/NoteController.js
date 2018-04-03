Ext.define('SSJT.view.mine.work.NoteController', {
    extend: 'SSJT.view.widgets.BrowseController',
    alias: 'controller.mine_work_note',

    // control: {
    //     '#': {
    //         reset: 'refresh'
    //     }
    // },

    // refresh: function() {
    //     var vm = this.getViewModel();
    //     vm.getStore('countries').reload();
    // },
    init(){
        const me = this;
        me.onSearch();
        me.callParent(arguments);
    },
    onCreate: function() {
        var note_view = Ext.create('Common.view.Note'),
            note_model = Ext.create('SSJT.model.PersonalNote'),
            note_viewmodel = note_view.getViewModel();
        note_view.setRecord(note_model);
        note_view.show();
    },
    onSearch(){
        var me = this,
            view = me.getView(),
            grid = view.getComponent('grid'),
            tbar = view.getTbar(),
            fields = tbar.query('field[name]'),
            store = grid.getStore(),
            filters = [],
            value;

        Ext.each(fields, (field) => {
            value = field.getValue();
            if(!Ext.isEmpty(value)) {
                filters.push({ property: field.getName(), value: value });
            }
        });
        store.suppressNextFilter = true;
        store.clearFilter(true);
        store.setFilters(filters);
        store.suppressNextFilter = false;
        store.loadPage(1);
    },
    onDeleteNote(g,o,e){
        ComUtils.confirm('确定删除该行数据?',()=>{
            let me = this,
                view = me.getView(),
                record = o.record,
                store = g.getStore();
            view.ajax('ajaxRequest/IPersonalService/DeleteNote',{
                data:{
                    NoteID:record.get('NoteID')
                },
                success(r){
                    ComUtils.toastShort('删除成功!');
                    if(store&&record){
                        store.remove(record);
                    }
                },
                maskTarget: view
            });
        })

    },
    onEditNote(g,o,e){
        debugger
        const me = this,
            view = me.getView(),
            record = o.record,
            store = g.getStore(),
            note_view_id = 'note-'+record.get('NoteID').toString().toLowerCase(),
            note_view = Ext.getCmp(note_view_id);
            if(!note_view){
                note_view = Ext.create('Common.view.Note',{
                    id:note_view_id,
                });
                note_view.setRecord(record);
            }
            note_view.getViewModel().set('statusType','edit');
            note_view.show();
    },
    onChildTap(list, location){
        if(!location.record)return;
        const me = this,
            event = location.event,
            ele = Ext.fly(event.target),
            record = location.record,
            noteId = record.get('NoteID');
        var selections = list.getSelections(),
            selectable = list.getSelectable();
        if(ele.hasCls('item-title')){
            let note_view_id = 'note-'+noteId.toString().toLowerCase(),
                note_view = Ext.getCmp(note_view_id);
            if(!note_view){
                note_view = Ext.create('Common.view.Note',{
                    id:note_view_id,
                });
                note_view.setRecord(record);
            }
            note_view.getViewModel().set('statusType','view');
            note_view.show();
        }
    }
});
