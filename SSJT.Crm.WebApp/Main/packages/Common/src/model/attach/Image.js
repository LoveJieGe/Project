/**
 * 图片 Model
 */
Ext.define('Common.model.attach.Image', {
    extend: 'Ext.data.Model',
    idProperty: 'FileID',
    fields: [
        'FileID', // client file id

        'ID', // EmbedID
        'FileName',
        'Size',

        'ThumbID', // EmbedID
        'ThumbName',
        'ThumbSize'
    ]
});