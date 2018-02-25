Ext.define('SSJT.view.person.PersonShowController', {
    extend: 'SSJT.view.widgets.ShowController',
    alias: 'controller.personshow',
    onFocus:function(item,e,opts){
        console.log(e);
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
