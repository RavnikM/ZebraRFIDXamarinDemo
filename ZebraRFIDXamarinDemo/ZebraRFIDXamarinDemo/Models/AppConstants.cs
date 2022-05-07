using System;
using System.Collections.Generic;
using System.Text;

namespace ZebraRFIDXamarinDemo.Models
{
    class AppConstants
    {
        public const string UpperTriggerForRfid = "Upper(RFID)Lower(Host Scan)";
        public const string UpperTriggerForScan = "Upper(Host Scan)Lower(RFID)";
        public const string LowerTriggerForSledScan = "Upper(RFID)Lower(Sled Scan)";
        public const string UpperTriggerForSledScan = "Upper(Sled Scan)Lower(RFID)";
    }
}
