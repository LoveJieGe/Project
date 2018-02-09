Ext.define('Common.util.Config',{
    alternateClassName:'ComConfig',
    singleton:true,
    isDev: Ext.manifest.env === 'development',
    httpUrl:this.isDev?'/':'/',
    showNavigation:true
})