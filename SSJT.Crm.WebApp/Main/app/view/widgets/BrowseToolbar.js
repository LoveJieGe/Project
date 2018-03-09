Ext.define('SSJT.view.widgets.BrowseToolbar',{
    extend:'Ext.Toolbar',
    xtype:'browsetoolbar',
    weighted:true,
    ui:'tools',
    defaultButtonUI:'action',
    items:{
        search:{
            xtype: 'textfield',
            label: '搜索',
            name: 'Search',
            labelWidth: 'auto',
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
        },
        clear: {
            iconCls: 'x-fa fa-undo',
            handler: 'onClearFiltersTap',
            tooltip: '清除',
            weight: 30
        }
    }
})