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
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        Button btnentrar, btnregistrar;
        EditText edtemail, edtpass;
        TextView tvemail, tvpass, tvresultado;
        string Email = "administrador@pbn.com", password="admin123";


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityLogin);
            // Create your application here

            tvemail = FindViewById<TextView>(Resource.Id.tvemail);
            tvpass = FindViewById<TextView>(Resource.Id.tvpass);
            tvresultado = FindViewById<TextView>(Resource.Id.tvresultado);
            edtemail = FindViewById<EditText>(Resource.Id.edtemail);
            edtpass = FindViewById<EditText>(Resource.Id.edtpass);
            btnregistrar = FindViewById<Button>(Resource.Id.btnregistrate);
            btnentrar = FindViewById<Button>(Resource.Id.btnentrar);
            btnregistrar.Click += Btnregistrar_Click;
            btnentrar.Click += Btnentrar_Click;
        }

        private void Btnentrar_Click(object sender, EventArgs e)
        {
            if (edtemail.Text == String.Empty)
            {
                tvemail.Text = "Ingrese una dirección de correo";
            }
            else if (edtpass.Text == String.Empty)
            {
                tvpass.Text = "Ingrese una contraseña";
            }
            else
            {
                if (edtemail.Text == Email && edtpass.Text == password)
                {
                    var res = new Intent(this, typeof(MainActivity));
                    StartActivity(res);
                }
                else
                {
                    tvresultado.Text = "Email o Contraseña incorrecta";
                }
            }
        }

        private void Btnregistrar_Click(object sender, EventArgs e)
        {
            var res = new Intent(this, typeof(RegistrarActivity));
            StartActivity(res);
        }
    }
}