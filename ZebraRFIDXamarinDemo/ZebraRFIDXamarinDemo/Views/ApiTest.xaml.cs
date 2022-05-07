using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void on_get_clicked(object sender, EventArgs e)
        {
            System.Console.WriteLine("Klik na GET");
        }


        public void on_post_clicked(object sender, EventArgs e)
        {
            System.Console.WriteLine("Klik na POST");
        }
    }
}