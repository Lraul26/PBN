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
    [Activity(Label = "ListaParadaActivity")]
    public class ListaParadaActivity : Activity
    {
        Parada parada;
        TextView txttitulo;
        ListView lvparadabus;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListaParadalayout);
            // Create your application here
            int id = Intent.GetIntExtra("id", 0);
            parada = CsGlobal.Parada.Where(x => x.IdPar == id).FirstOrDefault();

            txttitulo = FindViewById<TextView>(Resource.Id.txtparadabus);
            lvparadabus = FindViewById<ListView>(Resource.Id.lvparadabus);


            txttitulo.Text = parada.NombrePar.ToString();
            lvparadabus.Adapter = new AdapterBus(this, CsGlobal.Autobuces.Where(x => x.IdAutoBus == parada.Idbus).ToList());
        }
    }
}