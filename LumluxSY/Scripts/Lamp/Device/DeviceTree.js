var map;
var infoWindow = null;

var UITree = function () {

    //以指定的Json数据，初始化JStree控件
    //treeName为树div名称，url为数据源地址，checkbox为是否显示复选框，loadedfunction为加载完毕的回调函数
    function bindJsTree(treeName, url, checkbox, loadedfunction) {
        var control = $('#' + treeName)
        control.data('jstree', false);//清空数据，必须

        var isCheck = arguments[2] || false; //设置checkbox默认值为false
        if (isCheck) {
            //复选框树的初始化
            $.getJSON(url, function (data) {
                control.jstree({
                    'plugins': ["checkbox"], //出现选择框
                    'checkbox': { cascade: "", three_state: false }, //不级联
                    'core': {
                        'data': data,
                        "themes": {
                            "responsive": false
                        }
                    }
                }).bind('loaded.jstree', loadedfunction);
            });
        }
        else {
            //普通树列表的初始化
            $.getJSON(url, function (data) {
                control.jstree({
                    'core': {
                        'data': data,
                        "themes": {
                            "responsive": false
                        }
                    }
                }).bind('loaded.jstree', loadedfunction);
            });
        }
    }

    var ShowInfo = function (guid) {

        var url = '/Lamp/Device/EditHostInfo';
        $.ajax({
            type: 'POST',
            url: url,
            data: { hostGuid: guid + "" },
            success: function (data) {
                if (data) {
                    var infoHtml = "<div style='width:280px;height:200px'>" + data + "</div>";
                    //map.setCenter(parseFloat(data.fLat), parseFloat(data.fLng));
                    infoWindow.setContent(infoHtml);
                    infoWindow.setPosition(map.map.center);
                    infoWindow.open(map.map);
                }
            },
            error: function (error) {
                alert(error.responseText);
            }
        });
    }

    return {

        init: function () {

            var treeUrl = '/Lamp/Device/GetDeviceTreeForJson';

            bindJsTree("tree_3", treeUrl);

            //树控件的变化事件处理
            $('#tree_3').on("changed.jstree", function (e, data) {

                ShowInfo(data.selected);

            });
        }

    };

}();

var UIMap = function () {

    var MapInit = function () {
        map = new GMaps({
            div: '#gmap_marker',
            lat: parseFloat($('#MapCenterLat').val()),
            lng: parseFloat($('#MapCenterLng').val())
        });
    };

    var LoadHostInfo = function () {
        var url = '/Lamp/Device/GetHostInfos';
        $.ajax({
            type: 'POST',
            url: url,
            dataType: "json",
            success: function (data) {
                if (data) {
                    for (var i=0;i<data.length;i++)
                    {
                        map.addMarker({
                            lat: parseFloat(data[i].fLat),
                            lng: parseFloat(data[i].fLng),
                            title: '' + data[i].sName,
                            //icon: image,
                            visible: true,
                            //infoWindow: {
                            //    content: '<span style="color:#000">hi,' + data[i].sName + '</span>'
                            //}
                        });
                    }
                }
            },
            error: function (error) {
                alert(error.responseText);
            }
        });
    };

    return {
        init: function () {

            infoWindow = new google.maps.InfoWindow();

            MapInit();

            LoadHostInfo();
        }
    }
}();

