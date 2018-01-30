Ext.define('SSJT.store.main.Menu', {
    extend: 'Ext.data.TreeStore',

    alias: 'store.mainmenu',

    fields: [{
        name: 'text'
    }],

    constructor(config) {
        config = config || {};

        config.root = {
            expanded: true,
            children: [{
                text: '任务',
                iconCls: 'x-fa fa-list-ul',
                expanded: false,
                selectable: false,
                children: [{
                    text: '我的任务',
                    id: 'tasks/mine',
                    leaf: true
                }, {
                    text: '关注的任务',
                    id: 'tasks/followed',
                    leaf: true
                }, {
                    text: '共享给我的任务',
                    id: 'tasks/shared',
                    leaf: true
                }/*, {
                    text: '创建的任务',
                    id: 'tasks/created',
                    leaf: true
                }*/, {
                    text: '已完成的任务',
                    id: 'tasks/completed',
                    leaf: true
                }, {
                    text: '全部任务',
                    id: 'tasks/all',
                    leaf: true
                }]
            }, {
                text: '任务评论',
                id: 'tasks/msgbox',
                iconCls: 'x-fa fa-commenting-o',
                leaf: true
            }, {
                text: '任务统计',
                iconCls: 'x-fa fa-bar-chart',
                expanded: false,
                selectable: false,
                children: [{
                    text: '我的任务统计',
                    id: 'tasks/report/mychart',
                    leaf: true
                }, {
                    text: '团队任务统计',
                    id: 'tasks/report/teamchart',
                    leaf: true
                }, {

                    text: '任务完成情况',
                    id: 'tasks/report/complete', //'completereport',
                    leaf: true
                }]
            }, {
                text: '回收站',
                id: 'tasks/recycle',
                iconCls: 'x-fa fa-trash',
                leaf: true
            }]
        };

        this.callParent([
            config
        ]);
    }
});