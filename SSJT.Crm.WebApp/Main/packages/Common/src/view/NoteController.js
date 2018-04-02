Ext.define('Common.view.NoteController',{
    extend:'Ext.app.ViewController',
    alias:'controller.note',
    onBeforeShow(sender, e){
        debugger
        const vm = sender.getViewModel(),
            record = vm.get('record');
        if(record&&record.isModel){
            let x = record.get('LocationX'),
                y = record.get('LocationY'),
                w = record.get('Width'),
                h = record.get('Height');
            if(x>0)sender.setX(x);
            if(y>0)sender.setY(x);
            if(w>0)sender.setWidth(w);
            if(h>0)sender.setHeight(h);
        }
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
            iconCls = m.getIconCls(),
            vm = me.getViewModel(),
            record = vm.get('record');;
        vm.set('Priority',iconCls);
        record.set('Priority',m.value);
    },
    onColorTap(btn,e,opt){
        const me = this,
            view = me.getView(),
            color = btn.el.getStyle('background-color');
            // toolRgba = view.setRgba(color,0.9),
            // textRgba = view.setRgba(color,0.6),
            vm = me.getViewModel();
        // vm.set('ToolColor',toolRgba);
        // vm.set('TextColor',textRgba);
        vm.set('NoteColor',color);
    },
    onBtnSave(btn,e,opt){
        debugger
        const me = this,
            view = me.getView(),
            vm = me.getViewModel(),
            record = vm.get('record');
        record.set('Width',view.getWidth());
        record.set('Height',view.getHeight());
        record.set('LocationX',view.getX());
        record.set('LocationY',view.getY());
        ComUtils.ajax('ajaxRequest/IPersonalService/InsertData',{
            data:{
                p0:record.data
            },
            success(r){
                ComUtils.getApp().fireEvent('personalAdd',r);
                view.close();
            },
            maskTarget: view
        })
    }
})