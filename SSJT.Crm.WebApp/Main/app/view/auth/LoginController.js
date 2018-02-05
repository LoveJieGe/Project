Ext.define('SSJT.view.auth.LoginController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.authlogin',

    init: function() {
        this.callParent(arguments);
        var me = this,form = this.lookup('form');
        form.setValues({
            userID: 'Admin',
            password: '123456'
        });
        var map = new Ext.util.KeyMap({
            target: form.element,
            key: 13, // or Ext.event.Event.ENTER
            handler() {
                me.onLoginTap();
            },
            scope: me
        });
    },

    onLoginTap: function() {
        var me = this,
            form = me.lookup('form'),
            values = form.getValues();
        form.clearErrors();
        if(form.validate()){
            form.ajax('ajaxRequest/UserAuthentication/Login', {
                data: {
                    UserID: values.userID,
                    PassWord: values.password
                },
                params:{
                    Validate:values.validate
                } ,
                success(r) {
                    if(r.User&&Ext.isArray(r.User))
                        r.User = r.User[0];
                    me.fireEvent('login', r);
                },
                failure(r) {
                    ComUtils.toastShort(r.Message||'');
                },
                //button: 'btnLogin',
                maskTarget: true
            });
        }
    },
    onChangeValidate:function(sender,e){
        sender.setSrc('ValidateCode.ashx?_dc='+new Date().getTime());
    }
});
