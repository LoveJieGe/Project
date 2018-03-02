Ext.define('SSJT.view.person.PersonShowModel', {
    extend: 'Ext.app.ViewModel',
    alias: 'viewmodel.personshow',
    data:{
        time:new Date(),
        user:null
    },
    formulas:{
        userAvatar: {
            bind: {
                u: '{user}'
            },
            get (data) {
                if(!data.u) return '';
                return `${AvatarHelper.getAvatarUrl(data.u.get('UserID'))}&_dc=${data.u.get('AvatarHash')}`;
            }
        }
    }
});