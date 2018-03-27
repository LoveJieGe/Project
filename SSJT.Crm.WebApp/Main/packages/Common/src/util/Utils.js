Ext.define('Common.util.Utils',{
    alternateClassName:'ComUtils',
    singleton:true,
    requires: [
        'Ext.Toast',
        'Ext.MessageBox',
        'Common.model.ValueText',
        'Common.util.Config',
        'Ext.util.LocalStorage'
    ],
    /**
     * 常用正则
     */
    regex: {
        url: /^(http|https):\/\/(\w+:{0,1}\w*)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%!\-/]))?$/i,
        picture:/^image\/(?:png|jpg|jpeg|gif|bmp)$/i
    },

    /**
     * 常用正则, 字符串形式
     */
    regexStr: {
        query: '((\\?(?:&?[^=&]*=[^=&]*)*)?)', // 可以匹配 空字符串、?、?DocEntry=30000
        query2: '(\\?(?:&?[^=&]*=[^=&]*)*)' // 可以匹配 ?、?DocEntry=30000
    },
    errorCode:{
        /// 用户名或密码、验证码错误代码
        VErrorCode : -32091,
        /// 其他错误代码
        OErrorCode : -32090,
        /// 用户验证失败错误
        SErrorCode : -32092,
        /// 参数错误
        PErrorCode : -32093,
        /// 默认的错误代码
        Default  : 400,
        //没有授权的错误码
        UnauthorizedCode:401
    },
    /**
     * 当前是否是development模式
     * @property {Boolean}
     */
    isDev: Ext.manifest.env === 'development', // development/production
