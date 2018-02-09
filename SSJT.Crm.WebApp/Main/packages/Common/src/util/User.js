Ext.define('Common.util.User',{
    alternateClassName:'User',
    singleton:true,
    requires:[
        'Common.util.Utils'
    ],
    config:{
        user:null
    },
    /**
     * { UserID: 1, UserName: '', AvatarHash: '' }
     *
     * @param {Object} user
     */
    updateUser: function (user, oldUser) {
        var me = this;

        // if (!user || !oldUser || user.UserID != oldUser.UserID) {
        //     ComUtils.getApp().fireEvent('userchanged');
        // }
        Ext.Viewport.getViewModel().set('user', user);
    },
    /**
     * 获取当前登录用户的UserID
     *
     * @return {String}
     */
    getUserID() {
        var user = this.getUser();
        if (!user) return null;
        return user.UserID;
    }
});