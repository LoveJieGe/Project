/**
 * 导航树
 * 样式在 packages\local\theme-default\sass\src\list\Tree.scss
 */
Ext.define('Common.nav.Tree', {
    extend: 'Ext.list.Tree',
    xtype: 'navtree',

    scrollable: true,
    ui: 'nav',
    singleExpand: true,
    expanderFirst: false,
    expanderOnly: false,
    animation: {
        duration: 250,
        easing: 'ease'
    },

    initialize() {
        const me = this;
        me.callParent(arguments);

        me.on({
            itemclick: 'onNavItemClick',
            selectionchange: 'onNavSelectionChange',
            scope: me
        });
    },

    /**
     * 静默选择当前路由对应的导航树节点
     * @param {String} id
     */
    selectNodeSilent(id) {
        const me = this,
            navStore = me.getStore();

        if (navStore) {
            const node = navStore.getNodeById(id);
            if (node) {
                me.suspendEvents();
                me.setSelection(node);
                me.resumeEvents(true);

                const p = node.parentNode;
                if (p) {
                    p.expand();
                }
            }
        }
    },

    onNavItemClick(tree, info) {
        // The phone profile's controller uses this event to slide out the navigation
        // tree. We don't need to do anything but must be present since we always have
        // the listener on the view...
        const node = info.node;
        // 实现点击父节点时，自动选择第一个子节点
        if (!node.isLeaf() && node.childNodes.length > 0) { // 有子节点
            const selected = tree.getSelection();
            if (!selected || selected.parentNode !== node) { // 如果当前已选节点不是该父节点的子节点

                // info.toggle = false;

                node.expand(); // 展开
                tree.setSelection(node.childNodes[0]); // 选中第一个子节点

                return false;
            }
        }
    },

    /**
     * 点击树节点，跳转路由
     *
     * @param {Ext.list.Tree} tree
     * @param {Ext.data.Model} node
     */
    onNavSelectionChange(tree, node) {
        if (node) {
            RouteFloated.hideAll();
            Utils.redirectTo(node.get('id'));
        }
    }
});