/**
     * 获取应用程序的实例
     * @return {Ext.app.Application}
     */
    getApp() {
        return Ext.getApplication() || Ext.route.Router.application;
    },

    /**
     * 获取应用程序的名称
     * @return {String}
     */
    getAppName() {
        return this.getApp().getName();
    },
    /** **************************ajax方法调用********************************/
    _handleOptions(options) {
        const me = this;
        options = options || {};

        // 进度条
        /* if (options.loadTarget !== false) {
            if (Ext.isEmpty(options.loadTarget) || options.loadTarget === true) {
                options.loadTarget = Ext.Viewport;
            } else if (Ext.isString(options.loadTarget)) {
                options.loadTarget = Ext.getCmp(options.loadTarget);
            }
        }*/

        // 遮罩层
        if (options.maskTarget) {
            if (options.maskTarget == true) {
                options.maskTarget = Ext.Viewport;
            } else if (Ext.isString(options.maskTarget)) {
                options.maskTarget = Ext.getCmp(options.maskTarget);
            }
        }

        // 此ajax请求时需要禁用的按钮，可为空
        if (options.button) { // 也就是防止用户连续点击按钮
            const btns = [];
            let bs = options.button;
            bs = Ext.isArray(bs) ? bs : [bs];
            for (let i = 0; i < bs.length; i++) {
                const b = bs[i];
                if (Ext.isEmpty(b)) continue;
                btns.push(Ext.isString(b) ? Ext.getCmp(b) : b);
            }
            if (btns.length) {
                options.button = btns;
            } else {
                delete options.button;
            }
        }

        if (options.data) {
            options.params = Ext.apply({}, options.params, {
                data: Ext.encode(options.data)
            });
            delete options.data;
        }
        options.params = Ext.apply({}, options.params, this.getApp().getClientInfo());
        return options;
    },

    /**
     * 累加多个字符串为路径，比如 joinPath('http:// aaa.bbb', 'ccc/ddd', 'eee', '/fff/')
     * @return {String} 最终路径
     */
    joinPath() {
        let result = '';
        Ext.each(Array.prototype.slice.call(arguments), function (str) {
            if (!Ext.isEmpty(str)) {
                while (!Ext.isEmpty(result) && result[result.length - 1] == '/') {
                    result = result.substr(0, result.length - 1);
                }
                while (str[0] == '/') {
                    str = str.substr(1);
                }
                if (!Ext.isEmpty(result)) result += '/';
                result += str;
            }
        });

        return result;
    },

    /**
     * 根据一个 url/path/路径 等得到完整的url
     *
     * @param {String} path
     * @return {String}
     */
    getFullUrl(path) {
        const me = this;
        if (!Ext.isEmpty(path)) {
            let url;
            if (ComUtils.isUrl(path) || /\.json$/i.test(path)) {
                url = path;
            } else {
                // 后台路由丢失session，所以 暂时 先fix
                if (/[^ajax]\/[^/]+\/[^/]+$/.test(path)) {
                    const arr = path.split('/');
                    url = ComUtils.joinPath(ComConfig.httpUrl, 'AjaxHandler', `${Ext.String.capitalize(arr[0])}.ashx?class=${arr[1]}&method=${arr[2]}`);
                } else {
                    url = ComUtils.joinPath(ComConfig.httpUrl, path);
                }
            }

            return url;
        }

        return path;
    },

    /**
     * ajax请求统一入口
     * @param  {String} api     接口(不带http和域名), 比如shopController/saveShop.do
     * @param  {Object} options params、success、failure等
     * @return {Number}         此次请求的编号
     */
    ajax(api, options) {
        const me = this;
        // <debug>
        if (arguments.length == 0) {
            me.alert('参数不正确!');

            return false;
        }
        // </debug>

        const opt = me._handleOptions(options);
        /* if (opt.loadTarget) {
            me.loop(opt.loadTarget);
        }*/
        if (opt.maskTarget) {
            me.mask(opt.maskTarget);
        }
        const btnState = [];
        if (opt.button) {
            Ext.each(opt.button, function (b) {
                btnState.push(b.getDisabled());
                if (b.setCircularProgress) b.setCircularProgress(true); // 圆形进度条
                b.setDisabled(true);
            });
        }
        const request = Ext.Ajax.request(Ext.applyIf({
            url: me.getFullUrl(api),
            method: 'POST',
            //response:包含响应数据的XMLHttpRequest对象
            //opts:请求调用的参数
            success:function(response, opts) {
                const contentType = response.getResponseHeader('content-type'),
                    isJson = /json/i.test(contentType);
                let result = response.responseText,
                    succeed = true; // 请求成功
                if (!Ext.isEmpty(result) && isJson) {
                    try {
                        result = Ext.decode(result);
                    } catch (e) {}
                }
                if (result && result.hasOwnProperty('Success')) { // 或者 result有Success属性且为true时
                    succeed = result.Success;
                }
                if (succeed) { // result返回结果中success=true
                    if(result && result.hasOwnProperty('Data'))
                        result = Ext.decode(result.Data);
                    if (opt.success) opt.success.call(this, result);
                } else {
                    const msg = result.Message || '';
                    if (opt.failure) {
                        opt.failure.call(this, result);
                    } else if (!Ext.isEmpty(msg)) {
                        me.alert(msg);
                    }
                }
            },
            failure:function(r, op) {
                let err = r.responseText;
                if (!Ext.isEmpty(err)) {
                    try {
                        err = eval(`(${err})`);
                    } catch (e) {}
                } else {
                    err = r.statusText;
                }

                const msg = err.message || err;
                if (r.status == '0') {
                    me.toastShort(msg || 'communication failure');
                } else if (r.status == '-1') { // ajax被中止
                    // aborted
                } else if (me.isUnauthorized(r.status)) { // 未授权
                    Ext.route.Router.resume(true);
                    // 转到登录页
                    this.getApp().fireEvent('needlogin');
                    me.toastShort(msg);
                } else if (opt.failure) { // 普通异常
                    opt.failure.call(this, msg, r.status);
                } else {
                    me.alert(msg);
                }
                // <debug>
                console.log(r, op);
                // </debug>
            },
            callback(op, success, r) {
                if (opt.button) {
                    Ext.each(opt.button, function (b, i) {
                        if (!b.isDestroyed && !b.isDestroying) {
                            if (b.setCircularProgress) b.setCircularProgress(false);
                            b.setDisabled(btnState[i]);
                        }
                    });
                }
                /* if (opt.loadTarget) {
                    me.unLoop(opt.loadTarget);
                }*/
                if (opt.maskTarget) {
                    me.unMask(opt.maskTarget);
                }
                if (opt.callback) {
                    opt.callback.call(this, success, r);
                }
            },
            scope: opt.scope || me
        }, opt));

        // 与此component有关的ajax请求
        const h = opt.ajaxHost;
        if (h && !h.isDestroying) {
            if (!h.ajaxRequests) h.ajaxRequests = {};
            h.ajaxRequests[request.id] = request;
        }

        return request;
    },

    /**
     * 判断 状态码 是不是 未授权
     *
     * @param {String} status
     * @return {Boolean}
     */
    isUnauthorized(status) {
        return status == '440' || status == '401';
    },
    /** **************************消息提示********************************/

    /**
     * alert
     *
     * @param {String} msg 提示文字
     */
    alert(msg) {
        const m = (msg || '').replace(/(?:<style.*?>)((\n|\r|.)*?)(?:<\/style>)/ig, '');
        if (!Ext.isEmpty(m)) Ext.Msg.alert('系统提示', m);
    },

    /**
     * confirm
     *
     * @param {String} msg 提示文字
     * @param {Function} handle 回调
     */
    confirm(msg, handle) {
        Ext.Msg.confirm('系统提示', msg, function (btn) {
            if (btn == 'yes' && handle != null) {
                handle();
            }
        });
    },
