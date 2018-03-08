Ext.define('SSJT.view.widgets.BrowseToolbar',{
    extend:'Ext.Toolbar',
    xtype:'browsetoolbar',
    weighted:true,
    ui:'tools',
    defaultButtonUI:'action',
    items:{
        search:{
            xtype:'searchfield',
            reference:'search',
            placeholder:'搜索...',
            userCls:'expandable',
            bind: '{filters.search}',
            weight: 0
        },
        refresh: {
            iconCls: 'x-fa fa-refresh',
            handler: 'onRefreshTap',
            tooltip: '刷新',
            weight: 30
        },
        clear: {
            iconCls: 'x-fa fa-undo',
            handler: 'onClearFiltersTap',
            tooltip: '清除',
            weight: 20
        }
    }
})