Ext.define('Util.util.Config',{
    alternateClassName:'Config',
    singleton:true,
    isDev: Ext.manifest.env === 'development',
    httpUrl:this.isDev?'/':'/'
})