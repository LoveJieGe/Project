Ext.define('Common.view.mixin.ViewCache', {
    alternateClassName: 'ViewCache',
    extend: 'Ext.Mixin',

    mixinConfig: {
        id: 'viewCache'
    },

    /**
     * @property {Number} 缓存的界面实例个数
     */
    // viewCacheNum: 2,

    ensureViewCachePropetry() {
        const me = this;
        if (!me.viewCache) me.viewCache = {};
        if (!me.hiddenCacheKeys) me.hiddenCacheKeys = [];
    },

    /**
     * 把界面实例 加入缓存
     * @param {String} key
     * @param {Ext.Container} view
     */
    addToViewCache(key, view) {
        const me = this;
        me.ensureViewCachePropetry();

        const arr = me.hiddenCacheKeys;
        if (Ext.isString(key) && !Ext.isEmpty(key) && view && view.isComponent) {
            if (key in me.viewCache) {
                throw new Error(`${me.$className}.viewCache 里已经存在 key 为 ${key} 的实例了`);
            }
            me.viewCache[key] = view;
            if (view.getHidden()) {
                arr.push(key);
                me.constraintHiddenCacheCount();
            }
            view.onAfter({
                hide() {
                    arr.push(key);
                    me.constraintHiddenCacheCount();
                },
                show() {
                    Ext.Array.remove(arr, key);
                },
                destroy() {
                    delete me.viewCache[key];
                    Ext.Array.remove(arr, key);
                },
                priority: -2000
            });
        }
    },

    /**
     * 根据 key 从缓存中获取界面实例
     * @param {String} key
     */
    getFromViewCache(key) {
        const me = this;
        me.ensureViewCachePropetry();

        return me.viewCache[key];
    },

    /**
     * 限制隐藏的界面实例个数
     */
    constraintHiddenCacheCount() {
        const me = this,
            arr = me.hiddenCacheKeys;
        while (arr.length > (me.viewCacheNum || 2)) {
            const key = arr.shift(),
                cmp = me.viewCache[key];
            if (cmp && !cmp.isDestroyed) {
                cmp.destroy();
            }
        }
    },

    /**
     * 销毁所有缓存的界面实例
     */
    destroyAllViewCache() {
        const me = this;
        if (!me.viewCache) return;
        let key, cmp;
        for (key in me.viewCache) {
            cmp = me.viewCache[key];
            if (cmp && !cmp.isDestroyed) {
                cmp.destroy();
            }
        }
    }
});