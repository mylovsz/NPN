
var PageInit = function () {

    var InitLeftMeun = function () {
        var l = document.getElementById('ulTimeControlMainLeft');
        if (l == null)
            return;
        list = l.getElementsByTagName('li');
        for (var i = 0, len = list.length; i < len; i++) {
            var that = list[i];
            list[i].onclick = (function (k) {

                var vid = k.id;
                return function () {
                    $("#sHostGUID").val(vid);//保存主机GUID
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: '/Lamp/TimeControl/OneHostByTimeControl?sGUID=' + vid,
                        dataType: "json",
                        success: function (data) {
                            //test(" + JSON.stringify(data[i].tct.sGUID).replace(/"/g, "&" + "#34") + ") json转为string类型
                            if (data) {
                                var strOT = "";
                                var strTT = "";
                                for (var i = 0; i < data.length; i++) {
                                    if (i < 12) {
                                        strOT += "<tr><td>" + data[i].tct.iID + "</td><td>" + data[i].setTime + " </td><td title='" + data[i].ExecutiveAction + "'>" + data[i].ExecutiveAction + "</td><td>" + data[i].IsEnable + "</td><td><a href='#form_modal4' data-toggle='modal' onclick=\"GoToTimeControl('" + data[i].tct.sGUID + "')\">编辑</a></td></tr>";
                                    }
                                    else {
                                        strTT += "<tr><td>" + data[i].tct.iID + "</td><td>" + data[i].setTime + " </td><td title='" + data[i].ExecutiveAction + "'>" + data[i].ExecutiveAction + "</td><td>" + data[i].IsEnable + "</td><td><a href='#form_modal4' data-toggle='modal' onclick=\"GoToTimeControl('" + data[i].tct.sGUID + "')\">编辑</a></td></tr>";
                                    }
                                }
                                document.getElementById('OT').innerHTML = strOT;
                                document.getElementById('TT').innerHTML = strTT;

                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: '/Lamp/TimeControl/GetLoopControl?sGUID=' + vid + '&ttype=' + data[0].iHardware_Type,
                                    dataType: "json",
                                    success: function (data) {
                                        if (data) {
                                            var slgi = "";
                                            for (d in data) {
                                                slgi += "<option value='" + data[d].sGUID + "'>" + data[d].sName + "</option>";
                                            }
                                            document.getElementById('selectcircuitinfo_time').innerHTML = slgi;
                                        }
                                    },
                                    error: function (error) {
                                        alert("获取回路数据失败！");
                                    }
                                })
                            }
                        }, error: function (error) { alert("获取时段数据失败！"); }
                    });
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: '/Lamp/TimeControl/ReturnLightGroup?sGUID=' + vid,
                        dataType: "json",
                        success: function (data) {
                            if (data) {
                                //单灯组选择下拉框
                                $("#selectlightgroupinfo_time").val(null).trigger("change");//clear
                                var slgi = "";
                                slgi += "<option></option>";
                                for (d in data.LightGroupInfoes) {
                                    slgi += "<option  value=" + data.LightGroupInfoes[d].GUID + ">" + data.LightGroupInfoes[d].Name + "</option>";
                                }
                                document.getElementById('selectlightgroupinfo_time').innerHTML = slgi;
                            }
                        },
                        error: function (error) {
                            alert(error.responseText);
                        }
                    })

                };
            })(that);
        }
        // isFrist= parseInt(isFrist)+1;
    }
    var InitAllElement = function () {

        //$('#example').DataTable({
        //    "scrollY": "200px",

        //});
        $('#selecttype_time').select2({
            placeholder: "请选择执行类型",
            width: null,
            minimumResultsForSearch: Infinity
        });

        $('#selectcircuitinfo_time').select2({
            placeholder: "请选择回路",
            width: null,
            minimumResultsForSearch: Infinity
        });
        $('#selectlightgroupinfo_time').select2({
            placeholder: "请选择群组",
            width: null,
        });
        //$("#range0_time").ionRangeSlider({
        //    min: 0,
        //    max: 100,
        //    from: 100,
        //});

        $("#qz_Temp").hide();
        $("#qz_Temp_State").hide();
        $("#range0_time").hide();
        ////保存所选的执行类型
        //$("#selecttype_time").on('select2:select', function (e, data) {
        //    $("#selectedId").attr("value", e.params.data.element.id);
        //})
        //选择执行类型显示相应的元素
        $("#selecttype_time").on('select2:select', (function (e, data) {
            if (e.params.data.element.value == '0') {
                $("#hl_Temp").show();
                $("#qz_Temp").hide();
                $("#qz_Temp_State").hide();

                document.getElementById('EType').innerHTML = "";
                $("#btnsave").attr("data-dismiss", "modal");
                $("#range0_time").hide();
            }
            if (e.params.data.element.value == '1') {
                $("#hl_Temp").hide();
                $("#qz_Temp").show();
                $("#qz_Temp_State").show();

                document.getElementById('lLightGroup').innerHTML = "";
                $("#btnsave").attr("data-dismiss", "modal");
                $("#range0_time").ionRangeSlider({

                    min: 0,                        // min value
                    max: 100,                       // max value
                    from: 100,                       // overwrite default FROM setting

                    type: "single",                 // slider type
                    step: 10,                       // slider step
                    postfix: " %",             // postfix text
                    hasGrid: true,                  // enable grid
                    hideText: true,                 // hide all text data

                });
                $("#range0_time").show();
            }
            if (e.params.data.element.value == 'mr') {
                $("#hl_Temp").hide();
                $("#qz_Temp").hide();
                $("#qz_Temp_State").hide();
                // $("#range0_time").show();
            }
        }))

        //单点控制的调光按钮是否显示
        $("#modeswitch_time").on('switchChange.bootstrapSwitch', function (e, data) {
            if ($("#modeswitch_time").is(':checked')) {
                $("#range0_time").ionRangeSlider({

                    min: 0,                        // min value
                    max: 100,                       // max value
                    from: 100,                       // overwrite default FROM setting

                    type: "single",                 // slider type
                    step: 10,                       // slider step
                    postfix: " %",             // postfix text
                    hasGrid: true,                  // enable grid
                    hideText: true,                 // hide all text data

                });
                $("#slider1_time").show();
            }

            else {
                $("#range0_time").ionRangeSlider({

                    min: 0,                        // min value
                    max: 100,                       // max value
                    from: 100,                       // overwrite default FROM setting

                    type: "single",                 // slider type
                    step: 10,                       // slider step
                    postfix: " %",             // postfix text
                    hasGrid: true,                  // enable grid
                    hideText: true,                 // hide all text data

                });
                $("#slider1_time").hide();
            }

        });


       
        //$(".inbox .inbox-nav > li.active > a").css({ 'border-left': '4px solid #2f353b' });
        $("#CurrPages").css({ 'padding-left': '30px', 'padding-right': '30px', 'background-color': 'rgb(255, 255, 255)' });
        var test = document.getElementById('CurrPages');
        var wheight = parseFloat(window.innerHeight);

        var heightpx = wheight - parseFloat(test.offsetTop)
        var heightpxx = heightpx + 'px';
        $('#CurrPages').css('height', heightpxx);




        //组控制的调光按钮是否显示
        //$("#modeswitch1").on('switchChange.bootstrapSwitch', function (e, data) {
        //    if ($("#modeswitch1").is(':checked'))
        //        $("#slider2").show();
        //    else
        //        $("#slider2").hide();
        //});
    }

    return {
        //main function to initiate the module

        init: function () {

            InitAllElement();
            InitLeftMeun();
        }

    };

}();

