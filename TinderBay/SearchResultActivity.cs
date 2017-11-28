
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

/* Coded by: Ben Griffin */

namespace TinderBay
{
    [Activity(Label = "SearchResultActivity")]
    public class SearchResultActivity : Activity
    {
        protected Button btnToAccount;
        protected Button btnToHome;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle); Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.SearchResultLayout);

            btnToHome = FindViewById<Button>(Resource.Id.btnToHome);
            btnToAccount = FindViewById<Button>(Resource.Id.btnToAccount);

            //Set up text
            TextView displayText = FindViewById<TextView>(Resource.Id.displayText);

            //Get data from previous page
            displayText.Text = Intent.GetStringExtra("Search") ?? "Error 2";

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
