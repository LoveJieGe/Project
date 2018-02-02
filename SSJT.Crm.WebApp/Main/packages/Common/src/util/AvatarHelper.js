Ext.define('Common.util.AvatarHelper',{
    singleton:true,
    alternateClassName:'AvatarHelper',
    requires:[
        'Common.util.Utils'
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
            return ComUtils.joinPath(ComConfig.httpUrl, `Doc/Avatar.ashx?UserID=${userId}`);
        }

        return '';
    }
})