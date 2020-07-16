using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml;
using GMap.NET.Internals;
using GMap.NET.MapProviders;
using GMap.NET.Projections;

namespace GMap.NET.GMap.NET.MapProviders.Baidu
{
    

    public class BaiduHybirdMapProvider : BaiduMapProviderBase
    {
        public static readonly BaiduHybirdMapProvider Instance;

        readonly Guid id = new Guid("608748FC-5FDD-4d3a-9027-356F24A755E7");
        public override Guid Id
        {
            get { return id; }
        }

        readonly string name = "BaiduHybirdMap";
        public override string Name
        {
            get
            {
                return name;
            }
        }

        static BaiduHybirdMapProvider()
        {
            Instance = new BaiduHybirdMapProvider();
        }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = MakeTileImageUrl(pos, zoom, LanguageStr);

            return GetTileImageUsingHttp(url);
        }

        GMapProvider[] overlays;
        public override GMapProvider[] Overlays
        {
            get
            {
                if (overlays == null)
                {
                    overlays = new GMapProvider[] { BaiduSateliteMapProvider.Instance, this };
                }
                return overlays;
            }
        }
        string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            zoom = zoom - 1;
            var offsetX = Math.Pow(2, zoom);
            var offsetY = offsetX - 1;

            var numX = pos.X - offsetX;
            var numY = -pos.Y + offsetY;

            zoom = zoom + 1;
            var num = (pos.X + pos.Y)%8 + 1;
            var x = numX.ToString().Replace("-", "M");
            var y = numY.ToString().Replace("-", "M");

            //http://online1.map.bdimg.com/tile/?qt=tile&x=1449&y=419&z=13&styles=sl
            string url = string.Format(UrlFormat, x, y, zoom);
            Console.WriteLine("url:" + url);
            return url;
        }

        static readonly string UrlFormat = "http://online1.map.bdimg.com/tile/?qt=tile&x={0}&y={1}&z={2}&styles=sl";
        
    }
}
