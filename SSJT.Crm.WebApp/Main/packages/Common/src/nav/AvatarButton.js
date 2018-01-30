/**
 * 导航树下的头像按钮
 */
Ext.define('Common.nav.AvatarButton', {
    extend: 'Ext.Button',
    xtype: 'navavatarbutton',

    ui: 'large flat nav avatar',
    iconCls: 'avatar',
    textAlign: 'left',
    bind: {
        icon: '{userAvatar}',
        text: '<div class="title">{user.UserName}</div>' +
            '<div class="value">{user.UserID}</div>'
    },
    hidden: true,

    onTap() {
        const me = this;
        me.callParent(arguments);

        Utils.confirm('确定要注销吗?', () => {
            Utils.getApp().fireEvent('logout');
        });
    }
});