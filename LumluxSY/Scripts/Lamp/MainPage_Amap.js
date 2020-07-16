// 地图
var map;
// 信息弹窗
var infoWindow = null;

var markers = [];

var postReturnView = function (selectHostGuid, stateresult, time) {
    $.ajax({
        type: "POST",
        cache: false,//拒绝缓存
        async: false,//异步提交
        url: '/Lamp/Main/HostRealStateDefaultView',
        data: { guid: selectHostGuid, result: stateresult, datetime: time },
        dataType: 'html',
        success: function (data2) {
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

            var lata = parseFloat(lat)
            var lnga = parseFloat(lng)
            var position = new AMap.LngLat(lnga, lata);//标准写法
            var infoWindow = new AMap.InfoWindow({
                content: '名称：' + sName + '<br/>组名：' + sGroupName + '<br/>状态：' + sStateAlarm + '<br/>地址：' + sHostAdrr
            })
            vmarker = new AMap.Marker({
                position: position,   // 经纬度对象，也可以是经纬度构成的一维数组[116.39, 39.9]
                title: '名称：' + sName + ' 状态：' + sStateAlarm,
                icon: '/Image/Base/' + sHostMapImage,
                extData: {
                    id: that.id,
                    flag: "host",
                    name: sName,
                    groupName: sGroupName,
                    infoWindow: infoWindow
                }
            });
            vmarker.on('click', function (e, handler, context) {
                //e.infoWindow.setContent('名称：' + sName + '<br/>组名：' + sGroupName + '<br/>状态：' + sStateAlarm + '<br/>地址：' + sHostAdrr );
                //e.infoWindow.setContent('名称：' + sName + '<br/>组名：' + sGroupName + '<br/>状态：' + sStateAlarm + '<br/>地址：' + sHostAdrr + '<br/></hr>更多信息：<a class="btngetinfo" name="btngetinfo" data-target="#prjinfo" value="' + e.id + '" data-toggle="modal" href="/Lamp/Main/HostRealStateDefaultView">获取</a>');

                //e.infoWindow.open(map.map);

                showMarker("", e.target)
            })
            map.add(vmarker)
            markers.push(vmarker)
        }





    }
    // isFrist= parseInt(isFrist)+1;
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

function showMarker(e, marker) {
    if (map) {
        if (e != '') {
            for (var mk of markers) {
                if (mk.getExtData().flag == 'host' && mk.getExtData().id == e.getAttribute('id')) {
                    marker = mk
                    break
                }
            }
        }
        var guid = marker.getExtData().id
        var lnglat = marker.getPosition()
        marker.getExtData().infoWindow.open(map, lnglat);
        map.setCenter(lnglat)
        map.setZoom(18)
        //e.infoWindow
        getAllState();
        //alert(e.position.lat() + ':' + e.position.lng());
        $.ajax({
            type: "POST", contentType: "application/json; charset=utf-8",

            url: '/Lamp/Main/AllMarkerLights?sGUID=' + guid,
            dataType: "json",
            success: function (datas) {
                if (datas) {
                    var delMarkers = []
                    for (var x of markers) {
                        if (x.getExtData().flag == 'lamp') {
                            x.setMap(null)
                            delMarkers.push(x)
                        }
                    }
                    if (delMarkers.length>0) {
                        markers.pop(delMarkers);
                    }
                    //单灯
                    for (i in datas) {
                        if (datas[i].sVoltagePercent == 'NA') {
                            var infoWindow = new AMap.InfoWindow({
                                content: '名称：' + datas[i].Name + '<br/>型号：' + datas[i].sDesc + '<br/>所属主机:' + e.firstElementChild.value + '<br/>当前状态：' + datas[i].Faul + '<br/>太阳能电压：' + datas[i].SolarEnergyVoltage + '<br/>电压：' + datas[i].Voltage + '<br/>电流：' + datas[i].Current + '<br/>功率：' + datas[i].Power + '<br/>温度：' + datas[i].sTemperature + '<br/>更新时间：' + datas[i].sUpdateTime
                            })
                            var marker = new AMap.Marker({
                                position: [parseFloat(datas[i].Lng), parseFloat(datas[i].Lat)],
                                title: '名称：' + datas[i].Name + ' 当前状态：' + datas[i].Faul,
                                icon: '/Image/Base/' + datas[i].sImageUrl,
                                extData: {
                                    id: datas[i].GUID,
                                    infoWindow: infoWindow,
                                    flag: 'lamp'
                                }

                            })
                            marker.on('click', function (e) {
                                e.target.getExtData().infoWindow.open(map, e.lnglat);
                            })
                            map.add(marker)
                            markers.push(marker)

                        }
                        else {
                            var infoWindow = new AMap.InfoWindow({ content: '名称：' + datas[i].Name + '<br/>型号：' + datas[i].sDesc + '<br/>所属主机:' + e.firstElementChild.value + '<br/>当前状态：' + datas[i].Faul + '<br/>太阳能电压：' + datas[i].SolarEnergyVoltage + '<br/>电压：' + datas[i].Voltage + '<br/>电流：' + datas[i].Current + '<br/>功率：' + datas[i].Power + '<br/>温度：' + datas[i].sTemperature + '<br/>余量：' + datas[i].sVoltagePercent + '<br/>更新时间：' + datas[i].sUpdateTime })
                            var marker = new AMap.Marker({
                                position: [parseFloat(datas[i].Lng), parseFloat(datas[i].Lat)],
                                title: '名称：' + datas[i].Name + ' 当前状态：' + datas[i].Faul,
                                icon: '/Image/Base/' + datas[i].sImageUrl,
                                extData: {
                                    id: datas[i].GUID,
                                    infoWindow: infoWindow,
                                    flag: 'lamp'
                                }
                            })
                            marker.on('click', function (e) {
                                e.target.getExtData().infoWindow.open(map, e.lnglat);
                            })
                            map.add(marker)
                            markers.push(marker)
                        }

                    }
                }
            }, error: function (error) { alert(error.responseText); }
        });
    }
}

//初始化主页面
var initInfo = function () {
    var test = document.getElementById('gmap_marker');
    if (test == null) {
        return;
    }
    var wheight = parseFloat(window.innerHeight);

    var heightpx = wheight - parseFloat(test.offsetTop)
    var heightpxx = heightpx + 'px';
    $('#gmap_marker').css('height', heightpxx);

    infoWindow = new AMap.InfoWindow();  //使用默认信息窗体框样式，显示信息内容

    var lat = parseFloat($('#MapCenterLat').val())
    var lng = parseFloat($('#MapCenterLng').val())
    var position = new AMap.LngLat(lng, lat);//标准写法

    map = new AMap.Map("gmap_marker", {
        resizeEnable: true,
        center: position,
        zoom: 13
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
                    dstrli += " <li class='media' style='margin-top:5px' id='" + datan.HostInfos[i].GUID + "' onclick='showMarker(this)'> <input id='sHostAdrr' name='sHostAdrr' value='" + datan.HostInfos[i].ID + "' type='hidden'/> <input id='lat' name='lat' value='" + datan.HostInfos[i].Lat + "' type='hidden'/> <input id='lng' name='lng' value='" + datan.HostInfos[i].Lng + "' type='hidden'/> <input id='sHostMapImage' name='sHostMapImage' value='" + datan.HostInfos[i].sImageUrl + "' type='hidden'/> <input id='sStateAlarm' name='sStateAlarm' value='" + datan.HostInfos[i].strHostState + "' type='hidden'/> <input id='sName' name='sName' value='" + datan.HostInfos[i].Name + "' type='hidden'/> <input id='sGroupName' name='sGroupName' value='" + datan.HostInfos[i].GroupName + "' type='hidden'/> <div class='todo-tasklist-item todo-tasklist-item-border-green'><img class='todo-userpic pull-left' src='/Image/Base/" + datan.HostInfos[i].State + ".png' width='27px' height='27px'><div class='todo-tasklist-item-title'>" + datan.HostInfos[i].Name + "<span title='" + datan.HostInfos[i].GroupName + "' class='todo-tasklist-badge badge badge-roundless pull-right'>" + datan.HostInfos[i].AllGroupName + "</span></div><div class='todo-tasklist-controls pull-left'><span class='todo-tasklist-date'><i class='fa fa-calendar'></i>" + datan.HostInfos[i].sUpdateTime + "</span></div><div class='todo-tasklist-controls pull-right'><span class='todo-tasklist-badge badge badge-roundless pull-right'>单灯：" + datan.HostInfos[i].hostByLightCount + "</span></div></div></li>";
                    dstrdiv = "<div class='portlet box grey-salt' style='border:0px;'><div class='portlet-title' style='background-color:#f1f3fa'><div class='caption' style='height:20px'><input style='height:20px;padding: 0px 12px;background-color:#f1f3fa;border:0px solid #f1f3fa' type='text' class='form-control'  id='input' placeholder='快速搜索'></div><div class='tools' style='height:20px;padding:13px 0 8px'><a href='javascript:;' id='aLink' class='collapse'> </a></div></div><div id='IsOpen' class='portlet-body' style='padding:2px 15px'><div class='row'><ul class='media-list list-items scroller'  id='ulMainLeft' style=' overflow:auto;height: 350px;' data-handle-color='#637283'>" + dstrli + "</ul></div></div></div>";
                }

                AMap.leftMenu = function () {
                }
                AMap.leftMenu.prototype = {
                    addTo: function (map, dom) {
                        dom.appendChild(this._getHtmlDom(map));
                    },
                    _getHtmlDom: function (map) {
                        this.map = map;
                        // 创建一个能承载控件的<div>容器                  
                        var controlUI = document.createElement("DIV");
                        controlUI.style.margin = '10px';     //设置控件容器的宽度  
                        controlUI.style.width = '250px';    //设置控件容器的高度    
                        controlUI.style.position = 'absolute';
                        controlUI.style.background = '#FFFFFF';


                        controlUI.innerHTML = dstrdiv;

                        // 设置控件响应点击onclick事件                  
                        //controlUI.onclick = function () {
                        //    map.setCenter(new AMap.LngLat(116.404, 39.915));
                        //}
                        console.log("初始化左侧列表成功")

                        return controlUI;
                    }
                }


                var leftMenu = new AMap.leftMenu(map); //新建自定义插件对象  
                map.addControl(leftMenu);
                //地图上添加插件
                initLeftMeun();
                $("#input").bind('input propertychange', function () {
                    $("#aLink").removeClass().addClass("collapse");
                    $("#IsOpen").removeAttr("style");
                    $("#IsOpen").css({ "dispaly": "block" })
                    SeachlefMeunInfo();
                })
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

                AMap.artleImg = function () {
                }
                AMap.artleImg.prototype = {
                    addTo: function (map, dom) {
                        dom.appendChild(this._getHtmlDom(map));
                    },
                    _getHtmlDom: function (map) {
                        this.map = map;
                        // 创建一个能承载控件的<div>容器                  
                        var controlUI = document.createElement("DIV");
                        controlUI.style.margin = '10px 10px 10px 10px';     //设置控件容器的宽度 
                        controlUI.style.right='10px'
                        controlUI.style.padding = '5px 0px';    //设置控件容器的高度  
                        controlUI.style.position = 'absolute';
                        controlUI.style.background = 'rgba(255, 255, 255, 0.9)';

                        controlUI.innerHTML = strdiv;

                        // 设置控件响应点击onclick事件                  
                        //controlUI.onclick = function () {
                        //    map.setCenter(new AMap.LngLat(116.404, 39.915));
                        //}
                        console.log("初始化地图上的报警配置图片成功")

                        return controlUI;
                    }
                }


                var artleImg = new AMap.artleImg(map); //新建自定义插件对象  
                console.log('artleImg',artleImg)
                map.addControl(artleImg);
                //地图上添加插件
                initLeftMeun();

                //map.addControl({
                //    position: 'top_right',
                //    style: {
                //        margin: '10px',
                //        padding: '5px 0px',
                //        background: 'rgba(255, 255, 255, 0.9)'
                //    },
                //    content: strdiv,
                //});

            }
        },
        error: function (error) {
            location.href = '/Lamp/User/Login'
        }
    });


    AMap.AllHost = function () {
    }
    AMap.AllHost.prototype = {
        addTo: function (map, dom) {
            dom.appendChild(this._getHtmlDom(map));
        },
        _getHtmlDom: function (map) {
            this.map = map;
            // 创建一个能承载控件的<div>容器                  
            var controlUI = document.createElement("DIV");
            controlUI.style.margin = '10px 10px 10px 300px';     //设置控件容器的宽度  
            controlUI.style.padding = '7px 12px';    //设置控件容器的高度  
            controlUI.style.height = '30px';
            controlUI.style.position = 'absolute';
            controlUI.style.background = '#fff';
            controlUI.innerHTML = "全部主机";

            // 设置控件响应点击onclick事件                  
            //controlUI.onclick = function () {
            //    map.setCenter(new AMap.LngLat(116.404, 39.915));
            //}
            console.log("初始化全部主机成功")
            // 设置控件响应点击onclick事件                  
            controlUI.onclick = function () {
                map.setFitView();
            }
            return controlUI;
        }
    }
    var AllHost = new AMap.AllHost(map); //新建自定义插件对象  
    map.addControl(AllHost);


    //AMap.AllHost = function () {
    //}
    //AMap.AllHost.prototype = {
    //    addTo: function (map, dom) {
    //        dom.appendChild(this._getHtmlDom(map));
    //    },
    //    _getHtmlDom: function (map) {
    //        this.map = map;
    //        // 创建一个能承载控件的<div>容器                  
    //        var controlUI = document.createElement("DIV");
    //        controlUI.style.margin = '10px 10px 10px 300px';     //设置控件容器的宽度  
    //        controlUI.style.padding = '7px 12px';    //设置控件容器的高度  
    //        controlUI.style.height = '30px';
    //        controlUI.style.position = 'absolute';
    //        controlUI.style.background = '#fff';
    //        controlUI.innerHTML = "切换Goole地图";

    //        // 设置控件响应点击onclick事件                  
    //        controlUI.onclick = function () {
    //            localStorage.setItem("config_map", "GoogleMap");
    //            $.ajax({
    //                type: "GET",
    //                timeout: 10000,
    //                cache: false,//拒绝缓存
    //                async: false,//异步提交
    //                url: 'ditu.google.cn/maps/api/js?key=AIzaSyAc1YixAJuZBs7nnzCfBAxbwMKYexIU7sw&sensor=true',
    //                dataType: 'Json',
    //                success: function (data2) {
    //                    $.ajax({
    //                        type: "POST",
    //                        cache: false,//拒绝缓存
    //                        async: false,//异步提交
    //                        url: '/Lamp/Main/ConfigMap?map=GoogleMap',
    //                        data: { map: "GoogleMap" },
    //                        dataType: 'Json',
    //                        success: function (data2) {
    //                            location.reload(true);
    //                        },
    //                        error: function (error) {
    //                            location.href = '/Lamp/User/Login';
    //                        }
    //                    })
    //                },
    //                error: function (error) {
    //                    alert("无法访问GooGle地图，停止切换");
    //                }
    //            })
                
    //        }
    //        return controlUI;
    //    }
    //}
    //var AllHost = new AMap.AllHost(map); //新建自定义插件对象  
    //map.addControl(AllHost);


    //map.addControl({
    //    position: 'top_left',
    //    content: '全部主机',
    //    style: {
    //        margin: '10px',
    //        padding: '7px 12px',
    //        height: '30px',
    //        font: 'Roboto,Arial,sans-serif',
    //        background: '#fff'
    //    },
    //    events: {
    //        click: function () {
    //            $("#input").val("");
    //            while (map.markers.length) {
    //                map.markers.pop().setMap(null);
    //            }
    //            infoWindow.close(map.map);
    //            initLeftMeun();

    //            //$("#gmap_marker").height(900);
    //        }
    //    }
    //});

    //map.addControl({
    //    position: 'bottom_left',
    //    content: '<a href="http://www.lumlux.cn" target="_blank">Copyright &copy; Lumlux 2016</a>',
    //    id: 'fo',
    //    style: {
    //        // bottom:'5px',

    //    },

    //});

    //$("#fo").removeAttr("style");
    $("#fo").css({ "bottom": "5px" });
}


$(document).ready(function () {
    initInfo();
});