
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

using App1.Resources;
using Com.Paypal.Android.Sdk.Payments;
using Java.Math;


/* Coded by: Danny
 * 
 * "LQFUY6ESACZKU"
 * TinderBayTester@test.com.au
 * tinderbaytest123 */

namespace TinderBay
{
    [Activity(Label = "CheckoutActivity")]
    public class CheckoutActivity : Activity
    {
        private PayPalConfiguration config = new PayPalConfiguration()
     .Environment(PayPalConfiguration.EnvironmentSandbox)
     .ClientId("AcR8bCwFgG6GHUG96oFFrG6e7SX9E5LGtvezyzDaYdMj_vuM--glz3W-JvdXpGSie3BU8nhRJHIfEM5n");

        protected Button btnToAccount;
        protected Button btnToHome;
        protected Button btnBuy;
        int Index;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle); Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            Index = Intent.GetIntExtra("ProductID", 0);
            // Set out view from the layout resource
            SetContentView(Resource.Layout.CheckoutLayout);

            // Get our button from the layout resource,
            // and attach an event to it
            btnBuy = FindViewById<Button>(Resource.Id.buybutton);
            btnBuy.Click += btnBuy_Click;

            btnToHome = FindViewById<Button>(Resource.Id.btnToHome);
            btnToAccount = FindViewById<Button>(Resource.Id.btnToAccount);

            btnToAccount.Click += BtnToAccount_Click;
            btnToHome.Click += BtnToHome_Click;

            // start paypal service
            var intent = new Intent(this, typeof(PayPalService));
            intent.PutExtra(PayPalService.ExtraPaypalConfiguration, config);
            this.StartService(intent);


        }

        public void btnBuy_Click(object sender, EventArgs e)
        {
            string price = APIClass.ProductArray[Index-1].Price.ToString("F");
            string name = APIClass.ProductArray[Index-1].Name;
            var payment = new PayPalPayment(new BigDecimal(price), "AUD", name,
                PayPalPayment.PaymentIntentSale);

            var intent = new Intent(this, typeof(PaymentActivity));
            intent.PutExtra(PayPalService.ExtraPaypalConfiguration, config);
            intent.PutExtra(PaymentActivity.ExtraPayment, payment);

            this.StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
            {
                var confirm = data.GetParcelableExtra(PaymentActivity.ExtraResultConfirmation);
                if (confirm != null)
                {

                }
            }
            else if (resultCode == Result.Canceled)
            {

            }
            else if ((int)resultCode == PaymentActivity.ResultExtrasInvalid)
            {

            }
        }

        protected override void OnDestroy()
        {
            this.StopService(new Intent(this, typeof(PayPalService)));
            base.OnDestroy();
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