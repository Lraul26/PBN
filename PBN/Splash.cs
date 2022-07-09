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
    [Activity(Label = "Splash", MainLauncher = true)]
    public class Splash : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


        ISharedPreferences preferencia = Application.GetSharedPreferences("informacion", FileCreationMode.Private);
        bool recordar = preferencia.GetBoolean("recordar", false);
     
            if (recordar)
            {
                
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