jQuery(document).ready(function () {
    PageInit.init();



});


function test(cs) {
    alert(cs);
}
//点击编辑
function GoToTimeControl(sGUID) {

    var oNav_input = $("#drange").find("input").length;
    if (oNav_input == 1) {

        $("#drange").empty();

        $("#drange").append("<input id='range0_time' type='text' />");
    } else {
        $("#drange").append("<input id='range0_time' type='text' />");
    }
    



    $("#EditGUID").val(sGUID);
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '/Lamp/TimeControl/GetSets?sGUID=' + sGUID,
        dataType: "json",
        success: function (data) {
            $('#timeset').val(data[0].setTime);
            if (data[0].tct.iEnable == 1) {
                $('#uniform-IsCheckBox').children('span').attr("class", "checked");//启用
            }
            if (data[0].tct.iEnable == 0) {
                $('#uniform-IsCheckBox').children('span').attr("class", "");//不启用
            }
            if (data[0].iType == "0") {//回路

                var $example = $("#selecttype_time").select2({
                    width: null,
                    minimumResultsForSearch: Infinity
                });
                $example.val("0").trigger("change");//回路类型选择
                var s = $("#modeswitchhl_time");
                if (data[0].sRelayState == 0) {

                    s.prop("checked", false).trigger("change.bootstrapSwitch");
                }
                else {
                    s.prop("checked", true).trigger("change.bootstrapSwitch");
                    //$('#toggle-state-switch').bootstrapSwitch('modeswitchhl_time', true); // true || false
                }

                var $examplea = $("#selectcircuitinfo_time").select2({
                    width: null,
                    minimumResultsForSearch: Infinity
                });
                $examplea.val(data[0].sRelayInfo_GUID).trigger("change");//回路选择
                $("#hl_Temp").show();
                $("#qz_Temp").hide();
                $("#qz_Temp_State").hide();
                document.getElementById('EType').innerHTML = "";
                $("#btnsave").attr("data-dismiss", "modal");
            }
            else if (data[0].iType == "1") {//组类型选择
                $("#qz_Temp").show();
                $("#qz_Temp_State").show();
                $("#hl_Temp").hide();
                
                document.getElementById('lLightGroup').innerHTML = "";
                $("#btnsave").attr("data-dismiss", "modal");
                $("#btnsave").attr("data-dismiss", "modal");
                //类型赋值
                var $example = $("#selecttype_time").select2({
                    width: null,
                    minimumResultsForSearch: Infinity
                });
                $example.val("1").trigger("change");
                //组选择赋值
                var $examplelight = $("#selectlightgroupinfo_time").select2({
                    width: null,
                    minimumResultsForSearch: Infinity
                });
                $examplelight.val(data[0].sLightGroupGUID).trigger("change");
                //调光按钮赋值
                if (data[0].sLightGroupMState == "0") {
                    $("#modeswitch_time").prop("checked", false).trigger("change.bootstrapSwitch");
                }
                else {
                    $("#modeswitch_time").prop("checked", true).trigger("change.bootstrapSwitch");
                    $("#slider1_time").show();
                    //$('#range0_time').slider(100);
                    // $("#range0_time").prop("value", data[0].sLightGroupMVaule).trigger("focus");//调光值赋值
                    //$("#range0_time").prop("single", parseInt(data[0].sLightGroupMVaule)).$cache.line.trigger("focus")


                    $("#range0_time").ionRangeSlider({

                        min: 0,                        // min value
                        max: 100,                       // max value
                        from: parseInt(data[0].sLightGroupMVaule),                       // overwrite default FROM setting

                        type: "single",                 // slider type
                        step: 10,                       // slider step
                        postfix: " %",             // postfix text
                        hasGrid: true,                  // enable grid
                        hideText: true,                 // hide all text data

                    });
                    // $("#range0_time").val(data[0].sLightGroupMVaule);
                    // this.$cache.line.trigger("focus")
                }
                //群组状态赋值
                if (data[0].sLightGroupState == "0") {
                    $("#lightswitch").prop("checked", false).trigger("change.bootstrapSwitch");
                }
                else {
                    $("#lightswitch").prop("checked", true).trigger("change.bootstrapSwitch");
                }

                

            }
            else {
                var $example = $("#selecttype_time").select2({
                    placeholder: "请选择执行类型",
                    width: null,
                    minimumResultsForSearch: Infinity
                });
                $example.val("mr").trigger("change");
                $("#hl_Temp").hide();
                $("#qz_Temp").hide();
                $("#qz_Temp_State").hide();
            }



        },
        error: function (error) {
            alert("获取数据失败！");
        }
    });

}
//保存
function saveSet() {

    //GUID
    var tcGUID = $("#EditGUID").val();
    //所设时间
    var timeset = $('#timeset').val();
    //是否启用
    var IsCheckBox;
    var vIsCheckBox = $("#IsCheckBox")
    if (vIsCheckBox[0].checked == true) {
        IsCheckBox = 1;
    }
    else {
        IsCheckBox = 0;
    }
    //if ($('#uniform-IsCheckBox').children('span').className == 'checked') {
    //    IsCheckBox = 1;
    //}
    //else {
    //    IsCheckBox = 0;
    //}
    //类型
    var $example = $("#selecttype_time").select2({
        minimumResultsForSearch: Infinity
    });
    var selecttype_time = $example.val();
    if (selecttype_time == 'mr') {

        document.getElementById('EType').innerHTML = "请选择执行类型";
        $("#btnsave").attr("data-dismiss", "");
        return;
    }
    else if (selecttype_time=='0')
    {
       
        //回路选择
        var $example1 = $("#selectcircuitinfo_time").select2({
            minimumResultsForSearch: Infinity
        });
        var selectcircuitinfo_time = $example1.val();
        //回路状态
        var modeswitchhl_timeobj = $("#modeswitchhl_time");
        var modeswitchhl_time;
        if (modeswitchhl_timeobj[0].checked == true) {
            modeswitchhl_time = 1
        }
        else {
            modeswitchhl_time = 0;
        }
        document.getElementById('EType').innerHTML = "";
        $("#btnsave").attr("data-dismiss", "modal");
    }
    else if (selecttype_time == '1') {
        //组选择
        var $example2 = $("#selectlightgroupinfo_time").select2({
            minimumResultsForSearch: Infinity
        });
        var selectlightgroupinfo_time = $example2.val();
        if (selectlightgroupinfo_time == "") {
            document.getElementById('lLightGroup').innerHTML = "分组不能为空！";
            $("#btnsave").attr("data-dismiss", "");
            return;
        }
        else {
            document.getElementById('lLightGroup').innerHTML = "";
            $("#btnsave").attr("data-dismiss", "modal");
        }
        //调光
        var modeswitch_timeobj = $("#modeswitch_time");
        var modeswitch_time;
        var range0_time;//调光值
        if (modeswitch_timeobj[0].checked == true) {
            modeswitch_time = 1;
            range0_time = $("#range0_time").val();
        }
        else {
            modeswitch_time = 0;
        }


        //组状态
        var lightswitchobj = $("#lightswitch_time");
        var lightswitch;
        if (lightswitchobj.is(':checked'))
            lightswitch = 1
        else
            lightswitch = 0;
    }
   

   



    $.ajax({
        url: "/Lamp/TimeControl/SaveSets",
        data: { TimeCtrGUID: tcGUID, timeset: timeset, IsCheckBox: IsCheckBox, selecttype_time: selecttype_time, selectcircuitinfo_time: selectcircuitinfo_time, modeswitchhl_time: modeswitchhl_time, selectlightgroupinfo_time: selectlightgroupinfo_time, modeswitch_time: modeswitch_time, lightswitch: lightswitch, slider1_time: range0_time },
        type: "POST",
        dataType: "json",
        success: function (datas) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",  
                url: '/Lamp/TimeControl/OneHostByTimeControlSave?sGUID=' + $("#sHostGUID").val(),
                dataType: "json",
                success: function (data) {
                    //test(" + JSON.stringify(data[i].tct.sGUID).replace(/"/g, "&" + "#34") + ") json转为string类型
                    if (data) {
                        var strOT = "";
                        var strTT = "";
                        for (var i = 0; i < data.length; i++) {
                            if (i<12) {
                                strOT += "<tr><td>" + data[i].tct.iID + "</td><td>" + data[i].setTime + " </td><td title='" + data[i].ExecutiveAction + "'>" + data[i].ExecutiveAction + "</td><td>" + data[i].IsEnable + "</td><td><a href='#form_modal4' data-toggle='modal' onclick=\"GoToTimeControl('" + data[i].tct.sGUID + "')\">编辑</a></td></tr>";
                            }
                            else{
                                strTT += "<tr><td>" + data[i].tct.iID + "</td><td>" + data[i].setTime + " </td><td title='" + data[i].ExecutiveAction + "'>" + data[i].ExecutiveAction + "</td><td>" + data[i].IsEnable + "</td><td><a href='#form_modal4' data-toggle='modal' onclick=\"GoToTimeControl('" + data[i].tct.sGUID + "')\">编辑</a></td></tr>";
                            }


                        }
                        
                        document.getElementById('OT').innerHTML = strOT;
                        document.getElementById('TT').innerHTML = strTT;


                    }
                }, error: function (error) { alert("获取时段数据失败！"); }
            });

        }
    })


}

function loopControl() {
    alert("回路控制");
}
window.onload = function () {



}