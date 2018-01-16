/**
* jQuery ligerUI 1.0.0
* 
* Author leoxie [ gd_star@163.com ] 
* 
*/
if (typeof (LigerUIManagers) == "undefined") LigerUIManagers = {};
(function ($)
{
    $.fn.ligerGetComboBoxManager = function ()
    {
        return LigerUIManagers[this[0].id + "_ComboBox"];
    };
    $.fn.ligerRemoveComboBoxManager = function ()
    {
        return this.each(function ()
        {
            LigerUIManagers[this.id + "_ComboBox"] = null;
        });
    };

    ///	<param name="$" type="jQuery"></param>
    $.fn.ligerComboBox = function (p)
    {
        p = p || {};
        p = $.extend({
            resize: true,           //是否调整大小
            isMultiSelect: false,   //是否多选
            isShowCheckBox: false,  //是否选择复选框
            columns: false,       //表格状态
            selectBoxWidth: false, //宽度
            selectBoxHeight: false, //高度
            onBeforeSelect: false, //选择前事件
            onSelected: false, //选择值事件 
            initValue : null,
            initText : null,
            valueField : 'id',
            textField : 'text',
            valueFieldID : null,
            split: ";"
        }, p); 
        if (p.columns)
        {
            p.isShowCheckBox = true;
        }
        if(p.isMultiSelect)
        {
            p.isShowCheckBox = true;
        } 
        return this.each(function ()
        {
            if (this.usedComboBox) return;
            if (this.id == undefined) this.id = "LigerUI_" + new Date().getTime();
            var g = { 
                //查找Text,适用多选和单选
                findTextByValue: function (value)
                {
                    if (value == undefined) return "";
                    var texts = "";
                    $(p.data).each(function (i, item)
                    {
                        var val = item[p.valueField];
                        var txt = item[p.textField];
                        if (value == val)
                        {
                            texts += txt + p.split;
                        }
                    });
                    if (texts.length > 0) texts = texts.substr(0, texts.length - 1);
                    return texts;
                },
                //查找Value,适用多选和单选
                findValueByText: function (text)
                {
                    if (!text && text == "") return "";
                    var values = "";
                    $(p.data).each(function (i, item)
                    {
                        var val = item[p.valueField];
                        var txt = item[p.textField];
                        if (text == txt)
                        {
                            values += val + p.split;
                        }
                    });
                    if (values.length > 0) values = values.substr(0, values.length - 1);
                    return values;
                },
                bulidContent: function ()
                {
                    this.clearContent();
                    if (g.select)
                    {
                        this.setSelect();
                    }
                    else if (p.data)
                    {
                        this.setData(p.data);
                    }
                },
                clearContent: function ()
                {
                    $("table", g.selectBox).html("");
                    g.inputText.val("");
                    g.valueField.val("");
                },
                setSelect: function ()
                {
                    this.clearContent();
                    $('option', g.select).each(function (i)
                    {
                        var val = $(this).val();
                        var txt = $(this).html();
                        $("table.l-table-nocheckbox", g.selectBox).append("<tr><td index='" + i + "' value='" + val + "'>" + txt + "</td>");
                    });
                    $('td:eq(' + g.select[0].selectedIndex + ')', g.selectBox).each(function ()
                    {
                        if ($(this).hasClass("l-selected"))
                        {
                            g.selectBox.hide();
                            return;
                        }
                        $(".l-selected", g.selectBox).removeClass("l-selected");
                        $(this).addClass("l-selected");
                        if (g.select[0].selectedIndex != $(this).attr('index') && g.select[0].onchange)
                        {
                            g.select[0].selectedIndex = $(this).attr('index'); g.select[0].onchange();
                        }
                        var newIndex = parseInt($(this).attr('index'));
                        g.select[0].selectedIndex = newIndex;
                        g.select.trigger("change");
                        g.selectBox.hide();
                        g.inputText.val($(this).html());
                    });
                    po.addClickEven();
                },
                setData: function (data)
                {
                    this.clearContent();
                    if (p.columns)
                    {
                        g.selectBox.table.headrow = $("<tr class='l-table-headerow'><td width='18px'></td></tr>");
                        g.selectBox.table.append(g.selectBox.table.headrow);
                        g.selectBox.table.addClass("l-box-select-grid");
                        for (var j = 0; j < p.columns.length; j++)
                        {
                            var headrow = $("<td columnindex='" + j + "' columnname='" + p.columns[j].name + "'>" + p.columns[j].header + "</td>");
                            if (p.columns[j].width)
                            {
                                headrow.width(p.columns[j].width);
                            }
                            g.selectBox.table.headrow.append(headrow);
                        }
                    }
                    for (var i = 0; i < data.length; i++)
                    {
                        var val = data[i][p.valueField];
                        var txt = data[i][p.textField];
                        if (!p.columns)
                        {
                            $("table.l-table-checkbox", g.selectBox).append("<tr><td style='width:18px;'  index='" + i + "' value='" + val + "' text='" + txt + "' ><input type='checkbox' /></td><td index='" + i + "' value='" + val + "' align='left'>" + txt + "</td>");
                            $("table.l-table-nocheckbox", g.selectBox).append("<tr><td index='" + i + "' value='" + val + "' align='left'>" + txt + "</td>");
                        } else
                        {
                            var tr = $("<tr><td style='width:18px;'  index='" + i + "' value='" + val + "' text='" + txt + "' ><input type='checkbox' /></td></tr>");
                            $("td", g.selectBox.table.headrow).each(function ()
                            {
                                var columnname = $(this).attr("columnname");
                                if (columnname)
                                {
                                    var td = $("<td>" + data[i][columnname] + "</td>");
                                    tr.append(td);
                                }
                            });
                            g.selectBox.table.append(tr);
                        }
                    }
                    //自定义复选框支持
                    if (p.isShowCheckBox && $.fn.ligerCheckBox)
                    {
                        $("table input:checkbox", g.selectBox).ligerCheckBox();
                    }
                    $(".l-table-checkbox input:checkbox", g.selectBox).change(function ()
                    {
                        if (this.checked && p.onBeforeSelect)
                        {
                            var parentTD = null;
                            if ($(this).parent().get(0).tagName.toLowerCase() == "div")
                            {
                                parentTD = $(this).parent().parent();
                            } else
                            {
                                parentTD = $(this).parent();
                            }
                            if (parentTD != null && !p.onBeforeSelect(parentTD.attr("value"), parentTD.attr("text")))
                            {
                                g.selectBox.slideToggle("fast");
                                return false;
                            }
                        } 
                        if (!p.isMultiSelect)
                        {
                            if(this.checked)
                            {
                                $("input:checked", g.selectBox).not(this).each(function ()
                                {
                                    this.checked = false;
                                    $(".l-checkbox-checked", $(this).parent()).removeClass("l-checkbox-checked");
                                });
                                g.selectBox.slideToggle("fast");
                            }
                        }
                        po.changeValue();
                    });
                    po.addClickEven();
                }, 
                inputText: null,
                select: null,
                textFieldID: "",
                valueFieldID: "",
                valueField: null //隐藏域(保存值)
            };  
            //private object
            var po ={ 
              init: function ()
                {
                    var value = null;
                    //根据值来初始化
                    if (p.initValue != undefined)
                    {
                        value = p.initValue;
                        var text = g.findTextByValue(value);
                        g.inputText.val(text);
                        g.valueField.val(value);
                        po.onChangedValue(value, text);
                    }
                    //根据文本来初始化 
                    else if (p.initText != undefined)
                    {
                        value = g.findValueByText(p.initText);
                        g.inputText.val(p.initText);
                        g.valueField.val(value);
                        po.onChangedValue(value, p.initText);
                    }
                    if (!p.isShowCheckBox && value != null)
                    {
                        $("table tr", g.selectBox).find("td:first").each(function ()
                        {
                            if (value == $(this).attr("value"))
                            {
                                $(this).addClass("l-selected");
                            }
                        });
                    }
                    if (p.isShowCheckBox && value != null)
                    {
                        $(":checkbox", g.selectBox).each(function ()
                        {
                            var parentTD = null;
                            if ($(this).parent().get(0).tagName.toLowerCase() == "div")
                            {
                                parentTD = $(this).parent().parent();
                            } else
                            {
                                parentTD = $(this).parent();
                            }
                            if (parentTD == null) return;
                            var valuearr = value.toString().split(p.split);
                            $(valuearr).each(function (i, item)
                            {
                                if (item == parentTD.attr("value"))
                                {
                                    $(".l-checkbox", parentTD).addClass("l-checkbox-checked");
                                }
                            });
                        });
                    }
                },
                onChangedValue: function (newValue, newText)
                {
                    g.selectedText = newText;
                    g.selectedValue = newValue;
                    if (p.onSelected)
                        p.onSelected(newValue, newText);
                },
                changeValue: function ()
                {
                    var valueStr = "";
                    var textStr = "";
                    $("input:checked", g.selectBox).each(function ()
                    {
                        var parentTD = null;
                        if ($(this).parent().get(0).tagName.toLowerCase() == "div")
                        {
                            parentTD = $(this).parent().parent();
                        } else
                        {
                            parentTD = $(this).parent();
                        }
                        if (!parentTD) return;
                        valueStr += parentTD.attr("value") + p.split;
                        textStr += parentTD.attr("text") + p.split;
                    }); 
                    if (valueStr.length > 0) valueStr = valueStr.substr(0, valueStr.length - 1);
                    if (textStr.length > 0) textStr = textStr.substr(0, textStr.length - 1);
                    g.valueField.val(valueStr);
                    g.inputText.val(textStr);
                    po.onChangedValue(valueStr, textStr);
                },
                addClickEven: function ()
                {
                    //选项点击
                    $(".l-table-nocheckbox td", g.selectBox).click(function ()
                    {
                        if (p.onBeforeSelect && !p.onBeforeSelect($(this).attr("value"), $(this).html()))
                        {
                            g.selectBox.slideToggle("fast");
                            return false;
                        }
                        if ($(this).hasClass("l-selected"))
                        {
                            g.selectBox.slideToggle("fast");
                            return;
                        }
                        $(".l-selected", g.selectBox).removeClass("l-selected");
                        $(this).addClass("l-selected");
                        if (g.select)
                        {
                            if (g.select[0].selectedIndex != $(this).attr('index'))
                            {
                                var newIndex = parseInt($(this).attr('index'));
                                g.select[0].selectedIndex = newIndex;
                                g.select.trigger("change");
                            }
                        }
                        g.boxToggling = true;
                        g.selectBox.hide("fast", function ()
                        {
                            g.boxToggling = false;
                        });
                        g.inputText.val($(this).html());
                        g.valueField.val($(this).attr("value"));
                        po.onChangedValue($(this).attr("value"), $(this).html());
                    });
                }, 
                toggleSelectBox: function (isHide)
                {
                    var textHeight = g.wrapper.height();
                    g.boxToggling = true;
                    if (isHide)
                    {
                        g.selectBox.hide('fast', function ()
                        {
                            g.boxToggling = false;
                        });
                    }
                    else
                    {
                        if (g.wrapper.offset().top + g.selectBox.height() + textHeight + 4 - $(window).scrollTop() > $(window).height())
                        {
                            g.selectBox.css("marginTop", -1 * (g.selectBox.height() + textHeight + 5));
                        }
                        g.selectBox.show('fast', function ()
                        {
                            g.boxToggling = false;
                            if (!p.isShowCheckBox)
                            {
                                var offSet = ($('td.l-selected', g.selectBox).offset().top - g.selectBox.offset().top);
                                $(".l-box-select-inner", g.selectBox).animate({ scrollTop: offSet });
                            }
                        });
                    }
                    g.isShowed = g.selectBox.is(":visible");
                }
            };
           //文本框初始化
            if (this.tagName.toLowerCase() == "input")
            {
                this.readOnly = true;
                g.inputText = $(this); 
                g.textFieldID = this.id;
            }
            else if (this.tagName.toLowerCase() == "select")
            {
                $(this).addClass('l-hidden');
                g.select = $(this);
                p.isMultiSelect = false;
                p.isShowCheckBox = false;
                g.textFieldID = this.id+"_txt";
                g.inputText = $('<input type="text" readonly="true"/>');
                g.inputText.attr("id",g.textFieldID).insertAfter($(this));
            }else {
                //不支持其他类型
                return ;
            }
            if(g.inputText[0].name == undefined) g.inputText[0].name = g.textFieldID; 
            //隐藏域初始化
            g.valueField = null; 
            if (p.valueFieldID)
            { 
                g.valueField = $("#"+p.valueFieldID+":input");
                if(g.valueField.length==0) g.valueField = $('<input type="hidden"/>');
                g.valueField[0].id = g.valueField[0].name = p.valueFieldID;
            } 
            else
            {
                g.valueField = $('<input type="hidden"/>');
                g.valueField[0].id = g.valueField[0].name = g.textFieldID + "_val";
            }
            if(g.valueField[0].name == undefined) g.valueField[0].name = g.valueField[0].id; 
            //开关
            g.link = $('<div class="l-trigger"><div class="l-trigger-icon"></div></div>');
            //下拉框
            g.selectBox = $('<div class="l-box-select"><div class="l-box-select-inner"><table cellpadding="0" cellspacing="0" border="0"></table></div></div>');
            g.selectBox.table = $("table", g.selectBox);
            //外层
            g.wrapper = g.inputText.wrap('<div class="l-text"></div>').parent();
            g.wrapper.append(g.link).after(g.selectBox).after(g.valueField);

            if (!g.inputText.hasClass("l-text-field")) g.inputText.addClass("l-text-field");
            if (p.width)
            {
                g.wrapper.css({ width: p.width });
                g.inputText.css({ width: p.width - 20 });
            }
            if (p.height)
            {
                g.wrapper.height(p.height);
                g.inputText.height(p.height - 2);
                g.link.height(p.height - 4);
            }
            if (p.isShowCheckBox && !g.select)
            {
                $("table", g.selectBox).addClass("l-table-checkbox");
            } else
            {
                $("table", g.selectBox).addClass("l-table-nocheckbox");
            }
            //调整大小支持
            if (p.resize && $.fn.ligerResizable)
            {
                g.selectBox.ligerResizable({ handles: 'se,s', onStartResize: function ()
                {
                    g.resizing = true;
                }, onStopResize: function ()
                {
                    g.resizing = false;
                }
                });
                g.selectBox.append("<div class='l-btn-nw-drop'></div>");
            }
            //开关 事件
            g.link.hover(function ()
            {
                this.className = "l-trigger-hover";
            }, function ()
            {
                this.className = "l-trigger";
            }).mousedown(function ()
            {
                this.className = "l-trigger-pressed";
            }).mouseup(function ()
            {
                this.className = "l-trigger-hover";
            }).click(function ()
            {
                po.toggleSelectBox(g.selectBox.is(":visible"));
            });
            g.inputText.click(function ()
            {
                po.toggleSelectBox(g.selectBox.is(":visible"));
            });
            g.resizing = false;
            g.selectBox.hover(null, function (e)
            {
                if (g.selectBox.is(":visible") && !g.boxToggling && !g.resizing)
                { 
                    po.toggleSelectBox(true);
                }
            });
            //下拉框内容初始化
            g.bulidContent();
            //选择项初始化
            po.init();
            //下拉框宽度、高度初始化
            if (p.selectBoxWidth)
            {
                g.selectBox.width(p.selectBoxWidth);
            }
            else
            {
                g.selectBox.css('width', g.wrapper.css('width'));
            }
            var itemsleng = $("tr", g.selectBox.table).length;
            if (!p.selectBoxHeight && itemsleng < 8) p.selectBoxHeight = itemsleng * 30;
            if (p.selectBoxHeight)
            {
                g.selectBox.height(p.selectBoxHeight);
            }

            if (this.id == undefined) this.id = "LigerUI_" + new Date().getTime();
            LigerUIManagers[this.id + "_ComboBox"] = g; 
            this.usedComboBox = true;
        });
    };

})(jQuery);