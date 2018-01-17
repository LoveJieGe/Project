<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loader.aspx.cs" Inherits="SSJT.Crm.Web.Loader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        #layout {
            width: 100%;
        }
        body {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
            overflow: hidden;
            font-family: Verdana, Geneva, sans-serif;
            font-size: 12px
        }

        .layout-top-outter {
            width: 100%;
            border: 1px solid #BED5F3;
            background: url('Images/login/bgl.png') left top no-repeat;
            z-index: 10;
        }

        .layout-top-inner {
            background: url('Images/login/bgr.png') right top no-repeat;
            height: 100%;
            width: 100%;
        }

        .layout-top-content {
            overflow: hidden;
            height: 47px;
            margin: 0;
            padding: 0
        }

        .avatar {
            width: 50px;
            margin: 5px;
            display: inline-block;
        }
    </style>
    <link href="Scripts/easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="Scripts/easyui/themes/icon.css" rel="stylesheet" />
    <script src="Scripts/easyui/jquery.min.js"></script>
    <script src="Scripts/easyui/jquery.easyui.min.js"></script>
    <script src="Scripts/jquery/jquery.jclock.js"></script>
    <script type="text/javascript">
        var leftAccordion = null;
        var rightAccordion = null;
        var centerTab = null;
        $(function () {
            //$("#tree1").ligerTree();
            $('#layout').layout();
            //加载时间轴
            $('#jclock').jclock({
                withDate: true,
                withWeek: true
            });
            $("#pageloading").fadeOut(800);
        });

    </script>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server" style="height: 734px">
        <div data-options="region:'north',border:false" class="layout-top-outter" style="height: 75px; overflow: hidden;">
            <div class="layout-top-inner">
                <div class="layout-top-content">
                    <div style="display: inline-block; height: 100%;">
                        <a href="http://www.baidu.com" target="_blank">
                            <img src="images/login/Login.jpg" style="height: 100%;" /></a>
                    </div>
                    <div style="float: right; height: 100%;">
                        <div style="display: inline-block; padding: 5px;">
                            <div id="jclock"></div>
                            <div></div>
                        </div>
                        <div class="avatar">
                        </div>
                    </div>
                </div>
                <div>
                </div>
            </div>
        </div>
        <div data-options="region:'west',split:true,title:'菜单列表'" style="width: 180px; padding: 10px;">west content</div>
        <div data-options="region:'east',split:true,collapsed:true,title:'菜单列表'" style="width: 180px; padding: 10px;">east region</div>
        <div data-options="region:'center'">
            <div class="easyui-tabs" data-options="fit:true,border:false,plain:true">
                <div title="桌面" data-options="href:'_content.html'" style="padding: 10px" id="home"></div>
                <%--<div title="DataGrid" style="padding:5px">
                    <table class="easyui-datagrid"
                           data-options="url:'datagrid_data1.json',method:'get',singleSelect:true,fit:true,fitColumns:true">
                        <thead>
                        <tr>
                            <th data-options="field:'itemid'" width="80">Item ID</th>
                            <th data-options="field:'productid'" width="100">Product ID</th>
                            <th data-options="field:'listprice',align:'right'" width="80">List Price</th>
                            <th data-options="field:'unitcost',align:'right'" width="80">Unit Cost</th>
                            <th data-options="field:'attr1'" width="150">Attribute</th>
                            <th data-options="field:'status',align:'center'" width="50">Status</th>
                        </tr>
                        </thead>
                    </table>
                </div>--%>
            </div>
        </div>
        <div data-options="region:'south',border:false" style="height: 25px; background: #E0ECFF; overflow: hidden; text-align: center; padding: 2px;">
            Copyright © 2017-2020 yjyrj.com All Rights Reserved
            <a href="http://www.baidu.com" target="_blank">CRM软件</a> QQ:1651645004  v1.15 
        </div>
    </form>
</body>
</html>
