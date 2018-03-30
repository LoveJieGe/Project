Ext.define('SSJT.view.widgets.EditHeader',{
    extend:'Common.view.Dialog',
    xtype:'editheader',
    requires:[
        'Common.model.attach.Image'
    ],
    controller:{
        type:'editheader'
    },
    width:'auto',
    height:'auto',
    viewModel:{
        data:{
            user:null
        }
    },
    cls:'edit-avatar',
    items:[{
        xtype:'toolbar',
        defaultButtonUI: 'action',
        docked: 'top',
        cls:'top-bar',
        defaults:{
            xtype:'button',
            border: false,
        },
        items:[{
            itemId: 'btnBrowse',
            //text: '选择图片',
            //tooltip: '图片',
            iconCls: 'i-common-image',
            handler:'onTapBtnBrowse',
            //preventDefaultAction: false
        },{
            text: '4x3',
            value:'1.3333333333333333',
            handler:'onChangePixel',
        },{
            text: '1x1',
            value:'1',
            handler:'onChangePixel',
        }],
    },{
        xtype: 'container',
        reference:'img-container',
        style:{
            height:'100%',
        },
        html:'<div class="img-container">\
                <img />\
            </div>\
            <div class="docs-preview clearfix">\
                <div class="img-preview preview-lg"></div>\
                <div class="img-preview preview-md"></div>\
                <div class="img-preview preview-sm"></div>\
            </div>'
    },{
        xtype:'toolbar',
        defaultButtonUI: 'action',
        docked: 'bottom',
        defaults:{
            xtype:'button',
            border: false,
            docked: 'right',
            margin:'0 10 10 10',
            padding:'0 10 0 10'
        },
        items:[{
            text:'保存',
            handler:'onTapSave'
        },{
            text : '取消',
            handler:'onTapCancle',
        }]
    }],
    listeners:{
        show:'onShow'
    }
})