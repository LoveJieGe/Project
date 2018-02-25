Ext.define('SSJT.view.widgets.EditHeader',{
    extend:'Common.view.Dialog',
    xtype:'editheader',
    requires:[
        'Common.model.attach.Image'
    ],
    controller:{
        type:'editheader'
    },
    width:720,
    height:425,
    data:{
        store: {
            model: 'Common.model.attach.Image'
        }
    },
    items:[{
        xtype: 'button',
        itemId: 'btnBrowse',
        border: false,
        text: '选择图片',
        ui: 'action',
        //tooltip: '图片',
        iconCls: 'i-common-image',
        handler:'onTapBtnBrowse',
        preventDefaultAction: false
    },{
        xtype: 'filefield',
        reference:'file',
        name: 'photo',
        accept: 'image',
        displayed:false,
    }]
})