using System;
using System.Collections.Generic;
using System.Text;
using ZebraRFIDXamarinDemo.Models;

namespace ZebraRFIDXamarinDemo.ViewModels
{
    class TriggerMappingViewModel : BaseViewModel
    {
        bool _radioButtonOne, _radioButtonTwo, _radioButtonThree, _radioButtonFour;

        public TriggerMappingViewModel()
        {
            GetKeyLayoutType();
        }
        public bool RadioButtonOne { get => _radioButtonOne; set { _radioButtonOne = value; OnPropertyChanged(); } }
        public bool RadioButtonTwo { get => _radioButtonTwo; set { _radioButtonTwo = value; OnPropertyChanged(); } }
        public bool RadioButtonThree { get => _radioButtonThree; set { _radioButtonThree = value; OnPropertyChanged(); } }
        public bool RadioButtonFour { get => _radioButtonFour; set { _radioButtonFour = value; OnPropertyChanged(); } }

        internal void SelectedTrigger(object content)
        {
            rfidModel.SetKeyLayoutType(content);
        }

        public override void ReaderConnectionEvent(bool connection)
        {
            base.ReaderConnectionEvent(connection);
            GetKeyLayoutType();
        }

        private void GetKeyLayoutType()
        {
            string keyType = rfidModel.GetKeyLayoutType();
            switch (keyType)
            {
                case AppConstants.UpperTriggerForRfid:
                    RadioButtonOne = true;
                    break;
                case AppConstants.UpperTriggerForScan:
                    RadioButtonTwo = true;
                    break;
                case AppConstants.LowerTriggerForSledScan:
                    RadioButtonThree = true;
                    break;
                case AppConstants.UpperTriggerForSledScan:
                    RadioButtonFour = true;
                    break;
            }
        }
    }
}
