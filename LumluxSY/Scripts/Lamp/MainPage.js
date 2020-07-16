// 地图
var map;
//弹窗
var infoWindow = null;
//记住ul元素
var list = null;
var imageUrl = '/Image/Base/11.png';
var image = '../Image/Base/10.png';
var testimage = '/Image/Base/m4.png';
var sint;
var timeout = false; //启动及关闭按钮
var alarmlistarray = new Array();

//初始化主机(全部Marker)
var initLeftMeun = function () {
    var l = document.getElementById('ulMainLeft');
    if (l == null)
        return;
    list = l.getElementsByTagName('li');
    for (var i = 0, len = list.length; i < len; i++) {
        var that = list[i];
        var lat = 0, lng = 0; sName = null;
        for (var j = 0; j < that.children.length; j++) {
            if (that.children[j].id == 'lat')
                lat = that.children[j].value;
            if (that.children[j].id == 'lng')
                lng = that.children[j].value;
            if (that.children[j].id == 'sName')
                sName = that.children[j].value;
            if (that.children[j].id == 'sGroupName') {
                sGroupName = that.children[j].value;
            }
            if (that.children[j].id == 'sStateAlarm') {
                sStateAlarm = that.children[j].value;
            }
            if (that.children[j].id == 'sHostAdrr') {
                sHostAdrr = that.children[j].value;
            }
            if (that.children[j].id == 'sHostMapImage') {
                sHostMapImage = that.children[j].value;
            }
        }
        var vmarker;
        if (lat != 0 && lng != 0) {
            vmarker = map.addMarker({
                lat: parseFloat(lat),
                lng: parseFloat(lng),
                title: '名称：' + sName + ' 状态：' + sStateAlarm,
                icon: '/Image/Base/' + sHostMapImage,
                id: that.id,
                flag: "host",
                name: sName,
                groupName: sGroupName,
                click: function (e) {
                   //e.infoWindow.setContent('名称：' + sName + '<br/>组名：' + sGroupName + '<br/>状态：' + sStateAlarm + '<br/>地址：' + sHostAdrr );
                    //e.infoWindow.setContent('名称：' + sName + '<br/>组名：' + sGroupName + '<br/>状态：' + sStateAlarm + '<br/>地址：' + sHostAdrr + '<br/></hr>更多信息：<a class="btngetinfo" name="btngetinfo" data-target="#prjinfo" value="' + e.id + '" data-toggle="modal" href="/Lamp/Main/HostRealStateDefaultView">获取</a>');
                    e.infoWindow.open(map.map);
                    //e.infoWindow
                    getAllState();
                    //alert(e.position.lat() + ':' + e.position.lng());
                    $.ajax({
                        type: "POST", contentType: "application/json; charset=utf-8",

                        url: '/Lamp/Main/AllMarkerLights?sGUID=' + e.id,
                        dataType: "json",
                        success: function (datas) {
                            if (datas) {

                                for (var x = 0; x < map.markers.length; x++) {

                                    if (map.markers[x].flag != "host") {
                                        map.markers[x].setMap(null);
                                    }
                                }
                                //单灯
                                for (i in datas) {
                                    if (datas[i].sVoltagePercent=='NA') {
                                        map.addMarker({
                                            lat: parseFloat(datas[i].Lat),
                                            lng: parseFloat(datas[i].Lng),
                                            title: '名称：' + datas[i].Name + ' 当前状态：' + datas[i].Faul,
                                            icon: '/Image/Base/' + datas[i].sImageUrl,
                                            id: datas[i].GUID,
                                            visible: true,
                                            infoWindow: { content: '名称：' + datas[i].Name + '<br/>型号：' + datas[i].sDesc + '<br/>所属主机:' + e.name + '<br/>当前状态：' + datas[i].Faul + '<br/>太阳能电压：' + datas[i].SolarEnergyVoltage + '<br/>电压：' + datas[i].Voltage + '<br/>电流：' + datas[i].Current + '<br/>功率：' + datas[i].Power + '<br/>温度：' + datas[i].sTemperature + '<br/>更新时间：' + datas[i].sUpdateTime }
                                        })
                                    }
                                    else {
                                        map.addMarker({
                                            lat: parseFloat(datas[i].Lat),
                                            lng: parseFloat(datas[i].Lng),
                                            title: '名称：' + datas[i].Name + ' 当前状态：' + datas[i].Faul,
                                            icon: '/Image/Base/' + datas[i].sImageUrl,
                                            id: datas[i].GUID,
                                            visible: true,
                                            infoWindow: { content: '名称：' + datas[i].Name + '<br/>型号：' + datas[i].sDesc + '<br/>所属主机:' + e.name + '<br/>当前状态：' + datas[i].Faul + '<br/>太阳能电压：' + datas[i].SolarEnergyVoltage + '<br/>电压：' + datas[i].Voltage + '<br/>电流：' + datas[i].Current + '<br/>功率：' + datas[i].Power + '<br/>温度：' + datas[i].sTemperature + '<br/>余量：' + datas[i].sVoltagePercent + '<br/>更新时间：' + datas[i].sUpdateTime }
                                        })
                                    }
                                   
                                }
                            }
                        }, error: function (error) { alert(error.responseText); }
                    });
                    
                },
              
                infoWindow: {
                    //content: '<tbody><tr><td style="text-align:center">' + sName + '</td><td style="text-align:center;color:red">' + sName + '</td><td style="text-align:center;color:red">' + sName + '</td></tr></tbody>'
                    content: '名称：' + sName + '<br/>组名：' + sGroupName + '<br/>状态：' + sStateAlarm + '<br/>地址：' + sHostAdrr
                },
            });
            //vmarker = map.addMarker({
            //    lat: parseFloat(lat),
            //    lng: parseFloat(lng),
            //    title: '名称：' + sName+' 状态：' + sStateAlarm,
            //    icon: '/Image/Base/' + sHostMapImage,
            //    id: that.id,
            //    flag: "host",
            //    name: sName,
            //    groupName: sGroupName,
            //    infoWindow: {
            //        //content: '<tbody><tr><td style="text-align:center">' + sName + '</td><td style="text-align:center;color:red">' + sName + '</td><td style="text-align:center;color:red">' + sName + '</td></tr></tbody>'
            //        content: '名称：' + sName + '<br/>组名：' + sGroupName + '<br/>状态：' + sStateAlarm + '<br/>地址：' + sHostAdrr
            //    },
            //});
           
        }
        


        list[i].onclick = (function (k) {
            timeout == true;
            var info = that.id;
            var lat = 0, lng = 0;
            for (var j = 0; j < that.children.length; j++) {
                if (that.children[j].id == 'lat')
                    lat = that.children[j].value;
                if (that.children[j].id == 'lng')
                    lng = that.children[j].value;
                if (that.children[j].id == 'sName')
                    sName = that.children[j].value;
                if (that.children[j].id == 'sGroupName') {
                    sGroupName = that.children[j].value;
                }
                if (that.children[j].id == 'sStateAlarm') {
                    sStateAlarm = that.children[j].value;
                }
                if (that.children[j].id == 'sHostAdrr') {
                    sHostAdrr = that.children[j].value;
                }
                if (that.children[j].id == 'sHostMapImage') {
                    sHostMapImage = that.children[j].value;
                }
            }
            return function () {
                //for (var i = 0; i < map.markers.length; i++) {
                //    if (map.markers[i].id!=k.id) {
                //        map.markers[i].setMap(null);
                //    }
                //}
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: '/Lamp/Main/AllMarker?sGUID=' + info,
                    dataType: "json",
                    success: function (data) {
                        if (data) {

                            map.setCenter(k.position.lat(), k.position.lng());
                            infoWindow.setContent('名称：' + data.HostInfos[0].Name + '<br/>组名：' + data.HostInfos[0].GroupName + '<br/>状态：' + data.HostInfos[0].strHostState + '<br/>地址：' + data.HostInfos[0].ID);
                           infoWindow.setPosition(k.position);
                           infoWindow.open(map.map);
                           getAllState();
                            //map.setCenter(map.markers[0].position.lat(), map.markers[0].position.lng());
                            //map.markers[0].infoWindow.setPosition(map.markers[0].position);
                            //map.markers[0].infoWindow.open(map.map);

                            $.ajax({
                                type: "POST", contentType: "application/json; charset=utf-8",

                                url: '/Lamp/Main/AllMarkerLights?sGUID=' + info,
                                dataType: "json",
                                success: function (datas) {
                                    if (datas) {
                                        while (map.markers.length) {
                                            map.markers.pop().setMap(null);
                                        }
                                        //主机
                                       var vmk= map.addMarker({
                                           lat: parseFloat(data.HostInfos[0].Lat),
                                           lng: parseFloat(data.HostInfos[0].Lng),
                                           title: data.HostInfos[0].Name + ' 状态：' + data.HostInfos[0].strHostState,
                                            icon: '/Image/Base/' + data.HostInfos[0].sImageUrl,
                                            id: data.HostInfos[0].GUID,
                                            flag: "host",
                                            name: data.HostInfos[0].Name,
                                            click: function (e) {
                                                e.infoWindow.setContent('名称：' + data.HostInfos[0].Name + '<br/>组名：' + data.HostInfos[0].GroupName + '<br/>状态：' + data.HostInfos[0].strHostState + '<br/>地址：' + data.HostInfos[0].ID);
                                                e.infoWindow.open(map.map);
                                                getAllState();
                                            },
                                            infoWindow:
                                            {
                                                content: '名称：' + data.HostInfos[0].Name + '<br/>组名：' + data.HostInfos[0].GroupName + '<br/>状态：' + data.HostInfos[0].strHostState + '<br/>地址：' + data.HostInfos[0].ID,
                                            },
                                            //infowindow: { content: '名称：' + data.HostInfos[0].Name + '<br/>组名：' + data.HostInfos[0].GroupName + '<br/>状态：' + data.HostInfos[0].strHostState + '<br/>地址：' + data.HostInfos[0].ID }
                                       });
                                       
                                       
                                        

                                        //for (var i = 0; i < markers.length; i++) {
                                        //    if (markers[i].id == data.HostInfos[0].GUID) {
                                        //        markers[i].setCenter(markers[i].position.lat(), markers[i].position.lng());
                                        //        markers[i].infoWindow.setPosition(markers[i].position);
                                        //        markers[i].infoWindow.setContent('名称：');
                                        //        markers[i].infoWindow.open(map.map);
                                        //    }
                                           
                                        //}
                                        //单灯
                                       for (i in datas) {
                                           if (datas[i].sVoltagePercent=='NA') {
                                               map.addMarker({
                                                   lat: parseFloat(datas[i].Lat),
                                                   lng: parseFloat(datas[i].Lng),
                                                   title: '名称：' + datas[i].Name + ' 当前状态：' + datas[i].Faul,
                                                   icon: '/Image/Base/' + datas[i].sImageUrl,
                                                   id: datas[i].GUID,
                                                   visible: true,
                                                   infoWindow: { content: '名称：' + datas[i].Name + '<br/>型号：' + datas[i].sDesc + '<br/>所属主机：' + data.HostInfos[0].Name + '<br/>当前状态：' + datas[i].Faul + '<br/>太阳能电压：' + datas[i].SolarEnergyVoltage + '<br/>电压：' + datas[i].Voltage + '<br/>电流：' +datas[i].Current + '<br/>功率：' + datas[i].Power + '<br/>温度：' + datas[i].sTemperature + '<br/>更新时间：' + datas[i].sUpdateTime }
                                               })
                                           }
                                           else {
                                               map.addMarker({
                                                   lat: parseFloat(datas[i].Lat),
                                                   lng: parseFloat(datas[i].Lng),
                                                   title: '名称：' + datas[i].Name + ' 当前状态：' + datas[i].Faul,
                                                   icon: '/Image/Base/' + datas[i].sImageUrl,
                                                   id: datas[i].GUID,
                                                   visible: true,
                                                   infoWindow: { content: '名称：' + datas[i].Name + '<br/>型号：' + datas[i].sDesc + '<br/>所属主机：' + data.HostInfos[0].Name + '<br/>当前状态：' + datas[i].Faul + '<br/>太阳能电压：' + datas[i].SolarEnergyVoltage + '<br/>电压：' + datas[i].Voltage + '<br/>电流：' + datas[i].Current + '<br/>功率：' + datas[i].Power + '<br/>温度：' + datas[i].sTemperature + '<br/>余量：' + datas[i].sVoltagePercent + '<br/>更新时间：' + datas[i].sUpdateTime }
                                               })
                                           }
                                           
                                        }
                                        //map.setZoom();
                                    }
                                }, error: function (error) { alert(error.responseText); }
                            });
                            

                        }
                    }, error: function (error) { alert(error.responseText); }
                });
                
            };
        })(vmarker);
        
    }
    // isFrist= parseInt(isFrist)+1;
}


