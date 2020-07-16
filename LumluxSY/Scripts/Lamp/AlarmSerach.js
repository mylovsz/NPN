
var listCheckWhereUL = null;
var startTime;
var endTime;
var pageIndex;
var hostGUID = $("#hostGUID").val();
var checkWhere = null;
var hostWhere = null;
var alarmWhere = null;
var LightName = null;
//分页
var getDataBySrv = function (hostGUID, start, end, pageIndex, LightName) {

    var vselectedhost = $("#selectedHost").val();
    hostWhere = "";
    if (vselectedhost != null) {
        for (var x = 0, len = vselectedhost.length; x < len; x++) {
            hostWhere += vselectedhost[x] + ',';
        }
    }

    var s1, hostnewStr = "";
    if (hostWhere != "") {
        s1 = hostWhere.charAt(hostWhere.length - 1);
        if (s1 == ",") {
            for (var i = 0; i < hostWhere.length - 1; i++) {
                hostnewStr += hostWhere[i];
            }
            console.log(hostnewStr);
        }
    }
    var vselectedalarm = $("#selectedAlarm").val();
    alarmWhere = "";
    if (vselectedalarm != null) {
        for (var x = 0, len = vselectedalarm.length; x < len; x++) {
            alarmWhere += vselectedalarm[x] + ',';
        }
    }

    var s2, alarmnewStr = "";
    if (alarmWhere != "") {
        s2 = alarmWhere.charAt(alarmWhere.length - 1);
        if (s2 == ",") {
            for (var i = 0; i < alarmWhere.length - 1; i++) {
                alarmnewStr += alarmWhere[i];
            }
            console.log(alarmnewStr);
        }
    }
    $.ajax({
        url: "/Lamp/AlarmPage/Index",
        data: { hostGUID: hostGUID, startDate: start.format('YYYY-MM-DD HH:mm:ss'), endDate: end.format('YYYY-MM-DD HH:mm:ss'), pageIndex: pageIndex, hostWhere: hostWhere, alarmWhere: alarmWhere, LightName: LightName },
        type: "POST",
        dataType: "json",
        success: function (data) {
            if (data != "") {
                $("tbody").remove();
                var str = "";
                for (i in data) {
                    str += "<tbody><tr><td style='text-align:center;'>" + data[i].thost.sName + "</td><td style='text-align:center; '>" + data[i].li.sName + "</td><td style='text-align:center; '>" + data[i].li.sRemark + "</td><td style='text-align:center; '>" + data[i].Fault + "</td><td style='text-align:center; '>" + data[i].sUpdateTime + "</td><td style='text-align:center;'>" + data[i].ls.sSpareField2 + "</td><td style='text-align:center;'>" + data[i].ls.sSpareField3 + "</td><td style='text-align:center;'>" + data[i].ls.sSpareField4 + "</td><td style='text-align:center;'>" + data[i].ls.sSpareField1 + "</td><td style='text-align:center;'>" + data[i].ls.sSpareField6 + "</td><td style='text-align:center;'>" + data[i].ls.sSpareField5 + "</td></tr></tbody>";
                }
                //$("#iCount").html("当前所查前"+data.length+"条报警");
                $("table").append(str);
                $("span#iAlCount").text(data[0].iCount);//总记录
                $("span#iPage").text(data[0].iPage);//总页数
                if (parseInt(data[0].iPage) == 1) {
                    $("#aprev").hide();
                    $("#emPrev").show();
                    $("#anext").hide();
                    $("#emNext").show();
                }
                else {
                    if (parseInt($("#toPage").val()) == parseInt(data[0].iPage)) {//最后一页
                        $("#aprev").show();
                        $("#emPrev").hide();
                        $("#anext").hide();
                        $("#emNext").show();
                    }
                    else if (parseInt($("#toPage").val()) <= 1) {//第一页
                        $('#toPage').val("1");
                        $("#aprev").hide();
                        $("#emPrev").show();
                        $("#anext").show();
                        $("#emNext").hide();
                    }
                    else {
                        $("#aprev").show();
                        $("#emPrev").hide();
                        $("#anext").show();
                        $("#emNext").hide();
                    }

                }


            }
            else {
                $("tbody").remove();
                $("span#iAlCount").text("");
                $("#aprev").hide();
                $("#emPrev").show();
                $("#anext").hide();
                $("#emNext").show();
                $("span#iPage").text("");
                $('#toPage').val("");
            }
        }
    })
}
//查询
var getDataBySrv1 = function (hostGUID, start, end, pageIndex, hostWhere, alarmWhere, LightName) {
    $.ajax({
        url: "/Lamp/AlarmPage/GetDateWhrer",
        data: { hostGUID: hostGUID, startDate: start.format('YYYY-MM-DD HH:mm:ss'), endDate: end.format('YYYY-MM-DD HH:mm:ss'), pageIndex: pageIndex, hostWhere: hostWhere, alarmWhere: alarmWhere, LightName: LightName },
        type: "POST",
        dataType: "json",
        success: function (data) {
            if (data != "") {
                $("tbody").remove();
                var str = "";
                for (i in data) {
                    str += "<tbody><tr><td style='text-align:center;'>" + data[i].thost.sName + "</td><td style='text-align:center; '>" + data[i].li.sName + "</td><td style='text-align:center;'>" + data[i].li.sRemark + "</td><td style='text-align:center; '>" + data[i].Fault + "</td><td style='text-align:center; '>" + data[i].sUpdateTime + "</td><td style='text-align:center;'>" + data[i].ls.sSpareField2 + "</td><td style='text-align:center;'>" + data[i].ls.sSpareField3 + "</td><td style='text-align:center;'>" + data[i].ls.sSpareField4 + "</td><td style='text-align:center;'>" + data[i].ls.sSpareField1 + "</td><td style='text-align:center;'>" + data[i].ls.sSpareField6 + "</td><td style='text-align:center;'>" + data[i].ls.sSpareField5 + "</td></tr></tbody>";
                }
                //$("#iCount").html("当前所查前"+data.length+"条报警");
                $("table").append(str);
                $("span#iAlCount").text(data[0].iCount);//总记录
                $("span#iPage").text(data[0].iPage);//总页数
                $('#toPage').val("1");
                if (parseInt(data[0].iPage) == 1) {
                    $("#aprev").hide();
                    $("#emPrev").show();
                    $("#anext").hide();
                    $("#emNext").show();
                }
                else {
                    if (parseInt($("#toPage").val()) == parseInt(data[0].iPage)) {//最后一页
                        $("#aprev").show();
                        $("#emPrev").hide();
                        $("#anext").hide();
                        $("#emNext").show();
                    }
                    else if (parseInt($("#toPage").val()) <= 1) {//第一页
                        $('#toPage').val("1");
                        $("#aprev").hide();
                        $("#emPrev").show();
                        $("#anext").show();
                        $("#emNext").hide();
                    }
                    else {
                        $("#aprev").show();
                        $("#emPrev").hide();
                        $("#anext").show();
                        $("#emNext").hide();
                    }
                }




            }
            else {
                $("tbody").remove();
                $("span#iAlCount").text("");
                $("#aprev").hide();
                $("#emPrev").show();
                $("#anext").hide();
                $("#emNext").show();
                $("span#iPage").text("");
                $('#toPage').val("");
            }
        }
    })
}


