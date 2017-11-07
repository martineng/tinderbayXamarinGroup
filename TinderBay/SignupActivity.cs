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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SignupLayout);

            btnConfirm = FindViewById<Button>(Resource.Id.btnConfirm);

            etxtUsername = FindViewById<EditText>(Resource.Id.etxtUsername);
            etxtPassword = FindViewById<EditText>(Resource.Id.etxtPassword);

            btnConfirm.Click += BtnConfirm_Click;
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            string text = BCrypt.Net.BCrypt.HashString(etxtPassword.Text);

            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db");
                var db = new SQLiteConnection(dpPath);

                db.CreateTable<LoginTable>();
                LoginTable tbl = new LoginTable();

                tbl.username = etxtUsername.Text;
                tbl.passwordHash = text;

                db.Insert(tbl);
                Toast.MakeText(this, "User Created Successfully", ToastLength.Short).Show();
            }
            catch (Exception exception)
            {
                Toast.MakeText(this, exception.ToString(), ToastLength.Long).Show();
            }
        } // END BtnConfirm_Click
    }
}
