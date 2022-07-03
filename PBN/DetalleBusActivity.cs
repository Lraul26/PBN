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
        Button aceptar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityDetalleBusxml);

           

            int id = Intent.GetIntExtra("id", 0);
            bus = CsGlobal.Autobuces.Where(x => x.IdAutoBus == id).FirstOrDefault();

            tvtitulo = FindViewById<TextView>(Resource.Id.tvtitulo);
            aceptar = FindViewById<Button>(Resource.Id.button1);
            lvdtbus = FindViewById<ListView>(Resource.Id.lvdtbus);

            tvtitulo.Text = bus.NumeroAuntoBus.ToString();
            lvdtbus.Adapter = new AdapterParada(this, CsGlobal.Parada.Where(x => x.Idbus == bus.IdAutoBus).ToList());

            lvdtbus.ItemClick += Lvdtbus_ItemClick;
            aceptar.Click += Aceptar_Click;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            var item = new Intent(this, typeof(addparabusActivity));
            StartActivity(item);
        }

        private void Lvdtbus_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent i = new Intent(this, typeof(DetalleParadaActivity));
            Parada parada = CsGlobal.Parada[e.Position];
            i.PutExtra("id", parada.IdPar);
            StartActivity(i);
        }
    }
}