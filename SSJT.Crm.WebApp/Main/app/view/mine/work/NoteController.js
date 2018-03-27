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
    }
});
