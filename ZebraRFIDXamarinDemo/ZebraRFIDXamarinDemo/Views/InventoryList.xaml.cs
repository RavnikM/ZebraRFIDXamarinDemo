using Com.Zebra.Rfid.Api3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZebraRFIDXamarinDemo.Models;

namespace ZebraRFIDXamarinDemo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InventoryList : ContentPage
	{
		private InventoryListModel viewmodel;
	
		public InventoryList()
		{
			InitializeComponent();
			BindingContext = viewmodel = new InventoryListModel();
			Title = "Item inventory";
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