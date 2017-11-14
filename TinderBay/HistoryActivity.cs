
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TinderBay
{
    [Activity(Label = "HistoryActivity")]
    public class HistoryActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //set page and title bar
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.HistoryLayout);

            //Connect to DB

            //retrieve item sell status
            //retireve item sell date if sold
            // two entries for time being          

            Button button1 = FindViewById<Button>(Resource.Id.);
            button1.Click += delegate
            {
                //var newActivity = new Intent(this, typeof(PurchasePage)); //MARTIN: connect this intent to account form please!            
                //StartActivity(newActivity);
            };
        }
    }
}
