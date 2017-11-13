using System;
using System.IO;

using Android.App;
using Android.OS;
using Android.Widget;
using SQLite;

namespace TinderBay
{
    [Activity(Label = "SignupActivity")]
    public class SignupActivity : Activity
    {
        protected Button btnConfirm;
        protected EditText etxtUsername;
        protected EditText etxtPassword;
        protected EditText etxtConfirmPassword;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.SignupLayout);

            btnConfirm = FindViewById<Button>(Resource.Id.btnConfirm);

            etxtUsername = FindViewById<EditText>(Resource.Id.etxtUsername);
            etxtPassword = FindViewById<EditText>(Resource.Id.etxtPassword);
            etxtConfirmPassword = FindViewById<EditText>(Resource.Id.etxtConfirmPassword);

            btnConfirm.Click += BtnConfirm_Click;
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (etxtPassword.Text == etxtConfirmPassword.Text)
                {
                    string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db");
                    var db = new SQLiteConnection(dpPath);

                    db.CreateTable<LoginTable>();
                    LoginTable tbl = new LoginTable();

                    tbl.username = etxtUsername.Text;
                    tbl.passwordHash = BCrypt.Net.BCrypt.HashString(etxtPassword.Text);

                    db.Insert(tbl);
                    Toast.MakeText(this, "User Created Successfully", ToastLength.Short).Show();
                } // END IF
                else
                {
                    Toast.MakeText(this, "Password does not match", ToastLength.Short).Show();
                }// END ELSE
            }
            catch (Exception exception)
            {
                Toast.MakeText(this, exception.ToString(), ToastLength.Long).Show();
            }
        } // END BtnConfirm_Click
    }
}
