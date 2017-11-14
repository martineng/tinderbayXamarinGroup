
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
using Android.Gestures;

/* Coded by: Jack */

namespace TinderBay
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity, GestureDetector.IOnGestureListener
    {
        private GestureDetector _gesture;
        private TextView _textView;
        private ImageView _imageView;
        protected Button btnToAccount;
        protected Button btnToHome;
        protected Button btnToSearch;
        protected Button btnToBuy;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.HomeLayout); // shows main axml on phone

            _textView = FindViewById<TextView>(Resource.Id.priceView);
            _textView.Text = String.Format("${0}", 200);
            _gesture = new GestureDetector(this);

            btnToHome = FindViewById<Button>(Resource.Id.btnToHome);
            btnToAccount = FindViewById<Button>(Resource.Id.btnToAccount);
            btnToSearch = FindViewById<Button>(Resource.Id.btnToSearch);
            btnToBuy = FindViewById<Button>(Resource.Id.btnBuy);

            btnToAccount.Click += BtnToAccount_Click;
            btnToHome.Click += BtnToHome_Click;
            btnToSearch.Click += BtnToSearch_Click;
            btnToBuy.Click += BtnToBuy_Click;
        }

        /// <summary>
        /// Actual program will access database product id to display actual prices etc
        /// </summary>
        /// <param name="itemPrice"></param>
        /// <returns></returns>
        /*public double PriceDisplay(double itemPrice = 200) // all prices and images will be shown from database
        {
            //TextView id = priceView needs to display their unique prices when swiped onto
            _textView = FindViewById<TextView>(Resource.Id.priceView);
            _textView.Text = String.Format("${0}", itemPrice);

            // statement to say when car or bike is swiped onto, show the individual price of that image

            return itemPrice;
        }*/

        public override bool OnTouchEvent(MotionEvent e) // image slider
        {
            _gesture.OnTouchEvent(e);
            return false;
        }

        public bool OnDown(MotionEvent e)
        {
            return true;
        }

        public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY) // adds and declines items in database
        {
            _textView.Text = String.Format(String.Format("${0}", 400)); // displays the price of the item

            if (velocityX > 90)
            {
                Toast.MakeText(this, "item declined", ToastLength.Short).Show();
                _imageView = FindViewById<ImageView>(Resource.Id.imageView1);
                _imageView.SetImageResource(Resource.Drawable.car);
            }

            if (velocityX < -90)
            {
                Toast.MakeText(this, "item accepted", ToastLength.Short).Show();
                // make it slide through test images
                _imageView = FindViewById<ImageView>(Resource.Id.imageView1);
                _imageView.SetImageResource(Resource.Drawable.bike);
            }

            return true;
        }

        public void OnLongPress(MotionEvent e)
        {
            System.Diagnostics.Debug.WriteLine("LongPress detected");
            throw new NotImplementedException();
        }

        public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            return true;
        }

        public void OnShowPress(MotionEvent e)
        {
            //throw new NotImplementedException();
        }

        public bool OnSingleTapUp(MotionEvent e)
        {
            return true;
        }

        public void BtnToAccount_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ProfileActivity));
        }

        public void BtnToHome_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(HomeActivity));
        }

        public void BtnToSearch_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SearchActivity));
        }

        public void BtnToBuy_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(CheckoutActivity));
        }

    }
}
