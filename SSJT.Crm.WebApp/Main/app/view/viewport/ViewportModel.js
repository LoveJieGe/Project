Ext.define('SSJT.view.viewport.ViewportModel', {
    extend: 'Ext.app.ViewModel',
    alias: 'viewmodel.viewport',

    data: {
        user: null
    },

    formulas: {
        userAvatar: {
            bind: {
                u: '{user}'
            },
            get (data) {
                if(!data.u) return '';
                return `${AvatarHelper.getAvatarUrl(data.u.get('UserID'))}&_dc=${new Date().getTime()}`;
            }
        }
    }
});
