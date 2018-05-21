Ext.define('Common.view.NoteController',{
    extend:'Ext.app.ViewController',
    alias:'controller.note',
    onBeforeShow(sender, e){
        const me = this,
            vm = sender.getViewModel(),
            record = vm.get('record');
        if(record){
            if(record.get('LocationX')>0)
                sender.setX(record.get('LocationX'));
            if(record.get('LocationY')>0)
                sender.setY(record.get('LocationY'));
        }
    },
    onHideNote(){
        var me = this,
            view = me.getView(),
            vm = view.getViewModel(),
            type = Ext.util.Format.lowercase(vm.get('statusType'));
        if(type=='view'){
            view.hide();
        }else if(type=='add'){
            view.close();
        }else if(type=='edit'){
            ComUtils.confirm('确定放弃更改隐藏便签?',function(){
                view.hide();
            })
        }
    },
    onEditNote(btn,e,opt){
        var me = this
            vm = me.getViewModel();
        vm.set('statusType','edit');
    },
    onReturn(btn,e,opt){
        var me = this;
        ComUtils.confirm('确定放弃更改返回浏览?',function(){
            let vm = me.getViewModel(),
                view = me.getView(),
                record = vm.get('record');
            if(record){
                for(let key in record.modified)
                {
                    record.set(`${key}`,record.modified[key])
                }
            }
            vm.set('statusType','view');
        });
    },
    onMenuItemTap(m,e){
        const me = this,
            iconCls = m.getIconCls(),
            vm = me.getViewModel(),
            record = vm.get('record');;
        vm.set('PriorityCls',iconCls);
        record.set('Priority',m.value);
    },
    onColorTap(btn,e,opt){
        const me = this,
            view = me.getView(),
            color = btn.el.getStyle('background-color');
            vm = me.getViewModel();
        vm.set('NoteColor',color);
    },
    onBtnSave(btn,e,opt){
        debugger
        const me = this,
            view = me.getView(),
            vm = me.getViewModel(),
            record = vm.get('record'),
            w = view.getWidth(),
            h = view.getHeight(),
            status = vm.get('statusType');
        record.set('Width',w>0?w:view.getMinWidth());
        record.set('Height',h>0?h:view.getMinHeight());
        record.set('LocationX',view.getX());
        record.set('LocationY',view.getY());
        
        ComUtils.ajax(`ajaxRequest/IPersonalService/${status=='add'?'Insert':'Update'}Data`,{
            data:{
                p0:record.data
            },
            success(r){
                ComUtils.getApp().fireEvent(`personal${status=='add'?'Add':'Update'}`,r);
                if(status=='edit'){
                    let note_model = Ext.create('SSJT.model.PersonalNote',r);
                    view.setRecord(note_model);
                    vm.set('statusType','view');
                }else{
                    view.close();
                }
            },
            maskTarget: view
        })
    },
    onFinishNote(btn,e,opt){
        const me = this,
            view = me.getView(),
            vm = me.getViewModel(),
            record = vm.get('record'),
            noteID = record&&record.get('NoteID');
        ComUtils.ajax('ajaxRequest/IPersonalService/FinishNote',{
            data:{
                NoteID:noteID
            },
            success(r){
                ComUtils.getApp().fireEvent('personalUpdate',r);
                record.set({
                    'IsFinish':r.IsFinish,
                    'FinishDate':r.FinishDate
                });
            },
            maskTarget: view
        })
    }
})