Ext.define('SSJT.view.widgets.BrowseToolbar',{
    extend:'Ext.Toolbar',
    xtype:'browsetoolbar',
    weighted:true,
    ui:'tools',
    defaultButtonUI:'action',
    shadow:true,
    items:{
        search:{
            xtype: 'textfield',
            label: '搜索',
            name: 'Search',
            labelWidth: 'auto',
            placeholder:'编号,内容',
            triggers: {
                search: {
                    type: 'search',
                    handler: 'onSearch'
                }
            },
            weight: 20
        },
        refresh: {
            iconCls: 'x-fa fa-refresh',
            handler: 'onRefreshTap',
            tooltip: '刷新',
            weight: 10
        }
    }
})