Ext.define('Common.view.NoteController',{
    extend:'Ext.app.ViewController',
    alias:'controller.note',
    init(){
        var me = this,
            viewModel = me.getViewModel(),
            personNote = Ext.create('SSJT.model.PersonNote',{
                LocationX:100,
                LocationY:100,
                NoteContent:'测试测试'
            });
        viewModel.set('record',personNote);
        me.callParent(arguments);
    },
    onHideNote(){
        var me = this,
            view = me.getView();
        ComUtils.confirm(view.actionMsg,function(){
            if(view.action){
                let action = Ext.util.Format.lowercase(view.action);
                if(action=='add'){
                    view.destroy();
                }
            }
        })
    },
    onMenuItemTap(m,e){
        const me = this,
            iconCls = m&&m.getIconCls(),
            menu = me.lookup('prioritymenu');
        menu.setIconCls(iconCls);
    }
})