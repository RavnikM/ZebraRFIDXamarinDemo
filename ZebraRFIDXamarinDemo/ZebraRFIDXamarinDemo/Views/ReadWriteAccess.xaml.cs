
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZebraRFIDXamarinDemo.Models;

namespace ZebraRFIDXamarinDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadWriteAccess : TabbedPage
    {
        ReadWriteOperationsModel viewmodel;
        public ReadWriteAccess()
        {
            InitializeComponent();
            Title = "Item Commission";
            BindingContext = viewmodel = new ReadWriteOperationsModel();
        }

        private void ReadOperation(object sender, EventArgs e)
        {
            if (tagPattern.Text.Equals(""))
                DisplayAlert("Invalid Parameter", "Empty TAG PATTERN", "Cancel");
            else
                viewmodel.AccessOperationsReadClicked();
        }

        private void WriteOperation(object sender, EventArgs e)
        {
            if (tagPattern.Text.Equals("") || data.Text == null || (data.Text != null && data.Text.Equals("")))
                DisplayAlert("Invalid Parameter", "Empty TAG PATTERN or data", "Cancel");
            else
                viewmodel.AccessOperationsWriteClicked();
        }

        private void LockOperation(object sender, EventArgs e)
        {
            if (tagPattern.Text.Equals(""))
                DisplayAlert("Invalid Parameter", "Empty TAG PATTERN", "Cancel");
            else
                viewmodel.AccessOperationsLockClicked();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewmodel.UpdateIn();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewmodel.UpdateOut();
        }

    }
}