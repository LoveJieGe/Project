Ext.define('SSJT.view.person.PersonShowModel', {
    extend: 'Ext.app.ViewModel',
    alias: 'viewmodel.personshow',
    stores: {
        coworkers: {
            type: 'people',
            pageSize: 12
        },

        history: {
            type: 'actions',
            pageSize: 12
        }
    }
});