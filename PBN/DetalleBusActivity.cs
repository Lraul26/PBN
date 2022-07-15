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
    [Activity(Label = "DetalleBusActivity")]
    public class DetalleBusActivity : Activity
    {
        
        AutoBuces bus;
        TextView tvtitulo;
        ListView lvdtbus;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityDetalleBusxml);

            int id = Intent.GetIntExtra("id", 0);
            bus = Global.Autobuces.Where(x => x.IdAutoBus == id).FirstOrDefault();

            tvtitulo = FindViewById<TextView>(Resource.Id.tvtitulo);
            lvdtbus = FindViewById<ListView>(Resource.Id.lvdtbus);

            tvtitulo.Text = "Ruta " + bus.NumeroAuntoBus.ToString();
            lvdtbus.Adapter = new AdapterParada(this, Global.Parada.Where(x => x.Idbus == bus.IdAutoBus).ToList());

            lvdtbus.ItemClick += Lvdtbus_ItemClick;
        }
        private void Lvdtbus_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent i = new Intent(this, typeof(DetalleParadaActivity));
            Parada parada = Global.Parada[e.Position];
            i.PutExtra("id", parada.IdPar);
            StartActivity(i);
        }
    }
}