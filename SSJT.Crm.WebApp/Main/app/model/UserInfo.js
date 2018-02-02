Ext.define('SSJT.model.UserInfo',{
    extend:'SSJT.model.Base',

    fields: [
        {name:'userid',type:'string'},
        { name: 'username', type: 'string' },
        {name:'avatar',type:'string'},
        { name: 'expires', type: 'date' }
    ],
    isValid: function() {
        return !Ext.isEmpty(this.get('userid'))
            && this.get('expires') > new Date();
    }
   
})