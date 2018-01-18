Ext.define('SSJT.view.viewport.ViewportController',{
    extend:'Ext.app.ViewController',
    alias:'controller.viewport',
    required:[
        'Ext.Package',
        'Utils.util.Utils'
    ],
    listen:{
        controller:{
            '*':{
                login:'onLogin',
                unmatchedroute:'handleUnmatchedRoute'
            }
        }
    },
    routes:{
        'login':'handleLoginRoute'
    },
    onLaunch:function(){
        this.originalRoute = SSJT.getApplication().getDefaultToken();
        //检查用户是否登录
        Ext.route.Router.suspend();
        Ext.Ajax.request({
            url:'/handler/login/Login.ashx',
            method:'Post',
            success(r){
                console.log('成功')
            },
            failure(r){
                console.log('失败')
            }
        })
        // Utils.ajax('/handler/login/Login.ashx',{
        //     success(data){
        //         console.log('登陆成功')
        //     },
        //     callBack(){

        //     },
        //     maskTarget:false
        // })
    },
    handleUnmatchedRoute:function(route){
        var me = this;
        if(!me.session||!me.session.isValid()){
            me.originalRoute = route;
            me.redirectTo('login',{replace:true});
            return;
        }
        var target = SSjt.getApplication().getDefaultToken();
        Ext.log.warn('Route unknown ' + route);
        if(route!==target){
            me.redirectTo(target,{replace:true});
        }
        
    },
    handleLoginRoute:function(){
        //debugger
        var session = this.session;
        if(session&&session.isValid()){
            this.redirectTo('',{required:true});
            return;
        }
        this.showLoginView();
    },
    showView:function(xtype){
        var view = this.lookup(xtype),
            viewport = this.getView();
        if(!view){
            viewport.removeAll(true);
            viewport.add({
                xtype:xtype,
                reference:xtype
            });
        }
        viewport.setActiveItem(view);
    },
    showLoginView:function(){
        this.showView('authlogin');
    },
    onLogin:function(user){
        var me = this,
            token = Ext.History.getToken();
            newToken = "";
        User.setUser(user);

        if (Ext.String.startsWith(token, 'login/returnurl/')) { //有returnurl参数，则转到returnurl
            newToken = decodeURIComponent(token.substr(16));
        } else if (!Ext.isEmpty(token) && token != 'login') {
            newToken = token;
        }

        if (Ext.isEmpty(newToken)) {
            newToken = Utils.getApp().getDefaultToken();
        }

        me.redirectTo(newToken, {
            replace: true,
            force: true
        });
    }
});