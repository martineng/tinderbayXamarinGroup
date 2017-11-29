
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
using App1.Resources;

/* Coded by: Jack feat The Blues Brothers */

namespace TinderBay
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity, GestureDetector.IOnGestureListener
    {
        //Check if no item (Ben.G)
        bool IsItem = true;
        //Index for looping through items (Ben. G)
        int ProductIndex = 0;
        //Tag for searching (Ben.G)
        string selectedTag;
        bool matchesTag;
        string searchedWord;

        private GestureDetector _gesture;
        private TextView _textView;
        private TextView _productNameView;
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
            _productNameView = FindViewById<TextView>(Resource.Id.productNameView);
            _gesture = new GestureDetector(this);


            btnToHome = FindViewById<Button>(Resource.Id.btnToHome);
            btnToAccount = FindViewById<Button>(Resource.Id.btnToAccount);
            btnToSearch = FindViewById<Button>(Resource.Id.btnToSearch);
            btnToBuy = FindViewById<Button>(Resource.Id.btnBuy);

            btnToAccount.Click += BtnToAccount_Click;
            btnToHome.Click += BtnToHome_Click;
            btnToSearch.Click += BtnToSearch_Click;
            btnToBuy.Click += BtnToBuy_Click;

            //Get searched word from search screen
            searchedWord = Intent.GetStringExtra("Search") ?? "None";

            //Populate text views
            CheckTag();

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
            matchesTag = false;
            if (IsItem)
            {
                if (velocityX > 90)
                {
                    Toast.MakeText(this, "Item Accepted", ToastLength.Short).Show();
                        var checkoutActivity = new Intent(this, typeof(CheckoutActivity));
                        checkoutActivity.PutExtra("ProductID", ProductIndex);
                        StartActivity(checkoutActivity);
                }

                if (velocityX < -90)
                {
                    Toast.MakeText(this, "Item Declined", ToastLength.Short).Show();
                    CheckTag();
                }
            }
            else
            {
                Toast.MakeText(this, "No Item Selected", ToastLength.Short).Show();
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
            if (IsItem)
            {
                var checkoutActivity = new Intent(this, typeof(CheckoutActivity));
                checkoutActivity.PutExtra("ProductID", ProductIndex);
                StartActivity(checkoutActivity);
            }
            else
            {
                Toast.MakeText(this, "No Item Selected", ToastLength.Short).Show();
            }
        }

        //Changes the layout to info for the current selected(Ben.G)
        public void UpdateToProduct()
        {
            _productNameView.Text = APIClass.ProductArray[ProductIndex].Name;
            _textView.Text = String.Format("${0}",APIClass.ProductArray[ProductIndex].Price.ToString("F"));
        }

        //Changes the layout to show that you have run out of new items to look at(Ben.G)
        public void UpdateToBlank()
        {
            _productNameView.Text = "Run out of items";
            _textView.Text = "N/A";
            IsItem = false;
        }

        //Checks if the item matches the tag (Ben.G)
        public void CheckTag()
        {
            matchesTag = false;
            //Select next item in array, loop back to 0 if it runs out of items 
            while (matchesTag == false)
            {
                //If all the items have been scene display a message showing youve run out of items
                if (ProductIndex >= APIClass.ProductArray.Length)
                {
                    UpdateToBlank();
                    matchesTag = true;
                }
                //If theres no tag and no searched word then display the item
                else if(APIClass.SelectedTagsList.Count == 0 && (searchedWord == "" || searchedWord == "None"))
                {
                    UpdateToProduct();
                    matchesTag = true;
                }
                else
                {
                    //Check the tag against each tag in the tags list and if it matches display it
                    foreach(string tag in APIClass.SelectedTagsList)
                    {
                        if(tag == APIClass.ProductArray[ProductIndex].Tag)
                        {
                            matchesTag = true;
                        }
                    }

                    if(APIClass.ProductArray[ProductIndex].Name.ToUpper().Contains(searchedWord.ToUpper()) && searchedWord != "")
                    {
                        matchesTag = true;
                    }

                    if (matchesTag)
                    {
                        UpdateToProduct();
                    }
                }
                ProductIndex++;
            }
        }
    }
}
