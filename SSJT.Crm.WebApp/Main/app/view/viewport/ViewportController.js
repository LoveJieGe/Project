Ext.define('SSJT.view.viewport.ViewportController',{
    extend:'Ext.app.ViewController',
    alias:'controller.viewport',
    required:[
        'Ext.Package',
    ],
    listen:{
        controller:{
            '*':{
                login:'onLogin',
                logout: 'onLogout',
                unmatchedroute:'handleUnmatchedRoute'
            }
        },
        global:{
            beforeroute:'onBeforeRoute'
        }
    },
    routes:{
        'login':'handleLoginRoute',
        'home': 'showMain'
    },
    onLaunch:function(){
        var me = this;
        // this.originalRoute = SSJT.getApplication().getDefaultToken();
        //检查用户是否登录
        Ext.route.Router.suspend();
        debugger
        ComUtils.ajax('ajaxRequest/UserAuthentication/GetCurrentUser', {
            success(r) {
                console.log('已经是登录状态', r);
                me.setUserInfo(r);
                //恢复路由
                Ext.route.Router.resume();
            },
            failure:function(r){
                //true可以防止任何先前排队的标记被执行
                Ext.route.Router.resume(true);
                me.redirectTo('login', {replace: true,force: true})
            },
            callback() {
                Ext.getBody().removeCls('launching');
            },
            maskTarget: false
        });
       
    },
    handleUnmatchedRoute:function(route){
        debugger
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
            var token = Ext.History.getToken();
            if (!Ext.isEmpty(token)) {
                me.redirectTo(token, {
                    force: true
                });
            }
        }
        viewport.setActiveItem(view);
    },
    showLoginView:function(){
        this.showView('authlogin');
    },
    showMain:function(){
        debugger
        this.showView('main');
    },
    onLogin:function(user){
        debugger
        var user = SSJT.model.UserInfo.loadData(user);
        var me = this,
            token = Ext.History.getToken();
            newToken = "";  
        user = SSJT.model.UserInfo.loadData(user);
        User.setUser(user);
        if (Ext.String.startsWith(token, 'login/returnurl/')) { //有returnurl参数，则转到returnurl
            newToken = decodeURIComponent(token.substr(16));
        } else if (!Ext.isEmpty(token) && token != 'login') {
            newToken = token;
        }

        if (Ext.isEmpty(newToken)) {
            newToken = ComUtils.getApp().getDefaultToken();
        }
        //force:即使散列不会更改，将其设置为true也会强制执行
        me.redirectTo(newToken, {
            replace: true,
            force: true
        });
    },
    onLogout:function(){
        var me = this,
            view = me.getView();
            ComUtils.ajax('ajaxRequest/UserAuthentication/Logout', {
            success(r) {
                me.setUserInfo(null);
                me.redirectTo('login', {
                    replace: true
                });
            },
            maskTarget: view
        });   
    },
    // 全局路由的 before 事件处理
    onBeforeRoute(action, route) {
        debugger
        const me = this,
            lastView = me.lastView;

        if (lastView) {
            if (lastView instanceof Ext.Sheet) { // 如果上次的view是Ext.Sheet，就隐藏
                lastView.hide();
            }
        }
        /* else {
            if (route !== window._last_route) {
                ComUtils.backAllFloated(); // 隐藏所有悬浮层
            }
        }*/
    },
    setUserInfo:function(r){
        r = r?SSJT.model.UserInfo.loadData(r):r;
        User.setUser(r);
    }
});