Ext.define('Common.util.AvatarHelper',{
    singleton:true,
    alternateClassName:'AvatarHelper',
    requires:[
        'Util.util.Utils'
    ],
    /**
     * 组装 头像 url
     * @param {String} userId
     */
    getAvatarUrl(userId) {
        if (Ext.isEmpty(userId)) {
            userId = User.getUserID();
        }

        if (!Ext.isEmpty(userId)) {
            return Utils.joinPath(Config.httpUrl, `Doc/Avatar.ashx?UserID=${userId}`);
        }

        return '';
    }
})