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
    // store:{
    //     type:'person'
    // },
    title: '个人信息',

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
                },
                // right:{
                //     items:{
                //         weather:{

                //         }
                //     }
                // }
            }
        }
    }
});
