Ext.define('SSJT.view.person.Wizard', {
    extend: 'SSJT.view.widgets.Wizard',
    xtype: [
        'personwizard',
        'personcreate',
        'personedit'
    ],
    controller: {
        type: 'personwizard'
    },

    // viewModel: {
    //     type: 'personwizard'
    // },
    bind: {
        title: '{record.phantom? "添加" : "编辑"}用户'
    },

    cls: 'person-create',

    screens: [{
        title: '账号设置',
        iconCls: 'x-fa fa-info',
        items: [{
            xtype: 'textfield',
            reference: 'username',
            label: '用户名',
            required: true,
            bind: '{record.UserName}',
            listeners: {
                change: 'onUsernameChange'
            }
        }, {
            xtype: 'passwordfield',
            reference: 'password',
            required: true,
            placeholder: '登录密码',
            bind: {
                label: '{record.phantom? "密码" : "新密码"}',
                required: '{record.phantom}',
                
            }
        }, {
            xtype: 'passwordfield',
            reference: 'password_check',
            label: '确认密码',
            disabled: true,
            validators: {
                type: 'controller',
                fn: 'doPasswordMatch'
            },
            bind: {
                required: '{record.phantom}',
                disabled: '{!password.value}'
            }
        }]
    }, {
        title: '个人信息',
        iconCls: 'x-fa fa-home',
        items: [{
            xtype: 'datepickerfield',
            reference: 'birthday',
            label: '生日',
            required: true,
            bind: '{record.Birthday}'
        }, {
            xtype: 'emailfield',
            reference: 'email',
            label: '邮箱',
            required: true,
            bind: '{record.Email}'
        }, {
            xtype: 'textfield',
            reference: 'phone',
            label: '电话',
            required: true,
            bind: '{record.Tel}'
        }, {
            xtype: 'textfield',
            reference: 'address',
            label: '地址',
            bind: '{record.Address}'
        }]
    }, {
        title: '个人经历',
        iconCls: 'x-fa fa-sitemap',
        items: [{
            xtype: 'textfield',
            reference: 'education',
            label: '学校',
            required: true,
            bind: '{record.Education}'
        }, {
            xtype: 'textfield',
            reference: 'levels',
            label: '水平',
            required: true,
            bind: '{record.Levels}'
        }]
    }]
});
