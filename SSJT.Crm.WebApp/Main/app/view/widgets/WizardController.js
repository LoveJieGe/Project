Ext.define('SSJT.view.widgets.WizardController',{
    extend:'Ext.app.ViewController',
    alias:'controller.wizardcontroller',
    requires:[
        'Ext.History'
    ],
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
            form = me.getView();
        if(!form.validate())
            return;
        
    }
});