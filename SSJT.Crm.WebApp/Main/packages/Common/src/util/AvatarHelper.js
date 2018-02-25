Ext.define('Common.util.AvatarHelper',{
    singleton:true,
    alternateClassName:'AvatarHelper',
    requires:[
        'Common.util.Utils'
    ],
    mixins: ['ViewCache'], // 管理/缓存 界面实例
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
    },
    getAvatarDialog(){
        const me = this,
            key = 'avatarDialog';
        let dialog = me.getFromViewCache(key);
        if (!dialog) {
            dialog = Ext.widget('editheader');
            dialog.on({
                hide: function () {
                    //Ext.Viewport.remove(dialog, false); // 从 dom 树中移除，提高性能
                }
            });
            me.addToViewCache(key, dialog);
        }
        if (dialog.getParent() !== Ext.Viewport) {
            Ext.Viewport.add(dialog);
        }
        return dialog;
    },
    showAvatarDialog(){
        const me = this,
            dialog = me.getAvatarDialog();
        dialog.show();
    }
})