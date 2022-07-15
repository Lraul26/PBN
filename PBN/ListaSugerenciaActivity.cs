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
    [Activity(Label = "ListaSugerenciaActivity")]
    public class ListaSugerenciaActivity : Activity
    {
        proxibusnicweb.ProxiBusNicWS service = new proxibusnicweb.ProxiBusNicWS();
        ListView lvsugerencia;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityListaComentario);
            // Create your application here

            service.AgregarSugerenciaCompleted
        }
    }
}