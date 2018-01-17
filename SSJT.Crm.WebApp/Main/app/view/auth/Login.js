Ext.define('SSJT.view.auth.Login', {
    extend: 'Ext.Container',
    xtype: 'authlogin',

    controller: 'authlogin',

    cls: 'auth-login',

    layout: {
        type: 'vbox',
        align: 'center',
        pack: 'center'
    },

    items: [{
        cls: 'auth-header',
        html:
            '<span class="logo x-fa fa-circle-o-notch"></span>'+
            //'<div class="title">��ʷ����</div>'+
            '<div class="caption">CRMϵͳ</div>'
    }, {
        xtype: 'formpanel',
        reference: 'form',
        layout: 'vbox',
        ui: 'auth',
        bodyStyle:{
            background:'#fff'
        },
        items: [{
            xtype: 'textfield',
            name: 'username',
            placeholder: 'Username',
            required: true,
        }, {
            xtype: 'passwordfield',
            name: 'password',
            placeholder: 'Password',
            required: true
        }, {
            xtype: 'button',
            text: '��¼',
            iconAlign: 'right',
            iconCls: 'x-fa fa-angle-right',
            handler: 'onLoginTap',
            ui: 'action'
        }]
    }, {
        cls: 'auth-footer',
        html:
            '<div>Ext JS example</div>'+
            '<a href="http://www.sencha.com" target="_blank">'+
                '<span class="logo ext ext-sencha"></span>'+
                '<span class="label">Sencha</span>'+
            '</a>'
    }]
});
