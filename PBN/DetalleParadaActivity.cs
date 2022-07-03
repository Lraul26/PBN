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
    [Activity(Label = "DetalleParadaActivity")]
    public class DetalleParadaActivity : Activity
    {
        Parada parada;
        TextView NomParada;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityDetalleParada);

            int id = Intent.GetIntExtra("id", 0);
            parada = CsGlobal.Parada.Where(x => x.IdPar == id).FirstOrDefault();

            NomParada = FindViewById<TextView>(Resource.Id.txtparada);
            NomParada.Text = parada.NombrePar;
        }
    }
}