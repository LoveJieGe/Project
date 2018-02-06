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
        {
            name:'Expires',
            type:'date',
            dateFormat:'Y-m-d H:i'
        },{
            name:'CustomID',
            calculate:function(data){
                return data.UserID;
            }
        }
    ],
    isValid: function() {
        return !Ext.isEmpty(this.get('UserID'))
            && this.get('Expires') > new Date();
    },
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
            record.load(
                Ext.apply({ params: { id: id } }, options)
            );
        }
    },

});
