Ext.define('SSJT.view.person.PersonShowController', {
    extend: 'SSJT.view.widgets.ShowController',
    alias: 'controller.personshow',
    onFocus:function(item,e,opts){
        console.log(e);
    }
});
