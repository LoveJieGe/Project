Ext.define('SSJT.view.mine.work.NoteController', {
    extend: 'SSJT.view.widgets.BrowseController',
    alias: 'controller.personalnote',

    control: {
        '#': {
            reset: 'refresh'
        }
    },

    refresh: function() {
        var vm = this.getViewModel();
        vm.getStore('countries').reload();
    },

    onCreate: function() {
        this.redirectTo('office/create');
    }
});
