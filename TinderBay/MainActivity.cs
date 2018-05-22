﻿using Android.App;
using Android.Widget;
using Android.OS;

using System;
using System.IO;
using SQLite;
using App1.Resources;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> final

/* Coded by: Martin ENG
 * E-mail: me@martineng.info */

namespace TinderBay
{
    
    [Activity(Label = "TinderBay", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        // Declaring the components
        protected Button btnLogin;
        protected Button btnSignup;
        protected EditText etxtUsername;
        protected EditText etxtPassword;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Main);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnSignup = FindViewById<Button>(Resource.Id.btnSignup);

            etxtUsername = FindViewById<EditText>(Resource.Id.etxtUsername);
            etxtPassword = FindViewById<EditText>(Resource.Id.etxtPassword);

            btnLogin.Click += BtnLogin_Click;
            btnSignup.Click += BtnSignup_Click;
        }

        protected async void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //Get products and sales array (Ben. G)
                await APIClass.GetProductsAsync();
                await APIClass.GetSalesAsync();
<<<<<<< HEAD
=======

                APIClass.SelectedTagsList = new List<string>();
>>>>>>> final
                // Calling Database
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db");

                //var db = new SQLiteConnection(dpPath);
                //var dataTable = db.Table<LoginTable>();
                //var dataNode = dataTable.Where(x => x.username == etxtUsername.Text).FirstOrDefault(); // Linq Query

                
                if (etxtUsername.Text=="martin" && etxtPassword.Text=="martin")
                {
                    StartActivity(typeof(ProfileActivity));
                }
                /*
                // Check if input matched
                if (dataNode != null && BCrypt.Net.BCrypt.Verify(etxtPassword.Text, dataNode.passwordHash))
                {
                    Toast.MakeText(this, "Login Success!", ToastLength.Short).Show();
                    StartActivity(typeof(HomeActivity));
                }
                else
                {
                    Toast.MakeText(this, "Username or Password invalid", ToastLength.Short).Show();
                }*/
            }
            catch (Exception exception)
            {
                Toast.MakeText(this, exception.ToString(), ToastLength.Long).Show();
            }
        }

        protected void BtnSignup_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SignupActivity)); // Call the next view
        }

        /*
        // This method create the database the first time it runs
        // condition when database does not exit
        protected string CreateDb()
        {
            var output = "";
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db");
            var db = new SQLiteConnection(dpPath);
            return output += "\n Database Created...";
        } // END CreateDb()
        */
    }
}

