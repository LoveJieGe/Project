
Ext.define('Common.nav.LogoutButton', {
    extend: 'Ext.Button',
    xtype: 'logoutbutton',

    ui: 'large flat logout',
    textAlign: 'left',
    iconCls: 'x-fa fa-power-off',
    text:'注销',
    weight:20,
    onTap() {
        const me = this;
        me.callParent(arguments);

        ComUtils.confirm('确定要退出系统吗?', () => {
            ComUtils.getApp().fireEvent('logout');
        });
    }
});