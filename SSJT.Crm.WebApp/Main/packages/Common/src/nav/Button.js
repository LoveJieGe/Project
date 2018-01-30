/**
 * 展开收缩导航树的按钮
 */
Ext.define('Common.nav.Button', {
    extend: 'Ext.Button',
    xtype: 'navbutton',

    ui: 'large flat nav',

    config: {
        collapsed: false
    },

    updateCollapsed(c) {
        this.setIconCls(c ? 'x-fa fa-angle-right' : 'x-fa fa-angle-left');
    }
});