// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MapTest2
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddPinInfo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CenterButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView MapView { get; set; }

        [Action ("AddPinInfo_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddPinInfo_TouchUpInside (UIKit.UIButton sender);

        [Action ("CenterButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CenterButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AddPinInfo != null) {
                AddPinInfo.Dispose ();
                AddPinInfo = null;
            }

            if (CenterButton != null) {
                CenterButton.Dispose ();
                CenterButton = null;
            }

            if (MapView != null) {
                MapView.Dispose ();
                MapView = null;
            }
        }
    }
}