var TableDatatablesEditable = function () {

    var handleTable = function () {

        function restoreRow(oTable, nRow) {
            var aData = oTable.fnGetData(nRow);
            var jqTds = $('>td', nRow);

            for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
                oTable.fnUpdate(aData[i], nRow, i, false);
            }

            oTable.fnDraw();
        }

        function editRow(oTable, nRow) {
            var aData = oTable.fnGetData(nRow);
            var jqTds = $('>td', nRow);
            jqTds[0].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[0] + '">';
            jqTds[1].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[1] + '">';
            jqTds[2].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[2] + '">';
            jqTds[3].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[3] + '">';
            jqTds[4].innerHTML = '<a class="edit" href="">Save</a>';
            jqTds[5].innerHTML = '<a class="cancel" href="">Cancel</a>';
        }

        function saveRow(oTable, nRow) {
            var jqInputs = $('input', nRow);
            oTable.fnUpdate(jqInputs[0].value, nRow, 0, false);
            oTable.fnUpdate(jqInputs[1].value, nRow, 1, false);
            oTable.fnUpdate(jqInputs[2].value, nRow, 2, false);
            oTable.fnUpdate(jqInputs[3].value, nRow, 3, false);
            oTable.fnUpdate('<a class="edit" href="">Edit</a>', nRow, 4, false);
            oTable.fnUpdate('<a class="delete" href="">Delete</a>', nRow, 5, false);
            oTable.fnDraw();
        }

        function cancelEditRow(oTable, nRow) {
            var jqInputs = $('input', nRow);
            oTable.fnUpdate(jqInputs[0].value, nRow, 0, false);
            oTable.fnUpdate(jqInputs[1].value, nRow, 1, false);
            oTable.fnUpdate(jqInputs[2].value, nRow, 2, false);
            oTable.fnUpdate(jqInputs[3].value, nRow, 3, false);
            oTable.fnUpdate('<a class="edit" href="">Edit</a>', nRow, 4, false);
            oTable.fnDraw();
        }

        var table = $('#sample_editable_1');

        var oTable = table.dataTable({

            // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
            // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js). 
            // So when dropdowns used the scrollable div should be removed. 
            //"dom": "<'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r>t<'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",

            "lengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "All"] // change per page values here
            ],

            // Or you can use remote translation file
            //"language": {
            //   url: '//cdn.datatables.net/plug-ins/3cfcc339e89/i18n/Portuguese.json'
            //},

            // set the initial value
            "pageLength": 5,

            "language": {
                "lengthMenu": " _MENU_ records"
            },
            "columnDefs": [{ // set default column settings
                'orderable': true,
                'targets': [0]
            }, {
                "searchable": true,
                "targets": [0]
            }],
            "order": [
                [0, "asc"]
            ] // set first column as a default sort by asc
        });

        //var tableWrapper = $("#sample_editable_1_wrapper");

        var nEditing = null;
        var nNew = false;

        $('#sample_editable_1_new').click(function (e) {
            e.preventDefault();

            if (nNew && nEditing) {
                if (confirm("Previose row not saved. Do you want to save it ?")) {
                    saveRow(oTable, nEditing); // save
                    $(nEditing).find("td:first").html("Untitled");
                    nEditing = null;
                    nNew = false;

                } else {
                    oTable.fnDeleteRow(nEditing); // cancel
                    nEditing = null;
                    nNew = false;

                    return;
                }
            }

            var aiNew = oTable.fnAddData(['', '', '', '', '', '']);
            var nRow = oTable.fnGetNodes(aiNew[0]);
            editRow(oTable, nRow);
            nEditing = nRow;
            nNew = true;
        });

        table.on('click', '.delete', function (e) {
            e.preventDefault();

            if (confirm("Are you sure to delete this row ?") == false) {
                return;
            }

            var nRow = $(this).parents('tr')[0];
            oTable.fnDeleteRow(nRow);
            alert("Deleted! Do not forget to do some ajax to sync with backend :)");
        });

        table.on('click', '.cancel', function (e) {
            e.preventDefault();
            if (nNew) {
                oTable.fnDeleteRow(nEditing);
                nEditing = null;
                nNew = false;
            } else {
                restoreRow(oTable, nEditing);
                nEditing = null;
            }
        });

        table.on('click', '.edit', function (e) {
            e.preventDefault();

            /* Get the row as a parent of the link that was clicked on */
            var nRow = $(this).parents('tr')[0];

            if (nEditing !== null && nEditing != nRow) {
                /* Currently editing - but not this row - restore the old before continuing to edit mode */
                restoreRow(oTable, nEditing);
                editRow(oTable, nRow);
                nEditing = nRow;
            } else if (nEditing == nRow && this.innerHTML == "Save") {
                /* Editing this row and want to save it */
                saveRow(oTable, nEditing);
                nEditing = null;
                alert("Updated! Do not forget to do some ajax to sync with backend :)");
            } else {
                /* No edit in progress - let's start one */
                editRow(oTable, nRow);
                nEditing = nRow;
            }
        });
    }

    return {

        //main function to initiate the module
        init: function () {
            handleTable();
        }

    };

}();

if (App.isAngularJsApp() === false) {
    jQuery(document).ready(function () {
        UIMap.init();
        UITree.init();
        //TableDatatablesEditable.init();
    });
}