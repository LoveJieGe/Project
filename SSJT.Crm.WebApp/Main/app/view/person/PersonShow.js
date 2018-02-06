Ext.define('SSJT.view.person.PersonShow', {
    extend: 'SSJT.view.widgets.Show',
    xtype: 'personshow',
    requires:[
        'SSJT.view.person.PersonShowModel'
    ],
    controller: 'personshow',
    viewModel: {
        type: 'personshow'
    },

    title: 'Profile',

    items: {
        header: {
            xtype: 'personshowheader'
        },

        tools: {
            xtype: 'personshowtools',
            weight: -5
        },

        content: {
            items: {
                left: {
                    items: {
                        details: {
                            xtype: 'personshowdetails'
                        },
                    }
                }
            }
        }
    }
});
