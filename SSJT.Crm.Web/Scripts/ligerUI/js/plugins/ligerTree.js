/**
* jQuery ligerUI 1.0.0
* 
* Author leoxie [ gd_star@163.com ] 
* 
*/
if(typeof (LigerUIManagers) == "undefined") LigerUIManagers = {};
(function ($)
{
    ///	<param name="$" type="jQuery"></param>

    $.fn.ligerGetTreeManager = function ()
    {
        return LigerUIManagers[this[0].id + "_Tree"];
    };
    $.fn.ligerRemoveTreeManager = function ()
    {
        return this.each(function ()
        {
            LigerUIManagers[this.id + "_Tree"] = null;
        });
    };
    $.fn.ligerTree = function (p)
    {
        return this.each(function ()
        {
            p = $.extend({ 
                url: null,
                data: null,
                checkbox: true,
                autoCheckboxEven : true,
                parentIcon: 'folder',
                childIcon: 'leaf',
                textFieldName: 'text',
                attribute : ['id','url'],
                nodeWidth: 70,
                onBeforeExpand : null,
                onExpand : null,
                onBeforeCollapse: null,
                onCollapse : null,
                onBeforeSelect :null,
                onSelect :null,
                onBeforeCancelSelect :null,
                onCancelselect :null,
                onCheck :null,
                onSuccess:null,
                onError:null,
                onClick:null
            }, p || {});
            if (this.usedTree) return;
            if ($(this).hasClass('l-hidden')) { return; }
            //public Object
            var g = {
                getData :function()
                {
                    return g.data;
                },
                //是否包含子节点
                hasChildren: function (treenode)
                {
                    return $("> ul", treenode).length > 0;
                },
                //获取父节点
                getParentTreeItem: function (treenode, level)
                {
                    var treeitem = $(treenode);
                    if (treeitem.parent().hasClass("l-tree"))
                        return null;
                    if (level == undefined)
                    {
                        if (treeitem.parent().parent("li").length == 0)
                            return null;
                        return treeitem.parent().parent("li")[0];
                    }
                    var currentLevel = parseInt(treeitem.attr("outlinelevel"));
                    var currenttreeitem = treeitem;
                    for (var i = currentLevel - 1; i >= level; i--)
                    {
                        currenttreeitem = currenttreeitem.parent().parent("li");
                    }
                    return currenttreeitem[0];
                },
                getChecked: function ()
                {
                    if (!p.checkbox) return null;
                    var nodes = [];
                    $(".l-checkbox-checked", g.tree).parent().parent("li").each(function ()
                    {
                        var treedataindex = parseInt($(this).attr("treedataindex"));
                        nodes.push({ target: this,data:po.getDataNodeByTreeDataIndex(g.data,treedataindex) });
                    });
                    return nodes;
                },
                getSelected: function ()
                {
                    var node = {}; 
                    node.target = $(".l-selected", g.tree).parent("li")[0];
                    if (node.target)
                    {
                        var treedataindex = parseInt($(node.target).attr("treedataindex"));
                        node.data = po.getDataNodeByTreeDataIndex(g.data,treedataindex);
                        return node;
                    }
                    return null;
                },
                //升级为父节点级别
                upgrade: function (treeNode)
                {
                    $(".l-note", treeNode).each(function ()
                    {
                        $(this).removeClass("l-note").addClass("l-expandable-open");
                    });
                    $(".l-note-last", treeNode).each(function ()
                    {
                        $(this).removeClass("l-note-last").addClass("l-expandable-open");
                    });
                    $("." + po.getChildNodeClassName(), treeNode).each(function ()
                    {
                        $(this)
                        .removeClass(po.getChildNodeClassName())
                        .addClass(po.getParentNodeClassName(true));
                    });
                },
                //降级为叶节点级别
                demotion: function (treeNode)
                {
                    if (!treeNode && treeNode[0].tagName.toLowerCase() != 'li') return;
                    var islast = $(treeNode).hasClass("l-last");
                    $(".l-expandable-open", treeNode).each(function ()
                    {
                        $(this).removeClass("l-expandable-open")
                        .addClass(islast ? "l-note-last" : "l-note");
                    });
                    $(".l-expandable-close", treeNode).each(function ()
                    {
                        $(this).removeClass("l-expandable-close")
                        .addClass(islast ? "l-note-last" : "l-note");
                    });
                    $("." + po.getParentNodeClassName(true), treeNode).each(function ()
                    {
                        $(this)
                        .removeClass(po.getParentNodeClassName(true))
                        .addClass(po.getChildNodeClassName());
                    });
                },
                collapseAll: function ()
                {
                    $(".l-expandable-open", g.tree).click();
                },
                expandAll: function ()
                {
                    $(".l-expandable-close", g.tree).click();
                },
                loadData: function (node, url,param)
                {
                    g.loading.show(); 
                    param = param || {}; 
                    //请求服务器
                    $.ajax({
                        type: 'post',
                        url: url, 
                        data: param, 
                        dataType: 'json',
                        success: function (data)
                        {  
                            g.loading.hide();
                            g.append(node, data); 
                            if (p.onSuccess) p.onSuccess(data);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown)
                        { 
                            try
                            {
                                g.loading.hide();
                                if (p.onError)
                                    p.onError(XMLHttpRequest, textStatus, errorThrown);
                            }
                            catch (e)
                            {

                            }
                        }
                    });
                },
                //清空
                clear: function ()
                {
                    //g.tree.html("");
                    $("> li",g.tree).each(function(){ g.remove(this);});
                },
                remove: function (treeNode)
                {
                    var treedataindex = parseInt($(treeNode).attr("treedataindex"));
                    var treenodedata = po.getDataNodeByTreeDataIndex(g.data,treedataindex); 
                    if(treenodedata) po.setTreeDataStatus([treenodedata],'delete');
                    var parentNode = g.getParentTreeItem(treeNode);
                    //复选框处理
                    if (p.checkbox)
                    {
                        $(".l-checkbox", treeNode).remove();
                        po.setParentCheckboxStatus($(treeNode));
                    }
                    $(treeNode).remove();
                    if (parentNode == null) //代表顶级节点
                    {
                        parentNode = g.tree.parent();
                    }
                    //set parent
                    var treeitemlength = $("> ul > li", parentNode).length;
                    if (treeitemlength > 0)
                    {
                        //遍历设置子节点
                        $("> ul > li", parentNode).each(function (i, item)
                        {
                            if (i == 0 && !$(this).hasClass("l-first"))
                                $(this).addClass("l-first");
                            if (i == treeitemlength - 1 && !$(this).hasClass("l-last"))
                                $(this).addClass("l-last");
                            if (i == 0 && i == treeitemlength - 1 && !$(this).hasClass("l-onlychild"))
                                $(this).addClass("l-onlychild");
                            $("> div .l-note,> div .l-note-last", this)
                           .removeClass("l-note l-note-last")
                           .addClass(i == treeitemlength - 1 ? "l-note-last" : "l-note");
                            po.setTreeItem(this, { isLast: i == treeitemlength - 1 });
                        });
                    } else
                    {
                        //g.demotion(parentNode);
                    }

                },
                //增加节点集合
                append: function (parentNode, newdata)
                {
                    if (!newdata || !newdata.length) return false;
                    po.addTreeDataIndexToData(newdata);
                    po.setTreeDataStatus(newdata,'add'); 
                    po.appendData(parentNode,newdata);  
                    data = newdata;
                    if (!parentNode)//增加到根节点
                    {
                        //remove last node class
                        if ($("> li:last", g.tree).length > 0)
                            po.setTreeItem($("> li:last", g.tree)[0], { isLast: false });

                        var treeItemLengthBeforeAppend = $("> li", g.tree).length;
                        $("> li", $(po.getTreeHTML(data))).appendTo(g.tree);
                        var treeItemLength = $("> li", g.tree).length;
                        //遍历设置子节点
                        $("> li", g.tree).each(function (i, item)
                        {
                            if (i <= treeItemLengthBeforeAppend - 1) return;
                            po.initTreeItem($(this), 1, i == 0, i == treeItemLength - 1);
                        });
                        return;
                    }
                    var treeitem = $(parentNode);
                    var outlineLevel = parseInt(treeitem.attr("outlinelevel"));
                    //bulid 'ul' when 'ul' not existed
                    var hasChildren = $("> ul", treeitem).length > 0;
                    if (!hasChildren)
                    {
                        treeitem.append("<ul class='l-children'></ul>");
                        //设置为父节点
                        g.upgrade(parentNode);
                    }
                    //remove last node class 
                    if ($("> .l-children > li:last", treeitem).length > 0)
                        po.setTreeItem($("> .l-children > li:last", treeitem)[0], { isLast: false });

                    var treeItemLengthBeforeAppend = $("> ul > li", treeitem).length;
                    $("> li", $(po.getTreeHTML(data))).appendTo($("> ul", treeitem));
                    var treeItemLength = $("> ul > li", treeitem).length;
                    //遍历设置子节点
                    $("> ul > li", treeitem).each(function (i, item)
                    {
                        if (i <= treeItemLengthBeforeAppend - 1) return;
                        po.initTreeItem($(this), outlineLevel + 1, i == 0, i == treeItemLength - 1);
                    }); 
                    po.upadteTreeWidth();
                }
            };
            //private Object
            var po = { 
                getDataNodeByTreeDataIndex:function(data,treedataindex)
                { 
                    for(var i =0;i<data.length;i++)
                    {
                        if(data[i].treedataindex == treedataindex)
                            return data[i];
                        if(data[i].children)
                        {
                            var targetData= po.getDataNodeByTreeDataIndex(data[i].children,treedataindex);
                            if(targetData) return targetData;
                        }
                    }
                    return null;
                },
                setTreeDataStatus : function(data,status)
                {
                    $(data).each(function ()
                    { 
                        this.__status = status;
                        if(this.children)
                        {
                            po.setTreeDataStatus(this.children,status);
                        }
                    });
                },
                addTreeDataIndexToData : function(data)
                {
                    $(data).each(function ()
                    {
                        if(this.treedataindex != undefined) return;
                        this.treedataindex = g.treedataindex++;
                        if(this.children)
                        {
                            po.addTreeDataIndexToData(this.children);
                        }
                    });
                },
                appendData: function (treeNode,data)
                {
                    var treedataindex = parseInt($(treeNode).attr("treedataindex"));
                    var treenodedata = po.getDataNodeByTreeDataIndex(g.data,treedataindex); 
                    if(g.treedataindex == undefined) g.treedataindex = 0; 
                    if(treenodedata && treenodedata.children == undefined) treenodedata.children =[];
                    $(data).each(function (i,item)
                    {
                        if(treenodedata)
                            treenodedata.children[treenodedata.children.length] = $.extend({},item); 
                        else
                            g.data[g.data.length] =  $.extend({},item); 
                    });
                },
                setTreeItem: function (treeNode, options)
                {
                    if (!options) return;
                    var treeItem = $(treeNode);
                    var outlineLevel = parseInt(treeItem.attr("outlinelevel"));
                    if (options.isLast != undefined)
                    {
                        if (options.isLast == true)
                        {
                            treeItem.removeClass("l-last").addClass("l-last");
                            $("> div .l-note", treeItem).removeClass("l-note").addClass("l-note-last");
                            $(".l-children li", treeItem)
                            .find(".l-box:eq(" + (outlineLevel - 1) + ")")
                            .removeClass("l-line");
                        }
                        else if (options.isLast == false)
                        {
                            treeItem.removeClass("l-last");
                            $("> div .l-note-last", treeItem).removeClass("l-note-last").addClass("l-note");

                            $(".l-children li", treeItem)
                            .find(".l-box:eq(" + (outlineLevel - 1) + ")")
                            .removeClass("l-line")
                            .addClass("l-line");
                        }
                    }
                },
                //make tree html by data
                getTreeHTML: function (data)
                {
                    var treehtml = "<ul class='l-children'>";
                    for (var i = 0; i < data.length; i++)
                    {
                        treehtml += '<li ';
                        if(data[i].treedataindex!=undefined)
                            treehtml += 'treedataindex="'+data[i].treedataindex+'" ';
                        if(data[i].isexpand!=undefined)
                            treehtml += 'isexpand='+data[i].isexpand +' ';
                        //增加属性支持
                        for(var j=0;j<p.attribute.length;j++)
                        {
                            if(data[i][p.attribute[j]])
                                treehtml += p.attribute[j] + '="'+data[i][p.attribute[j]]+'" '; 
                        }
                        treehtml +='>'; 
                        treehtml += '<span>' + data[i].text + '</span>';
                        //add children
                        if (data[i].children)
                        {
                            treehtml += po.getTreeHTML(data[i].children);
                        }
                        treehtml += '</li>';
                    }
                    treehtml += "</ul>";
                    return treehtml;
                },
                upadteTreeWidth: function ()
                {
                    if (!g.maxOutlineLevel) g.maxOutlineLevel = 1;
                    var treeWidth = g.maxOutlineLevel * 22;
                    if (p.checkbox) treeWidth += 22;
                    if (p.parentIcon || p.childIcon) treeWidth += 22;
                    treeWidth += p.nodeWidth;
                    g.tree.width(treeWidth);
                },
                getChildNodeClassName: function ()
                {
                    return 'l-tree-icon-' + p.childIcon;
                },
                getParentNodeClassName: function (isOpen)
                {
                    var nodeclassname = 'l-tree-icon-' + p.parentIcon;
                    if (isOpen) nodeclassname += '-open';
                    return nodeclassname;
                },
                applyTree: function ()
                {
                    //init 
                    var treeitemlength = $("> li", g.tree).length;
                    if(treeitemlength==0) return;
                    $("> li", g.tree).each(function (i, item)
                    {
                        var dataindex = g.data.length;
                        g.data[dataindex] = 
                        {
                            text:$("> span,> a",this).text(),
                            treedataindex:g.treedataindex++
                        }; 
                        for(var j=0;j<p.attribute.length;j++)
                        {
                            if($(this).attr(p.attribute[j]))
                                g.data[dataindex][p.attribute[j]] = $(this).attr(p.attribute[j]);
                        }
                        po.initTreeItem($(this), 1, i == 0, i == treeitemlength - 1,g.data[dataindex]);
                    });
                    po.upadteTreeWidth();
                },
                applyTreeEven: function (treeNode)
                { 
                    $("> .l-body", treeNode).hover(function ()
                    {
                        $(this).addClass("l-over");
                    }, function ()
                    {
                        $(this).removeClass("l-over");
                    }); 
                },
                setTreeEven : function()
                {
                    g.tree.click(function (e)
                    { 
                        var obj = (e.target || e.srcElement);
                        var treeitem = null;
                        if(obj.tagName.toLowerCase() == "a" || obj.tagName.toLowerCase()=="span" || $(obj).hasClass("l-box"))
                            treeitem = $(obj).parent().parent();  
                        else if($(obj).hasClass("l-body"))
                            treeitem = $(obj).parent();
                        else
                            treeitem = $(obj);
                        if(!treeitem) return;
                        var treedataindex = parseInt(treeitem.attr("treedataindex"));
                        var treenodedata = po.getDataNodeByTreeDataIndex(g.data,treedataindex); 
                        if (!$(obj).hasClass("l-expandable-open") && !$(obj).hasClass("l-expandable-close"))
                        {
                            if ($(">div:first",treeitem).hasClass("l-selected"))
                            {
                                if(p.onBeforeCancelSelect 
                                && p.onBeforeCancelSelect({data:treenodedata,target:treeitem[0]}) == false)
                                    return false;
                                $(">div:first",treeitem).removeClass("l-selected");
                                p.onCancelSelect && p.onCancelSelect({data:treenodedata,target:treeitem[0]});
                            }
                            else
                            { 
                                if(p.onBeforeSelect 
                                && p.onBeforeSelect({data:treenodedata,target:treeitem[0]}) == false)
                                    return false;
                                $(".l-body", g.tree).removeClass("l-selected");
                                $(">div:first",treeitem).addClass("l-selected");
                                 p.onSelect && p.onSelect({data:treenodedata,target:treeitem[0]});
                            }
                        }
                         //状态：已经张开
                        if ($(obj).hasClass("l-expandable-open"))
                        {
                            if(p.onBeforeCollapse 
                            && p.onBeforeCollapse({data:treenodedata,target:treeitem[0]}) == false)
                                return false;
                            $(obj).removeClass("l-expandable-open").addClass("l-expandable-close");
                            $("> .l-children", treeitem).slideToggle('fast');
                            $("> div ." + po.getParentNodeClassName(true), treeitem)
                            .removeClass(po.getParentNodeClassName(true))
                            .addClass(po.getParentNodeClassName());
                            p.onCollapse && p.onCollapse({data:treenodedata,target:treeitem[0]});
                        }
                        //状态：没有张开
                        else if ($(obj).hasClass("l-expandable-close"))
                        {
                            if(p.onBeforeExpand 
                            && p.onBeforeExpand({data:treenodedata,target:treeitem[0]}) == false)
                                return false;
                            $(obj).removeClass("l-expandable-close").addClass("l-expandable-open");
                            $("> .l-children", treeitem).slideToggle('fast',function(){
                                p.onExpand && p.onExpand({data:treenodedata,target:treeitem[0]});
                            });
                            $("> div ." + po.getParentNodeClassName(), treeitem)
                            .removeClass(po.getParentNodeClassName())
                            .addClass(po.getParentNodeClassName(true)); 
                        }
                        //chekcbox even
                        else if ($(obj).hasClass("l-checkbox") && p.autoCheckboxEven)
                        {
                            //状态：未选中
                            if ($(obj).hasClass("l-checkbox-unchecked"))
                            {
                                $(obj).removeClass("l-checkbox-unchecked").addClass("l-checkbox-checked");
                                $(".l-children .l-checkbox", treeitem)
                                .removeClass("l-checkbox-incomplete l-checkbox-unchecked")
                                .addClass("l-checkbox-checked");
                                p.onCheck && p.onCheck({data:treenodedata,target:treeitem[0]},true);
                            }
                            //状态：选中
                            else if ($(obj).hasClass("l-checkbox-checked"))
                            {
                                $(obj).removeClass("l-checkbox-checked").addClass("l-checkbox-unchecked");
                                $(".l-children .l-checkbox", treeitem)
                                .removeClass("l-checkbox-incomplete l-checkbox-checked")
                                .addClass("l-checkbox-unchecked");
                                p.onCheck && p.onCheck({data:treenodedata,target:treeitem[0]},false);
                            }
                            //状态：未完全选中
                            else if ($(obj).hasClass("l-checkbox-incomplete"))
                            {
                                $(obj).removeClass("l-checkbox-incomplete").addClass("l-checkbox-checked");
                                $(".l-children .l-checkbox", treeitem)
                                .removeClass("l-checkbox-incomplete l-checkbox-unchecked")
                                .addClass("l-checkbox-checked");
                                p.onCheck && p.onCheck({data:treenodedata,target:treeitem[0]},true);
                            }
                            po.setParentCheckboxStatus(treeitem);
                        } 
                        p.onClick && p.onClick({data:treenodedata,target:treeitem[0]});
                    }); 
                },
                //递归设置父节点的状态
                setParentCheckboxStatus: function (treeitem)
                {
                    //当前同级别或低级别的节点是否都选中了
                    var isCheckedComplete = $(".l-checkbox-unchecked", treeitem.parent()).length == 0;
                    //当前同级别或低级别的节点是否都没有选中
                    var isCheckedNull = $(".l-checkbox-checked", treeitem.parent()).length == 0;
                    if (isCheckedComplete)
                    {
                        treeitem.parent().prev().find(".l-checkbox")
                                    .removeClass("l-checkbox-unchecked l-checkbox-incomplete")
                                    .addClass("l-checkbox-checked");
                    }
                    else if (isCheckedNull)
                    {
                        treeitem.parent().prev().find("> .l-checkbox")
                                    .removeClass("l-checkbox-checked l-checkbox-incomplete")
                                    .addClass("l-checkbox-unchecked");
                    }
                    else
                    {
                        treeitem.parent().prev().find("> .l-checkbox")
                                    .removeClass("l-checkbox-unchecked l-checkbox-checked")
                                    .addClass("l-checkbox-incomplete");
                    }
                    if (treeitem.parent().parent("li").length > 0)
                        po.setParentCheckboxStatus(treeitem.parent().parent("li"));
                },
                initTreeItem: function (treeitem, outlineLevel, isFirst, isLast,data)
                {
                    if (treeitem.attr("outlinelevel")) return;
                    if (!g.maxOutlineLevel || g.maxOutlineLevel < outlineLevel)
                        g.maxOutlineLevel = outlineLevel;
                    treeitem.attr("outlinelevel", outlineLevel);
                    if(data && data.treedataindex != undefined && !treeitem.attr("treedataindex"))
                        treeitem.attr("treedataindex",data.treedataindex);
                    var isExpand = treeitem.attr("isexpand");
                    if (isFirst && !treeitem.hasClass("l-first")) treeitem.addClass("l-first");
                    if (isLast && !treeitem.hasClass("l-last")) treeitem.addClass("l-last");
                    if (isFirst && isLast && !treeitem.hasClass("l-onlychild")) treeitem.addClass("l-onlychild");
                    $("> span,> a", treeitem).wrap("<div></div>");
                    if (!$("> div", treeitem).hasClass("l-body")) $("> div", treeitem).addClass("l-body");
                    //包含子节点
                    if (g.hasChildren(treeitem[0]))
                    {
                        if (p.parentIcon)
                            $("> div", treeitem).prepend('<div class="l-box ' + po.getParentNodeClassName(true) + '"></div>');
                        if (p.checkbox)
                            $("> div", treeitem).prepend('<div class="l-box l-checkbox l-checkbox-unchecked"></div>');
                        $("> div", treeitem).prepend('<div class="l-box l-expandable-open"></div>');
                        var treeitemlength = $("> ul > li", treeitem).length;
                        if (!$("> ul", treeitem).hasClass("l-children")) 
                            $("> ul", treeitem).addClass("l-children");
                        if(data && data.children == undefined) data.children=[];
                        //遍历设置子节点
                        $("> ul > li", treeitem).each(function (i, item)
                        {
                            if(data)
                            {
                                var dataindex = data.children.length; 
                                data.children[dataindex] = 
                                {
                                    text:$("> span,> a",this).text(),
                                    treedataindex:g.treedataindex++
                                }; 
                                for(var j=0;j<p.attribute.length;j++)
                                {
                                    if($(this).attr(p.attribute[j]))
                                        data.children[dataindex][p.attribute[j]] = $(this).attr(p.attribute[j]);
                                }

                                po.initTreeItem($(this), outlineLevel + 1, i == 0, i == treeitemlength - 1,data.children[dataindex]);
                            }
                            else
                            {
                                po.initTreeItem($(this), outlineLevel + 1, i == 0, i == treeitemlength - 1);
                            }
                        });
                    }
                    //不包含子节点
                    else
                    {
                        if (p.childIcon)
                            $("> div", treeitem).prepend('<div class="l-box ' + po.getChildNodeClassName() + '"></div>');
                        if (p.checkbox)
                            $("> div", treeitem).prepend('<div class="l-box l-checkbox l-checkbox-unchecked"></div>');
                        if (isLast)
                            $("> div", treeitem).prepend('<div class="l-box l-note-last"></div>');
                        else
                            $("> div", treeitem).prepend('<div class="l-box l-note"></div>');
                    }
                    for (var i = outlineLevel - 1; i >= 1; i--)
                    {
                        var currentParentTreeItem = $(g.getParentTreeItem(treeitem[0], i));
                        if (currentParentTreeItem.hasClass("l-last"))
                            $("> div", treeitem).prepend('<div class="l-box"></div>');
                        else
                            $("> div", treeitem).prepend('<div class="l-box l-line"></div>');
                    }
                    if (g.hasChildren(treeitem[0]) && isExpand != undefined && (isExpand == 'false' || isExpand == false))
                    {

                        $("> div .l-expandable-open", treeitem)
                         .removeClass("l-expandable-open")
                         .addClass("l-expandable-close");
                        $("> .l-children", treeitem).hide();

                        $("> div ." + po.getParentNodeClassName(true), treeitem)
                         .removeClass(po.getParentNodeClassName(true))
                         .addClass(po.getParentNodeClassName());
                    } 
                    //visual init
                    if ($(treeitem).hasClass("l-expandable-open"))
                    {
                        $("> .l-children", treeitem).show();
                    }
                    else if ($(this).hasClass("l-expandable-close"))
                    {
                        $("> .l-children", treeitem).hide();
                    }
                    po.applyTreeEven(treeitem[0]);
                }
            };
            if (!$(this).hasClass('l-tree')) $(this).addClass('l-tree');
            g.tree = $(this);
            g.loading = $("<div class='l-tree-loading'></div>");
            g.tree.after(g.loading);
            g.data = [];
            g.treedataindex = 0;
            po.applyTree();
            po.setTreeEven();
            if (p.data)
            {
                g.append(null, p.data);
            }
            if (p.url)
            {
                g.loadData(null, p.url);
            }
            if (this.id == undefined || this.id == "") this.id = "LigerUI_" + new Date().getTime();
            LigerUIManagers[this.id + "_Tree"] = g;
            this.usedTree = true;
        });
    };

})(jQuery);