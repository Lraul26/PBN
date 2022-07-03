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
        EditText etparada;
        Button btnguardar, btncancelar;
        TextView tvresultado;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityDetalleParada);

            int id = Intent.GetIntExtra("id", 0);
            parada = CsGlobal.Parada.Where(x => x.IdPar == id).FirstOrDefault();

            etparada = FindViewById<EditText>(Resource.Id.edparada);
            btnguardar = FindViewById<Button>(Resource.Id.btnguardar);
            btncancelar = FindViewById<Button>(Resource.Id.btncancelar);
            tvresultado = FindViewById<TextView>(Resource.Id.tvresultado);

            etparada.Text = parada.NombrePar;
            btncancelar.Click += Btncancelar_Click;
            btnguardar.Click += Btnguardar_Click;
        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
        
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            
        }
    }
}