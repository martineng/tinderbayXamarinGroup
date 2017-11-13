
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

/* Coded by: Martin ENG
 * E-mail: me@martineng.info */

namespace TinderBay
{
    [Activity(Label = "ProfileActivity")]
    public class ProfileActivity : Activity
    {
        protected ImageButton imgbtnProfile;
        protected Button btnUpdatePassword;
        protected Button btnUpdateEmail;
        protected Button btnHistory;
        protected Button btnSale;
        protected Button btnLogout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.ProfileLayout);
        }

        protected void imgbtnProfile_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnUpdateEmail_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSale_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
        }

    }
}
