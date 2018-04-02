Ext.define('SSJT.view.widgets.BrowseController',{
    extend:'Ext.app.ViewController',
    alias:'controller.browse',
    listen:{
        controller:{
            '*':{
                personalAdd:'onPersonalAdd'
            }
        }
    },
    onPersonalAdd:function(r){
        debugger
        const me = this,
            view = me.getView(),
            grid = view.down('#grid');
            store = grid&&grid.getStore(),
            record = store&&store.getById(r.NoteID);
        if(store&&!record){
            record = Ext.create(store.getModel(), r);
            //record.phantom = true;
            store.insert(0, record);
        }
    },
    onSearch:function(){

    },
    onRefreshTap:function(){

    },
});