/**
     * 判断字符串是不是 url
     * @param {String} url
     * @return {Boolean}
     */
    isUrl(url) {
        return this.regex.url.test(url);
    },
    /**
     * 根据xtype找到组件
     * @param  {String} xtype
     * @param  {Boolean} exact 明确查找xtype。若为false，表示任何继承自xtype的组件都会被找到；否则，只找顶层类型为xtype的组件
     * @return {Ext.Component}
     */
    getCmp(xtype, exact) {
        if (exact === undefined) exact = true;
        const cmps = Ext.ComponentQuery.query(xtype + (exact ? '(true)' : ''));

        return cmps.length >= 1 ? cmps[0] : null;
    },
    // ****************************显示或隐藏 加载的菊花遮罩层****************************/

    /**
     * 显示'加载中...'的菊花
     * @param  {Ext.Component} view 视图或者控件
     * @param  {String} msg  提示信息
     */
    mask(view, msg) {
        const message = msg || ''; // || '请稍后';
        /* && view.isPainted()*/
        if (view  && !view.isDestroyed) {
            const mask = this.getLoadMask(message);
            if (mask && mask.getParent() !== view) {
                view.add(mask);
            }
            view.setMasked(mask);
        }
    },

    /**
     * 隐藏'加载中...'的菊花
     * @param  {Ext.Component} view 视图或者控件
     */
    unMask(view) {
        /* && view.isPainted()*/ 
        if (view && !view.isDestroyed &&
            view._masked && !view._masked.isDestroyed) {
            view.setMasked(false);
        }
    },

    /**
     * 获取loadmask实例，重用已有的，防止不断创建
     * @param  {String} msg 提示信息
     * @return {Ext.Loadmask}     [description]
     */
    getLoadMask(msg) {
        let mask = this.getCmp('loadmask', true);
        if (mask) {
            mask.setMessage(msg);
        } else {
            mask = Ext.widget('loadmask', {
                message: msg
            });
            mask.on('tap', 'hide', mask);
        }

        return mask;
    },
    toastShort(msg) {
        if (!Ext.isEmpty(msg)) Ext.toast(msg, 1500);
    },
    /**
     * delay:显示的时长
     */
    toastShort(msg,delay) {
        if (!Ext.isEmpty(msg)) Ext.toast(msg, delay);
    },
     /** **************************路由跳转********************************/

    /**
     * url跳转
     */
    redirectTo() {
        const app = this.getApp();
        if (app) {
            app.redirectTo.apply(app, arguments);
        }
    },
    /**
     * 根据 token 获取 路由对象
     * 如果提供了第二个参数(控制器 或 app 实例)，则 只获取 它里面 有的
     *
     * @param {String} token
     * @param {Ext.app.BaseController} instance 可选，控制器 或 app 实例
     * @return {Ext.route.Route}
     */
    getRouteByToken(token, instance) {
        const routes = Ext.route.Router.routes;

        let enumsObj = {},
            name,
            route;
        if (instance && instance.getRoutes) {
            const obj = instance.getRoutes();
            if (obj) enumsObj = obj;
        } else {
            enumsObj = routes;
        }
        
        for (name in enumsObj) {
            route = routes[name];
            if (token && route.recognize(token)) {
                return route;
            }
        }
        return null;
    },
     /** **************************LocalStorge********************************/
    store: new Ext.util.LocalStorage({
        id: 'SSJT-state'
    }),
    getLSItem: function(key, defaultValue) {
        var value = this.store.getItem(this.getAppName()+'-'+key);
        return value === undefined? defaultValue : Ext.decode(value);
    },

    setLSItem: function(key, value) {
        if (value == null) {    // !== undefined && !== null
            this.store.removeItem(this.getAppName()+'-'+key);
        } else {
            this.store.setItem(this.getAppName()+'-'+key, Ext.encode(value));
        }
    },

    clearLsItem: function(key) {
        this.setLSItem(key, null);
    },
    /** **************************格式转换********************************/
    string2Hex:function (str) {
        var result = "";
        if (str != null) {
            str = str.toString();
            for (var i = 0; i < str.length; i++) {
                var temp = str.charCodeAt(i).toString(16);
                if (temp.length == 1) temp = "0" + temp + "00";
                else if (temp.length == 2) temp = temp + "00";
                else if (temp.length == 3) temp = temp.substring(1, 3) + "0" + temp.substring(0, 1);
                else if (temp.length == 4) temp = temp.substring(2, 4) + temp.substring(0, 2);
                result += temp;
            }
        }
        return result.toUpperCase();
    },
    hex2String : function (str) {
        var result = "";
        if (str != null) {
            str = str.toString();
            for (var i = 0; i < str.length; i += 4) {
                result = result + String.fromCharCode("0x" + str.substring(i + 2, i + 4) + str.substring(i, i + 2));
            }
        }
        return result;
    },
    /**
     * 计算哈希值
     *
     * @param {String} s
     * @return {Number}
     */
    hashCode(s) {
        if (!s) return null;
        let hash = 0,
            i, chr, len;
        if (!s.length) return hash;
        for (i = 0, len = s.length; i < len; i++) {
            chr = s.charCodeAt(i);
            hash = (hash << 5) - hash + chr;
            hash |= 0; // Convert to 32bit integer
        }

        return hash;
    },
})