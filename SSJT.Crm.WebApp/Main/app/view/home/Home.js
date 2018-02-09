Ext.define('SSJT.view.main.Home', {
    extend: 'Ext.Panel',
    xtype: 'home',
    requires:[
        'SSJT.view.crm.Container'
    ],
    controller: 'mainhome',
    //referenceHolder: true,
    layout: 'fit',
    scrollable: 'y',
    items: [{
            xtype: 'crm-container',
    }]
});