/**
 * This class is the controller for the main view for the application. It is specified as
 * the "controller" of the Main view class.
 */
Ext.define('SSJT.view.home.HomeController', {
    extend: 'Ext.app.ViewController',

    alias: 'controller.mainhome',

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
        'home':{
            action: 'toTasks',
        }
        // 'home/:type': {
        //     conditions: {
        //         ':type': '(mine|followed|shared|created|completed|all)'
        //     }
        // },
        // 'home/msgbox': 'toTaskMsgbox',
        // 'home/report/:type': 'toTaskReport',
        // 'home/recycle': 'toRecycleBin'
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

    updateShowNavigation(showNavigation, oldValue) {
        // Ignore the first update since our initial state is managed specially. This
        // logic depends on view state that must be fully setup before we can toggle
        // things.
        //
        if (oldValue !== undefined) {
            const me = this,
                navigation = me.lookup('navigation'),
                mainmenu = me.lookup('mainmenu'),
                rootEl = mainmenu.rootItem.el;
            //如果有样式则删除，没有则添加
            navigation.toggleCls('navtree-ct-collapsed');

            if (showNavigation) {
                // Restore the text and other decorations before we expand so that they
                // will be revealed properly. The forced width is still in force from
                // the collapse so the items won't wrap.
                rootEl.setWidth('');
                mainmenu.setMicro(false);
                me.lookup('btnLogout').setTooltip('');
            } else {
                // Ensure the right-side decorations (they get munged by the animation)
                // get clipped by propping up the width of the tree's root item while we
                // are collapsed.
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

        me.lookup('navTree').selectNodeSilent(Ext.History.getToken());

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
    toTasks(type) {
        console.log('路由',type);
        // const me = this,
        //     center = me.ensureCenterByXType('task_container'),
        //     vm = center.getViewModel(),
        //     oldTaskType = vm.get('taskType');

        // if (oldTaskType != type) {
        //     vm.set('taskType', type);
        //     vm.notify();
        //     center.getController().onTaskTypeChange();
        // }
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