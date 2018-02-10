Ext.define('SSJT.view.widgets.ShowHeader', {
    extend: 'Ext.Container',
    xtype: 'showheader',

    cls: 'show-header',
    weighted: true,

    /**
    * align控制容器的子条目是如何对齐的。此属性的可接受配置值为:
    *  start :子项在容器的左侧被包装在一起。
    * center :子项在容器的中等宽度包装。
    * end :子项在容器的右侧包装。
    * stretch :子项垂直拉伸以填充容器的高度。
     */
    layout: {
        type: 'hbox',
        align: 'stretch'
    },

    items: {
        title: {
            xtype: 'component',
            userCls: 'header-title',
            flex: 1,
            bind: {
                record: '{record}'
            }
        },

        edit: {
            xtype: 'button',
            iconCls: 'x-fa fa-pencil',
            handler: 'onEditTap',
            text: '编辑',
            weight: 10,
            ui: 'flat',

            platformConfig: {
                phone: {
                    hidden: true
                }
            }
        }
    }
});
