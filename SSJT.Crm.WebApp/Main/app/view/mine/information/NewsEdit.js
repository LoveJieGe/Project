Ext.define('SSJT.view.mine.information.NewsEdit',{
    extend:'Common.view.Dialog',
    requires:[
        'Common.field.UEditor'
    ],
    width:700,
    height:500,
    xtype:'info_news_edit',
    controller:'info_news_edit',
    title:'添加新闻',
    buttonAlign:'right',
    buttons: [{
        text: '确定',
        ui: 'action',
        //docked:'right',
        handler: 'onOk'
    }, {
        text: '取消',
        ui: 'flat',
        //docked:'right',
        handler: 'onCancle'
    }],
    items:[{
            xtype:'container',
            layout:'hbox',
            padding:'5 5 0 5',
            items:[{
                xtype:'fieldcontainer',
                items:[{
                    xtype:'textfield',
                    name:'NewsTitle',
                    label:'新闻标题',
                    required:true,
                    labelTextAlign :'right'
                },{
                    xtype:'textfield',
                    label:'部门',
                    labelTextAlign :'right'
                }]
            }]
        },{
            xtype:'com_ueditor',
            name:'NewsContent',
            ue:{
                initialFrameHeight:270,
                toolbars: [
                    ['source', 'undo', 'redo', 
                        '|','fontfamily','fontsize','bold','italic','underline', 'strikethrough',
                        '|','forecolor','backcolor','insertorderedlist','insertunorderedlist',
                        '|','indent','justifyleft','justifycenter','justifyright','justifyjustify',
                        //'simpleupload',
                        '|','simpleupload','insertimage','emotion','template','background',
                        '|','inserttable','deletetable','selectall', 'cleardoc','preview'
                    ]
                ],
            },
            flex:1
        }]
})