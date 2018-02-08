Ext.define('SSJT.store.person.Person', {
    extend: 'Ext.data.Store',
    alias: 'store.person',
    requires: [
        'SSJT.model.Person'
    ],

    model: 'SSJT.model.Person',

    remoteSort: true,
    remoteFilter: true,
});