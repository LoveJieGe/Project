Ext.define('SSJT.store.person.PersonalNote',{
    extend:'Ext.data.Store',
    alias:'store.personalnote',
    requires:[
        'SSJT.model.PersonalNote'
    ],
    model:'SSJT.model.PersonalNote',
    remoteFilter:true,
    remoteSort:true,
    proxy: {
        type: 'ajax',
        api : 'userRequest/IStoreServer/QueryPersonNotes',
    },
})