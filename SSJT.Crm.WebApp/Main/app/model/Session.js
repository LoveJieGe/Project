Ext.define('SSJT.model.Session', {
    extend: 'Ext.data.Model',

    fields: [
        { name: 'Expires', type: 'date' },
        { name: 'User', reference: 'Personnel' }
    ],

    isValid: function() {
        return this.get('Expires') > new Date()
            && this.getUser() !== null;
    },
});
