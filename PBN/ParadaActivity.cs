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
    [Activity(Label = "ParadaActivity")]
    public class ParadaActivity : Activity
    {
        ListView lvparada;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Paradalayout);
            // Create your application here
            lvparada = FindViewById<ListView>(Resource.Id.lvparada);
            lvparada.ItemClick += Lvparada_ItemClick;
            lvparada.Adapter = new AdapterParada(this, Global.Parada);
        }

        private void Lvparada_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent i = new Intent(this, typeof(ListaParadaActivity));
            Parada parada = Global.Parada[e.Position];
            i.PutExtra("id", parada.IdPar);
            StartActivity(i);
        }
    }
}