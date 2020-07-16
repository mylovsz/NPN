var hostGUID = $("#hostGUID").val();
var checkWhere = null;
var hostWhere = null;
var startTime;
var endTime;
var alarmWhere = null;
var LightName = null;
var ChartsAmcharts = function () {
    var getDataBySrv = function (start, end, hostWhere, alarmWhere, LightName) {
        $.ajax({
            url: "/Lamp/FailureRate/Index",
            data: { startDate: start.format('YYYY-MM-DD HH:mm:ss'), endDate: end.format('YYYY-MM-DD HH:mm:ss'), hostWhere: hostWhere, alarmWhere: alarmWhere, LightName: LightName },
            type: "POST",
            dataType: "json",
            success: function (data) {
                if (true) {


                    initChartSample7(data);


                    var strtr = "";
                    for (i in data) {
                        if (parseFloat(data[i].sValue) != 100) {


                            // strtr += "<li>&nbsp;&nbsp;<img src='/Image/Base/" + datam[i].sValue + "' />&nbsp;&nbsp;" + datam[i].sDesc + "&nbsp;&nbsp;</li>";
                            strtr += "<tr><td>" + data[i].sKey + "：</td><td>" + (parseFloat(data[i].sValue)/10000*100).toFixed(2) + "%</td></tr>";
                        }
                    }
                    document.getElementById('tDESC').innerHTML = strtr;
                }
            }
        })
    }

    var initChartSample7 = function (datas) {
        var chartData = [];
        generateChartData(datas);

        function generateChartData(datas) {
            for (var i = 0; i < datas.length; i++) {
                chartData.push({ sKey: datas[i].sKey, sValue: parseInt(datas[i].sValue) });
            }
        }

        var chart = AmCharts.makeChart("chart_7", {
            "type": "pie",
            "theme": "light",

            "fontFamily": 'Open Sans',

            "color": '#888',

            "dataProvider": chartData,
            "valueField": "sValue",
            "titleField": "sKey",
            "outlineAlpha": 0.4,
            "depth3D": 30,
            "pullOutRadius": 10,
            "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>",
            "angle": 40,
            "exportConfig": {
                menuItems: [{
                    icon: '/lib/3/images/export.png',
                    format: 'png'
                }]
            }
        });

        jQuery('.chart_7_chart_input').off().on('input change', function () {
            var property = jQuery(this).data('property');
            var target = chart;
            var value = Number(this.value);
            chart.startDuration = 0;

            if (property == 'innerRadius') {
                value += "%";
            }

            target[property] = value;
            chart.validateNow();
        });

        $('#chart_7').closest('.portlet').find('.fullscreen').click(function () {
            chart.invalidateSize();
        });
    }



    var handleDateRangePickers = function () {
        if (!jQuery().daterangepicker) {
            return;
        }

        $('#sreportrange').daterangepicker({
            opens: (App.isRTL() ? 'left' : 'left'),
            startDate: moment(),
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
            timePickerSeconds:true,
            ranges: {
                '最近1小时': [moment().subtract('hours', 1), moment()],
                '今天': [moment().startOf('days'), moment().endOf('days')],
                '昨日': [moment().subtract('days', 1).startOf('day'), moment().subtract('days', 1).endOf('day')],
                '最近7天': [moment().subtract('days', 6).startOf('days'), moment().subtract('days', 0).endOf('days')],
                '最近30天': [moment().subtract('days', 29).startOf('days'), moment().subtract('days', 0).endOf('days')],
                '本月': [moment().startOf('month'), moment().endOf('month')],
                '上个月': [moment().subtract('month', 1).startOf('month'), moment().subtract('month',1).endOf('month')]
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
               $('#sreportrange span').html(start.format('YYYY-MM-DD HH:mm:ss') + ' - ' + end.format('YYYY-MM-DD HH:mm:ss'));
               startTime = start;
               endTime = end;
               //getDataBySrv(hostGUID, startTime, endTime, pageIndex);
           }
       );
        //Set the initial state of the picker label
        //var s = moment();
        //var e = moment();
        $('#sreportrange span').html(moment().startOf('seconds').format('YYYY-MM-DD HH:mm:ss') + ' - ' + moment().endOf('seconds').format('YYYY-MM-DD HH:mm:ss'));
        // getDataBySrv(s, e);


        startTime = moment();
        endTime = moment();

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

        getDataBySrv(startTime, endTime, hostnewStr, alarmnewStr, $("#LightName").val());

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
            

            getDataBySrv(startTime, endTime, hostnewStr, alarmnewStr, $("#LightName").val());
        })
    }
    return {
        //main function to initiate the module

        init: function () {

            handleDateRangePickers();
            InitBtnSeachClick();

            //initChartSample7();

        }

    };

}();

jQuery(document).ready(function () {
    ChartsAmcharts.init();
});

window.onload = function () {


    $('#selectedHost').select2({
        placeholder: "选择查询目标",
        closeOnSelect: false,
    });

    $('#selectedAlarm').select2({
        placeholder: "选择查询条件",
        closeOnSelect: false,
    });
    if ($(".select2-selection--multiple").length > 0) {
        $(".select2-selection--multiple").css({ "overflow-y": "scroll", "max-height":60, "overflow-x": "hidden"});
    }
}