Ext.define('SSJT.view.widgets.Show', {
    extend: 'Ext.Panel',

    controller: {
        type: 'show'
    },

    viewModel: {
        data: {
            record: null
        }
    },
    /**
     * https://www.sencha.com/blog/using-sencha-ext-config/
     * 在eventedConfig中定义的配置选项将自动生成setter / getter方法
     * (有关自动生成的getter / setter方法的更多信息，请参见配置)
     */
    eventedConfig: {
        record: null
    },

    platformConfig: {
        phone: {
            header: {
                items: {
                    edit: {
                        xtype: 'button',
                        iconCls: 'x-fa fa-pencil',
                        handler: 'onEditTap',
                        weight: 10
                    }
                }
            }
        },

        '!phone': {
            header: {
                hidden: true
            }
        }
    },
    /**
     * 配置选项使此组件可滚动。可接受的值是:
     *  true:可以自动滚动
     *  false(或null):禁用滚动——这是默认值。
     *  x或horizontal :只允许水平滚动。
     *  y or vertical:垂直滚动只允许垂直滚动,
     *  如果需要高级配置,还接受一个Ext.scroll.Scroller的配置对象。
     */
    scrollable: {
        y: 'scroll'
    },
    /**
     * 如果设置为true，则可以将子项目指定为对象，每个属性名称指定一个itemId，并且该属性值是子项目配置对象。
     * 使用此方案时，每个子项目可能包含影响其在此容器中的顺序的权重配置值。 较低的权重是朝着开始，较高的权重到结束。
     */
    weighted: true,

    defaults: {
        userCls: 'page-constrained'
    },

    items: {
        /**
         * 传递为false，以防止创建标题。
         *  您还可以指定一个带有配置对象(可选包含xtype)的头来定制面板的头
         */
        header: {
            xtype: 'showheader',
            weight: -10
        },

        content: {
            weighted: true,
            userCls: [
                'page-constrained',
                'blocks'
            ],
            defaults: {
                userCls: 'blocks-column',
                weighted: true,
                defaults: {
                    ui: 'block'
                }
            },
            items: {
                left: {
                    weighted: true
                },

                right: {
                    weighted: true,
                }
            }
        }
    }
});
