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
                debugger
                if(!data.u) return '';
                return `${AvatarHelper.getAvatarUrl(data.u.get('UserID'))}&_dc=${data.u.AvatarHash}`;
            }
        }
    }
});
