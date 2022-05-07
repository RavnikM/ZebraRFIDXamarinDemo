using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using System.IO;

namespace ZebraRFIDXamarinDemo.Droid
{
    [Activity(Label = "ZebraRFIDXamarinDemo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const string FIRMWARE_FOLDER = "/ZebraFirmware";
        const string OUTPUT_FOLDER = "/ZebraOutput";
        protected override void OnCreate(Bundle bundle)
        {
            //global::Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            LoadApplication(new App());
            CreateDirectory();
        }

        /// <summary>
        /// Create directory for store the firmware plugin(Plugin should be ".SCNPLG")
        /// </summary>
        private void CreateDirectory()
        {
            CheckFileReadWritePermissions();

        }

        /// <summary>
        /// Check application permissions
        /// </summary>
        private void CheckFileReadWritePermissions()
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {
                return;
            }
            else
            {
                if (PackageManager.CheckPermission(Manifest.Permission.ReadExternalStorage, PackageName) != Permission.Granted
                    && PackageManager.CheckPermission(Manifest.Permission.WriteExternalStorage, PackageName) != Permission.Granted)
                {
                    var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
                    RequestPermissions(permissions, 2226);

                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            // Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (requestCode == 2226)
            {
                try
                {

                    var firmwareDirectory = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads) + FIRMWARE_FOLDER;
                    var outputDirectory = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads) + OUTPUT_FOLDER;
                    Directory.CreateDirectory(firmwareDirectory);
                    Directory.CreateDirectory(outputDirectory);

                    if (Directory.Exists(firmwareDirectory))
                    {
                        Console.WriteLine("That path firmwareDirectory  exists already.");

                    }

                }
                catch (Java.Lang.Exception e)
                {
                    Console.WriteLine("Sample app Exception " + e.Message);
                }
            }
        }
    }
}

