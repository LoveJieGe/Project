Ext.define('SSJT.view.utils.Helper',{
    alternateClassName:'CrmHelper',
    singleton:true,
    mixins:[
        'ViewCache'
    ],
    getEditView(xtype,config) {
        const me = this,
            key = `Crm_${xtype}`;
        let view = me.getFromViewCache(key);
        if(!view){
            view = Ext.create({
                xtype:xtype
            },config);
            me.addToViewCache(view);
        }

        return view;
    },
    loadUEEditor(callback){
        const bundleId = 'ueeditor';
        if (!RM.isDefined(bundleId)) {
            const path = Ext.getResourcePath('libs/cropper/', 'shared', null),
                isDev = Ext.manifest.env == 'development',
                ver = Ext.manifest.version,
                arr = isDev ? [
                    `${path}jquery-1.10.2.js?v=${ver}`,
                    `${path}cropper.js?v=${ver}`,
                    `${path}cropper.css?v=${ver}`
                ] : [
                    `${path}jquery-1.10.2.min.js?v=${ver}`,
                    `${path}cropper.min.js?v=${ver}`,
                    `${path}cropper.min.css?v=${ver}`
                ];
            RM.load(arr, bundleId, {
                async: false
            });
        }
        RM.ready(bundleId, {
            success() {
                if(callback)
                    callback();
            }
        });
    }
})