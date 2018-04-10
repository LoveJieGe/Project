Ext.define('SSJT.store.main.ListItem',{
    extend:'Ext.data.TreeStore',
    alias:'store.menu_llistitem',
    fields: [{
        name: 'text',
        type: 'string'
    }],
    config:{
        root:{
            text: 'Groceries',
            children: [{
                text: 'Drinks',
                children: [{
                    text: 'Water',
                    children: [{
                        text: 'Sparkling',
                        leaf: true
                    }, {
                        text: 'Still',
                        leaf: true
                    }]
                }, {
                    text: 'Coffee',
                    leaf: true
                }, {
                    text: 'Espresso',
                    leaf: true
                }, {
                    text: 'Redbull',
                    leaf: true
                }, {
                    text: 'Coke',
                    leaf: true
                }, {
                    text: 'Diet Coke',
                    leaf: true
                }]
            }, {
                text: 'Fruit',
                children: [{
                    text: 'Bananas',
                    leaf: true
                }, {
                    text: 'Lemon',
                    leaf: true
                }]
            }, {
                text: 'Snacks',
                children: [{
                    text: 'Nuts',
                    leaf: true
                }, {
                    text: 'Pretzels',
                    leaf: true
                }, {
                    text: 'Wasabi Peas',
                    leaf: true
                }]
            }, {
                text: '浏览器',
                children: [{
                    text: 'IE',
                    leaf: true
                }, {
                    text: '火狐',
                    leaf: true
                }, {
                    text: '谷歌',
                    leaf: true
                }]
            }]
        }
    }
    //defaultRootProperty: 'children',
})
