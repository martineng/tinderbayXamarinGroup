
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
    [Activity(Label = "UpdatePasswordActivity")]
    public class UpdatePasswordActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.ProfileLayout);
        }
    }
}
