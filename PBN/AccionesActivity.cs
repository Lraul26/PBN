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
    [Activity(Label = "AccionesActivity")]
    public class AccionesActivity : Activity
    {
        ImageButton AgregarBus, EditarBus, AgregarParada, EditarParada;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityAcciones);
            // Create your application here

            AgregarBus = FindViewById<ImageButton>(Resource.Id.IbtnAgrgarBus);
            EditarBus = FindViewById<ImageButton>(Resource.Id.IbtnEditarBus);
            AgregarParada = FindViewById<ImageButton>(Resource.Id.IbtnAgregarParada);
            EditarParada = FindViewById<ImageButton>(Resource.Id.IbtnEditarParada);

            AgregarParada.Click += AgregarParada_Click;
        }

        private void AgregarParada_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AgregarParadaActivity));
            StartActivity(intent);
        }
    }
}