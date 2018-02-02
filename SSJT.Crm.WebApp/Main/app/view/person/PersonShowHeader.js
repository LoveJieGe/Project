Ext.define('SSJT.view.person.PersonShowHeader', {
    extend: 'SSJT.view.widgets.ShowHeader',
    xtype: 'personshowheader',
    mixins: [
        'Ext.mixin.Responsive'
    ],
    requires: [
        'Ext.Image'
    ],
    responsiveConfig: {
        'width < 600': {
            layout: {
                vertical: true,
                align: 'center',
                pack: 'center'
            }
        },

        'width > 599': {
            layout: {
                vertical: false,
                align: 'end',
                pack: 'start'
            }
        }
    },

    cls: [
        'show-header',
        'person-header'
    ],

    items: {
        image: {
            xtype: 'image',
            weight: -10,
            userCls: [
                'header-picture',
                'picture'
            ],
            bind: {
                src: ''
            }
        },

        title: {
            tpl: [
                '<div class="name">管理员</div>',
                '<div class="desc">头部信息</div>'
            ]
        }
    }
});
