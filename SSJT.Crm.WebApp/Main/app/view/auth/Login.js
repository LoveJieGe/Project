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
            //'<div class="title">博思伟创</div>'+
            '<div class="caption">CRM应用</div>'
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
            name: 'userID',
            placeholder: '用户名',
            required: true
        }, {
            xtype: 'passwordfield',
            name: 'password',
            placeholder: '密码',
            required: true
        }, {
            xtype:'container',
            padding:'5 0 5 0',
            layout:'hbox',
            items:[{
                xtype: 'textfield',
                name: 'validate',
                placeholder: '验证码',
                required: true,
                flex:1 
            },{
                xtype: 'img',
                mode:'img',
                src:'ValidateCode.ashx',
                tooltip:'换一张',
                style:{
                    cursor:'pointer'
                },
                width:80,
                padding:'0 0 0 1',
                listeners:{
                    tap:'onChangeValidate'
                }
            }]
        }, {
            xtype: 'button',
            text: '登录',
            iconAlign: 'right',
            iconCls: 'x-fa fa-angle-right',
            handler: 'onLoginTap',
            ui: 'action'
        }]
    }, {
        cls: 'auth-footer',
        html:
            '<div> Copyright © 2017-2020 yjyrj.com All Rights Reserved</div>'+
            '<a href="http://www.sencha.com" target="_blank">'+
                '<span class="logo ext ext-sencha"></span>'+
                '<span class="label">Sencha</span>'+
            '</a>'
    }]
});
