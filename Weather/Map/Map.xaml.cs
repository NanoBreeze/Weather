using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Weather.Map
{

    /*
    - Get pixel to coordinate, uses GetOffsetFromLocation
           Geopoint location = new Geopoint(new BasicGeoposition {Latitude = 30, Longitude = 30});
           Point offset = new Point();
           myMap.GetOffsetFromLocation(location, out offset); 
    - Get coordinate to pixel, uses GetLocationFromOffset(...)
           Geopoint geo = new Geopoint(new BasicGeoposition());
           myMap.GetLocationFromOffset(new Point {Y = 100, X = 100}, out geo);
    - Get screen dimensions and cut appropriately
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            var bottom = bounds.Bottom;
            var right = bounds.Right;

    */


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Map : Page
    {
        Geopoint[,] geoPoints;  //stores all the divided/evenly-spaced Geopoints on the screen
        public Map()
        {
            this.InitializeComponent();

            ////initalize a 2D array of Geopoints
            //geoPoints = new Geopoint[8,8];

            //Geopoint myPoint = new Geopoint(new BasicGeoposition() { Latitude = 50, Longitude = 11 });
            //MapIcon myPOI = new MapIcon { Location = myPoint, NormalizedAnchorPoint = new Point(0.5, 1.0), Title = "Here I am", ZIndex = 0 };
            ////myPOI.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/StoreLogo.png"));
            //MapItemsControl test = new MapItemsControl();


            //myMap.MapElements.Add(myPOI);
            //myMap.Center = myPoint;
            //myMap.ZoomLevel = 10;

            // Specify a known location.
            BasicGeoposition snPosition = new BasicGeoposition() { Latitude = 47.620, Longitude = -122.349 };
            Geopoint snPoint = new Geopoint(snPosition);

            // Create a XAML border.
            Border border = new Border
            {
                Height = 100,
                Width = 100,
                BorderBrush = new SolidColorBrush(Windows.UI.Colors.Blue),
                BorderThickness = new Thickness(5),
            };

            // Center the map over the POI.
            myMap.Center = snPoint;
            myMap.ZoomLevel = 14;

            // Add XAML to the map.
            myMap.Children.Add(border);
            MapControl.SetLocation(border, snPoint);
            MapControl.SetNormalizedAnchorPoint(border, new Point(0.5, 0.5));   
        }

        private void MyMap_OnActualCameraChanged(MapControl sender, MapActualCameraChangedEventArgs args)
        {
            Debug.WriteLine("Changed");
        }



        private void MyMap_OnTargetCameraChanged(MapControl sender, MapTargetCameraChangedEventArgs args)
        {
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            var bottom = bounds.Bottom;
            var right = bounds.Right;

            Debug.WriteLine("Target Camera Changed");
            Geopoint location = new Geopoint(new BasicGeoposition {Latitude = 30, Longitude = 30});
             Point offset = new Point();
            myMap.GetOffsetFromLocation(location, out offset);

            Geopoint geo = new Geopoint(new BasicGeoposition());
            myMap.GetLocationFromOffset(new Point { Y = offset.Y, X = offset.X}, out geo);
        }
    }
}
