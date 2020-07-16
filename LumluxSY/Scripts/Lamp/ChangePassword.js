
// 母页面
var LayoutPage = function () {
    var handleLayout = function () {

        $("#closealert").click(function () {
            $("#alert1")[0].hidden = true;
        })

        //确认修改密码
        $("#comfirmpsd").click(function () {
            if (($("#oldpsd")[0].textLength > 20) || ($("#newpsd1")[0].textLength > 20) || ($("#newpsd2")[0].textLength > 20)) {
                $("#alertInfo").text("密码个数不能超过20！")
                $("#alert1")[0].hidden = false;
                return;
            }
            if (($("#oldpsd")[0].value == "") || ($("#newpsd1")[0].value == "") || ($("#newpsd2")[0].value == "")) {
                $("#alertInfo").text("不能为空！")
                $("#alert1")[0].hidden = false;
                return;
            }
            if ($("#oldpsd")[0].value == $("#newpsd1")[0].value) {
                $("#alertInfo").text("新密码与原密码不能完全相同！")
                $("#alert1")[0].hidden = false;
                return;
            }
            if ($("#newpsd2")[0].value != $("#newpsd1")[0].value) {
                $("#alertInfo").text("新密码与确认密码必须相同！")
                $("#alert1")[0].hidden = false;
                return;
            }
            $("#alert1")[0].hidden = true;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '/Lamp/Shared/ChangePassWordResult?sOldpassword=' + $("#oldpsd")[0].value + '&sNewpassword=' + $("#newpsd1")[0].value,
                dataType: "json",
                success: function (data) {
                    switch (data) {
                        case 0:
                            $("#alertInfo").text("请先登录！")
                            $("#alert1")[0].hidden = false;
                            break;
                        case 1:
                            $("#alertInfo").text("参数错误！")
                            $("#alert1")[0].hidden = false;
                            break;
                        case 2:
                            $("#alertInfo").text("未发现该主机！")
                            $("#alert1")[0].hidden = false;
                            break;
                        case 3:
                            $("#alertInfo").text("主机密码错误！")
                            $("#alert1")[0].hidden = false;
                            break;
                        case 4:
                            $("#alertInfo").text("数据库错误！")
                            $("#alert1")[0].hidden = false;
                            break;
                        case 5:
                            $("#alertInfo").text("密码修改成功！")
                            $("#alert1")[0].hidden = false;
                            $("#closebtn2").click();
                            break;
                        default:
                            $("#alertInfo").text("请重启浏览器！")
                            $("#alert1")[0].hidden = false;
                            break;

                    }
                },
                error: function (error) {
                    alert(error.responseText);
                }
            })
        })

        //关闭修改密码界面1
        $("#closebtn1").click(function () {
            $("#oldpsd")[0].value = "";
            $("#newpsd1")[0].value = "";
            $("#newpsd2")[0].value = "";
            $("#alert1")[0].hidden = true;
        })
        //关闭修改密码界面2
        $("#closebtn2").click(function () {
            $("#oldpsd")[0].value = "";
            $("#newpsd1")[0].value = "";
            $("#newpsd2")[0].value = "";
            $("#alert1")[0].hidden = true;
        })
    }
    return {
        //main function to initiate the module
        init: function () {
            handleLayout();
        }

    };

}();

// 页面初始化
jQuery(document).ready(function () {
    $("#alert1")[0].hidden = true;
    LayoutPage.init();
});