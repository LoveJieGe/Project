Ext.define('SSJT.view.widgets.EditHeaderController',{
    extend:'Ext.app.ViewController',
    alias:'controller.editheader',
    // init:function(){
    //     // const me = this,view = me.getView(),
    //     //     btnBrowse = view.down('#btnBrowse');
    //     // AttachHelper.ensurePlUploadlibs(() => {
    //     //     me.doInitUploader(btnBrowse);
    //     // });
    // },
    doInitUploader:function(btnBrowse) {
        const me = this,view = me.getView();

        var uploader = new plupload.Uploader({
            //runtimes:用来指定上传方式，指定多个上传方式请使用逗号隔开。一般情况下，你不需要配置该参数，
            //因为Plupload默认会根据你的其他的参数配置来选择最合适的上传方式。如果没有特殊要求的话，
            //Plupload会首先选择html5上传方式，如果浏览器不支持html5，则会使用flash或silverlight，
            //如果前面两者也都不支持，则会使用最传统的html4上传方式。
            //如果你想指定使用某个上传方式，或改变上传方式的优先顺序，则你可以配置该参数。
            runtimes: 'html5,html4',
            //required_features:可以使用该参数来设置你必须需要的一些功能特征，Plupload会根据你的设置来选择合适的上传方式。
            //因为，不同的上传方式，支持的功能是不同的，比如拖拽上传只有html5上传方式支持，图片压缩则只有html5,flash,silverlight上传方式支持。
            //该参数的值是一个混合类型，可以是一个以逗号分隔的字符串，
            required_features: 'send_browser_cookies',
            ////browse_button: 触发文件选择对话框的DOM元素，当点击该元素后便后弹出文件选择对话框。
            //该值可以是DOM元素对象本身，也可以是该DOM元素的id
            browse_button: btnBrowse.buttonElement.dom, 
            //container:用来指定Plupload所创建的html结构的父容器，默认为前面指定的browse_button的父元素。
            //该参数的值可以是一个元素的id,也可以是DOM元素本身。
            container: btnBrowse.element.dom, 
            url: ComUtils.joinPath(ComConfig.httpUrl, 'Doc/plupload/EmImgUp.ashx'),
            //分片上传文件时，每片文件被切割成的大小，为数字时单位为字节。也可以使用一个带单位的字符串，如"200kb"。
            //当该值为0时表示不使用分片上传功能
            chunk_size: '1mb',
            //当值为true时会为每个上传的文件生成一个唯一的文件名，并作为额外的参数post到服务器端，
            //参数明为name,值为生成的文件名
            unique_names: true,
            //可以使用该参数来限制上传文件的类型，大小等，该参数以对象的形式传入，它包括三个属性：
            //mime_types：用来限定上传文件的类型，为一个数组，该数组的每个元素又是一个对象，
            //该对象有title和extensions两个属性，title为该过滤器的名称，extensions为文件扩展名，有多个时用逗号隔开。
            //该属性默认为一个空数组，即不做限制。
            //max_file_size：用来限定上传文件的大小，如果文件体积超过了该值，则不能被选取。
            //值可以为一个数字，单位为b,也可以是一个字符串，由数字和单位组成，如'200kb'
            // prevent_duplicates：是否允许选取重复的文件，为true时表示不允许，为false时表示允许，默认为false。
            //如果两个文件的文件名和大小都相同，则会被认为是重复的文件
            multi_selection:false,
            filters: {
                prevent_duplicates: true,
                max_file_size: '4mb',
                mime_types: [{
                    title: '图片文件',
                    extensions: 'jpg,jpeg,gif,png,bmp'
                }]
            },

            init: {
                //当文件添加到上传队列后触发
                FilesAdded(up, files) {
                    me.onFilesAdded.apply(me, arguments);
                }
            }
        });
        uploader.init();
        me.uploader = uploader;
    },
    /**
     * 选择文件后触发
     * @param {plupload.Uploader} uploader
     * @param {plupload.File[]} files
     */
    onFilesAdded(uploader, files) {
        debugger
        const me = this,view = me.getView(),
            store = me.getStore(),img = new moxie.image.Image();;

        plupload.each(files, function (file) {
            // const records = store.add({
            //     FileID: file.id,
            //     FileName: file.name,
            //     Size: file.size
            // });
            img.load(file.getSource());
            // if (records.length) {
            //     const record = records[0],
            //         img = new moxie.image.Image();
            //     img.onload = function () {
            //         var item = view.getItem(record);
            //         if (item) {
            //             var dom = Ext.fly(item).down('.img-wrap').dom;
            //             this.embed(dom, {
            //                 width: 100,
            //                 height: 100,
            //                 preserveHeaders: false
            //             });
            //         }
            //     };
               
            // }

        });
    },
    onTapBtnBrowse(btn) {
        debugger
        const me = this,
        file = this.lookup('file');
        file.onClick();
        // if (!window.plupload || !me.uploader) {
        //     ComUtils.toastShort(AttachHelper.waitUploadMsg);
        //     return;
        // }
    },
});