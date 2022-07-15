using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PBN
{
    [Activity(Label = "AgregarComentarioActivity")]
    public class AgregarComentarioActivity : Activity
    {

        proxibusnicweb.ProxiBusNicWS service = new proxibusnicweb.ProxiBusNicWS();
        proxibusnicweb.SugerenciaWS sugerencia = new proxibusnicweb.SugerenciaWS();
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

            lvparada.ItemClick += Lvparada_ItemClick;
            Aceptar.Click += Aceptar_Click;
            Cancelar.Click += Cancelar_Click;

            service.ListarParadaCompleted += Service_ListarParadaCompleted;
            service.ListarBusParadaAsync();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                sugerencia.ParadaId = positions;
                sugerencia.DescripcionSugerencia = comentarios.Text;
                sugerencia.UsuarioCreacion = "admin@gmail.com";

                Toast.MakeText(Application.Context, "Registro de comentario Exitoso" + service.AgregarSugerencia(sugerencia), ToastLength.Short).Show();
                limpiar();
            }
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
            _adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemMultipleChoice, lparada);
            lvparada.Adapter = _adapter;
            lvparada.ChoiceMode = ChoiceMode.Multiple;
        }
        private void Lvparada_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            positions = e.Position;
        }
        private bool Validar()
        {
            if (String.IsNullOrEmpty(comentarios.Text.Trim()))
            {
                Toast.MakeText(Application.Context, "Ingrese un Comentario", ToastLength.Short).Show();
                return false;
            }
            if (positions == -1)
            {
                Toast.MakeText(Application.Context, "Seleccione una Parada", ToastLength.Short).Show();
                return false;
            }
            return true;
        }
        private void limpiar()
        {
            comentarios.Text = String.Empty;
            positions = -1;
        }
    }
}