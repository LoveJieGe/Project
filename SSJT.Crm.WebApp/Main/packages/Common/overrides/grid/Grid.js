/**
 * 桌面端可以鼠标选中文字
 */
Ext.define(null,{
    override:'Ext.grid.Grid',
    platformConfig:{
        desktop:{
            userSelectable:'text'
        }
    }
})