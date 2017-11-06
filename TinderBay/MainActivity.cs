using Android.App;
using Android.Widget;
using Android.OS;



namespace TinderBay
{
    [Activity(Label = "TinderBay", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
        }
    }
}

