// 母页面
var LayoutPage = function () {
    var handleLayout = function () {
        //单点控制的调光按钮是否显示
        $("#modeswitch").on('switchChange.bootstrapSwitch', function (e, data) {
            if ($("#modeswitch").is(':checked'))
                $("#slider1").show();
            else
                $("#slider1").hide();
        });
        //组控制的调光按钮是否显示
        //$("#modeswitch1").on('switchChange.bootstrapSwitch', function (e, data) {
        //    if ($("#modeswitch1").is(':checked'))
        //        $("#slider2").show();
        //    else
        //        $("#slider2").hide();
        //});

        //$("#closealert").click(function () {
        //    $("#alert1")[0].hidden = true;
        //})

        ////确认修改密码
        //$("#comfirmpsd").click(function () {
        //    if (($("#oldpsd")[0].textLength > 20) || ($("#newpsd1")[0].textLength > 20) || ($("#newpsd2")[0].textLength > 20))
        //    {
        //        $("#alertInfo").text("密码个数不能超过20！")
        //        $("#alert1")[0].hidden = false;
        //        return;
        //    }
        //    if (($("#oldpsd")[0].value == "") || ($("#newpsd1")[0].value == "") || ($("#newpsd2")[0].value == "")) {
        //        $("#alertInfo").text("不能为空！")
        //        $("#alert1")[0].hidden = false;
        //        return;
        //    }
        //    if ($("#oldpsd")[0].value == $("#newpsd1")[0].value) {
        //        $("#alertInfo").text("新密码与原密码不能完全相同！")
        //        $("#alert1")[0].hidden = false;
        //        return;
        //    }
        //    if ($("#newpsd2")[0].value != $("#newpsd1")[0].value)
        //    {
        //        $("#alertInfo").text("新密码与确认密码必须相同！")
        //        $("#alert1")[0].hidden = false;
        //        return;
        //    }
        //    $("#alert1")[0].hidden = true;
        //    $.ajax({
        //        type: "POST",
        //        contentType: "application/json; charset=utf-8",
        //        url: '/Lamp/Shared/ChangePassWordResult?sOldpassword=' + $("#oldpsd")[0].value + '&sNewpassword=' + $("#newpsd1")[0].value,
        //        dataType: "json",
        //        success: function (data) {
        //            switch (data) {
        //                case 0:
        //                    $("#alertInfo").text("请先登录！")
        //                    $("#alert1")[0].hidden = false;
        //                    break;
        //                case 1:
        //                    $("#alertInfo").text("参数错误！")
        //                    $("#alert1")[0].hidden = false;
        //                    break;
        //                case 2:
        //                    $("#alertInfo").text("未发现该主机！")
        //                    $("#alert1")[0].hidden = false;
        //                    break;
        //                case 3:
        //                    $("#alertInfo").text("主机密码错误！")
        //                    $("#alert1")[0].hidden = false;
        //                    break;
        //                case 4:
        //                    $("#alertInfo").text("数据库错误！")
        //                    $("#alert1")[0].hidden = false;
        //                    break;
        //                case 5:
        //                    $("#alertInfo").text("密码修改成功！")
        //                    $("#alert1")[0].hidden = false;
        //                    $("#closebtn2").click();
        //                    break;
        //                default:
        //                    $("#alertInfo").text("请重启浏览器！")
        //                    $("#alert1")[0].hidden = false;
        //                    break;

        //            }
        //        },
        //        error: function (error) {
        //            alert(error.responseText);
        //        }
        //    })
        //})

        ////关闭修改密码界面1
        //$("#closebtn1").click(function(){
        //    $("#oldpsd")[0].value="";
        //    $("#newpsd1")[0].value = "";
        //    $("#newpsd2")[0].value = "";
        //    $("#alert1")[0].hidden = true;
        //})
        ////关闭修改密码界面2
        //$("#closebtn2").click(function () {
        //    $("#oldpsd")[0].value = "";
        //    $("#newpsd1")[0].value = "";
        //    $("#newpsd2")[0].value = "";
        //    $("#alert1")[0].hidden = true;
        //})

        //修改所有select2的显示字
        $('#selecthostinfo').select2({
            placeholder: "目标主控",
            width: null
        });

        $('#selectlightinfo').select2({
            placeholder: "目标单灯",
            width: null
        });

        $('#selecthostinfo1').select2({
            placeholder: "目标主控",
            width: null
        });

        $('#selectlightgroupinfo').select2({
            placeholder: "目标群组",
            width: null
        });

        $('#selecthostinfo2').select2({
            placeholder: "目标主控",
            width: null
        });

        $("#selectcircuit").select2({
            placeholder: "目标回路",
            width: null
        });

        // demo 0
        $("#range0").ionRangeSlider({
            min: 0,
            max: 100,
            from: 100
        });
        // demo 0
        $("#range1").ionRangeSlider({
            min: 0,
            max: 100,
            from: 100
        });

        //load右菜单主机下拉框
        $("#selecthostinfo").on('select2:select', (function (e, data) {
            $("#selectlightguid").attr("value", "");
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '/Lamp/Shared/ReturnLight?sGUID=' + e.params.data.element.id,
                dataType: "json",
                success: function (data) {
                    if (data) {
                        //单灯选择下拉框
                        $("#selectlightinfo").val(null).trigger("change");//clear
                            var sli = "";
                            sli += "<option></option>";
                            for (c in data.LightInfoes) {
                                sli += "<option  id=" + data.LightInfoes[c].GUID + ">" + data.LightInfoes[c].Name + "</option>";
                            }
                            document.getElementById('selectlightinfo').innerHTML = sli;
                    }
                },
                error: function (error) {
                    //alert(error.responseText);
                }
            })
        }))

        //load右菜单主机1下拉框
        $("#selecthostinfo1").on('select2:select', (function (e, data) {
            $("#selectlightgroupguid").attr("value", "");
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '/Lamp/Shared/ReturnLightGroup?sGUID=' + e.params.data.element.id,
                dataType: "json",
                success: function (data) {
                    if (data) {
                        //单灯组选择下拉框
                        $("#selectlightgroupinfo").val(null).trigger("change");//clear
                        var slgi = "";
                        slgi += "<option></option>";
                        for (d in data.LightGroupInfoes) {
                            slgi += "<option  id=" + data.LightGroupInfoes[d].GUID + ">" + data.LightGroupInfoes[d].Name + "</option>";
                        }
                        document.getElementById('selectlightgroupinfo').innerHTML = slgi;
                    }
                },
                error: function (error) {
                    //alert(error.responseText);
                }
            })
        }))

        //load右菜单主机1下拉框
        $("#selecthostinfo2").on('select2:select', (function (e, data) {
            $("#selectcircuitguid").attr("value", "");
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '/Lamp/Shared/ReturnCircuit?sGUID=' + e.params.data.element.id,
                dataType: "json",
                success: function (data) {
                    //回路选择下拉框
                    $("#selectcircuit").val(null).trigger("change");//clear
                    if (data==1) {//大三遥
                        var slgi = "";
                        slgi = "<option></option><option value=0>所有回路</option><option value=1>回路一</option><option value=2>回路二</option><option value=3>回路三</option><option value=4>回路四</option><option value=5>回路五</option><option value=6>回路六</option>";
                        document.getElementById('selectcircuit').innerHTML = slgi;
                    }
                    else {//小三遥和其他
                        var slgi = "";
                        slgi = "<option></option><option value=0>所有回路</option><option value=1>回路一</option><option value=2>回路二</option><option value=3>回路三</option>";
                        document.getElementById('selectcircuit').innerHTML = slgi;
                    }
                },
                error: function (error) {
                   // alert(error.responseText);
                }
            })
        }))

        //Load右菜单主机
        $("#btnquicksidebar").click(function () {
            $("#selectlightguid").attr("value", "");
            $("#selectlightgroupguid").attr("value", "");
            $("#selectcircuitguid").attr("value","");
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '/Lamp/Shared/ReturnHostGroup',
                dataType: "json",
                success: function (data) {
                    if (data) {
                        //主机选择下拉框
                        $("#selecthostinfo").val(null).trigger("change");//clear
                        $("#selecthostinfo1").val(null).trigger("change");//clear
                        $("#selecthostinfo2").val(null).trigger("change");//clear
                        $("#selectlightinfo").val(null).trigger("change");//clear
                        $("#selectlightgroupinfo").val(null).trigger("change");//clear
                        $("#selectcircuit").val(null).trigger("change");//clear
                        var str = "";
                        str += "<option></option>";
                        for (i in data.GroupInfoes) {
                            str += "<optgroup label=" + data.GroupInfoes[i].Name + ">";
                            for(j in data.HostInfoes)
                            {
                                if (data.GroupInfoes[i].GUID == data.HostInfoes[j].GroupGUID)
                                    str += "<option id=" + data.HostInfoes[j].GUID + ">" + data.HostInfoes[j].Name + "</option>";
                            }
                            str+="</optgroup>"
                        }
                        var a = 0;
                        for (z in data.HostInfoes)
                        {
                            if ($.trim(data.HostInfoes[z].GroupGUID) == "") {
                                a = 1;
                            }
                        }
                        if (a == 1) {
                            str += "<optgroup label='未分组'>";
                            for (x in data.HostInfoes) {
                                if ($.trim(data.HostInfoes[x].GroupGUID) == "")
                                    str += "<option id=" + data.HostInfoes[x].GUID + ">" + data.HostInfoes[x].Name + "</option>";
                            }
                            str += "</optgroup>"
                        }
                       
                        document.getElementById('selecthostinfo').innerHTML = str;
                        document.getElementById('selecthostinfo1').innerHTML = str;
                        document.getElementById('selecthostinfo2').innerHTML = str;
                        $("#selectlightinfo").html("");//clear
                        $("#selectlightgroupinfo").html("");//clear
                        $("#selectcircuit").html("");//clear
                    }
                },
                error: function (error) {
                   // alert(error.responseText);
                }
            })
        })

        //保存选中的单灯主机ID
        $("#selectlightinfo").on('select2:select', function (e, data) {
            $("#selectlightguid").attr("value", e.params.data.element.id);
        })

        //保存选中的回路主机ID
        $("#selecthostinfo2").on('select2:select', function (e, data) {
            $("#selectcircuitguid").attr("value", e.params.data.element.id);
        })

        //保存选中的单灯组主机ID
        $("#selectlightgroupinfo").on('select2:select', function (e, data) {
            $("#selectlightgroupguid").attr("value",e.params.data.element.id) ;
        })

        //发送回路开下放
        $("#Open").click(function (e, data) {
            var result = 0;
            var selectioncircuit = $("#selectcircuit").val();
            //alert($("#range0").data("ionRangeSlider").$cache.input.prop("value"));
            if (selectioncircuit!=null) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: '/Lamp/Shared/ReturnCircuitResult?sGUID=' + $("#selectcircuitguid").attr("value") + '&sMode=' + selectioncircuit + '&sOpen=1',
                    dataType: "json",
                    success: function (data) {
                        if (data != null) {
                            result = data;
                            switch (data) {
                                case 0:
                                    $("#loadicon").attr("style", "width: 140px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                    $("#iconimage").attr("src", "/Image/Base/fail.png");
                                    $("#icontext").text("请选择回路！");
                                    setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                    setTimeout(function () {
                                        $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                        $("#icontext").text("正在下放！");
                                        $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                    }, 2000);
                                    break;
                                case 1:
                                    $("#iconimage").attr("src", "/Image/Base/fail.png");
                                    $("#icontext").text("请为主机添加地址！");
                                    $("#loadicon").attr("style", "width: 190px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                    setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                    setTimeout(function () {
                                        $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                        $("#icontext").text("正在下放！");
                                        $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                    }, 2000);
                                    break;
                                case 2:
                                    $("#iconimage").attr("src", "/Image/Base/fail.png");
                                    $("#icontext").text("数据库错误！");
                                    setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                    setTimeout(function () {
                                        $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                        $("#icontext").text("正在下放！");
                                        $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                    }, 2000);
                                    break;
                                case 3:
                                    $("#icontext").text("正在下放！");
                                    GetCircuitRev();//1000为1秒钟,设置为1分钟。
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                    //$("#loadicon").attr("style","width: 110px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                    break;
                                default:
                                    $("#iconimage").attr("src", "/Image/Base/fail.png");
                                    $("#icontext").text("下放失败！");
                                    setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                    setTimeout(function () {
                                        $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                        $("#icontext").text("正在下放！");
                                        $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                    }, 2000);
                                    break;
                            }
                        }

                    },
                    error: function (error) {
                        $("#iconimage").attr("src", "/Image/Base/fail.png");
                        $("#icontext").text("下放失败！");
                        setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                        setTimeout(function () {
                            $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                            $("#icontext").text("正在下放！");
                            $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                        }, 2000);
                        //alert(error.responseText);
                    }
                })
            }
            else {
                $("#loadicon").attr("style", "width: 140px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                $("#iconimage").attr("src", "/Image/Base/fail.png");
                $("#icontext").text("请选择回路！");
                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                setTimeout(function () {
                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                    $("#icontext").text("正在下放！");
                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                }, 2000);
            }
        })

        //发送回路开下放
        $("#Close").click(function (e, data) {
            var result = 0;
            var selectioncircuit = $("#selectcircuit").val();
            //alert($("#range0").data("ionRangeSlider").$cache.input.prop("value"));
            if (selectioncircuit != null) {

            //alert($("#range0").data("ionRangeSlider").$cache.input.prop("value"));
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '/Lamp/Shared/ReturnCircuitResult?sGUID=' + $("#selectcircuitguid").attr("value") + '&sMode=' + selectioncircuit + '&sOpen=0',
                dataType: "json",
                success: function (data) {
                    if (data != null) {
                        result = data;
                        switch (data) {
                            case 0:
                                $("#loadicon").attr("style", "width: 140px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("请选择回路！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                            case 1:
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("请为主机添加地址！");
                                $("#loadicon").attr("style", "width: 190px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                            case 2:
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("数据库错误！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                            case 3:
                                $("#icontext").text("正在下放！");
                                GetCircuitRev();//1000为1秒钟,设置为1分钟。
                                $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                //$("#loadicon").attr("style","width: 110px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                break;
                            default:
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("下放失败！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                        }
                    }

                },
                error: function (error) {
                    $("#iconimage").attr("src", "/Image/Base/fail.png");
                    $("#icontext").text("下放失败！");
                    setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                    setTimeout(function () {
                        $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                        $("#icontext").text("正在下放！");
                        $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                    }, 2000);
                    //alert(error.responseText);
                }
            })

            }
            else {
                $("#loadicon").attr("style", "width: 140px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                $("#iconimage").attr("src", "/Image/Base/fail.png");
                $("#icontext").text("请选择回路！");
                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                setTimeout(function () {
                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                    $("#icontext").text("正在下放！");
                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                }, 2000);
            }
        })

        //单灯数据查询
        function GetCircuitRev() {
            if (i <= 6) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: '/Lamp/Shared/ReturnCircuitRevsResult?sGUID=' + $("#selectcircuitguid").attr("value") + '&sTime=' + i * 2,
                    dataType: "json",
                    success: function (data) {
                        switch (data) {
                            case 0:
                                $("#loadicon").attr("style", "width: 140px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("请选择回路！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                i = 1;
                                break;
                            case 1:
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("请为主机添加ID！");
                                $("#loadicon").attr("style", "width: 190px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                i = 1;
                                break;
                            case 2:
                                setTimeout(GetCircuitRev, 1500);//1.5秒钟。
                                i++;
                                break;
                            case 3:
                                $("#loadicon").attr("style", "width: 140px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("数据库错误！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                i = 1;
                                break;
                            case 4:
                                $("#iconimage").attr("src", "/Image/Base/success.png");
                                $("#icontext").text("下放成功！");
                                i = 1;
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                            default:
                                i = 1;
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("下放失败！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                        }
                    },
                    error: function (error) {
                        i = 1;
                        $("#iconimage").attr("src", "/Image/Base/fail.png");
                        $("#icontext").text("下放失败！");
                        setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                        setTimeout(function () {
                            $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                            $("#icontext").text("正在下放！");
                            $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                        }, 2000);
                        //alert(error.responseText);
                    }
                })
            }
            else {
                i = 1;
                $("#iconimage").attr("src", "/Image/Base/fail.png");
                $("#icontext").text("下放失败！");
                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                setTimeout(function () {
                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                    $("#icontext").text("正在下放！");
                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                }, 2000);
            }
        }

        var i = 1;
        //单灯数据查询
        function GetLightRev() {
            if (i <= 6)
            {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: '/Lamp/Shared/ReturnLightRevsResult?sGUID=' + $("#selectlightguid").attr("value") + '&sTime=' + i * 2 + '&sType=1',
                    dataType: "json",
                    success: function (data) {
                        switch (data) {
                            case 0:
                                $("#loadicon").attr("style", "width: 140px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("请选择单灯！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                i = 1;
                                break;
                            case 1:
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("请为主机添加ID！");
                                $("#loadicon").attr("style", "width: 190px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                i = 1;
                                break;
                            case 2:
                                setTimeout(GetLightRev, 1500);//1.5秒钟。
                                i++;
                                break;
                            case 3:
                                $("#loadicon").attr("style", "width: 140px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("数据库错误！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                i = 1;
                                break;
                            case 4:
                                $("#iconimage").attr("src", "/Image/Base/success.png");
                                $("#icontext").text("下放成功！");
                                i = 1;
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                            default:
                                i = 1;
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("下放失败！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                        }
                    },
                    error: function (error) {
                        i = 1;
                        $("#iconimage").attr("src", "/Image/Base/fail.png");
                        $("#icontext").text("下放失败！");
                        setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                        setTimeout(function () {
                            $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                            $("#icontext").text("正在下放！");
                            $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                        }, 2000);
                       // alert(error.responseText);
                    }
                })
            }
            else {
                i = 1;
                $("#iconimage").attr("src", "/Image/Base/fail.png");
                $("#icontext").text("下放失败！");
                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                setTimeout(function () {
                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                    $("#icontext").text("正在下放！");
                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                }, 2000);
            }
        }

        //单灯组数据查询
        function GetLightGroupRev() {
            if (i <= 6) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: '/Lamp/Shared/ReturnLightRevsResult?sGUID=' + $("#selectlightgroupguid").attr("value") + '&sTime=' + i * 2 + '&sType=2',
                    dataType: "json",
                    success: function (data) {
                        switch (data) {
                            case 0:
                                $("#loadicon").attr("style", "width: 140px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("请选择群组！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                i = 1;
                                break;
                            case 1:
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("请为主机添加ID！");
                                $("#loadicon").attr("style", "width: 190px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                i = 1;
                                break;
                            case 2:
                                setTimeout(GetLightGroupRev, 1500);//1.5秒钟。
                                i++;
                                break;
                            case 3:
                                $("#loadicon").attr("style", "width: 140px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("数据库错误！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                i = 1;
                                break;
                            case 4:
                                $("#iconimage").attr("src", "/Image/Base/success.png");
                                $("#icontext").text("下放成功！");
                                i = 1;
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                            default:
                                i = 1;
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("下放失败！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                        }
                    },
                    error: function (error) {
                        i = 1;
                        $("#iconimage").attr("src", "/Image/Base/fail.png");
                        $("#icontext").text("下放失败！");
                        setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                        setTimeout(function () {
                            $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                            $("#icontext").text("正在下放！");
                            $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                        }, 2000);
                        //alert(error.responseText);
                    }
                })
            }
            else {
                i = 1;
                $("#iconimage").attr("src", "/Image/Base/fail.png");
                $("#icontext").text("下放失败！");
                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                setTimeout(function () {
                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                    $("#icontext").text("正在下放！");
                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                }, 2000);
            }
        }

        //发送单灯下放
        $("#lightsend").click(function (e, data) {
            var result = 0;
            //alert($("#range0").data("ionRangeSlider").$cache.input.prop("value"));
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '/Lamp/Shared/ReturnLightResult?sGUID=' +$("#selectlightguid").attr("value") + '&sMode=' + $("#modeswitch").is(':checked') + '&sSwitch=' + $("#lightswitch").is(':checked') + '&sValue=' + $("#range0").data("ionRangeSlider").$cache.input.prop("value") + '&sType=1' + '&sGroup=0',
                dataType: "json",
                success: function (data) {
                    if (data!=null) {
                        result = data;
                        switch (data) {
                            case 0:
                                $("#loadicon").attr("style", "width: 140px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("请选择单灯！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                            case 1:
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("请为主机添加地址！");
                                $("#loadicon").attr("style", "width: 190px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                            case 2:
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("数据库错误！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                            case 3:
                                $("#icontext").text("正在下放！");
                                GetLightRev();//1000为1秒钟,设置为1分钟。
                                 $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                //$("#loadicon").attr("style","width: 110px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                break;
                            default:
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("下放失败！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                        }
                    }
                    
                },
                error: function (error) {
                    $("#iconimage").attr("src", "/Image/Base/fail.png");
                    $("#icontext").text("下放失败！");
                    setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                    setTimeout(function () {
                        $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                        $("#icontext").text("正在下放！");
                        $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                    }, 2000);
                    //alert(error.responseText);
                }
            })
        })

        //发送单灯组下放
        $("#groupsend").click(function (e, data) {
            var result = 0;
            //alert($("#range0").data("ionRangeSlider").$cache.input.prop("value"));
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '/Lamp/Shared/ReturnLightResult?sGUID=' + $("#selectlightgroupguid").attr("value") + '&sMode=' + $("#modeswitch1").is(':checked') + '&sSwitch=' + $("#lightswitch1").is(':checked') + '&sValue=' + $("#range1").data("ionRangeSlider").$cache.input.prop("value") + '&sType=2' + '&sGroup=0',
                dataType: "json",
                success: function (data) {
                    if (data != null) {
                        result = data;
                        switch (data) {
                            case 0:
                                $("#loadicon").attr("style", "width: 140px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("请选择群组！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                            case 1:
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("请为主机添加地址！");
                                $("#loadicon").attr("style", "width: 190px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                            case 2:
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("数据库错误！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                            case 3:
                                $("#icontext").text("正在下放！");
                                $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                GetLightGroupRev();
                                //$("#loadicon").attr("style","width: 110px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                break;
                            default:
                                $("#iconimage").attr("src", "/Image/Base/fail.png");
                                $("#icontext").text("下放失败！");
                                setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                                setTimeout(function () {
                                    $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                                    $("#icontext").text("正在下放！");
                                    $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                                }, 2000);
                                break;
                        }
                    }

                },
                error: function (error) {
                    $("#loadicon").attr("style", "width: 140px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                    $("#iconimage").attr("src", "/Image/Base/fail.png");
                    $("#icontext").text("下放失败！");
                    setTimeout(function () { document.getElementById("cancle").click(); }, 1500);
                    setTimeout(function () {
                        $("#iconimage").attr("src", "/UILib/Metronic/assets/global/img/loading-spinner-grey.gif");
                        $("#icontext").text("正在下放！");
                        $("#loadicon").attr("style", "width: 130px; position: absolute; left: 50%; top: 50%; margin-left: -70px; margin-top: -20px; background-color: white;");
                    }, 2000);
                    //alert(error.responseText);
                }
            })
        })

        //修改密码以后注册prjinfo消失事件
        $("#changepassword").click(function () {
            $("#prjinfo").on("hidden.bs.modal", function () {
                $("#divDlg").html("");
            });
        })

        //var init1 = function () {
        //    $("#btnreload").load(function () {
        //        $("#btnreload").bind("click", function () {
        //            App.blockUI({ target: "#HostAllInfoDlg", boxed: !0, overlayColor: '#000', message: "正在获取!" });
        //            window.setTimeout(function () { App.unblockUI("#HostAllInfoDlg"); }, 2000);
        //        })
        //    })
        //}


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
    //$("#alert1")[0].hidden = true;
    LayoutPage.init();

    //$("#btnreload").load(function () {
    //    init1();
    //});
});

////function TimeCtrGaugegotoParent(datas) {
////    if (datas == "配置成功，正在跳转主页......") {
////        // $('#basic').modal('hide');
////        //$("#basic").removeData("bs.modal");
////        window.location.reload();
////    }
////    // window.location.reload();
////    //alert("修改成功！");


////}