//$('.btngetinfo').bind("click",(function (e, data) {
//    if (e!=null) {
//        $.ajax({
//            type: "POST",
//            contentType: "application/json; charset=utf-8",
//            url: '/Lamp/Main/ReturnAllInfo?sGUID=' + e.id,
//            dataType: "json",
//            success: function (data) {
//                if (data != null) {

//                }
//            }
//        })
//    }
//}))

//$(infoWindow).click(function () {
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: '/Lamp/Main/ReturnAllInfo?sGUID=' + e.id,
//        dataType: "json",
//        success: function (data) {
//            if (data != null) {

//            }
//        }
//    })
//})
var i = 1;
//单灯数据查询
var GetCircuitRev = function (selectHostGuid) {
    if (i <= 7) {
        i++;
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            cache: false,//拒绝缓存
            async: false,//异步提交
            url: '/Lamp/Main/HostRealStateReceiveState?sGUID=' + selectHostGuid + '&sTime=' + i * 2,
            dataType: "json",
            success: function (data1) {
                switch (data1.Stateresult) {
                    case 3:
                        postReturnView(selectHostGuid, data1.Stateresult, data1.StateDateTime);
                        App.blockUI({ target: "#HostAllInfoDlg", boxed: !0, overlayColor: '#000', message: "参数错误!" });
                        window.setTimeout(function () { App.unblockUI("#HostAllInfoDlg"); }, 2000);

                        i = 1;
                        break;
                    case 4:
                        postReturnView(selectHostGuid, data1.Stateresult, data1.StateDateTime);
                        App.blockUI({ target: "#HostAllInfoDlg", boxed: !0, overlayColor: '#000', message: "无此主机!" });
                        window.setTimeout(function () { App.unblockUI("#HostAllInfoDlg"); }, 2000);
                        i = 1;
                        break;
                    case 5:
                        postReturnView(selectHostGuid, data1.Stateresult, data1.StateDateTime);
                        App.blockUI({ target: "#HostAllInfoDlg", boxed: !0, overlayColor: '#000', message: "未配置测量板!" });
                        window.setTimeout(function () { App.unblockUI("#HostAllInfoDlg"); }, 2000);
                        i = 1;
                        break;
                    case 6:
                        window.setTimeout(function () { GetCircuitRev(selectHostGuid) },1500);//1.5秒钟。
                        break;
                    case 7:
                        postReturnView(selectHostGuid, data1.Stateresult, data1.StateDateTime);
                        App.blockUI({ target: "#HostAllInfoDlg", boxed: !0, overlayColor: '#000', message: "获取成功!" });
                        window.setTimeout(function () { App.unblockUI("#HostAllInfoDlg"); }, 2000);
                        break;
                    default:
                        i = 1;
                        postReturnView(selectHostGuid, 6, data1.StateDateTime);
                        App.blockUI({ target: "#HostAllInfoDlg", boxed: !0, overlayColor: '#000', message: "获取失败!" });
                        window.setTimeout(function () { App.unblockUI("#HostAllInfoDlg"); }, 2000);
                        break;
                }
            },
            error: function (error) {
                i = 1;
                location.href = '/Lamp/User/Login';
            }
        })
    }
    else {
        i = 1;
        postReturnView(selectHostGuid, 6);
        App.blockUI({ target: "#HostAllInfoDlg", boxed: !0, overlayColor: '#000', message: "获取失败!" });
        window.setTimeout(function () { App.unblockUI("#HostAllInfoDlg"); }, 2000);
    }
}

