Ext.define('SSJT.view.mine.information.ContainerControoler', {
    extend:'Ext.app.ViewController',
    alias:'controller.info_container',
    onCreate() {
        const newsEdit = CrmHelper.getEditView('info_news_edit');
        if(newsEdit.getHidden()) {
            newsEdit.show();
        }
    }
})