Ext.define('Common.util.GridExport',{
    alternateClassName:'GridExportHelper',
    requires:[
        'Ext.exporter.file.excel.Workbook',
        'Common.util.Utils'
    ],
    singleton:true,
    /**
     * 
     * @param {Ext.grid.Grid} grid Grid列表
     * @param {string} filename 文件名字
     * @param {object} opt
     * opt={
     *  addTime:{boolean} 文件名字加上当前时间(默认是true)，
     *  exportVisibleCol:{boolean} true导出列表的可见列，false导出列表所有列(包括隐藏的)
     *  widthRate：{int} 导出到Excel的宽度相对列表宽度的比率，默认0.75
     *  colorList:{Object/Array}是一个Financial.model.ColorInformation的对象或数组,
     *  maskTarget:{boolean/string}遮罩层,true代表当前整个视图，或者指定视图的id，
     *  callback：{function}导出后的回调，
     *  success：导出成功处理函数,
     *  failure:导出失败处理函数
     *  rendererColumn:所有列数据处理函数,
     *  [DataIndex]{Column中的dataIndex字段所对应的值}当前列数据处理函数
     * }
     */
    onExport(grid,filename,opt){
        const me = this;
        opt = me.handleOptions(opt);
        filename = me.getFileName(filename,opt);
        if(grid&&grid.isGrid){
            if(opt.maskTarget){
                ComUtils.mask(opt.maskTarget,opt.maskMessage||'正在导出数据');
            }
            //延时0.1是为了出现遮罩层，不知道正常为什么不会出现
            setTimeout(function(){
                let workbook = me.getWorkBook(opt);
                me.writeGridData(workbook,grid,opt);
                let render = workbook.render().replace(/&amp;/g,'&');
                let promise = Ext.exporter.File.saveAs(render, filename+'.xls', 'UTF-8');
                promise.then(function(records){
                        if(opt.success){
                            opt.success(records);
                        }
                    },function(error){
                        if(opt.failure){
                            opt.failure(error);
                        }else{
                            Utils.alert('导出失败!');
                        }
                }).always(function(){
                    if(opt.maskTarget){
                        ComUtils.unMask(opt.maskTarget);
                    }
                    if(opt.callback){
                        opt.callback();
                    }
                })
            },50);
            
        }
    },
    handleOptions(options){
        options = Ext.apply({
            addTime:true,
            exportVisibleCol:true,
        },options);
        if (options.maskTarget) {
            if (options.maskTarget == true) {
                options.maskTarget = Ext.Viewport;
            } else if (Ext.isString(options.maskTarget)) {
                let view = Utils.getCmp(options.maskTarget);
                if(!view){
                    view = Ext.getCmp(options.maskTarget);
                }
                options.maskTarget = view;
            }
        }
        return options;
    },
    getFileName(filename,opt){
        if(Ext.isEmpty(filename)){
            return Ext.util.Format.date(new Date(),'Ymd_Hms');
        }
        let index = filename.lastIndexOf('.');
        if(index>=0){
            filename = filename.substring(0,index);
        }
        if(opt.addTime){
            filename = `${filename}_${Ext.util.Format.date(new Date(),'Ymd_Hms')}`;
        }
        return filename;
    },
    getWorkBook(opt){
        const me = this;
        var workbook = Ext.create('Ext.exporter.file.excel.Workbook', Ext.applyIf({
            author:'PushSoft',
            protectStructure:'False',
            protectWindows:'False'
        },opt.workBook));
        me.writeStyle(workbook);
        return workbook;
    },
    /**
     * 样式
     * @param {Ext.exporter.file.excel.Workbook} workbook 
     */
    writeStyle(workbook){
        const me = this;
        workbook.addStyle({
            autoGenerateId:false,
            id:'Default',
            font:{
                fontName:'Tahoma',
                size:9
            },
            borders:[]
        });
        me.appendFormatStyle(workbook,'Date','yyyy-MM-dd');
        me.appendFormatStyle(workbook,'DateTime','yyyy-MM-dd HH:mm');
        me.appendFormatStyle(workbook,'Rate','#,##0.#########');
        me.appendFormatStyle(workbook,'Price','#,##0.00#######');
        me.appendFormatStyle(workbook,'Money','#,##0.00');
        me.appendFormatStyle(workbook,'Percent','#,##0.##');
        me.appendFormatStyle(workbook,'Quantity','#,##0.#########');
        workbook.addStyle({
            autoGenerateId:false,
            id:'Header',
            font:{
                fontName:'Tahoma',
                size:9,
                bold:1
            },
            interior:{
                color:'#C0C0C0',
                pattern:'Solid'
            }
        });
        workbook.addStyle({
            autoGenerateId:false,
            id:'Footer',
            font:{
                fontName:'Tahoma',
                size:9,
                bold:1
            },
            interior:{
                color:'#C0C0C0',
                pattern:'Solid'
            },
            format:'0.00_);[Red]\(0.00\)'
        });
        workbook.addStyle({
            autoGenerateId:false,
            id:'Wrap',
            alignment:{
                vertical:'Center',
                wrapText:'1'
            },
        });
        workbook.addStyle({
            autoGenerateId:false,
            id:'HeaderGroup',
            alignment:{
                vertical:'Center',
                horizontal:'Center'
            },
            font:{
                fontName:'Tahoma',
                size:9,
                bold:1
            },
            interior:{
                color:'#C0C0C0',
                pattern:'Solid'
            },
        });
    },
    appendFormatStyle(workbook,styleId,format){
        workbook.addStyle({
            autoGenerateId:false,
            id:styleId,
            font:{
                fontName:'Tahoma',
                size:9
            },
            format:format
        })
    },
    /**
     * 数据
     * @param {Ext.exporter.file.excel.Workbook} workbook 
     * @param {Ext.grid.Grid} grid 
     * @param {Object} opt 
     * @param {boolean} isVisible 
     */
    writeGridData(workbook,grid,opt){
        let me = this,
            table = workbook.addWorksheet(Ext.apply({
            name:opt.sheetName||'GridData',
        },opt.worksheet)).addTable(Ext.applyIf({
            defaultColumnWidth:80,
            defaultRowHeight:15
        },opt.table));
        //columns
        me.setColumns(grid,table,opt);
        me.setHeader(grid,table,opt);
        me.setRowData(workbook,grid,table,opt);
    },
    setColumns(grid,table,opt){
        let me = this,
            store = grid.getStore(),
            model = store.getModel(),
            columns = opt.exportVisibleCol?grid.getVisibleColumns():grid.getColumns();
        if(Ext.Object.isEmpty(columns))return;
        if(opt.exportVisibleCol)
            columns = columns.filter(x=>{return x.isVisible(true);});
        Ext.Object.each(columns,function(key,column){
            let dataIndex = column.getDataIndex(),
                width = column.getWidth()||column.getComputedWidth(),
                dataType = column.dataType||me.getColumnDataType(model,dataIndex)||'',
                styleId = null;
            switch(dataType.toLowerCase()){
                case 'date':
                    styleId = 'Date';break;
                case 'datetime':
                    styleId = 'DateTime';break;
                case 'rate':
                    styleId = 'Rate';break;
                case 'price':
                    styleId = 'Price';break;
                case 'money':
                    styleId = 'Money';break;
                case 'percent':
                    styleId = 'Percent';break;
                case 'quantity':
                    styleId = 'Quantity';break;
            }
            width = Math.ceil(width*(opt.widthRate||0.75));
            table.addColumn({
                autoFitWidth:1,
                width:width,
                styleId:styleId
            });
        });
    },
    setHeader(grid,table,opt){
        let me =this,
            columns =  opt.exportVisibleCol?grid.getVisibleColumns():grid.getColumns();
        if(Ext.Object.isEmpty(columns))return;
        if(opt.exportVisibleCol)
            columns = columns.filter(x=>{return x.isVisible(true);});
        var headerList = {};
        Ext.Object.each(columns,function(key,column){
            let parent = column.getParent();
            if(parent&&parent.isGridColumn){
                if(!headerList[parent.getId()]){
                    headerList[parent.getId()] = parent;
                }
            }
        });
        //带头
        if(!Ext.Object.isEmpty(headerList)){
            let headerGroupRow = table.addRow();
            Ext.Object.each(headerList,function(key, value, myself){
                let column = value,
                    colSpan = column.getVisibleCount();
                if(colSpan>0){
                    headerGroupRow.addCell({
                        styleId:'HeaderGroup',
                        mergeAcross:colSpan-1,
                        value:column.getText()
                    });
                }
            });
        }
    //header
        let headerRow = table.addRow();
        Ext.Object.each(columns,function(key,column){
            headerRow.addCell({
                styleId:'Header',
                value:column.getText()
            });
        });
    },
    setRowData(workbook,grid,table,opt){
        let me =this,
            columns =  opt.exportVisibleCol?grid.getVisibleColumns():grid.getColumns(),
            store = grid.getStore(),
            model = store.getModel(),
            count = store.getCount();
        if(Ext.Object.isEmpty(columns))return;
        if(opt.exportVisibleCol)
            columns = columns.filter(x=>{return x.isVisible(true);});
        for(let i = 0;i<count;i++){
            let record = store.getAt(i);
            let dataRow = table.addRow(),
                index = 1;
            Ext.Object.each(columns,function(key,column){
                let dataIndex = column.getDataIndex(),
                    data = record.get(dataIndex),
                    cells = column.getCells(),
                    cell = cells&&cells[i];
                    dataType = column.dataType||me.getColumnDataType(model,dataIndex)||'',
                    styleId = null;
                if(Ext.isString(data))
                    data = data.replace(/\s/g,'&nbsp;');
                //对数据进行处理
                //data = Ext.util.Format.htmlEncode(data);
                if(opt.rendererColumn){
                    opt.rendererColumn(data,record,dataIndex,column);
                }
                if(opt[dataIndex]){
                    data = opt[dataIndex](data,record,dataIndex,column);
                }
                //样式
                styleId = me.handleColumnColor(workbook,opt,dataIndex,record,dataType);
                if(dataType.toLowerCase()=='datetime'){
                    data = Ext.util.Format.date(data,'Y-m-d H:m')
                    dataType = 'DateTime';
                }else if(dataType.toLowerCase()=='int'){
                    dataType = 'Number'
                }else{
                    dataType = 'String';
                }
                dataRow.addCell({
                    styleId:styleId,
                    value:data,
                    index:index++,
                    dataType:Ext.String.capitalize(dataType)
                });
            });
        }
    },
    handleColumnColor(workbook,opt,dataIndex,record,dataType){
        let styleId = null;
        if(!Ext.Object.isEmpty(opt.colorList)){
            const me = this;
            Ext.Object.each(opt.colorList,function(key,colorInfo){
                if(colorInfo&&colorInfo.isModel){
                    let hasStyle = false, 
                        columnName = colorInfo.get('ColumnName');
                    if((columnName==dataIndex)||colorInfo.get('ApplyToRow')){
                        let condition = colorInfo.get('Condition'),
                            value = colorInfo.get('Value'),
                            recordValue = record.get(columnName),
                            operate;
                        switch(condition){
                            case 1:
                                if(recordValue==value)
                                    hasStyle = true;
                                break;
                            case 2:
                                if(recordValue!=value)
                                    hasStyle = true;
                                break;
                            case 3:
                                if(recordValue<value)
                                    hasStyle = true;
                                break;
                            case 4:
                                if(recordValue>value)
                                    hasStyle = true;
                                break;
                            case 5:
                                if(recordValue<=value)
                                    hasStyle = true;
                                break;
                            case 6:
                                if(recordValue>=value)
                                    hasStyle = true;
                                break;
                            case 7:
                                let expression = colorInfo.get('Expression');
                                if(!Ext.isEmpty(expression)){
                                    hasStyle = me.parseExpression(expression,record,columnName);
                                }
                                break;
                        }
                        if(hasStyle){
                            styleId = me.AppendFormatStyleColor(workbook,colorInfo,dataType);
                        }
                    }
                }
            });
        }
        return styleId;
    },
    parseExpression(expression,record,columnName){
        let keyReg = /==?|!=|>=?|<=?/g;
            exArr =  expression.split(/&&?|\|\|?/g),
            keys = [],
            result = false;
        if(exArr){
            exArr.forEach(function(x){
                x = (x||'').replace(/\(|\)/,'');
                let keyValue = x.split(keyReg);
                if(keyValue){
                    let recordValue = record.get(keyValue[0]),
                        valueReg = new RegExp(keyValue[0],'g');
                    expression = expression.replace(valueReg,recordValue);
                }
            });
        }
        try {
            result = eval(expression);
            if(!Ext.isBoolean(result))
                result = false;
        } catch (error) {
            result = false;
        }
        return result;
    },
    AppendFormatStyleColor(workbook,model,dataType){
        let styles = workbook.getStyles(),
            tempStyle,
            orderId = model.get('OrderID'),
            backColor = model.get('BackColor'),
            format = null;
        if(!orderId){
            orderId = model.getId();
            let index = orderId.lastIndexOf('-');
            if(index>=0){
                orderId = orderId.substring(index+1);
            }
        }
        styleId = 'SModel_'+orderId;
        if(!Ext.isEmpty(dataType)){
            switch(dataType.toLocaleLowerCase()){
                case 'date':
                    styleId = 'S'+dataType+orderId;
                    format = 'yyyy-MM-dd';break;
                case 'datetime':
                    styleId = 'S'+dataType+orderId;
                    format = 'yyyy-MM-dd HH:mm';break;
                case 'rate':
                    styleId = 'S'+dataType+orderId;
                    format = '#,##0.#########';break;
                case 'price':
                    styleId = 'S'+dataType+orderId;
                    format = '#,##0.00#######';break;
                case 'money':
                    styleId = 'S'+dataType+orderId;
                    format = '#,##0.00';break;
                case 'percent':
                    styleId = 'S'+dataType+orderId;
                    format = '#,##0.##';break;
                case 'quantity':
                    styleId = 'S'+dataType+orderId;
                    format = '#,##0.#########';break;
            }
        }
        tempStyle = styles.findBy(function(x){
            return x.getId()==styleId
        });
        if(!tempStyle){
            workbook.addStyle({
                autoGenerateId:false,
                id:styleId,
                font:{
                    fontName:'Tahoma',
                    size:9,
                    color:model.get('FontColor')||'Automatic'
                },
                interior:{
                    color:backColor||'Automatic',
                    pattern:backColor?'Solid':'None'
                },
                format:format
            });
        }
        return styleId;
    },
    getColumnDataType(model,dataIndex){
        const field = model.getField(dataIndex);
        var dataType = null;
        if(field&&field.isField){
            let type = field.getType();
            if(type!='auto'||type!='string'||type!='int'){
                dataType = type;
            }
        }
        return dataType;
    },
    checkHtml(htmlStr) {  
        var  reg = /<[^>]+>/g;  
        return reg.test(htmlStr);  
    }  
})