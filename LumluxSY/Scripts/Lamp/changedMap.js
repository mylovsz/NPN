
var config_map = localStorage.getItem("config_map");

if (config_map == "GoogleMap") {
    $("body").append('<script src="http://ditu.google.cn/maps/api/js?key=AIzaSyAc1YixAJuZBs7nnzCfBAxbwMKYexIU7sw&sensor=true" type="text\/javascript"><\/script> <script src="\/UILib\/Metronic\/assets\/global\/plugins\/gmaps\/gmaps.min.js" type="text\/javascript"><\/script><script src="\/Scripts\/Lamp\/markerclusterer.js"><\/script> <script src="\/Scripts\/Lamp\/MainPage.js" type="text\/javascript"></script>');
} else {
    localStorage.setItem("config_map", "AMap");

    var script = document.createElement('script');
    script.type = 'text/jacascript';
    script.src = 'https://webapi.amap.com/maps?v=1.4.15&key=2e6742d09c3d5f25d6cdb66f01a51f1c';     //填自己的js路径
    $('body').append(script);

    var script1 = document.createElement('script');
    script1.type = 'text/jacascript';
    script1.src = '/Scripts/Lamp/MainPage_Amap.js';
    $('body').append(script1);
}