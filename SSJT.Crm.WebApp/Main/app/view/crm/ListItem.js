
Ext.define('SSJT.view.crm.ListItem',{
    extend:'Ext.dataview.NestedList',
    xtype:'menu-listItem',
    fullscreen: true,
    title: 'Groceries',
    store: {
        type:'menu_llistitem'
    }
});
