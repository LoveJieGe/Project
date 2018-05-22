Ext.define('SSJT.view.utils.Helper', {
    alternateClassName:'CrmHelper',
    requires:['Common.util.ResourceManager'],
    singleton:true,
    mixins:[
        'ViewCache'
    ],
    getEditView(xtype, config) {
        const me = this,
            key = `Crm_${xtype}`;
        let view = me.getFromViewCache(key);
        if(!view) {
            view = Ext.create({
                xtype:xtype
            }, config);
            me.addToViewCache(view);
        }

        return view;
    },
    loadUEEditor(success, error) {
        const bundleId = 'test';
        if (!RM.isDefined(bundleId)) {
            const path = 'http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js';
           var arr = [path];
            RM.load(arr, bundleId, {
                async: false
            });
        }
        RM.ready(bundleId, {
            success(_result) {
            },
            error(_result) {
                if(error) {
                    error(_result);
                }
            }
        });
    },
    loadExceljs(success, error) {
        const bundleId = 'exceljs';
        if (!RM.isDefined(bundleId)) {
            const path = Ext.getResourcePath('libs/xlsx/lib', 'shared', null),
                ver = Ext.manifest.version;
            if (!RM.isDefined(bundleId)) {
                RM.load(`${path}/exceljs.browser.js?v=${ver}`, bundleId);
            }
        }
        RM.ready(bundleId, {
            success(_result) {
                if(success) {
                    success(_result);
                }
            },
            error(_result) {
                if(error) {
                    error(_result);
                }
            }
        });
    }
});