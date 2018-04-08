Ext.define('SSJT.store.person.WeatherInfo',{
    extend:'Ext.data.Store',
    alias:'store.weatherinfo',
    requires:[
        'SSJT.model.WeatherInfo'
    ],
    model:'SSJT.model.WeatherInfo',
    // proxy:{
    //     type:'ajax',
    //     api:'/AjaxHandler/WeatherHandler.ashx',
    // }
})