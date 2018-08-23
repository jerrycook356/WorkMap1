using System;
using MapKit;
using CoreLocation;
using UIKit;
using System.Diagnostics.Contracts;

namespace MapTest2
{
    public class MapDelegate:MKMapViewDelegate
    {
        private static readonly string identifier = "id";
        LocalStorageList storage = new LocalStorageList();
        
        public MapDelegate()
        {
        }

        public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            Contract.Ensures(Contract.Result<MKAnnotationView>() != null);
            MKAnnotationView annotationView = mapView.DequeueReusableAnnotation(identifier);

            //set current location of user and annotation
            //  CLLocationCoordinate2D currentLocation = mapView.UserLocation.Coordinate;
            CLLocationCoordinate2D annotationLocation = annotation.Coordinate;

            //no special annotation for user (if using user location on map)
            //  if (currentLocation.Latitude == annotationLocation.Latitude &&
            //   currentLocation.Longitude == annotationLocation.Longitude)
            //   return null;



            if (annotationView == null)
            {
                annotationView = new MKPinAnnotationView(annotation, identifier);
            }
            else
            {
                annotationView.Annotation = annotation;
            }


            annotationView.CanShowCallout = true;
            (annotationView as MKPinAnnotationView).AnimatesDrop = true;
            (annotationView as MKPinAnnotationView).PinColor = MKPinAnnotationColor.Red;
            annotationView.SetSelected(true, false);

            UIButton annotationDetailButton = UIButton.FromType(UIButtonType.InfoDark);
            annotationDetailButton.TouchUpInside += (sender, e) =>
            {

                var coord = annotation.Coordinate;
                storage.RemoveAnnotation(coord);
                mapView.RemoveAnnotation(annotation);
               
            };

            annotationView.RightCalloutAccessoryView = annotationDetailButton;
            //if want to change icon on the left, maybe another button later
            //use left callout accessory view


            return annotationView;
        }

    }
}
