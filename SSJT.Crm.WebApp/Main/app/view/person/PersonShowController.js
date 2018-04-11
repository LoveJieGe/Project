Ext.define('SSJT.view.person.PersonShowController', {
    extend: 'SSJT.view.widgets.ShowController',
    alias: 'controller.personshow',
    init:function(){
        const me = this,
            vm = me.getViewModel();
        let task = {
            run: function() {
                if(vm){
                    let time = vm.get('time'),
                     now = new Date();
                     if(((now-time)/1000/60)>1)
                        vm.set('time',new Date());
                }
            },
            interval: 5000
        };
        Ext.TaskManager.start(task);
        me.loadWeather();
        this.callParent(arguments);
    },
    loadWeather(){
        const me = this,
            view = me.getView(),
            weatherView = view.down('personshowweather')
        ComUtils.loadWeather(function(result){
            ComUtils.ajax('/AjaxHandler/WeatherHandler.ashx',{
                params:{
                    city:result.city
                },
                success(r){
                    //let model = Ext.create(weather.getModel(),r);
                    weatherView&&weatherView.setData(r);
                }
            });
        });
    },
    onRecordChange: function(view, record) {
        const me = this,
            vm = this.getViewModel();
        if(record&&record.isModel&&(record instanceof SSJT.model.Person))
            vm.set('user',record);
        else
            vm.set('user',null);
        //weather.load();
        this.callParent(arguments);
    },
    showEditAvatar:function(e){
        const edit=this.lookup('editAvattar');
        edit&&edit.show();
    },
    hideEditAvatar:function(e){
        const edit=this.lookup('editAvattar');
        edit&&edit.hide();
    },
    onEditAvatar:function(){
        AvatarHelper.showAvatarDialog();
    },

});
