Ext.define('SSJT.view.main.Main', {
    extend: 'Ext.Container',
    xtype: 'main',
    requires:[
        'Common.nav.Tree',
        'Common.nav.AvatarButton',
        'Common.nav.Button',
        'SSJT.view.crm.Container'
    ],
    controller: 'maincontroller',
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
                },
                // listeners:{
                //     selectionchange:'onNavSelectionChange'
                // }
            },{
                xtype: 'navavatarbutton',
                handler:'onAvatarTap'
            },{
                xtype: 'logoutbutton',
                reference:'btnLogout'
            }, {
                xtype: 'navbutton',
                reference: 'btnToggle',
                handler: 'onToggleNavigationSize'
            }]
         }
        ,
        //  {
        //     xtype: 'crm-container', //此处放 任务、任务评论、任务统计等 的容器
        //     itemId: 'center'
        // }
    ]
});