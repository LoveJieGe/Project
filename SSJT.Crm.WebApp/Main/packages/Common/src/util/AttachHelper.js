Ext.define('Common.util.AttachHelper', {
    alternateClassName: 'AttachHelper',
   
    singleton: true,
    requires:[
        'Common.util.ResourceManager'
    ],
    waitUploadMsg: '请等待上传组件初始化完毕',

    /**
     * 组装 PDEmb 附件的url
     * @param {String} docId 附件Guid
     * @return {String}
     */
    buildEmbedSrc(docId) {
        return ComUtils.joinPath(Config.httpUrl, `Doc/EmDownFile.ashx?EmbedID=${ComUtils.toHex(docId)}`);
    },

    /**
     * 组装 对象图片 的url
     * @return {String}
     *
     * @param {Number} objType 对象号
     * @param {String} picName 图片名
     * @return {String}
     */
    buildObjPicSrc(objType, picName) {
        return ComUtils.joinPath(Config.httpUrl, `Doc/ObjPicture.ashx?ObjType=${objType}&PicName=${picName}`);
    },
    /**
     * 加载上传组件库 plupload
     * @param {Function} callback
     */
    ensurePlUploadlibs(callback) {
        const bundleId = 'pluploadlibsloaded';
        if (!RM.isDefined(bundleId)) {
            const path = Ext.getResourcePath('libs/plupload/', 'shared', null),
                isDev = Ext.manifest.env == 'development',
                lan = navigator.language || navigator.systemLanguage || navigator.userLanguage,
                ver = Ext.manifest.version,
                arr = isDev ? [
                    `${path}moxie.js?v=${ver}`,
                    `${path}plupload.dev.js?v=${ver}`
                ] : [
                    `${path}plupload.full.min.js?v=${ver}`
                ];
            if (lan == 'zh-CN') {
                arr.push(`${path}i18n/zh_CN.js?v=${ver}`);
            }
            RM.load(arr, bundleId, {
                async: false
            });
        }
        RM.ready(bundleId, {
            success() {
                callback();
            }
        });
    },
    ensureCropperlibs(callback){
        const bundleId = 'cropperlibsloaded';
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
});