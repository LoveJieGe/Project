Ext.define('SSJT.model.UserInfo',{
    extend:'SSJT.model.Base',

    fields: [
        {name:'UserID',type:'string'},
        { name: 'UserName', type: 'string' },
        {name:'Avatar',type:'string'},
        { name: 'Expires', type: 'date',convert:function(v,rec){
            if(v&&Ext.isString(v))
                v = Ext.Date.parse(v,'Y-m-d H:i:s',true);
            return v;
        } }
    ],
    isValid: function() {
        return !Ext.isEmpty(this.get('userid'))
            && this.get('expires') > new Date();
    }
   
})