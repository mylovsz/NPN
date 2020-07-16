/* Formatting function for row details - modify as you need */
function format(d) {

    //$.ajax({
    //        type: "POST",
    //        contentType: "application/json; charset=utf-8",
    //        cache: false,//拒绝缓存
    //        async: false,//异步提交
    //        url: '/Lamp/HostInfoHistory/Returnjsonresult1',
    //        dataType: "json",
    //        success: function (data1) {
    //            var STR="";
    //            STR+='<table id="aaa" cellpadding="5" cellspacing="0" class="lightinfo table table-header-fixed table-striped table-bordered text-center" border="0" style="padding-left:50px;">' +
    //    '<theader><tr>' +
    //        '<td>回路名称</td><td>电压(V)</td><td>电流(A)</td><td>功率(W)</td><td>相位</td><td>回路状态</td><td>获取时间</td>' +
    //    '</tr></theader>'+
    //        '<tbody>' 
    //            for (var i in data1) {
    //                STR += '<tr>' + '<td>' + data1[i].lightname + '</td><td>' + data1[i].voltage + '</td><td>' + data1[i].current + '</td><td>' + data1[i].power + '</td><td>' + data1[i].phase + '</td><td>' + data1[i].state + '</td><td>' + data1[i].time + '</td></tr>';
    //            }
    //            STR+='</tbody>' +'</table>';
    //            return STR;
    //        }
    //})

                var STR="";
                STR += '<table id="aaa" cellpadding="5" cellspacing="0" class="lightinfo table table-advance table-header-fixed table-striped table-bordered text-center" border="0" style="padding-left:50px;">' +
        '<theader><tr>' +
            '<td>回路名称</td><td>电压(V)</td><td>电流(A)</td><td>功率(W)</td><td>相位</td><td>回路状态</td><td>获取时间</td>' +
        '</tr></theader>'+
            '<tbody>' 
                for (var i in d.lightstate) {
                    STR += '<tr>' + '<td>' + d.lightstate[i].lightname + '</td><td>' + d.lightstate[i].voltage + '</td><td>' + d.lightstate[i].current + '</td><td>' + d.lightstate[i].power + '</td><td>' + d.lightstate[i].phase + '</td><td>' + d.lightstate[i].state + '</td><td>' + d.lightstate[i].time + '</td></tr>';
                }
                STR+='</tbody>' +'</table>';
                return STR;
}

var listCheckWhereUL = null;
var startTime;
var endTime;
var pageIndex;
var hostGUID = $("#hhhostGUID").val();
var checkWhere = null;
var hostWhere = null;
var alarmWhere = null;
//分页
var getDataBySrv = function (hostGUID, start, end, pageIndex) {

    var vhost = $("#hhdivHost li");
    hostWhere = "";
    for (var x = 0, len = vhost.length; x < len; x++) {
        var chthat = vhost[x];
        if (chthat.className == "select2-selection__choice") {
            hostWhere += chthat.title + ',';
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

    var valarm = $("#hhdivAlarm li");
    alarmWhere = "";
    for (var x = 0, len = valarm.length; x < len; x++) {
        var chthat = valarm[x];
        if (chthat.className == "select2-selection__choice") {
            alarmWhere += chthat.title + ',';
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
        data: { hostGUID: hostGUID, startDate: start.format('YYYY-MM-DD'), endDate: end.format('YYYY-MM-DD'), pageIndex: pageIndex, hostWhere: hostWhere, alarmWhere: alarmWhere },
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
                $("span#hhiAlCount").text(data[0].iCount);//总记录
                $("span#hhiPage").text(data[0].iPage);//总页数
                if (parseInt($("#hhtoPage").val()) == 1) {
                    $("#hhaprev").hide();
                    $("#hhemPrev").show();
                    $("#hhanext").show();
                    $("#hhemNext").hide();
                }


            }
            else {
                $("tbody").remove();
                $("span#hhiAlCount").text("");
                $("#hhaprev").hide();
                $("#hhemPrev").show();
                $("#hhanext").hide();
                $("#hhemNext").show();
                $("span#hhiPage").text("");
                $('#hhtoPage').val("");
            }
        }
    })
}
//查询
var getDataBySrv1 = function (hostGUID, start, end, pageIndex, hostWhere, alarmWhere) {
    $.ajax({
        url: "/Lamp/AlarmPage/GetDateWhrer",
        data: { hostGUID: hostGUID, startDate: start.format('YYYY-MM-DD'), endDate: end.format('YYYY-MM-DD'), pageIndex: pageIndex, hostWhere: hostWhere, alarmWhere: alarmWhere },
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
                $("span#hhiAlCount").text(data[0].iCount);//总记录
                $("span#hhiPage").text(data[0].iPage);//总页数
                $('#hhtoPage').val("1");
                //if (parseInt($("#toPage").val()) == 1) {}
                $("#hhaprev").hide();
                $("#hhemPrev").show();
                $("#hhanext").show();
                $("#hhemNext").hide();



            }
            else {
                $("tbody").remove();
                $("span#hhiAlCount").text("");
                $("#hhaprev").hide();
                $("#hhemPrev").show();
                $("#hhanext").hide();
                $("#hhemNext").show();
                $("span#hhiPage").text("");
                $('#hhtoPage').val("");
            }
        }
    })
}


