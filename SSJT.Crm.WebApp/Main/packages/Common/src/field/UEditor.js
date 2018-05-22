Ext.define('Common.field.UEditor', {
    extend:'Ext.field.Text',
    requires:[
        'Common.util.ResourceManager'
    ],
    xtype:'com_ueditor',
    config:{
        resizable:{
            edges:'e s'
        },
        ue:{
            lazy:true,
            $value:true
        }
    },
    clearable:false,

    afterRender(){
        const me = this;
        me.callParent(arguments);

        const input = me.inputElement,
            pNode = input.dom.parentNode,
            bundleId = 'ueditorbundle';
        pNode.style.setProperty('width','100%');

    }
});