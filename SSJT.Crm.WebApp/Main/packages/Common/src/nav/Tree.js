/**
 * 导航树
 * 样式在 packages\local\theme-default\sass\src\list\Tree.scss
 */
Ext.define('Common.nav.Tree', {
    extend: 'Ext.list.Tree',
    xtype: 'navtree',

    scrollable: true,
    ui: 'nav',
    singleExpand: true,//如果每个分支中只有一个节点可以扩展，则为true。
    expanderFirst: false,//true将扩展器显示在项目文本的左侧。false将扩展器显示在项文本的右侧。
    expanderOnly: false,//true只对扩展元素的单击进行扩展。false将允许扩展单击元素的任何部分
    animation: {
        duration: 250,//以毫秒为单位的动画持续时间。
        easing: 'ease'//有效的值是“ease”、“linear”、“ease-in”、“ease-out”、“ease-in-out”，或者是由CSS定义的cubic-bezier曲线。
    },
    userCls:'scrollbar',
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
        debugger
        const me = this,
            navStore = me.getStore();

        if (navStore) {
            const node = navStore.getNodeById(id);
            if (node) {
                //暂停所有事件
                me.suspendEvents();
                me.setSelection(node);
                //回复所有事件，true:在被暂停时，可以防止任何先前排队的事件被触发
                me.resumeEvents(true);
                const p = node.parentNode;
                if (p) {
                    p.expand();
                }
            }
        }
    },
    /**
     * 
     * @param {Ext.list.Tree} tree 所选择的树的对象
     * @param {*} info节点的信息 
     */
    onNavItemClick(tree, info) {
        const node = info.node;
        // 实现点击父节点时，自动选择第一个子节点
        if (!node.isLeaf() && node.childNodes.length > 0) { // 有子节点
            const selected = tree.getSelection();
            if (!selected || selected.parentNode !== node) { // 如果当前已选节点不是该父节点的子节点
                //展开节点
                if(node.isExpanded()){
                    node.collapse();
                }else{
                    node.expand(); 
                }
                //tree.setSelection(node.childNodes[0]); // 选中第一个子节点
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
        debugger
        if (node) {
            //RouteFloated.hideAll();
            ComUtils.redirectTo(node.get('id'));
        }
    }
});