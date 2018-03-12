Ext.define('SSJT.view.widgets.BrowseController',{
    extend:'Ext.app.ViewController',
    alias:'controller.browse',
    control:{
        '#':{
            storechange:'onStoreChange',
        }
    },
    /**
     * createBuffered:创建一个委托函数，可选地使用绑定的范围，当被调用时，它会缓冲所传递函数的执行，
     * 以获得所配置的毫秒数。如果在此期间再次调用，将取消即将到来的调用，超时时间将再次开始。
     */
    initViewModel: function(vm) {
        const me = this;
        vm.bind(
            { bindTo: '{filters}', deep: true },
            Ext.Function.createBuffered(function() {
                if (!me.destroyed) {
                    me.updateFilters()
                }
            }, 500, me, {}));
    },
    onStoreChange(){
        this.updateFilters(true);
    },
    updateFilters(reload){
        const me = this,
            view = me.getView(),
            store = view.getStore(),
            collection = store&&store.getFilters(),
            filters = me.getViewModel().get('filters'),
            fields = view.getFields(),
            dirty = !!reload;
        var item,value;
        if(!collection)return;
        Ext.Object.each(fields,function(key,field){
            value = filters[key];
            if(value&&value.isModel){
                value = value.get('value');
            }
            key = field.propertty||key;
            item = collection.get(key);
            if(item&&item.getValue()==value)return;
            dirty = true;
            if(value==null){
                store.removeFilter(key,true);
            }else{
                store.filter(key,value,true);
            }
        })
        if(dirty){
            store.removeAll();
            store.load();
        }

    }
});