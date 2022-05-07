using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZebraRFIDXamarinDemo.ViewModels;

namespace ZebraRFIDXamarinDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiTest : ContentPage
    {
        private ApiTestViewModel apitest;
        private HttpClient _client;

        public ApiTest()
        {
            InitializeComponent();
            BindingContext = apitest = new ApiTestViewModel();
            apitest.Request = "http://api.open-notify.org/iss-now.json?callback=?";
            apitest.PostRequest = "http://192.168.1.7:5000/api/addtag";
            apitest.PostResponse = "{'sometagdata' : S123456789}";
            _client = new HttpClient();
            
        }
        
        public async void on_get_clicked(object sender, EventArgs e)
        {
            System.Console.WriteLine("Klik na GET");

            try { 
                HttpResponseMessage response = await _client.GetAsync(apitest.Request);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    System.Console.WriteLine(content);
                    apitest.Response = content;
                }
            }
            catch (Exception e2) 
                {
                System.Console.WriteLine("Http request error happend!");
                System.Console.WriteLine(e2.Message);
                await DisplayAlert("Exception happend!",e2.Message, "Ok");
            }
        }


        public async void on_post_clicked(object sender, EventArgs e)
        {
            System.Console.WriteLine("Klik na POST");

            try
            {
                var data = new StringContent(apitest.PostResponse);
                HttpResponseMessage response = await _client.PostAsync(apitest.PostRequest, data);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    System.Console.WriteLine(content);
                    apitest.Response = content;
                }
            }   
            
            catch (Exception e1)
            {
                System.Console.WriteLine("Http request error happend!");
                System.Console.WriteLine(e1.Message);
                await DisplayAlert("Exception happend!", e1.Message, "Ok");

            }

        }
    }
}