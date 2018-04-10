Ext.define('SSJT.view.person.ShowWeather',{
    extend:'Ext.Panel',
    xtype:'personshowweather',
    cls:'person-weather',
    tpl:[
        '<div>',
            '<div class="ctop clearfix">',
                '<div class="city fl">{Province}<span>></span>{City} 天气</div>',
                '<div class="time fr">{LastModifyDate:date("G:i")}更新<span>|</span>数据来源 中央气象台</div>',
            '</div>',
            '<div class="weatcher">',
                '<div class="weather-desc {[this.getCls(values.WeatherDesc1)]}">',
                    '<h3>{LastModifyDate:date("d")}日(今天)</h3>',
                    `<big style="background-image:url(${Ext.resolveResource('<shared>images/weather/')}{ImageFrom1})"></big>`,
                    `<big style="background-image:url(${Ext.resolveResource('<shared>images/weather/')}{ImageTo1})"></big>`,
                    '<span>{WeatherDesc1}</span>',
                    '<span>{TempC1}</span>',
                    '<span>{Wind1}</span>',
                '</div>',
                    '<div class="weather-desc {[this.getCls(values.WeatherDesc2)]}">',
                    '<h3>{[Ext.util.Format.date(ComUtils.addDate(values.LastModifyDate,1),"d")]}日(明天)</h3>',
                    `<big style="background-image:url(${Ext.resolveResource('<shared>images/weather/')}{ImageFrom2})"></big>`,
                    `<big style="background-image:url(${Ext.resolveResource('<shared>images/weather/')}{ImageTo2})"></big>`,
                    '<span>{WeatherDesc2}</span>',
                    '<span>{TempC2}</span>',
                    '<span>{Wind2}</span>',
                '</div>',
                '<div class="weather-desc {[this.getCls(values.WeatherDesc3)]}">',
                    '<h3>{[Ext.util.Format.date(ComUtils.addDate(values.LastModifyDate,2),"d")]}日(后天)</h3>',
                    `<big style="background-image:url(${Ext.resolveResource('<shared>images/weather/')}{ImageFrom3})"></big>`,
                    `<big style="background-image:url(${Ext.resolveResource('<shared>images/weather/')}{ImageTo3})"></big>`,
                    '<span>{WeatherDesc3}</span>',
                    '<span>{TempC3}</span>',
                    '<span>{Wind3}</span>',
                '</div>',
            '</div>',
        '</div>',
        {
            getCls(desc){
                if(Ext.isEmpty(desc))return '';
                if(desc.indexOf('晴')===0)return 'sunny-day';
                if(desc.indexOf('多云')===0)return 'partly-cloudy-day';
                if(/^雷|阵雨|阴/.test)return 'cloudy-day';
                return '';
            }
        }
    ],
    
});