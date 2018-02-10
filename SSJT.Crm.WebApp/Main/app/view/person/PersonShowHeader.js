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
        editAvatar: {
            weight: -15,
            xtype: 'button',
            iconCls: 'x-fa fa-pencil',
            handler: 'onEditTap',
            text: '编辑头像',
            weight: 10,
            ui: 'flat',

            platformConfig: {
                phone: {
                    hidden: true
                }
            }
        },
        image: {
            xtype: 'image',
            weight: -10,//较低的值被吸引到容器的开始位置——垂直布局的顶部，位置在水平布局中开始。
            userCls: [
                'header-picture',
                'avatar'
            ],
            src:'/Main/resources/images/auth-background.jpg',
            // bind: {
            //     src: ''
            // },
            listeners:{
                focusenter:function(){console.log(111)}
            }
        },
        title: {
            tpl: [
                '<div class="name">{UserName}</div>',
                '<div class="desc">{UserID}</div>'
            ]
        }
    }
});
