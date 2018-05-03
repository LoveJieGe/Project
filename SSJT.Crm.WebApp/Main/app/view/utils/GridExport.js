Ext.define('SSJT.view.utils.GridExport',{
    alternateClassName:'ExportHelper',
    singleton:true,
    requires:[
        'Ext.exporter.file.excel.Workbook'
    ],

    onExport(grid,opt,isVisible){
        const me = this;
        let workbook = me.writeWorkBook(opt);
        me.writeStyle(workbook);
    },
    privates:{
        writeWorkBook(opt){
            var workbook = Ext.create('Ext.exporter.file.excel.Workbook', Ext.applyIf({
                protectStructure: 'False',
                protectWindows: 'False'
            },opt.workbook));
            return workbook;
        },
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
            me.appendFormatStyle(workbook,'Date','Medium Date');
            me.appendFormatStyle(workbook,'DateTime','Long Date');
            me.appendFormatStyle(workbook,'Rate','Percent');
            me.appendFormatStyle(workbook,'Price','Currency');
            me.appendFormatStyle(workbook,'Money','Currency');
            me.appendFormatStyle(workbook,'Percent','Percent');
            me.appendFormatStyle(workbook,'Quantity','General Number');
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
                format:'General Number'
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
        writeGridData(workbook,grid,opt,isVisible){
            let table = workbook.addWorksheet(Ext.apply({
                name:'GridData',
            },opt.worksheet)).addTable(Ext.applyIf({
                defaultColumnWidth:80,
                defaultRowHeight:15
            },opt.table));
        },
        handlerColumn(grid,isVisible){
            const header = grid.getHeaderContainer();
            let columns,columnArr = [];
            if(isVisible){
                let tempColumn;
                columns = header.getVisibleColumns();
                columns.forEach(x=>{
                    
                });
            }
        }
    }
    
})