var postReturnView=function(selectHostGuid,stateresult,time)
{
    $.ajax({
        type: "POST",
        cache: false,//拒绝缓存
        async: false,//异步提交
        url: '/Lamp/Main/HostRealStateDefaultView',
        data:{guid:selectHostGuid,result:stateresult,datetime:time},
        dataType: 'html',
        success:function(data2)
        {
            $("#divDlg").html(data2);
            $("#btnreload").click(function () {
                updateAllState(selectHostGuid);
            })
        },
        error: function (error) {
            location.href = '/Lamp/User/Login';
        }
    })
}

var updateAllState = function (selectHostGuid) {
    App.blockUI({ target: "#HostAllInfoDlg", boxed: !0, overlayColor: '#000', message: "正在获取!" });
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,//拒绝缓存
        async: false,//异步提交
        url: '/Lamp/Main/GetHostRealStateCmdPost?sGuid=' + selectHostGuid,
        dataType: "json",
        success: function (data) {
            switch (data) {
                case 0:
                    postReturnView(selectHostGuid, data);
                    App.blockUI({ target: "#HostAllInfoDlg", boxed: !0, overlayColor: '#000', message: "无此主机!" });
                    window.setTimeout(function () { App.unblockUI("#HostAllInfoDlg"); }, 2000);

                    break;
                case 1:
                    postReturnView(selectHostGuid, data);
                    App.blockUI({ target: "#HostAllInfoDlg", boxed: !0, overlayColor: '#000', message: "请为主机添加地址!" });
                    window.setTimeout(function () { App.unblockUI("#HostAllInfoDlg"); }, 2000);

                    break;
                case 2:
                    postReturnView(selectHostGuid, data);
                    App.blockUI({ target: "#HostAllInfoDlg", boxed: !0, overlayColor: '#000', message: "数据库错误!" });
                    window.setTimeout(function () { App.unblockUI("#HostAllInfoDlg"); }, 2000);

                    break;
                case 3:
                    GetCircuitRev(selectHostGuid);//1000为1秒钟,设置为1分钟。
                    break;
                default:
                    postReturnView(selectHostGuid, data);
                    App.blockUI({ target: "#HostAllInfoDlg", boxed: !0, overlayColor: '#000', message: "获取失败!" });
                    window.setTimeout(function () { App.unblockUI("#HostAllInfoDlg"); }, 2000);

                    break;
            }
        },
        error: function (error) {
            location.href = '/Lamp/User/Login';
        }
    })
}