var ChartsAmcharts = function () {
    if (hostGUID != "") {
        $("#hhdivHost").hide();
    }

    var handleDateRangePickers = function () {
        if (!jQuery().daterangepicker) {
            return;
        }
        $("#hhaprev").click(function test1() {
            var ipagecount = $("span#hhiPage").text();//总页数
            var vpageIndex = parseInt($("#hhtoPage").val()) - 1;
            if (parseInt(vpageIndex) == 1) {
                $("#hhaprev").hide();
                $("#hhemPrev").show();
            }
            if (parseInt(vpageIndex) < parseInt(ipagecount)) {
                $("#hhanext").show();
                $("#hhemNext").hide();
            }
            $('#hhtoPage').val(parseInt(vpageIndex));
            // $('#reportrange span').html(startTime.format('YYYY-MM-DD') + ' - ' + endTime.format('YYYY-MM-DD'));
            getDataBySrv(hostGUID, startTime, endTime, parseInt(vpageIndex));
        })
        $("#hhanext").click(function test2() {
            var vpageIndex1 = parseInt($("#hhtoPage").val()) + 1;
            var ipagecount = $("span#hhiPage").text();
            if (parseInt(vpageIndex1) >= 1) {
                $("#hhaprev").show();
                $("#hhemPrev").hide();

            }
            if (parseInt(vpageIndex1) == parseInt(ipagecount)) {
                $("#hhemNext").show();
                $("#hhanext").hide();
            }
            $('#hhtoPage').val(parseInt(vpageIndex1));
            //$('#reportrange span').html(startTime.format('YYYY-MM-DD') + ' - ' + endTime.format('YYYY-MM-DD'));
            getDataBySrv(hostGUID, startTime, endTime, parseInt(vpageIndex1));
        })
        $("input#hhtoPage").blur(function () {


            //var ipagecount = $("span#iPage").text();

            if (parseInt($("#hhtoPage").val()) > parseInt($("span#hhiPage").text())) {
                $('#hhtoPage').val("1");
            }
            if (parseInt($("#hhtoPage").val()) < 1) {
                $('#hhtoPage').val("1");
            }
            if (parseInt($("#hhtoPage").val()) == parseInt($("span#hhiPage").text())) {
                $("#hhemNext").show();
                $("#hhanext").hide();
                $("#hhaprev").show();
                $("#hhemPrev").hide();
            }
            //$('#reportrange span').html(startTime.format('YYYY-MM-DD') + ' - ' + endTime.format('YYYY-MM-DD'));
            getDataBySrv(hostGUID, startTime, endTime, parseInt($("#hhtoPage").val()));

        });
        $('#hhreportrange').daterangepicker({
            opens: (App.isRTL() ? 'left' : 'right'),
            startDate: moment().subtract('days', 29),
            endDate: moment(),
            minDate: '01/01/2012',
            maxDate: '12/31/2040',
            dateLimit: {
                days: 3650
            },
            showDropdowns: true,
            showWeekNumbers: true,
            timePicker: false,
            timePickerIncrement: 1,
            timePicker12Hour: true,
            ranges: {
                '今天': [moment(), moment()],
                '昨天': [moment().subtract('days', 1), moment().subtract('days', 1)],
                '最近7天': [moment().subtract('days', 6), moment()],
                '最近30天': [moment().subtract('days', 29), moment()],
                '本月': [moment().startOf('month'), moment().endOf('month')],
                '上个月': [moment().subtract('month', 1).startOf('month'), moment().subtract('month', 1).endOf('month')]
            },
            buttonClasses: ['btn'],
            applyClass: 'green',
            cancelClass: 'default',
            format: 'YYYY-MM-DD',
            separator: ' to ',
            locale: {
                applyLabel: '确定',
                cancelLabel: '取消',
                fromLabel: 'From',
                toLabel: 'To',
                customRangeLabel: '自定义',
                daysOfWeek: ['日', '一', '二', '三', '四', '五', '六'],
                monthNames: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月'],
                firstDay: 1
            }
        },
            function (start, end) {
                $('#hhreportrange span').html(start.format('YYYY-MM-DD') + ' - ' + end.format('YYYY-MM-DD'));
                $("#hhtoPage").val(parseInt(pageIndex));
                startTime = start;
                endTime = end;
                //getDataBySrv(hostGUID, startTime, endTime, pageIndex);
            }
        );
        //Set the initial state of the picker label

        $('#hhreportrange span').html(moment().subtract('days', 29).format('YYYY-MM-DD') + ' - ' + moment().format('YYYY-MM-DD'));
        // $('#toPage').val(parseInt(pageIndex));
        startTime = moment().subtract('days', 29);
        endTime = moment();
        pageIndex = 1;
        hostGUID = $("#hhhostGUID").val();
        $("#hhaprev").hide();
        $("#hhemPrev").show();
        $("#hhemNext").hide();
        //getDataBySrv(hostGUID, startTime, endTime, parseInt(pageIndex));


    }

    var InitBtnSeachClick = function () {
        $("#hhbtnSeach").click(function () {
            var vhost = $("#hhdivHost li");
            hostWhere = "";
            for (var x = 0, len = vhost.length; x < len; x++) {
                var chthat = vhost[x];
                if (chthat.className == "select2-selection__choice") {
                    hostWhere += chthat.title + ',';
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

            var valarm = $("#hhdivAlarm li");
            alarmWhere = "";
            for (var x = 0, len = valarm.length; x < len; x++) {
                var chthat = valarm[x];
                if (chthat.className == "select2-selection__choice") {
                    alarmWhere += chthat.title + ',';
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



            getDataBySrv1(hostGUID, startTime, endTime, parseInt(pageIndex), hostnewStr, alarmnewStr);
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
    var vspan = $("#hhCheckWhere li");
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



$(document).ready(function () {
    ChartsAmcharts.init();


    //$(function () {

    //    var options = {
    //        lines: {
    //            show: true
    //        },
    //        points: {
    //            show: true
    //        },
    //        xaxis: {
    //            tickDecimals: 0,
    //            tickSize: 1
    //        }
    //    };

    //    var data = [];

    //    $.plot("#placeholder1", data, options);

    //    // Fetch one series, adding to what we already have

    //    var alreadyFetched = {};

    //    $("button.fetchSeries").click(function () {

    //        var button = $(this);

    //        // Find the URL in the link right next to us, then fetch the data

    //        var dataurl = button.siblings("a").attr("href");

    //        function onDataReceived(series) {

    //            // Extract the first coordinate pair; jQuery has parsed it, so
    //            // the data is now just an ordinary JavaScript object

    //            var firstcoordinate = "(" + series.data[0][0] + ", " + series.data[0][1] + ")";
    //            button.siblings("span").text("Fetched " + series.label + ", first point: " + firstcoordinate);

    //            // Push the new data onto our existing data array

    //            if (!alreadyFetched[series.label]) {
    //                alreadyFetched[series.label] = true;
    //                data.push(series);
    //            }

    //            $.plot("#placeholder1", data, options);
    //        }

    //        $.ajax({
    //            url: dataurl,
    //            type: "GET",
    //            dataType: "json",
    //            success: onDataReceived
    //        });
    //    });

    //    // Initiate a recurring data update

    //    $("button.dataUpdate").click(function () {

    //        data = [];
    //        alreadyFetched = {};

    //        $.plot("#placeholder1", data, options);

    //        var iteration = 0;

    //        function fetchData() {

    //            ++iteration;

    //            function onDataReceived(series) {

    //                // Load all the data in one pass; if we only got partial
    //                // data we could merge it with what we already have.

    //                data = [series];
    //                $.plot("#placeholder1", data, options);
    //            }

    //            // Normally we call the same URL - a script connected to a
    //            // database - but in this case we only have static example
    //            // files, so we need to modify the URL.

    //            $.ajax({
    //                url: "/Script/Lamp/data-eu-gdp-growth-" + iteration + ".json",
    //                type: "GET",
    //                dataType: "json",
    //                success: onDataReceived
    //            });

    //            if (iteration < 5) {
    //                setTimeout(fetchData, 1000);
    //            } else {
    //                data = [];
    //                alreadyFetched = {};
    //            }
    //        }

    //        setTimeout(fetchData, 1000);
    //    });

    //    // Load the first series by default, so we don't have an empty plot

    //    $("button.fetchSeries:first").click();

    //});

    var table = $('#HostHistoryTable').DataTable({
        "paging":   false,
        "ordering": false,
        "info": false,
        "searching":false,
        "ajax": "/lamp/HostInfoHistory/Returnjsonresult?guid='dfdsafdsfasfdsafdsa'",
        //"ajax": "/Scripts/Lamp/objects.txt",
        "columns": [
            {
                "className": 'details-control',
                "orderable": false,
                "data": null,
                "defaultContent": ''
            },
            { "data": "hostname" },
            { "data": "statetype" },
            { "data": "state" },
            { "data": "starttime" },
            { "data": "stoptime" }
        ]
    });


    // Add event listener for opening and closing details
    $('#HostHistoryTable tbody').on('click', 'td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        }
        else {
            // Open this row
            row.child( format(row.data()) ).show();
            tr.addClass('shown');
        }
    });
});



window.onload = function () {
    //document.getElementsByClassName("select2-selection select2-selection--multiple").style.overflowY = "scroll";
    //document.getElementsByClassName("select2-selection select2-selection--multiple").style.height = "60px";



    $('#hhselectedHost').select2({
        placeholder: "选择查询目标",
        closeOnSelect: false,
        //width: null
    });


    $('#hhselectedAlarm').select2({
        placeholder: "选择查询条件",
        closeOnSelect: false
        //width: null
    });

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