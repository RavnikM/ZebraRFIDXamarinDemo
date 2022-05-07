
using System;
using System.Collections.Generic;
using ZebraRFIDXamarinDemo.Views;

namespace ZebraRFIDXamarinDemo
{
	public class PageDataViewModel
	{
		public PageDataViewModel(Type type, string title, string description)
		{
			Type = type;
			Title = title;
			Description = description;
		}

		public Type Type { private set; get; }

		public string Title { private set; get; }

		public string Description { private set; get; }

		static PageDataViewModel()
		{
			All = new List<PageDataViewModel>
			{
				new PageDataViewModel(typeof(InventoryList), "Item inventory",
									  "Used for Item count or stock count\nPerforms inventory operation"),
				new PageDataViewModel(typeof(ReadWriteAccess), "Item commission",
									  "Used for item commissioning\nPerforms read, write or lock operation on tag memory bank"),
				new PageDataViewModel(typeof(LocateTag), "Item search",
									  "Used for locate the intersted item\nPerforms tag locatinging operation"),
                new PageDataViewModel(typeof(RelativeDistance), "Relative Distance",
                                      "Shows the relative proximity of multiple tags"),
				new PageDataViewModel(typeof(ReaderList), "Reader List",
									  "To select the reader from available reader list"),
                new PageDataViewModel(typeof(ViewDemo), "Demo *",
									  "Place holder"),
				new PageDataViewModel(typeof(FirmwareUpdate), "Firmware Update",
									  "Used for Updating Firmware"),
				new PageDataViewModel(typeof(BarcodeScanner), "Barcode Scanner",
									  "Used for Scanning Barcode"),
				new PageDataViewModel(typeof(TriggerMapping), "Trigger Key Mapping",
									  "Used for config trigger keys"),
				new PageDataViewModel(typeof(ApiTest), "Api Test", "Used for api testing")

			};
		}

		public static IList<PageDataViewModel> All { private set; get; }
	}
}
