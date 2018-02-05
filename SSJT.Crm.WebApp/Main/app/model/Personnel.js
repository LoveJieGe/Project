Ext.define('SSJT.model.Personnel', {
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
    }
});
