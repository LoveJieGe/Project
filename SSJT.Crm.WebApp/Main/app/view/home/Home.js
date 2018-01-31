Ext.define('SSJT.view.main.Home', {
    extend: 'Ext.Container',
    xtype: 'mainhome',
    requires:[
        'Common.nav.Tree',
        'Common.nav.AvatarButton',
        'Common.nav.Button'
    ],
    controller: 'mainhome',
    referenceHolder: true,
    layout: 'fit',
    items: [{
            xtype: 'container',
            docked: 'left',
            cls:'navtree-ct',
            userCls: 'navtree-ct',
            reference: 'navigation',
            layout: 'vbox',
            items: [{
                xtype: 'navtree',
                flex: 1,
                reference: 'mainmenu',
                store: {
                    type: 'mainmenu'
                }
            },{
                xtype: 'navavatarbutton'
            },{
                xtype: 'logoutbutton',
                reference:'btnLogout'
            }, {
                xtype: 'navbutton',
                reference: 'btnToggle',
                handler: 'onToggleNavigationSize'
            }]
        }
        /*, {
            xtype: 'task_container', //此处放 任务、任务评论、任务统计等 的容器
            itemId: 'center'
        }*/
    ]
});