var ChartsAmcharts = function () {
    if (hostGUID != "") {
        $("#divHost").hide();
    }

    var handleDateRangePickers = function () {
        if (!jQuery().daterangepicker) {
            return;
        }
        $("#aprev").click(function test1() {
            var ipagecount = $("span#iPage").text();//总页数
            var vpageIndex = parseInt($("#toPage").val()) - 1;
            if (parseInt(vpageIndex) == 1) {
                $("#aprev").hide();
                $("#emPrev").show();
            }
            if (parseInt(vpageIndex) < parseInt(ipagecount)) {
                $("#anext").show();
                $("#emNext").hide();
            }
            $('#toPage').val(parseInt(vpageIndex));
            // $('#reportrange span').html(startTime.format('YYYY-MM-DD') + ' - ' + endTime.format('YYYY-MM-DD'));
            getDataBySrv(hostGUID, startTime, endTime, parseInt(vpageIndex), $("#LightName").val());
        })
        $("#anext").click(function test2() {
            var vpageIndex1 = parseInt($("#toPage").val()) + 1;
            var ipagecount = $("span#iPage").text();
            if (parseInt(vpageIndex1) >= 1) {
                $("#aprev").show();
                $("#emPrev").hide();

            }
            if (parseInt(vpageIndex1) == parseInt(ipagecount)) {
                $("#emNext").show();
                $("#anext").hide();
            }
            $('#toPage').val(parseInt(vpageIndex1));
            //$('#reportrange span').html(startTime.format('YYYY-MM-DD') + ' - ' + endTime.format('YYYY-MM-DD'));
            getDataBySrv(hostGUID, startTime, endTime, parseInt(vpageIndex1), $("#LightName").val());
        })
        $("input#toPage").blur(function () {


            //var ipagecount = $("span#iPage").text();
            var vtoPages = $("#toPage").val();
            var vsubToPage = vtoPages;
            if (vtoPages == null || vtoPages == undefined || vtoPages == "") {
                $('#toPage').val("1");
            }
            if (parseInt(vtoPages) > parseInt($("span#iPage").text())) {
                $('#toPage').val("1");
            }
            if (parseInt(vtoPages) < 1) {
                $('#toPage').val("1");
            }
            if (parseInt(vtoPages) == parseInt($("span#iPage").text())) {
                $("#emNext").show();
                $("#anext").hide();
                $("#aprev").show();
                $("#emPrev").hide();
            }

            //$('#reportrange span').html(startTime.format('YYYY-MM-DD') + ' - ' + endTime.format('YYYY-MM-DD'));
            if (parseInt(vtoPages) == 0 || parseInt(vtoPages) > parseInt($("span#iPage").text())) {
                getDataBySrv(hostGUID, startTime, endTime, parseInt(1), $("#LightName").val());
            }
            else {
                getDataBySrv(hostGUID, startTime, endTime, parseInt(vtoPages), $("#LightName").val());
            }
           

        });
        $('#reportrange').daterangepicker({
            opens: (App.isRTL() ? 'left' : 'left'),
            startDate: moment().subtract('days', 29),
            endDate: moment(),
            //minDate: '01/01/2012',
            //maxDate: '12/31/2040',
            dateLimit: {
                days: 3650
            },
            showDropdowns: true,
            showWeekNumbers: true,
            timePicker: true,
            timePickerIncrement: 1,
            timePicker24Hour: true,
            timePickerSeconds: true,
            ranges: {
                '最近1小时': [moment().subtract('hours', 1), moment()],
                '今天': [moment().startOf('days'), moment().endOf('days')],
                '昨日': [moment().subtract('days', 1).startOf('day'), moment().subtract('days', 1).endOf('day')],
                '最近7天': [moment().subtract('days', 6).startOf('days'), moment().subtract('days', 0).endOf('days')],
                '最近30天': [moment().subtract('days', 29).startOf('days'), moment().subtract('days', 0).endOf('days')],
                '本月': [moment().startOf('month'), moment().endOf('month')],
                '上个月': [moment().subtract('month', 1).startOf('month'), moment().subtract('month', 1).endOf('month')]
            },
            buttonClasses: ['btn'],
            applyClass: 'green',
            cancelClass: 'default',
            format: 'YYYY-MM-DD HH:mm:ss',
            separator: ' to ',
            locale: {
                applyLabel: '确定',
                cancelLabel: '取消',
                fromLabel: 'From',
                toLabel: 'To',
                customRangeLabel: '自定义',
                daysOfWeek: ['日', '一', '二', '三', '四', '五', '六'],
                monthNames: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月'],
                firstDay: 0
            }
        },
            function (start, end) {
                $('#reportrange span').html(start.format('YYYY-MM-DD HH:mm:ss') + ' - ' + end.format('YYYY-MM-DD HH:mm:ss'));
                $("#toPage").val(parseInt(pageIndex));
                startTime = start;
                endTime = end;
                //getDataBySrv(hostGUID, startTime, endTime, pageIndex);
            }
        );
        //Set the initial state of the picker label

        $('#reportrange span').html(moment().subtract('days', 29).format('YYYY-MM-DD HH:mm:ss') + ' - ' + moment().format('YYYY-MM-DD HH:mm:ss'));
        // $('#toPage').val(parseInt(pageIndex));
        startTime = moment().subtract('days', 29);
        endTime = moment();
        pageIndex = 1;
        hostGUID = $("#hostGUID").val();
        $("#aprev").hide();
        $("#emPrev").show();
        $("#emNext").hide();
        //getDataBySrv(hostGUID, startTime, endTime, parseInt(pageIndex));

        var vselectedhost = $("#selectedHost").val();
        hostWhere = "";
        if (vselectedhost != null) {
            for (var x = 0, len = vselectedhost.length; x < len; x++) {
                hostWhere += vselectedhost[x] + ',';
            }
        }

        var s1, hostnewStr = "";
        if (hostWhere != "") {
            s1 = hostWhere.charAt(hostWhere.length - 1);
            if (s1 == ",") {
                for (var i = 0; i < hostWhere.length - 1; i++) {
                    hostnewStr += hostWhere[i];
                }
                console.log(hostnewStr);
            }
        }
        var vselectedalarm = $("#selectedAlarm").val();
        alarmWhere = "";
        if (vselectedalarm != null) {
            for (var x = 0, len = vselectedalarm.length; x < len; x++) {
                alarmWhere += vselectedalarm[x] + ',';
            }
        }

        var s2, alarmnewStr = "";
        if (alarmWhere != "") {
            s2 = alarmWhere.charAt(alarmWhere.length - 1);
            if (s2 == ",") {
                for (var i = 0; i < alarmWhere.length - 1; i++) {
                    alarmnewStr += alarmWhere[i];
                }
                console.log(alarmnewStr);
            }
        }
       getDataBySrv1(hostGUID, startTime, endTime, parseInt(pageIndex), hostnewStr, alarmnewStr, $("#LightName").val());

    }

    var InitBtnSeachClick = function () {
        $("#btnSeach").click(function () {
            var vselectedhost = $("#selectedHost").val();
            hostWhere = "";
            if (vselectedhost != null) {
                for (var x = 0, len = vselectedhost.length; x < len; x++) {
                    hostWhere += vselectedhost[x] + ',';
                }
            }

            var s1, hostnewStr = "";
            if (hostWhere != "") {
                s1 = hostWhere.charAt(hostWhere.length - 1);
                if (s1 == ",") {
                    for (var i = 0; i < hostWhere.length - 1; i++) {
                        hostnewStr += hostWhere[i];
                    }
                    console.log(hostnewStr);
                }
            }
            var vselectedalarm = $("#selectedAlarm").val();
            alarmWhere = "";
            if (vselectedalarm != null) {
                for (var x = 0, len = vselectedalarm.length; x < len; x++) {
                    alarmWhere += vselectedalarm[x] + ',';
                }
            }

            var s2, alarmnewStr = "";
            if (alarmWhere != "") {
                s2 = alarmWhere.charAt(alarmWhere.length - 1);
                if (s2 == ",") {
                    for (var i = 0; i < alarmWhere.length - 1; i++) {
                        alarmnewStr += alarmWhere[i];
                    }
                    console.log(alarmnewStr);
                }
            }
            getDataBySrv1(hostGUID, startTime, endTime, parseInt(pageIndex), hostnewStr, alarmnewStr, $("#LightName").val());
        })
    }
    return {
        //main function to initiate the module

        init: function () {
            InitBtnSeachClick();
            handleDateRangePickers();
        }

    };

}();
var initCheckWhereULClick = function () {
    var vspan = $("#CheckWhere li");
    for (var i = 0, len = vspan.length; i < len; i++) {
        var that = vspan[i];
        vspan[i].onclick = (function (k) {
            return function () {
                checkWhere = "";
                for (var x = 0, len = vspan.length; x < len; x++) {
                    var chthat = vspan[x];
                    if (chthat.getElementsByTagName('span')[0].className == 'checked') {
                        checkWhere += chthat.id + ',';
                    }

                }
                var s, newStr = "";
                if (checkWhere != "") {
                    s = checkWhere.charAt(checkWhere.length - 1);
                    if (s == ",") {
                        for (var i = 0; i < checkWhere.length - 1; i++) {
                            newStr += checkWhere[i];
                        }
                        console.log(newStr);
                    }
                }

                //var vcheckWhere = checkWhere.substring(0, str.length - 1);
                //vcheckWhere = k.id + k.getElementsByTagName('span')[0].className;
                getDataBySrv1(hostGUID, startTime, endTime, parseInt(pageIndex), newStr);
                //alert(k.id+k.getElementsByTagName('span')[0].className);

            };
        })(that);
    }
}
jQuery(document).ready(function () {
    ChartsAmcharts.init();




});
window.onload = function () {
    //document.getElementsByClassName("select2-selection select2-selection--multiple").style.overflowY = "scroll";
    //document.getElementsByClassName("select2-selection select2-selection--multiple").style.height = "60px";



    $('#selectedHost').select2({
        placeholder: "选择查询目标",
        closeOnSelect: false,
        //width: null
    });
    
    $('#selectedHost').trigger('close.select2');


    $('#selectedAlarm').select2({
        placeholder: "选择查询条件",
        closeOnSelect: false
        //width: null
    });
    $('#selectedAlarm').trigger('close');

    if ($(".select2-selection--multiple").length > 0) {
        $(".select2-selection--multiple").css({ overflowY: "scroll", "max-height": 60, "overflow-x": "hidden" });
    }
    // $("#divAlarm .select2-search__field").attr({
    //"placeholder": "请选择报警筛选条件......"
    //})
    //$("#divHost .select2-search__field").attr({
    //"placeholder": "请选择主机筛选条件......"
    //})
    //initCheckWhereULClick();
}
