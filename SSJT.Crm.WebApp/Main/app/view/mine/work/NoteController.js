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
        me.on
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
            tbar = view.getTbar();
    }
});
