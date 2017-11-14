
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

/* Coded by: Callum */

namespace TinderBay
{
    [Activity(Label = "HistoryActivity")]
    public class HistoryActivity : Activity
    {
        protected Button btnToAccount;
        protected Button btnToHome;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //set page and title bar
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.HistoryLayout);        

            Button button1 = FindViewById<Button>(Resource.Id.button4);
            button1.Click += delegate
            {
                //var newActivity = new Intent(this, typeof(PurchasePage)); //MARTIN: connect this intent to account form please!            
                //StartActivity(newActivity);
            };

            btnToHome = FindViewById<Button>(Resource.Id.btnToHome);
            btnToAccount = FindViewById<Button>(Resource.Id.btnToAccount);

            btnToAccount.Click += BtnToAccount_Click;
            btnToHome.Click += BtnToHome_Click;
        }

        public void BtnToAccount_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ProfileActivity));
        }

        public void BtnToHome_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(HomeActivity));
        }

    }
}
