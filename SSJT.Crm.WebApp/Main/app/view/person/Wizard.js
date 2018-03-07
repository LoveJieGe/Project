Ext.define('SSJT.view.person.Wizard', {
    extend: 'SSJT.view.widgets.Wizard',
    xtype: [
        'personwizard',
        'personcreate',
        'personedit'
    ],
    controller: {
        type: 'personwizard'
    },

    viewModel: {
        formulas:{
            Levels:function(get){
                debugger
                const me = this,
                    r = get('record');
                if(r){
                    const levels = r.get('Levels');
                    
                }
            }
        }
    },
    bind: {
        title: '{record.phantom? "添加" : "编辑"}用户'
    },

    cls: 'person-create',
    
    screens: [{
        title: '账号设置',
        iconCls: 'x-fa fa-info',
        defaults:{
            labelTextAlign:'right'
        },
        platformConfig:{
            phone:{
                defaults:{
                    labelWidth:'85px'
                }
            }
        },
        items: [{
            xtype: 'textfield',
            reference: 'username',
            label: '用户名',
            name:'UserName',
            required: true,
            bind: '{record.UserName}',
            listeners: {
                change: 'onUsernameChange'
            }
        }, {
            xtype: 'passwordfield',
            reference: 'password',
            required: true,
            placeholder: '登录密码',
            name:'PassWord',
            bind: {
                label: '{record.phantom? "密码" : "新密码"}',
                required: '{record.phantom}',
            }
        }, {
            xtype: 'passwordfield',
            reference: 'password_check',
            label: '确认密码',
            disabled: true,
            validators: {
                type: 'controller',
                fn: 'doPasswordMatch'
            },
            bind: {
                required: '{password.value}',
                disabled: '{!password.value}'
            }
        }]
    }, {
        title: '个人信息',
        iconCls: 'x-fa fa-home',
        defaults:{
            labelTextAlign:'right'
        },
        platformConfig:{
            phone:{
                defaults:{
                    labelWidth:'85px'
                }
            }
        },
        items: [{
            xtype: 'datepickerfield',
            reference: 'birthday',
            name:'Birthday',
            label: '生日',
            required: true,
            bind: '{record.Birthday}'
        }, {
            xtype: 'emailfield',
            reference: 'email',
            validateDisabled:true,
            name:'Email',
            label: '邮箱',
            validators:/^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((.[a-zA-Z0-9_-]{2,3}){1,2})$/,
            required: true,
            bind: '{record.Email}'
        }, {
            xtype: 'textfield',
            reference: 'mobile',
            name:'Mobile',
            label: '手机',
            required: true,
            validators:/^[1][3,4,5,6,7,8][0-9]{9}$/,
            bind: '{record.Mobile}'
        },{
            xtype: 'textfield',
            name:'Tel',
            reference: 'phone',
            validators:/^(([0\+]\d{2,3}-)?(0\d{2,3})-?)(\d{7,8})(-(\d{3,}))?$/,
            label: '电话',
            bind: '{record.Tel}'
        }, {
            xtype: 'textfield',
            name:'Address',
            reference: 'address',
            label: '现住址',
            required:true,
            bind: '{record.Address}'
        }]
    }, {
        title: '教育工作',
        iconCls: 'x-fa fa-sitemap',
        defaults:{
            labelTextAlign:'right'
        },
        platformConfig:{
            phone:{
                defaults:{
                    labelWidth:'85px'
                }
            }
        },
        items: [{
            xtype: 'textfield',
            name:'Education',
            reference: 'education',
            label: '学校',
            required: true,
            bind: '{record.Education}'
        },{
            xtype: 'selectfield',
            name: 'Levels',
            reference: 'levels',
            role: 'type',
            placeholder: '水平',
            label:'水平',
            forceSelection: true,
            editable: false,
            clearable: false,
            picker: 'floated',
            options: [{
                value: 'primary_school',
                text: '小学'
            }, {
                value: 'junior_high_school',
                text: '初中'
            }, {
                value: 'high_school',
                text: '高中'
            }, {
                value: 'specialist',
                text: '大学专科'
            }, {
                value: 'regular_college_course',
                text: '大学本科'
            },{
                value: 'postgraduate',
                text: '研究生'
            },{
                value: 'phd_student',
                text: '博士生'
            }],
            bind:'{Levels?Levels:"primary_school"}'
        },{
            xtype: 'textfield',
            reference: 'professional',
            label: '专业',
            name:'Professional',
            required: true,
            bind: '{record.Professional}'
        }]
    }]
});
