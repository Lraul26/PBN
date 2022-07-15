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
    [Activity(Label = "AgregarComentarioActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class AgregarComentarioActivity : Activity
    {
        ListView lvparada;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityAgregarComentarios);
            lvparada = FindViewById<ListView>(Resource.Id.lvoaradaCom);

            lvparada.Adapter = new AdapterParada(this,Global.Parada); 
            
        }
    }
}