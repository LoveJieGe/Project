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
    loadUEEditor(success,error){
        const bundleId = 'test';
        if (!RM.isDefined(bundleId)) {
            const path = 'http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js';
           var arr=[path];
            RM.load(arr, bundleId, {
                async: false
            });
        }
        RM.ready(bundleId, {
            success(_result) {
                if (remote_ip_info.ret == '1') {  
                    success(remote_ip_info);
                    //$("#cityName").html(cityName);
                }  
            },
            error(_result) {
                if(error) {
                    error(_result);
                }
            }
        });
    }
})