Ext.define(null,{
    override:'Ext.grid.cell.Text',
    config:{
        encodeHtml:false// Grid 单元格默认会将html字符串原样输出, 而不是显示为富文本。所以此处改为 false
    }
})