var getAllState = function () {
    $("a[name='btngetinfo']").bind("click", (function (e) {
        if (e != null) {
            var selectHostGuid = e.currentTarget.getAttributeNode("value").value;
            $("#prjinfo").on("hidden.bs.modal", function () {
                $("#divDlg").html("");
            });

            $("#prjinfo").on("shown.bs.modal", function () {
                i = 1;
                updateAllState(selectHostGuid);

                $("#btnreload").click(function () {
                    updateAllState(selectHostGuid);
                })
            });
        }
    }))
}



//刷新状态-实时
var ReloadState = function () {
    //$("#fo").css({ "bottom": "5px" });
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,//拒绝缓存
        async: false,//异步提交
        url: '/Lamp/Main/ReloadState',
        dataType: "json",
        success: function (datass) {
            if (datass) {
                if (alarmlistarray.length >= 0) {
                    alarmlistarray.splice(0, alarmlistarray.length);
                    console.log(alarmlistarray)
                }
                var leftlul = document.getElementById("ulMainLeft");
                if (leftlul == null)
                    return;
                listleftulli = leftlul.getElementsByTagName("li");
                for (var i = 0, len = listleftulli.length; i < len; i++) {
                    var thatleftlist = listleftulli[i];
                    for (x in datass) {
                        if (thatleftlist.id == datass[x].GUID) {
                            img = document.getElementById(thatleftlist.id).getElementsByTagName("img")[0];
                            img.src = '/Image/Base/' + datass[x].State + '.png';
                        }
                    }
                }

                for (y in datass) {
                    if (datass[y].AlarmState == "alarm") {
                        datass[y].AlarmDesc = "主机报警";
                        alarmlistarray.push($.extend(true, {}, (datass[y])));
                    }
                    if(datass[y].hostByAlarmLightCount > 0)
                    {
                        datass[y].AlarmDesc = "单灯报警:" + datass[y].hostByAlarmLightCount;
                        alarmlistarray.push(datass[y])
                    }
                }

                var str = "";

                for (var i = 0; i < alarmlistarray.length; i++) {
                    str += " <li class='media' style='margin-top:5px' id='" + alarmlistarray[i].GUID + "'><a href='/Lamp/LayoutMetronic/AlarmInfos?sGUID=" + alarmlistarray[i].GUID + "'><div class='todo-tasklist-item'><img class='todo-userpic pull-left' src='/Image/Base/alarm.png' width='27px' height='27px'><div class='todo-tasklist-item-title'>" + alarmlistarray[i].Name + "<span class='todo-tasklist-badge badge badge-roundless pull-right'>" + alarmlistarray[i].GroupName + "</span></div><div class='todo-tasklist-controls pull-left'><span class='todo-tasklist-date'><i class='fa fa-calendar'></i>" + alarmlistarray[i].sUpdateTime + " </span></div><div class='todo-tasklist-controls pull-right'><span class='todo-tasklist-badge badge badge-roundless pull-right'>" + alarmlistarray[i].AlarmDesc + "</span></div></div></a></li>";
                }
                document.getElementById('AlarmUL').innerHTML = str;
                document.getElementById('salarm_1').innerHTML = alarmlistarray.length > 9 ? "9+" : alarmlistarray.length;
                document.getElementById('salarm_2').innerHTML = alarmlistarray.length > 9 ? "9+" : alarmlistarray.length;
            }
        },
        error: function (error) {
            location.href = '/Lamp/User/Login'
        }
    });

    var counts = 0;
    for (var i = 0; i < map.markers.length; i++) {

        if (map.markers[i].flag == "host") {
            counts = counts + 1;
        }
    }
    //代表点击了左菜单
    if (counts == 1) {
        var hostselecteguid = map.markers[0].id;
        
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: '/Lamp/Main/curHostAllLights?hostGUID=' + hostselecteguid,
            dataType: "json",
            success: function (datax) {
                if (datax) {
                    for (var i = 0; i < map.markers.length; i++) {
                        for (x in datax) {
                            //判断是否是单灯
                            if (map.markers[i].id == datax[x].GUID) {
                                if (datax[x].sVoltagePercent=='NA') {
                                    //map.markers[i].setIcon("/"+datax[x].sImageUrl);
                                    map.markers[i].setIcon('/Image/Base/' + datax[x].sImageUrl);
                                    map.markers[i].setTitle('名称：' + datax[x].Name + ' 当前状态：' + datax[x].Faul);
                                    map.markers[i].infoWindow.setContent('名称：' + datax[x].Name + '<br/>型号：' + datax[x].sDesc + '<br/>所属主机：' + map.markers[0].name + '<br/>当前状态：' + datax[x].Faul + '<br/>太阳能电压：' + datax[x].SolarEnergyVoltage + '<br/>电压：' + datax[x].Voltage + '<br/>电流：' + datax[x].Current + '<br/>功率：' + datax[x].Power + '<br/>温度：' + datax[x].sTemperature + '<br/>更新时间：' + datax[x].sUpdateTime);
                                }
                                else {
                                    //map.markers[i].setIcon("/"+datax[x].sImageUrl);
                                    map.markers[i].setIcon('/Image/Base/' + datax[x].sImageUrl);
                                    map.markers[i].setTitle('名称：' + datax[x].Name + ' 当前状态：' + datax[x].Faul);
                                    map.markers[i].infoWindow.setContent('名称：' + datax[x].Name + '<br/>型号：' + datax[x].sDesc + '<br/>所属主机：' + map.markers[0].name + '<br/>当前状态：' + datax[x].Faul + '<br/>太阳能电压：' + datax[x].SolarEnergyVoltage + '<br/>电压：' + datax[x].Voltage + '<br/>电流：' + datax[x].Current + '<br/>功率：' + datax[x].Power + '<br/>温度：' + datax[x].sTemperature + '<br/>余量：' + datax[x].sVoltagePercent + '<br/>更新时间：' + datax[x].sUpdateTime);
                                }
                            }
                        }

                    }
                }
            },
            error: function (error) {
                location.href = '/Lamp/User/Login'
            }

        });
       
    }
    //地图上的报警配置图片-实时
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '/Lamp/Main/RealTimeAlarmDemoInfo?RTPrjctGUID=' + $("#PrjectGUID").val(),
        dataType: "json",
        success: function (datam) {
            if (datam) {
                var strul = "";
                var strli = "";
                for (i in datam) {
                    strli += "<li>&nbsp;&nbsp;<img src='/Image/Base/" + datam[i].sValue + "' />&nbsp;&nbsp;" + datam[i].sDesc + "&nbsp;&nbsp;</li>";
                    strul = "<div id='imageBaic' style='float:right;'><ul>" + strli + "</ul></div>";
                }
                document.getElementById('imageBaic').innerHTML = strul;
            }
        },
        error: function (error) {
            location.href = '/Lamp/User/Login'
        }
    });

}

