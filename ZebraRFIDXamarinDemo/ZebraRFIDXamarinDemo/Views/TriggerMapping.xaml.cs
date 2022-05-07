using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZebraRFIDXamarinDemo.ViewModels;

namespace ZebraRFIDXamarinDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TriggerMapping : ContentPage
    {
        private TriggerMappingViewModel viewModel;
        public TriggerMapping()
        {
            InitializeComponent();
            BindingContext = viewModel = new TriggerMappingViewModel();
            Title = "Trigger Key Mapping";
        }

        void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            if (button != null)
            {
                if (button.IsChecked)
                {
                    viewModel.SelectedTrigger(button.Content);
                }
            }
        }
    }
}