Ext.define('Common.model.ColorInformation',{
    extend:'Ext.data.Model',
    alias:'model.colorInformation',
    fields:[
        'ColumnName',
        'Value',
        'Expression',
        'OrderID',
        /**
         * Condition:1代表ColumnName的值=value
         * 2:代表ColumnName的值!=value
         * 3:代表ColumnName的值>value
         * 4代表ColumnName的值<value
         * 5代表ColumnName的值>=value
         * 6代表ColumnName的值<=value
         * 7代表要使用Expression表达式
         */
        {
            name:'Condition',
            type:'int',
            defaultValue:1
        },
        {
            name:'ApplyToRow',
            type:'boolean',
            defaultValue:true
        },
        'FontFamily',
        {
            name:'FontSize',
            type:'int',
            defaultValue:9
        },
        {
            name:'FontColor',
            type:'string',
            convert:function(v,rec){
                if(Ext.isEmpty(v)){
                    return '';
                }
                let color = Ext.util.Color.create(v);
                if(color&&!Ext.Object.isEmpty(color)){
                    return color.toHex();
                }else{
                    return v;
                }
            }
        },
        {
            name:'FontBold',
            type:'boolean',
            defaultValue:false
        },
        {
            name:'FontItalic',
            type:'boolean',
            defaultValue:false
        },
        {
            name:'BackColor',
            type:'string',
            convert:function(v,rec){
                if(Ext.isEmpty(v)){
                    return '';
                }
                let color = Ext.util.Color.create(v);
                if(color&&!Ext.Object.isEmpty(color)){
                    return color.toHex();
                }else{
                    return v;
                }
            }
        },
    ]
})