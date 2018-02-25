Ext.define('Common.view.Dialog', {
    extend: 'Ext.Dialog',

    referenceHolder: true,//如果设置为true，那么这个容器将被标记为层次结构中的一个点，在这个层次中，
    //将会保存对具有指定引用配置的项目的引用。如果指定了控制器，容器将自动成为referenceHolder。
    closable: true,
    closeAction: 'hide',

    hidden: true,

    width: 900,
    height: '90vh'
});