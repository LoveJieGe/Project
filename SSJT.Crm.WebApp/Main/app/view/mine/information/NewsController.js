Ext.define('SSJT.view.mine.information.NewsController', {
    extend:'SSJT.view.mine.information.ContainerControoler',
    alias:'contaoller.info_news',
    onCreate(){
        const editView = CrmHelper.getEditView('info_news_edit');
        if(editView.getHidden()){
            editView.show();
        }
    }
});