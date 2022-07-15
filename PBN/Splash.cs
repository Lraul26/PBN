using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBN
{
    [Activity(MainLauncher = true, Theme = "@style/SplashTema", Icon = "@drawable/logoPBM", NoHistory = true)]
    public class Splash : Activity
    {
       protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            ISharedPreferences preferencia = Application.GetSharedPreferences("informacion", FileCreationMode.Private);
            bool recordar = preferencia.GetBoolean("recordar", false);
            string correo = preferencia.GetString("correo", "");
            string clave = preferencia.GetString("clave", "");

            if (recordar)
            {
                Global.Usuario.correo = correo;
                Global.Usuario.clave = clave;
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
            else
            {
                ISharedPreferencesEditor editor = preferencia.Edit();
                editor.Clear();
                editor.Apply();

                Intent intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);
            }
            this.Finish();


        }
     
    }
}