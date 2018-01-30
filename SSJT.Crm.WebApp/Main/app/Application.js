/**
 * The main application class. An instance of this class is created by app.js when it
 * calls Ext.application(). This is the ideal place to handle application launch and
 * initialization details.
 */
Ext.define('SSJT.Application', {
    extend: 'Ext.app.Application',
    name: 'SSJT',
    requires: [
        // This will automatically load all classes in the SSJT namespace
        // so that application classes do not need to require each other.
        'SSJT.*',
        'Util.*',
        'Common.*'
    ],
    quickTips: false,
    platformConfig: {
        desktop: {
            quickTips: true
        }
    },
    defaultToken:'home',
    viewport:{
        controller:'viewport',
        viewModel: 'viewport'
    },
    launch:function(profile){
        var me = this;
        var dev = Config.isDev;
        Ext.Viewport.getController().onLaunch();
        me.callParent([profile]);
    },
    getClientInfo:function(){
        return null;
    },
    onAppUpdate: function () {
        Ext.Msg.confirm('Application Update', 'This application has an update, reload?',
            function (choice) {
                if (choice === 'yes') {
                    window.location.reload();
                }
            }
        );
    }
});
