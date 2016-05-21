using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Weather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Dictionary<string, int> map = new Dictionary<string, int>()
            {
                {"London",6058560},
                {"Hamilton", 5969785},
                {"Waterloo", 6176821},
            };

        private int cityId = 0;

        public MainPage()
        {
            this.InitializeComponent();
            textBlock123.Text = "City: ";

        }


        /// <summary>
        /// Gets information from online API 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        async Task<string> RunAsync(int cityId)
        {
            string cityName = null;
            string temperature = null;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response;
                
                response = await
                    client.GetAsync(
                        "http://api.openweathermap.org/data/2.5/weather?id="+cityId.ToString()+"&appid=23dde959b0c9a19b586ed9af3bbc8868").ConfigureAwait(continueOnCapturedContext: false);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    dynamic content1 = JsonConvert.DeserializeObject(content);
                    temperature = content1.main.temp;
                    cityName = content1.name;
                }
            }
            return temperature;
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)comboBox.SelectedItem;
            string value = typeItem.Content.ToString();
            cityId = CityID(value);
            var temperature= await RunAsync(cityId);
            textBlock123.Text = temperature;
            //string temperature = 
        }

        private int CityID(string cityName)
        {
        
            int output = map[cityName];
            return output;
        }
    }
}
