Ext.define('SSJT.model.Base', {
    extend: 'Ext.data.Model',
    fields: [{ // Calculated fields
        // https://docs.sencha.com/extjs/latest/modern/Ext.data.field.Field.html#cfg-calculate
        name: 'url', 
        calculate: function (data) {
            debugger;
            return Ext.String.format('{0:lowercase}/{1}',
                this.owner.entityName,
                data.id);
        }
    }],
    schema: {
        namespace: 'SSJT.model'
    },
    toUrl: function() {
        return this.get('url');
    },

    toEditUrl: function() {
        return this.toUrl() + '/edit';
    }
});
