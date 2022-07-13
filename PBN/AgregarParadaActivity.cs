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
        string Usuario = CsGlobal.Usuario.correo;
        bool Activo = true;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityAgregarParada);
            // Create your application here

            BtnGaleria = FindViewById<Button>(Resource.Id.btnAgregarfoto);
            BtnCamara = FindViewById<Button>(Resource.Id.btnCamara);
            BtnGuardar = FindViewById<Button>(Resource.Id.btnAceptar);

            Descripcion = FindViewById<EditText>(Resource.Id.etDescrip);
            Alias = FindViewById<EditText>(Resource.Id.etAlias); Alias.Text = "N/A";
            Longitu = FindViewById<EditText>(Resource.Id.etlatitud); Longitu.Text  = "N/A";
            Latitud = FindViewById<EditText>(Resource.Id.etlongitud); Latitud.Text = "N/A";

            FotoParada = FindViewById<ImageView>(Resource.Id.ivParada); 

            BtnCamara.Click += BtnCamara_Click;
            BtnGuardar.Click += BtnGuardar_Click;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (validarVacios())
            {
                
            }
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