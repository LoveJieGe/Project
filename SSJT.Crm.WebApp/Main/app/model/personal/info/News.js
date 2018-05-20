Ext.define('SSJT.model.personal.info.News',{
    extend:'SSJT.model.Base',
    fields:[
        {
            name:'NewsId',
            type:'int'
        },
        'NewsTitle',
        'NewsContent',
        'CreatorName',
        'DepName',
        {
            name:'NewsTime',
            type:'date',
            dateFormat:'Y-m-d H:i:s'
        },
        'IsDelete',
        {
            name:'DeleteTime',
            type:'date',
            dateFormat:'Y-m-d H:i:s'
        },
        {
            name:'CustomID',
            calculate:function(data){
                return ComUtils.string2Hex(data.NewsId);
            }
        }
    ]
})