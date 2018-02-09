Ext.define('SSJT.view.person.PersonShowDetails', {
    extend: 'Ext.Panel',
    xtype: 'personshowdetails',

    cls: 'person-details',
    title: '详细信息',

    bind: {
        record: '{record}'
    },

    tpl: [
        '<div class="block-section">',
            '<div class="item">',
                '<div class="label">用户名</div>',
                //'<div class="value">{username}</div>',
            '</div>',
            '<tpl if="phone">',
                '<div class="item">',
                    '<div class="label">电话</div>',
                    //'<div class="value">{phone}</div>',
                '</div>',
            '</tpl>',
        '</div>',
        '<div class="block-section">',
            '<div class="item">',
                '<div class="label">邮箱</div>',
                //'<div class="value">{email}</div>',
            '</div>',
            '<tpl if="skype">',
                '<div class="item">',
                    '<div class="label">网络电话</div>',
                    //'<div class="value">{skype}</div>',
                '</div>',
            '</tpl>',
            '<tpl if="linkedin">',
                '<div class="item">',
                    '<div class="label">LinkedIn</div>',
                    //'<div class="value">{linkedin}</div>',
                '</div>',
            '</tpl>',
        '</div>',
        '<div class="block-section">',
            '<div class="item">',
                '<div class="label">生日</div>',
                //'<div class="value">{birthday:date("F jS, Y")}</div>',
                //'<div class="extra">{birthday:dateDiff(new Date())}</div>',
            '</div>',
        '</div>'
    ]
});
