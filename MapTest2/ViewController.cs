using System;

using UIKit;
using MapKit;
using CoreLocation;
using Foundation;
using System.Collections.Generic;

namespace MapTest2
{
    public partial class ViewController : UIViewController
    {
      static  List<CoalAnnotation> annots = new List<CoalAnnotation>();
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // map centered on lockwood
            CLLocationCoordinate2D coords = new CLLocationCoordinate2D(38.32515865003414, -82.57881700040785);
            MKCoordinateSpan span = new MKCoordinateSpan(MilesToLatitudeDegrees(.15), MilesToLongitudeDegrees(.15, coords.Latitude));
            MapView.Region =new  MKCoordinateRegion(coords, span);
            MapView.MapType = MKMapType.Satellite;

            // tap to add pin after info is entered into infor screen 
            UILongPressGestureRecognizer tap = new UILongPressGestureRecognizer(Tapper);
            View.AddGestureRecognizer(tap);

            //fill map with previously made annotations
            FillMap();
        }

       

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public double MilesToLatitudeDegrees(double miles)
        {
            double earthRadius = 3960.0; //in miles
            double radianDegree = 180 / Math.PI;
            return (miles / earthRadius) * radianDegree;
        }

        public double MilesToLongitudeDegrees(double miles,double atLatitude)
        {
            double earthRadius = 3960.0; //in miles
            double radianToDegree = 180 / Math.PI;
            double degreeToRadian = Math.PI / 180;

            //derive the earths radius at the point in latitude
            double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreeToRadian);
            return (miles / radiusAtLatitude) * radianToDegree;
        }

        partial void CenterButton_TouchUpInside(UIButton sender)
        {
            ViewDidLoad();
        }

        partial void AddPinInfo_TouchUpInside(UIButton sender)
        {
            ViewChanger changer = new ViewChanger(this, "AddInfo");
        }
        void Tapper(UILongPressGestureRecognizer press)
        {
            StockpileInfo info = new StockpileInfo();
            var pixelLocation = press.LocationInView(MapView);
            var geoLocation = MapView.ConvertPoint(pixelLocation, MapView);
            var stockpile = info.getStockPileNumber();
            var company = info.getCompany();
            CoalAnnotation coalAn = new CoalAnnotation(stockpile, company, geoLocation);
            coalAn.IncrementId();
            annots.Add(coalAn);

            MapView.AddAnnotation(coalAn);
        }
       public void FillMap()
        {
            foreach(var annotation in annots)

            {
                MapView.AddAnnotation(annotation);
            }
        }

    }
}
