using System;
using System.Collections.Generic;
using System.Text;


using Com.Zebra.Rfid.Api3;
using Com.Zebra.Scannercontrol;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZebraRFIDXamarinDemo.ViewModels
{
    public class ApiTestViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        //public string UniqueTags { get => _uniquetags; set { _uniquetags = value; OnPropertyChanged(); } }
        //public string TotalTags { get => _totaltags; set { _totaltags = value; OnPropertyChanged(); } }
        //public string TotalTime { get => _totaltime; set { _totaltime = value; OnPropertyChanged(); } }

        private static string _get_response;
        private static string _get_request;

        public string Response { get => _get_response; set { _get_response = value; OnPropertyChanged(); } }

        public string Request { get => _get_request; set { _get_request = value; OnPropertyChanged(); } }



        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
