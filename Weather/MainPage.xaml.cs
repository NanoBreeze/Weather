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
        public MainPage()
        {
            this.InitializeComponent();
        }

        static async Task RunAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response;
                response = await
                    client.GetAsync(
                        "http://api.openweathermap.org/data/2.5/weather?q=London,uk&appid=23dde959b0c9a19b586ed9af3bbc8868").ConfigureAwait(continueOnCapturedContext:false);

                if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(content);
                    }
                
            }


            //using (var client = new HttpClient())
            //{
            //    // TODO - Send HTTP requests
            //    // New code:
            //    client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    try
            //    {
            //        Debug.WriteLine("About to get string");
            //        var response =
            //            await client.GetStringAsync("weather?q=London,uk&appid=23dde959b0c9a19b586ed9af3bbc8868");

            //        Debug.WriteLine(response);
            //        //HttpResponseMessage response =
            //        //    await client.GetAsync("weather?q=London,uk&appid=23dde959b0c9a19b586ed9af3bbc8868");
            //        //response.EnsureSuccessStatusCode(); // Throw if not a success code.
            //        //if (response.IsSuccessStatusCode)
            //        //{
            //        //    string product = await response.Content.ReadAsStringAsync();
            //        //    dynamic a = JsonConvert.DeserializeObject(product);
            //        //    var m = a.main.temp;

            //        //}
            //        // ...
            //    }
            //    catch (HttpRequestException e)
            //    {
            //        // Handle exception.
            //    }

            //}
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            RunAsync().Wait();
        }
    }
}
