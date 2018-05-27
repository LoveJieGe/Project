Ext.define('SSJT.view.mine.information.NewsEditController', {
    extend:'Ext.app.ViewController',
    alias:'controller.info_news_edit',
    onCancle() {
        const me = this,
            view = me.getView();
        if(view.isVisible(true)) {
            view.hide();
        }
    },
    onOk() {

    }
});