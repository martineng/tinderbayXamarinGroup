
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

/* Coded by: Ben Griffin */

namespace TinderBay
{
    [Activity(Label = "SearchActivity")]
    public class SearchActivity : Activity
    {
        private List<string> SelectedTagsList;
        private Button btnToAccount;
        protected Button btnToHome;

        private string selectedTag;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.SearchLayout);

            btnToHome = FindViewById<Button>(Resource.Id.btnToHome);
            btnToAccount = FindViewById<Button>(Resource.Id.btnToAccount);

            SelectedTagsList = new List<string>();

            //Set up text view
            TextView TagText = FindViewById<TextView>(Resource.Id.TagText);

            //Set up search bar
            EditText searchEditText = FindViewById<EditText>(Resource.Id.searchEditText);

            //Set up spinner
            Spinner TagSelectSpinner = FindViewById<Spinner>(Resource.Id.TagSelectSpinner);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.tagArray, Android.Resource.Layout.SimpleSpinnerItem);
            TagSelectSpinner.ItemSelected += new System.EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            TagSelectSpinner.Adapter = adapter;

            btnToAccount.Click += BtnToAccount_Click;
            btnToHome.Click += BtnToHome_Click;

            //Set up button
            Button returnBtn = FindViewById<Button>(Resource.Id.returnBtn);
            returnBtn.Click += delegate
            {
                //Pass the tags to the APIClass
                APIClass.SelectedTagsList = SelectedTagsList;
                //Pass searched word using intent
                var homeActivity = new Intent(this, typeof(HomeActivity));
                homeActivity.PutExtra("Search", searchEditText.Text);
                StartActivity(homeActivity);
            };
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            
            //Set up spinner and text view
            Spinner spinner = (Spinner)sender;
            TextView TagText = FindViewById<TextView>(Resource.Id.TagText);


            //Read selected item from spinner
            selectedTag = string.Format("{0}", spinner.GetItemAtPosition(e.Position));

            //Check if the selected tag is already in the list
            bool tagAlreadySelected = false;
            foreach (string tag in SelectedTagsList)
            {
                if (tag.Equals(selectedTag))
                {
                    tagAlreadySelected = true;
                }
            }

            //If the tag isnt in the list, add it
            if (tagAlreadySelected == false)
            {
                SelectedTagsList.Add(selectedTag);
            }
            //If the tag is on the list remove it
            else
            {
                SelectedTagsList.Remove(selectedTag);
            }

            //Remove default tag
            SelectedTagsList.Remove("None");

            //Display selected tags
            string tempString = "";
            foreach (string tag in SelectedTagsList)
            {
                tempString = tempString + " " + tag;
            }
            TagText.Text = tempString;
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
