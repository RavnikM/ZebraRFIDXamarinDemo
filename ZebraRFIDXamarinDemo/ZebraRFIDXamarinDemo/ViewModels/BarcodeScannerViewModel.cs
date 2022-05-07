
using System.Collections.ObjectModel;
using ZebraRFIDXamarinDemo.Models;

namespace ZebraRFIDXamarinDemo.ViewModels
{
    class BarcodeScannerViewModel : BaseViewModel
    {
        private string _barcodeCount, _connectionStatus;
        private bool _showStatus, _showList;
        private ObservableCollection<BarCodeData> _barcodeData;
        public ObservableCollection<BarCodeData> BarcodeList { get => _barcodeData; set => _barcodeData = value; }
        public string BarcodeCount { get => _barcodeCount; set { _barcodeCount = value; OnPropertyChanged(); } }
        public string ConnectionStatus { get => _connectionStatus; set { _connectionStatus = value; OnPropertyChanged(); } }
        public bool ShowStatus { get => _showStatus; set { _showStatus = value; OnPropertyChanged(); } }
        public bool ShowList { get => _showList; set { _showList = value; OnPropertyChanged(); } }


        public BarcodeScannerViewModel()
        {
            _barcodeData = new ObservableCollection<BarCodeData>();
            BarcodeCount = "BARCODE LIST: COUNT = 0";
            UpdateHint();
        }

        internal void ClearBarcode()
        {
            BarcodeList.Clear();
            BarcodeCount = "BARCODE LIST: COUNT = 0";
        }

        public override void BarcodeEvent(string barcode, string barcodeType)
        {
            ShowList = true;
            ShowStatus = false;
            BarcodeList.Insert(0, new BarCodeData { Barcode = barcode, BarcodeType = barcodeType });
            BarcodeCount = "BARCODE LIST: COUNT = " + BarcodeList.Count;
        }

        public override void ScannerConnectionEvent(string deviceName)
        {
            UpdateHint();
        }

        private void UpdateHint()
        {
            if (BarcodeList.Count == 0)
            {
                ShowStatus = true;
                ShowList = false;
                ConnectionStatus = scannerConnected ? "Connected" : "Not Connected";
            }
            else
            {
                ShowStatus = false;
            }
        }
        public class BarCodeData
        {
            public string Barcode { get; set; }
            public string BarcodeType { get; set; }
        }
    }
}
