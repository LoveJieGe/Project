Ext.define('SSJT.model.MainMenu',{
    extend:'Ext.data.TreeModel',
    alias:'model.mainmenu',
    fields:[
        'id',
        'text',
        'mtype',
        'iconCls',
        'parentId',
        {
            name:'leaf',
            type:'boolean',
            defaultValue: true,
        }
    ]
});