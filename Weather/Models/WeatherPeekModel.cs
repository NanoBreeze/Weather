using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls;

namespace Weather.Models
{
    /// <summary>
    /// Model for the WeatherPeekIcons, which are icons shown next to cities that contain individual city's weather info
    /// </summary>
    class WeatherPeekModel
    {

        //includes long/lat coordinates of WeatherPeekIcon to display. 
        //Geopoint location = new Geopoint(new BasicGeoposition { Latitude = 30, Longitude = 30 });


        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public BasicGeoposition Geoposition { get; set; }

        public Geopoint Geopoint { get; set; }

        /// <summary>
        /// Contains graphical representation of the forecased weather in city, eg, a sunny sky, a cloud with rain drop
        /// </summary>
        public Image ForecastImage { get; set; }

        /// <summary>
        /// Contains the temperature of the city
        /// </summary>
        public string Temperature { get; set; }

    }
}
