Ext.define('SSJT.view.widgets.WizardController',{
    extend:'Ext.app.ViewController',
    alias:'controller.wizardcontroller',
    requires:[
        'Ext.History'
    ],
    statics:{
        fieldNames:null
    },
    onScreenAdd: function(tab,items) {
        this.resync();
    },
    resync: function() {
        var me = this,
            tabs = me.lookup('tabs'),
            prev = me.lookup('prev'),
            next = me.lookup('next'),
            index = me.getActiveIndex(tabs),
            count = me.getItemCount(tabs),
            single = count < 2;

        tabs.getTabBar().setHidden(single);
        prev.setDisabled(index <= 0).setHidden(single);
        next.setDisabled(index == -1 || index >= count-1).setHidden(single);
    },
    advance:function(increment){
        const me = this,
            tabs = me.lookup('tabs'),
            index = me.getActiveIndex(tabs),
            count = me.getItemCount(tabs),
            next = increment+index;
        tabs.setActiveItem(Math.max(0, Math.min(count-1, next)));
    },
    getActiveIndex: function(tabs) {
        return tabs&&(tabs.getInnerItems().indexOf(tabs.getActiveItem()));
    },
    getItemCount: function(tabs) {
        return tabs&&tabs.getInnerItems().length;
    },
    onScreenRemove: function(tabs) {
        if (tabs&&!tabs.destroying) {
            this.resync();
        }
    },
    onScreenActivate: function(tabs) {
        // This event is triggered when the view is being destroyed!
        if (tabs&&!tabs.destroying) {
            this.resync();
        }
    },
    onNextTap:function(){
        this.advance(1);
    },
    onPrevTap:function(){
        this.advance(-1);
    },
    finalize:function(){
        const me = this,
            view = me.getView();
        if(view.getFloated()){
            view.close();
        }else{
            Ext.History.back();
        }
    },
    onCancelTap:function(){
        this.finalize();
    },
    onSubmitTap:function(){
        const me = this,
            form = me.getView(),
            values = form.getValues();
        if(!form.validate())
            return;
        debugger
        if(values.Levels){
            values.Levels = me.getEducationText(values.Levels);
        }
        form.ajax('ajaxRequest/IStoreServer/UpdateEmployee',{
            data:{
                userID:'Admin',
                values:values,
                fieldnames:me.getFieldNames()
            },
            success(data){
                debugger
                console.log(data)
            },
            failure(data){
                debugger
            },
            maskTarget:form
        })
    },
    getEducationText(value){
        if(!Ext.isEmpty(value)&&Ext.isString(value)){
            const me = this,
                levels = me.lookup('levels'),
                sel = levels.getSelection();
            return sel&&sel.get('text');
        }
        return null;
    },
    getFieldNames:function(){
        const me = this,
            self = me.self;
        if(!self.fieldNames){
            const form = me.getView(),
                fields = form.query('field[name]');
            self.fieldNames = fields.map(v=>v.getName());
        }
        return self.fieldNames;
    }
});