//初始化主页面
var initInfo = function () {
    var test = document.getElementById('gmap_marker');
    if (test==null) {
        return;
    }
    var wheight = parseFloat(window.innerHeight);

    var heightpx = wheight - parseFloat(test.offsetTop)
    var heightpxx = heightpx + 'px';
    $('#gmap_marker').css('height', heightpxx);

    infoWindow = new google.maps.InfoWindow({ pixelOffset: new google.maps.Size(-1, -41) });
    map = new GMaps({
        el: '#gmap_marker',
        lat: parseFloat($('#MapCenterLat').val()),
        lng: parseFloat($('#MapCenterLng').val()),
    });
    //初始化地图上的左菜单
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //url: '/Lamp/Main/AlarmDemoInfo?PrjctGUID=' + $("#PrjectGUID").val(),
        url: '/Lamp/Main/MapInitLeftMenu',
        dataType: "json",
        success: function (datan) {
            if (datan) {
                var dstrdiv = "";
                var dstrli = "";
                for (i in datan.HostInfos) {
                    dstrli += " <li class='media' style='margin-top:5px' id='" + datan.HostInfos[i].GUID + "'> <input id='sHostAdrr' name='sHostAdrr' value='" + datan.HostInfos[i].ID + "' type='hidden'/> <input id='lat' name='lat' value='" + datan.HostInfos[i].Lat + "' type='hidden'/> <input id='lng' name='lng' value='" + datan.HostInfos[i].Lng + "' type='hidden'/> <input id='sHostMapImage' name='sHostMapImage' value='" + datan.HostInfos[i].sImageUrl + "' type='hidden'/> <input id='sStateAlarm' name='sStateAlarm' value='" + datan.HostInfos[i].strHostState + "' type='hidden'/> <input id='sName' name='sName' value='" + datan.HostInfos[i].Name + "' type='hidden'/> <input id='sGroupName' name='sGroupName' value='" + datan.HostInfos[i].GroupName + "' type='hidden'/> <div class='todo-tasklist-item todo-tasklist-item-border-green'><img class='todo-userpic pull-left' src='/Image/Base/" + datan.HostInfos[i].State + ".png' width='27px' height='27px'><div class='todo-tasklist-item-title'>" + datan.HostInfos[i].Name + "<span title='" + datan.HostInfos[i].GroupName + "' class='todo-tasklist-badge badge badge-roundless pull-right'>" + datan.HostInfos[i].AllGroupName + "</span></div><div class='todo-tasklist-controls pull-left'><span class='todo-tasklist-date'><i class='fa fa-calendar'></i>" + datan.HostInfos[i].sUpdateTime + "</span></div><div class='todo-tasklist-controls pull-right'><span class='todo-tasklist-badge badge badge-roundless pull-right'>单灯：" + datan.HostInfos[i].hostByLightCount + "</span></div></div></li>";
                    dstrdiv = "<div class='portlet box grey-salt' style='border:0px;'><div class='portlet-title' style='background-color:#f1f3fa'><div class='caption' style='height:20px'><input style='height:20px;padding: 0px 12px;background-color:#f1f3fa;border:0px solid #f1f3fa' type='text' class='form-control'  id='input' placeholder='快速搜索'></div><div class='tools' style='height:20px;padding:13px 0 8px'><a href='javascript:;' id='aLink' class='collapse'> </a></div></div><div id='IsOpen' class='portlet-body' style='padding:2px 15px'><div class='row'><ul class='media-list list-items scroller'  id='ulMainLeft' style=' overflow:auto;height: 350px;' data-handle-color='#637283'>" + dstrli + "</ul></div></div></div>";
                }
                //document.getElementById('test1').innerHTML = dstrdiv;
                map.addControl({
                    position: 'left',
                    content: dstrdiv,
                    style: {
                        margin: '10px',
                        width: '250px',
                        background: '#FFFFFF'
                    },
                });

            }
        },
        error: function (error) {
            location.href = '/Lamp/User/Login'
        }
    });



    //初始化地图上的报警配置图片
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '/Lamp/Main/AlarmDemoInfo?PrjctGUID=' + $("#PrjectGUID").val(),
        dataType: "json",
        success: function (datam) {
            if (datam) {
                var strdiv = "";
                var strli = "";
                for (i in datam) {
                    strli += "<li style='margin:0px 10px;'>&nbsp;&nbsp;<img style= 'margin-right: 5px;' src='/Image/Base/" + datam[i].sValue + "' />" + datam[i].sDesc + "</li>";
                    strdiv = "<div id='imageBaic' style='float:right;'><ul>" + strli + "</ul></div>";
                }
                map.addControl({
                    position: 'top_right',
                    style: {
                        margin: '10px',
                        padding: '5px 0px',
                        background: 'rgba(255, 255, 255, 0.9)'
                    },
                    content: strdiv,
                });

            }
        },
        error: function (error) {
            location.href = '/Lamp/User/Login'
        }
    });

    map.addControl({
        position: 'top_left',
        content: '全部主机',
        style: {
            margin: '10px',
            padding: '7px 12px',
            height: '30px',
            font: 'Roboto,Arial,sans-serif',
            background: '#fff'
        },
        events: {
            click: function () {
                $("#input").val("");
                while (map.markers.length) {
                    map.markers.pop().setMap(null);
                }
                infoWindow.close(map.map);
                initLeftMeun();
                
                //$("#gmap_marker").height(900);
            }
        }
    });

    //map.addControl({
    //    position: 'top_left',
    //    content: '切换高德地图',
    //    style: {
    //        margin: '10px',
    //        padding: '7px 12px',
    //        height: '30px',
    //        font: 'Roboto,Arial,sans-serif',
    //        background: '#fff'
    //    },
    //    events: {
    //        click: function () {
    //            localStorage.setItem("config_map", "AMap");
    //            $.ajax({
    //                type: "POST",
    //                cache: false,//拒绝缓存
    //                async: false,//异步提交
    //                url: '/Lamp/Main/ConfigMap?map=AMap',
    //                data: { map: "AMap" },
    //                dataType: 'Json',
    //                success: function (data2) {
    //                    location.reload(true);
    //                },
    //                error: function (error) {
    //                    location.href = '/Lamp/User/Login';
    //                }
    //            })
    //        }
    //    }
    //});

    map.addControl({
        position: 'bottom_left',
        content: '<a href="http://www.lumlux.cn" target="_blank">Copyright &copy; Lumlux 2016</a>',
        id:'fo',
        style: {
           // bottom:'5px',
            
        },
       
    });
    
    //initLeftMeun();
    map.addListener("tilesloaded", function () {
        var hostcout = 0;
        // $.ajaxSetup({ cache: false });
        for (var i = 0; i < map.markers.length; i++) {

            if (map.markers[i].flag == "host") {
                hostcout = hostcout + 1;
            }
        }
        if (hostcout!=1) {
            initLeftMeun();
            $("#input").keyup(function (e) {

                $("#aLink").removeClass().addClass("collapse");
                $("#IsOpen").removeAttr("style");
                $("#IsOpen").css({ "dispaly": "block" })
                SeachlefMeunInfo();
            });
            //$("#fo").removeAttr("style");
            $("#fo").css({ "bottom": "5px" });
        }
    });
}
//模糊搜索刷新
function SeachlefMeunInfo() {
    
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '/Lamp/Main/SeachData?sWhere=' + $("#input").val(),
        dataType: "json",
        success: function (data) {
            if (data) {
                var luls = document.getElementById("ulMainLeft");
                if (luls == null)
                    return;
                listullis = luls.getElementsByTagName("li");
                for (var i = 0, len = listullis.length; i < len; i++) {
                    var thatlists = listullis[i];
                    $("#ulMainLeft #" + thatlists.id).hide();
                }
                for (x in data) {
                    for (var i = 0, len = listullis.length; i < len; i++) {
                        var thatlists = listullis[i];
                        if (data[x].GUID == thatlists.id) {
                            $("#ulMainLeft #" + thatlists.id).show();
                        }
                    }
                }
            }
        },
        error: function (error) {
            location.href = '/Lamp/User/Login'
        }
    });
}

//$("#btnreload").click(function () {
//    setTimeout(function () {
//        $("#cancle").click();
//    },2000);
//})


setInterval(ReloadState, 10000);


$(document).ready(function () {
    initInfo();
});

window.onload = function () {
    
}
