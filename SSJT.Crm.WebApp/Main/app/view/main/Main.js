Ext.define('SSJT.view.main.Main', {
    extend: 'Ext.Panel',
    xtype: 'main',
    requires:[
        'Common.nav.Tree',
        'Common.nav.AvatarButton',
        'Common.nav.Button',
        'SSJT.view.crm.Container'
    ],
    mixins: [
        'Ext.mixin.Responsive'
    ],
    eventedConfig:{
        showNavigation:true
    },
    // platformConfig: {
    //     phone: {
    //         showNavigation:false
    //     },

    //     '!phone': {
    //         showNavigation:true
    //     }
    // },
    responsiveConfig: {
        'width >= 1024': {
            showNavigation:true
        },
        'width < 1024': {
            showNavigation:false
        }
    },
    controller: 'maincontroller',
    //referenceHolder: true,
    layout: 'card',
    lbar:{
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
     },
     listeners:{
        shownavigationchange:'onShowNavigationChange'
     }
    // items: [
    //     //  {
    //     //     xtype: 'crm-container', //此处放 任务、任务评论、任务统计等 的容器
    //     //     itemId: 'center'
    //     // }
    // ]
});