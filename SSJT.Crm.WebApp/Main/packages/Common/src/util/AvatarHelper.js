Ext.define('Common.util.AvatarHelper',{
    singleton:true,
    alternateClassName:'AvatarHelper',
    requires:[
        'Common.util.Utils'
    ],
    mixins: ['ViewCache'], // 管理/缓存 界面实例
    // 1×1像素透明图片base64
    onePxImg: 'data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7',
    /**
     * 组装 头像 url
     * @param {String} userId
     */
    getAvatarUrl(userId) {
        if (Ext.isEmpty(userId)) {
            userId = User.getUserID();
        }

        if (!Ext.isEmpty(userId)) {
            return ComUtils.joinPath(ComConfig.httpUrl, `Doc/AvatarHandler.ashx?UserID=${ComUtils.string2Hex(userId)}`);
        }

        return '';
    },
    /**
     * 组装头像 html
     * @param {Object} option 可选项: id用户编号字段(默认UserID), name用户名称字段(默认UserName), title鼠标悬停提示, cls其他class样式类
     * @return {String}
     */
    getAvatarHtml(option) {
        option = option || {};

        const id = option.id || 'UserID',
            name = option.name || 'UserName',
            cls = option.cls || '',
            title = option.title || '',
            titleAttr = Ext.isEmpty(title) ? '' : ` title="${title}"`;

        return [
            `<a class="avatar link-avatar firstletter ${cls}"  style="{[AvatarHelper.getColorStyle(values.${name})]}" ${titleAttr}>`,
                `<img src="{[AvatarHelper.onePxImg]}" onload="AvatarHelper.load(this)" style="display:none" data-user="{${id}}" />`,
            '</a>'
        ].join('');
    },
     /**
     * 加载头像
     * @param {HTMLElement} node <img>节点
     */
    load: function (node) {
        if (!node || !node.parentNode || !node.parentNode.parentNode) return;

        var userId = node.getAttribute('data-user');
        if (Ext.isEmpty(userId)) return;
        if (userId == 'System') {
            node.parentNode.className += ' system';
        }

        node.removeAttribute('onload');

        if (Ext.browser.is.Cordova) {
            // var nodeId = Ext.id(node);
            // this.doTsk(nodeId, userId);
        } else {
            var url = this.getAvatarUrl(userId),
                imgLoaded,
                imgError;

            imgLoaded = function (e) {
                e.target.parentNode.className += ' loaded';
                e.target.style.removeProperty('display');
                e.target.removeEventListener('load', imgLoaded, false);
                e.target.removeEventListener('error', imgError, false);
            };
            imgError = function (e) {
                e.target.parentNode.removeChild(e.target);
                e.target.removeEventListener('load', imgLoaded, false);
                e.target.removeEventListener('error', imgError, false);
            };

            node.addEventListener('load', imgLoaded, false);
            node.addEventListener('error', imgError, false);
            node.src = url;
        }
    },
    /**
     * 计算名字唯一色
     * @param {String} name 名字
     * @return {String} 颜色
     */
    getUniqueColor(name) {
        if (Ext.isEmpty(name)) return 'transparent';

        var hex = (Math.abs(ComUtils.hashCode(name)) % 0xcccccc).toString(16),
            color = `#${Ext.String.leftPad(hex, 6, '0')}`;

        return color;
    },

    /**
     * 计算名字唯一颜色样式
     * @param {String} name 名字
     * @return {String} 颜色样式
     */
    getColorStyle(name) {
        const color = this.getUniqueColor(name);

        return `background-color:${color};`;
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