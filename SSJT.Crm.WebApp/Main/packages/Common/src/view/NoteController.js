Ext.define('Common.view.NoteController',{
    extend:'Ext.app.ViewController',
    alias:'controller.note',
    init(){
        var me = this,
            viewModel = me.getViewModel();
        me.callParent(arguments);
    },
    onHideNote(){
        var me = this,
            view = me.getView();
        ComUtils.confirm(view.actionMsg,function(){
            if(view.action){
                let action = Ext.util.Format.lowercase(view.action);
                if(action=='add'){
                    view.destroy();
                }
            }
        })
    },
    onMenuItemTap(m,e){
        const me = this,
            iconCls = m&&m.getIconCls(),
            menu = me.lookup('prioritymenu');
        menu.setIconCls(iconCls);
    },
    onColorTap(btn,e,opt){
        const me = this,
            view = me.getView(),
            color = btn.el.getStyle('background-color');
            toolRgba = me.setRgba(color,0.9),
            textRgba = me.setRgba(color,0.6),
            header = view.getHeader(),
            bottom = me.lookup('bottomTool'),
            textarea = me.lookup('textarea'),
            btn = me.lookup('btnsave');
        btn.el.setStyle('background-color',color);
        header.el.setStyle('background-color',toolRgba);
        bottom.el.setStyle('background-color',toolRgba);
        textarea.el.setStyle('background-color',textRgba);
    },
    setRgba(rgba,alpha){
        rgba = rgba&&rgba.match(/(\d(\.\d+)?)+/g);
        if(rgba&&rgba.length==4){
            rgba[3] = alpha;
            return 'rgba('+rgba.join(',')+')';
        }else if(rgba&&rgba.length==3){
            rgba.push(alpha);
            return 'rgba('+rgba.join(',')+')';
        }
    },
    onBtnSave(){

    }
})