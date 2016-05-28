using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Weather
{
    public sealed partial class WeatherPeekIcon : UserControl
    {
        public WeatherPeekIcon()
        {
            this.InitializeComponent();
        }


        /// <summary>
        /// Provides binding for Temperature. Used with textblock
        /// </summary>
        public string Temperature
        {
            get { return (string)GetValue(TemperatureProperty); }
            set { SetValue(TemperatureProperty, value); }
        }
        public static readonly DependencyProperty TemperatureProperty =
            DependencyProperty.Register("Temperature", typeof(string), typeof(WeatherPeekIcon), null);

        /// <summary>
        /// Provides binding for setting an image to represent a forecast, eg, sun, clouds with rain. Used with ImageSource
        /// </summary>
        public ImageSource ForecastImage
        {
            get { return (ImageSource) GetValue(ForcastImageProperty); }
            set { SetValue(ForcastImageProperty, value); }
        }
        public static readonly DependencyProperty ForcastImageProperty =
        DependencyProperty.Register("ForecastImage", typeof(string), typeof(WeatherPeekIcon), null);

    }
}
