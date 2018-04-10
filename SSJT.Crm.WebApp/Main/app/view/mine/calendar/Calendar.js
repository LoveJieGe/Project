Ext.define('SSJT.view.mine.calendar.Calendar', {
    extend: 'Ext.Panel',
    xtype: 'mine_work_calendar',
    requires: [ 
        'Ext.calendar.panel.Panel'
    ],
    layout: 'fit',
    items: [{
        xtype: 'calendar',
        defaultView:'day',
        createButtonPosition:'titleBar',
        views: {
            day: {
                startTime: 6,
                endTime: 22
            },
            workweek: {
                xtype: 'calendar-week',
                //titleTpl: '{start:date("j M")} - {end:date("j M")}',
                label: 'Work Week',
                weight: 15,
                dayHeaderFormat: 'D d',
                firstDayOfWeek: 1,
                visibleDays: 5
            }
        },
        timezoneOffset: 0,
        store: {
            autoLoad: true,
            proxy: {
                type: 'ajax',
                api:''
            }
        }
    }]
});