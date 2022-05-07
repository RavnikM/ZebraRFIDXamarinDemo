using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ZebraRFIDXamarinDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiTest : ContentPage
    {
        public ApiTest()
        {
            InitializeComponent();
            
        }
        
        public async void on_get_clicked(object sender, EventArgs e)
        {
            System.Console.WriteLine("Klik na GET");

            HttpClient _client;
            _client = new HttpClient();
            HttpResponseMessage response = await _client.GetAsync("http://api.open-notify.org/iss-now.json?callback=?");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                System.Console.WriteLine(content);
                
                //RecivedDataEditorGET.Text = content;
            }
        }


        public void on_post_clicked(object sender, EventArgs e)
        {
            System.Console.WriteLine("Klik na POST");
        }
    }
}