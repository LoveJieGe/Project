/**
 * This class is the controller for the main view for the application. It is specified as
 * the "controller" of the Main view class.
 */
Ext.define('SSJT.view.main.MainController', {
    extend: 'Ext.app.ViewController',

    alias: 'controller.maincontroller',
    init(){
        debugger
        const me = this,
            mainmenu = me.lookup('mainmenu'),
            store = mainmenu.getStore();
            store.load();
        me.setShowNavigation(this.getView().getShowNavigation());
    },
    config: {
        showNavigation: true
    },

    listen: {
        controller: {
            '*': {
                toggletasknavtree: 'onToggleTaskNavTree',
                userchanged: 'onUserChanged'
            }
        },
        global: {
            afterroute: 'onAfterRoute'
        }
    },

    routes: {
        ':type(/:args)?': {
            action: 'handleNavigationRoute',
            conditions: {
                // NOTE(SB): how to build this list automatically from the Menu store?
                ':type': '(customer|home|office|product|financial|personnel|system)',
                ':args': '(.*)'
            }
        },
        ':type/:id(/:args)?': {
            action: 'handleDataRoute',
            conditions: {
                ':type': '(office|organization|person)',
                ':id': '([a-zA-Z0-9]+|create|edit)',
                ':args': '(.*)'
            }
        }
        // 'crm/recycle': 'toRecycleBin'
    },
    smallResponsive:function(a,b,c){
        me.setShowNavigation(false);
    },
    largeResponsive:function(a,b,c){
        me.setShowNavigation(true);
    },
    onToggleTaskNavTree(expand) {
        const me = this;
        if (expand !== undefined) {
            me.setShowNavigation(!!expand);
        } else {
            me.onToggleNavigationSize();
        }
    },

    onToggleNavigationSize() {
        this.setShowNavigation(!this.getShowNavigation());
    },
    //导航条属性变化时
    updateShowNavigation(showNavigation, oldValue) {
        if (oldValue !== undefined) {
            const me = this,
                navigation = me.lookup('navigation'),
                mainmenu = me.lookup('mainmenu'),
                rootEl = mainmenu.rootItem.el;
            var tooltip;
            if(!tooltip){
                tooltip = new Ext.tip.ToolTip({
                        xtype:'tooltip',
                        align:'tl-tr?',
                        dismissDelay:1000,
                        ui:'large',
                        html:'注销',
                });
            }
            //如果有样式则删除，没有则添加
            navigation.toggleCls('navtree-ct-collapsed');

            if (showNavigation) {
                rootEl.setWidth('');
                mainmenu.setMicro(false);
                me.lookup('btnLogout').setTooltip(null);
            } else {
                //将Treelist UI设置为true，只显示根节点的图标。将光标悬停(或在触控设备上点击)显示图标旁边的子节点。
                rootEl.setWidth(rootEl.getWidth());
                mainmenu.setMicro(true);
                me.lookup('btnLogout').setTooltip(tooltip);
            }
            me.lookup('btnToggle').setCollapsed(!showNavigation);
        }
    },

    // 全局路由的 after 事件处理 (MX.override.route.Route)
    onAfterRoute(route, token) {
        if (token.split('/')[0] == 'tasks') {
            document.title = '任务';
        }
    },
    onUserChanged() {
        try {
            Task.view.widget.BodySelectCombo.bodiesCache = null;
        } catch (e) {}
    },

    // destroy() {
    //     const me = this;
    //     me.callParent(arguments);

    //     // 销毁缓存的 view 实例
    //     TaskHelper.destroyAllViewCache();
    // },
    onShowNavigationChange:function(instance, newValue, oldValue){
        this.setShowNavigation(newValue);
    },
    /**
     * 显示 容器(这个是导航条处的)
     * @param {String} type
     */
    handleNavigationRoute(type,args) {
        debugger
        console.log('路由',type);
        const me = this,
            dataId = (type||'')+(args||'');
            node = me.lookup('mainmenu').getStore().getNodeById(dataId);
        var mtype = node&&node.get('mtype')
        //选中导航条中的项
        me.lookup('mainmenu').selectNodeSilent(dataId);
        
        me.activate(
            me.ensureView(mtype, {
                xtype: mtype
            }, args));
            //vm = center.getViewModel(),
            //oldTaskType = vm.get('taskType');

        // if (oldTaskType != type) {
        //     vm.set('taskType', type);
        //     vm.notify();
        //     center.getController().onTaskTypeChange();
        // }
    },
    handleDataRoute(type,id,args){
        debugger
        var me = this,
            args = Ext.Array.clean((args||'').split('/')),//通过数组进行筛选并删除Ext.isEmpty中定义的空项。
            Model = SSJT.model[Ext.String.capitalize(type)],//capitalize将给定字符串的第一个字母大写
            action, xtype, view;
            me.lookup('mainmenu').setSelection(null);
            if (id == 'create') {
                action = 'create';
                id = null;
            } else if (args[0] == 'edit') {
                action = 'edit';
                args.shift();//从数组中移除第一个元素并返回该元素
            } else {
                action = 'show';
            }
            xtype = type + action;

            if (!Ext.ClassManager.getNameByAlias('widget.' + xtype)) {
                Ext.log.error('Invalid route: no view for xtype: ' + xtype);
            }
            view = me.ensureView(xtype, { xtype: xtype });
            if(id==null){
                view.setRecord(new Model());
                me.activate(view);
                return;
            }
            ComUtils.mask(me.getView());
            //Ext.Viewport.setMasked({ xtype: 'loadmask' });
            Model.load(id, {
                callback: function(record, operation, success) {
                    view.setRecord(record);
                    me.activate(view);
                    //Ext.Viewport.setMasked(false);
                    ComUtils.unMask(me.getView());
                    // if (type === 'person') {
                    //     var user = me.getViewModel().get('user');
                    //     if (record.get('CustomID') != user.get('CustomID')) {
                    //         me.fireEvent('actionlog', 'profile', record);
                    //     }
                    // }
                }
            });
    },
    onAvatarTap(){
        var user = this.getViewModel().get('user');
        console.log("user",user);
        debugger
        this.redirectTo(user);
    },
    ensureView(xtype,config,route){
        var container = this.getView(),
        item = container.child('component[viewId=' + xtype + ']'),
        reset = !!item;
        if (!item) {
            item = container.add(Ext.apply({ 
                viewId: xtype,
                xtype:xtype 
            }, config));
        }
        if (Ext.isDefined(item.config.route)) {
            item.setRoute(route);
        }
        // Reset the component (form?) only if previously instantiated (i.e. with outdated data).
        if (reset && Ext.isFunction(item.reset)) {
            item.reset();
        }
        return item;
    },
    activate(ref){
        var view = ref.isComponent?ref:this.lookup(ref),
            child = view||ref,
            parent;
        while(parent=child.getParent()){
            parent.setActiveItem(child);
            child = parent;
        }
        return view;
    }
});