Ext.define('SSJT.view.person.PersonShowController', {
    extend: 'SSJT.view.widgets.ShowController',
    alias: 'controller.personshow',
    onRecordChange: function(view, record) {
        debugger
        this.callParent(arguments);
    },
    showEditAvatar:function(e){
        const edit=this.lookup('editAvattar');
        edit&&edit.show();
    },
    hideEditAvatar:function(e){
        const edit=this.lookup('editAvattar');
        edit&&edit.hide();
    },
    onEditAvatar:function(){
        AvatarHelper.showAvatarDialog();
    }
});
