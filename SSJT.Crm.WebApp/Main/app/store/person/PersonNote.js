Ext.define('SSJT.store.person.PersonNote',{
    extend:'Ext.data.Store',
    alias:'store.personnote',
    model:'SSJT.model.PersonNote',
    remoteFilter:true,
    remoteSort:true,
    proxy: {
        type: 'ajax',
        api : 'userRequest/IStoreServer/QueryPersonNotes',
    },
})