Ext.define('SSJT.view.person.ShowTools', {
    extend: 'Ext.Container',
    xtype: 'personshowtools',

    mixins: [
          'Ext.mixin.Responsive'
    ],

    cls: 'person-tools',

    layout: {
        type: 'box',
        align: 'center'
    },

    responsiveConfig: {
        'width < 600': {
            layout: {
                vertical: true
            }
        },
        'width > 599': {
            layout: {
                vertical: false
            }
        }
    },

    items: [{
        xtype: 'toolbar',
        flex: 1,

        items: [{
            iconCls: 'x-fa fa-phone',
            handler: 'onCallTap',
            ui: 'action-phone',
        },{
            iconCls: 'x-fa fa-skype',
            handler: 'onSkypeTap',
            ui: 'action-skype',
        },{
            iconCls: 'x-fa fa-envelope',
            handler: 'onEmailTap',
            ui: 'action-email',
        },{
            iconCls: 'x-fa fa-linkedin',
            handler: 'onLinkedInTap',
            ui: 'action-linkedin',
        }]
    }, {
        xtype: 'component',
        cls: 'header-clock',
        tpl: [
            '<div class="date">{time:date("F d , l")}</div>',
            '<div class="time"><span class="x-fa fa-clock-o"></span> {time:date("G:i A")}</div>'
        ],
        // bind: {
        //     record: '{record}'
        // }
        bind: {
            data: {
                time: '{time}'
            }
        }
    }]
});
