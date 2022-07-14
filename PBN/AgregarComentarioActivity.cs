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
    [Activity(Label = "AgregarComentarioActivity")]
    public class AgregarComentarioActivity : Activity
    {
        

        ListView lvparada;
        EditText comentarios;
        ImageButton Aceptar, Cancelar;
        int positions = -1;
        List<string> lparada;
        List<int> idparada;
        ArrayAdapter _adapter;
        SearchView _sv;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityAgregarComentarios);

            _sv = FindViewById<SearchView>(Resource.Id.searchComentario);
            lvparada = FindViewById<ListView>(Resource.Id.lvoaradaCom);
            comentarios = FindViewById<EditText>(Resource.Id.txtComentario);
            Aceptar = FindViewById<ImageButton>(Resource.Id.bntAceptar);
            Cancelar = FindViewById<ImageButton>(Resource.Id.btnCancelar);

            proxibusnicweb.ProxiBusNicWS service = new proxibusnicweb.ProxiBusNicWS();
            service.ListarParadaCompleted += Service_ListarParadaCompleted;
            service.ListarParadaAsync();

        }

        private void Service_ListarParadaCompleted(object sender, proxibusnicweb.ListarParadaCompletedEventArgs e)
        {
            lparada = new List<string>();
            idparada = new List<int>();

            foreach (var item in e.Result)
            {
                lparada.Add(item.Descripcion);
                idparada.Add(item.Id);
            }
            lvparada.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, idparada);

        }
    }
}