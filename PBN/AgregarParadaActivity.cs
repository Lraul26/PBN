using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PBN
{
    [Activity(Label = "AgregarParadaActivity")]
    public class AgregarParadaActivity : Activity
    {
        proxibusnicweb.ParadasWS serve = new proxibusnicweb.ParadasWS();
        proxibusnicweb.ProxiBusNicWS db = new proxibusnicweb.ProxiBusNicWS();

        EditText Descripcion, Alias, Longitu, Latitud;
        ImageView FotoParada;
        Button BtnCamara,BtnGaleria ,BtnGuardar;
        private byte[] bitmapData;
        string Usuario = Global.Usuario.correo;
        CheckBox estado;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityAgregarParada);
            // Create your application here

            BtnGaleria = FindViewById<Button>(Resource.Id.btnAgregarfoto);
            BtnCamara = FindViewById<Button>(Resource.Id.btnCamara);
            BtnGuardar = FindViewById<Button>(Resource.Id.btnAceptar);

            Descripcion = FindViewById<EditText>(Resource.Id.etDescrip);
            Alias = FindViewById<EditText>(Resource.Id.etAlias); 
            Longitud = FindViewById<EditText>(Resource.Id.etlatitud); 
            Latitud = FindViewById<EditText>(Resource.Id.etlongitud); 

            FotoParada = FindViewById<ImageView>(Resource.Id.ivParada);

            estado = FindViewById<CheckBox>(Resource.Id.chkEstado);
            BtnCamara.Click += BtnCamara_Click;
            BtnGuardar.Click += BtnGuardar_Click;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (validarVacios())
            {
                serve.Descripcion = Descripcion.Text;
                serve.Alias = Alias.Text;
                serve.FotoParada = bitmapData;
                serve.Estado = Activo;
                serve.Longitud = Longitud.Text;
                serve.Latitud = Latitud.Text;
                serve.FechaCreacion = DateTime.Now;
                serve.UsuarioCreacion = "admin@gmail.com";
                serve.FechaModificacion = DateTime.Now;
                serve.UsuarioModificacion = "admin@gmail.com";

                Toast.MakeText(Application.Context, "Registro de Parada Exitoso"+ db.AgregarParada(serve), ToastLength.Short).Show();
            }
        }
        private void Db_AgregarParadaCompleted(object sender, proxibusnicweb.AgregarParadaCompletedEventArgs e)
        {
            
        }

        private void BtnCamara_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            FotoParada.SetImageBitmap(bitmap);
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }
        }

        public bool ValidarNulos()
        {
            if(Alias.Text == String.Empty)
            {
                Alias.Text = null;
                return true;
            }
            if (Alias.Text == String.Empty)
            {
                Longitud.Text = null;
                return true;
            }
            if (Alias.Text == String.Empty)
            {
                Latitud.Text = null;
                return true;
            }
             return true;
        }

        private void limpiar()
        {
            Descripcion.Text = String.Empty;
        }
        private bool validarVacios()
        {
            if (String.IsNullOrEmpty(Descripcion.Text.Trim()))
            {
                Toast.MakeText(Application.Context, "Ingrese una descripcion", ToastLength.Short).Show();
                return false;
            }
            return true;
        }
    }
}