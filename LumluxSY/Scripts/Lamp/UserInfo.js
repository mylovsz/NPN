var UIMap = function () {

    var MapInit = function () {
        map = new GMaps({
            div: '#gmap_marker',
            lat: parseFloat($('#ProjectLat').text()),
            lng: parseFloat($('#ProjectLng').text())
        });
        map.setZoom(11);
        map.addMarker({
            lat: parseFloat($('#ProjectLat').text()),
            lng: parseFloat($('#ProjectLng').text()),
            title: '工程名称：' + $("#ProjectName").text(),
            icon: '/Image/Base/star.png' ,
            visible: true
        })
    };
    return {
        init: function () {

            infoWindow = new google.maps.InfoWindow();

            MapInit();
        }
    }
}();

jQuery(document).ready(function () {
    UIMap.init();
});