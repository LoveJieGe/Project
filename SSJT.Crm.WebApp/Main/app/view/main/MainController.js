/**
 * This class is the controller for the main view for the application. It is specified as
 * the "controller" of the Main view class.
 */
Ext.define('SSJT.view.main.MainController', {
    extend: 'Ext.app.ViewController',

    alias: 'controller.maincontroller',
    init(){
        console.log("初始化");

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
            action: 'toTasks',
            conditions: {
                // NOTE(SB): how to build this list automatically from the Menu store?
                ':type': '(customer|main|office|product|financial|personnel|system)',
                ':args': '(.*)'
            }
        }
        // 'crm/recycle': 'toRecycleBin'
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
                me.lookup('btnLogout').setTooltip({
                    xtype:'tooltip',
                    align:'tl-tr?',
                    ui:'large',
                    html:'注销',
                });
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

    ensureCenterByXType(xtype) {
        const me = this,
            view = me.getView();

        me.lookup('mainmenu').selectNodeSilent(Ext.History.getToken());

        let center = view.child('#center');
        // 确保中间的容器是 task_container
        if (!center || center.xtype != xtype) {
            if (center) view.remove(center, true);
            center = view.add({
                xtype: xtype,
                itemId: 'center'
            });
        }

        return center;
    },

    /**
     * 显示 任务 容器(其内部放置 我的任务、关注的任务、创建的任务 等)
     * @param {String} type
     */
    toTasks(type,args) {
        debugger
        console.log('路由',type);
        const me = this,
            center = me.ensureCenterByXType('crm-container');
            //vm = center.getViewModel(),
            //oldTaskType = vm.get('taskType');

        // if (oldTaskType != type) {
        //     vm.set('taskType', type);
        //     vm.notify();
        //     center.getController().onTaskTypeChange();
        // }
    },
    toHome(){
        debugger
        me.ensureCenterByXType('crm-container');
    },
    toTaskMsgbox() {
        const me = this;

        me.ensureCenterByXType('task_msgbox_container');
    },

    /**
     * 显示报表容器
     * @param {String} type
     */
    toTaskReport(type) {
        const me = this,
            center = me.ensureCenterByXType('task_report_container');

        center.getViewModel().set('reportType', type);
        center.getController().onReportTypeChange();
    },

    toRecycleBin() {
        const me = this,
            center = me.ensureCenterByXType('task_recycle_container');

        center.getController().onSearch();
    }
});