Ext.define('SSJT.model.Person', {
    extend: 'SSJT.model.Base',
    fields: [
        'UserID',
        'UserName', 
        {
            name:'Birthday',
            type:'date',
            dateFormat:'Y-m-d'
        },
        'Email',    
        'Address',
        'Sex',
        'Tel',
        'Remarks',
        'Education',
        'Levels',
        'Professional',
        'Dname',
        'ZhiWu',
        'Post',
        {
            name:'CustomID',
            calculate:function(data){
                return ComUtils.string2Hex(data.UserID);
            }
        },
        'AvatarName',
        {
            name:'AvatarHash',
            calculate:function(data){
                return ComUtils.hashCode(data.AvatarName);
            }
        },
        {
            name:'AvatarUrl',
            calculate:function(data){
                return AvatarHelper.getAvatarUrl(data.UserID);
            }
        }
    ],
    statics: {
        /**
         * The server people.list() API treats differently a request containing a specific id,
         * in which case it will lookup for the id (GUID), username and email. That means the
         * returned id may be different from the requested one. Since the static Model.load()
         * method perfoms a check on the returned id, we need first to create a phantom record,
         * then request the server with the desired id.
         */
        load: function(id, options, session) {
            var record = Ext.create('SSJT.model.Person');
            record.setSession(session),
            id = ComUtils.hex2String(id);
            record.load(
                Ext.apply({ params: { data: Ext.encode({UserID:id}) } }, options)
            );
        }
    },
    proxy: {
        type: 'ajax',
        api : 'userRequest/IStoreServer/QueryPerson',
    },
});
