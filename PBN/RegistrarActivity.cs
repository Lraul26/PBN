using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBN
{
    [Activity(Label = "RegistrarActivity")]
    public class RegistrarActivity : Activity
    {
        Button btnsesion;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityRegistrar);
            // Create your application here
            btnsesion = FindViewById<Button>(Resource.Id.btnaceptar);
            btnsesion.Click += Btnsesion_Click;

        }

        private void Btnsesion_Click(object sender, EventArgs e)
        {
            var res = new Intent(this, typeof(LoginActivity));
            StartActivity(res);
        }
    }
}