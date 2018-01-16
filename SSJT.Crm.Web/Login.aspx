<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SSJT.Crm.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>系统登录</title>
    <%--<link href="Content/themes/default/easyui.css" rel="stylesheet" />
    
    <script src="Scripts/jquery/messages_zh.min.js"></script>
    <script src="Scripts/jquery/jquery.easyui.min.js"></script>
    <script src="Scripts/jquery/easyui-lang-zh_CN.js"></script>
    --%>
    <link href="Scripts/ligerUI/skins/ext/css/ligerui-dialog.css" rel="stylesheet" />
    <script src="Scripts/jquery/jquery-1.11.1.js"></script>
    <script src="Scripts/jquery/jquery.md5.js"></script>
    <script src="Scripts/jquery/jquery.validate.min.js"></script>
    <script src="Scripts/ligerUI/js/plugins/ligerDialog.js"></script>

    <script type="text/javascript">
        $(function () {
            $('#btnReset').click(function () {
                $(':input', '#form1').not(':button,:submit,:reset,:hidden').val('');
            });
            $('#btnLogin').click(function () {
                //validateInfo();
                onLogin();
            });
        });
        var onLogin = function () {
            //data.push({name:'Action',value:'login'});
            validate();
            var data = $('#form').serializeArray();
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: '/Handler/LoginHandler.ashx',
                data: data.push({ name: 'Action', value: 'login' }),
                success: function (data) {

                },
                beforeSend: function () {
                    $.ligerDialog.waitting("正在登陆中,请稍后...");
                    $('#btnLogin').attr('disable', true);
                }
            })
        }
        var validate = function () {
            $('#form').validate({
                rules: {
                    UserID: "required",
                    PassWord: {
                        required: true,
                        minlength: 5
                    },
                    ValidateCode: "required"
                },
                messages: {
                    UserID: "请输入用户名",
                    PassWord: {
                        required: "请输入密码",
                        minlength: "密码长度不能小于 5 个字母"
                    },
                    ValidateCode: "请输入验证码"
                },
                errorElement: "font",
                errorPlacement: function (error, element) {
                    // Append error within linked label
                    $(element)
                        .closest("form")
                        .find("label[for='" + element.attr("name") + "']")
                        .append(error);
                }
            })

        }
    </script>
    <style>
        body {
            background: url(images/login/loginbackground.jpg) repeat-x;
        }

        .login-div {
            background: url(images/login/login_02.gif);
            width: 200px;
            height: 200px;
            display: inline-block;
        }

        .login-div-input {
            display: inline-block;
            float: right;
            padding-top: 60px;
            position: absolute;
            width:100%;
        }
        .login-div-input>div {
            position:relative;
        }
        .validate-div {
            float:left;
        }

            .validate-div div {
                display: inline-block;
            }

            .validate-div input {
                width: 80px;
            }

            .validate-div img {
                cursor: pointer;
                border: 1px solid #ddd
            }

        .login-button-div {
           margin-top: 15px;
        }

            .login-button-div div {
                display: inline-block;
                width: 85px;
            }

            .login-button-div input {
                width: 70px;
                height: 30px;
                cursor: pointer;
            }

        .error {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form" method="post">
        <div style="margin-top: 200px;">
            <div style="display: inline-block;">
                <a href="http://www.baidu.com" target="_blank">
                    <img src="images/login/Login.jpg" /></a>
            </div>
            <div class="login-div">
            </div>
            <div class="login-div-input">
                <div>
                    <input type="text" name="UserID" />
                    <label for="UserID"></label>
                    <br />
                </div>
                <div style="height: 12px;"></div>
                <div>
                    <input type="password" name="PassWord" />
                    <label for="PassWord"></label>
                    <br />
                </div>
                <div style="height: 12px;"></div>
                <div style="height:25px;">
                    <div class="validate-div">
                        <div style="margin-right: 2px;">
                            <input type="text" name="ValidateCode" />
                        </div>

                        <div style="float: right; padding: 2px;">
                            <img onclick="this.src=this.src+'?'" src="ValidateCode.ashx" alt="看不清楚，换一张" title="看不清楚，换一张" />
                        </div>
                    </div>
                    <div>
                        <label for="ValidateCode"></label>
                    </div>
                </div>
                
                <div class="login-button-div">
                    <div>
                        <input type="submit" id="btnLogin" value="登录" />
                    </div>
                    <div>
                        <input type="button" id="btnReset" value="重置"/>
                    </div>

                </div>
            </div>
        </div>

    </form>
</body>
</html>
