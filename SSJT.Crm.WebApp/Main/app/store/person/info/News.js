Ext.define('SSJT.store.person.info.News',{
    extend:'Ext.data.Store',
    alias:'store.info_news',
    requires:[
        'SSJT.model.personal.info.News'
    ],
    model:'SSJT.model.personal.info.News',
    remoteFilter:true,
    remoteSort:true,
    // proxy: {
    //     type: 'ajax',
    //     api : 'storeRequest/IStoreServer/QueryPersonNotes',
    // },
})