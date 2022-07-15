using Android;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.Media;
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
        readonly string[] permissionGroup =
        {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera
        };

        proxibusnicweb.ParadasWS serve = new proxibusnicweb.ParadasWS();
        proxibusnicweb.ProxiBusNicWS db = new proxibusnicweb.ProxiBusNicWS();

        EditText Descripcion, Alias, Longitud, Latitud;
        ImageView FotoParada;
        ImageButton BtnCamara, BtnGaleria;
        Button BtnGuardar;
        private byte[] bitmapData ;
        bool Activo = true;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityAgregarParada);
            // Create your application here

            BtnGaleria = FindViewById<ImageButton>(Resource.Id.btnAgregarfoto);
            BtnCamara = FindViewById<ImageButton>(Resource.Id.btnCamara);
            BtnGuardar = FindViewById<Button>(Resource.Id.btnAceptar);

            Descripcion = FindViewById<EditText>(Resource.Id.etDescrip);
            Alias = FindViewById<EditText>(Resource.Id.etAlias); 
            Longitud = FindViewById<EditText>(Resource.Id.etlatitud); 
            Latitud = FindViewById<EditText>(Resource.Id.etlongitud); 

            FotoParada = FindViewById<ImageView>(Resource.Id.ivParada);

            BtnGaleria.Click += BtnGaleria_Click;
            BtnCamara.Click += BtnCamara_Click;
            BtnGuardar.Click += BtnGuardar_Click;
        }

       

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (validarVacios())
            {
                if (ValidarNulos())
                {
                    serve.Descripcion = Descripcion.Text;
                    serve.Alias = Alias.Text;
                    serve.FotoParada = bitmapData;
                    serve.Estado = Activo;
                    serve.Longitud = Longitud.Text;
                    serve.Latitud = Latitud.Text;
                    serve.UsuarioCreacion = "admin@gmail.com";
                    serve.UsuarioModificacion = "admin@gmail.com";
                    Toast.MakeText(Application.Context, "Registro de Parada Exitoso" + db.AgregarParada(serve), ToastLength.Short).Show();
                    limpiar();
                }
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
        private void BtnGaleria_Click(object sender, EventArgs e)
        {
            SubirFoto();
        }

        async void SubirFoto()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                Toast.MakeText(this, "El Dispositivo no es compatible", ToastLength.Short).Show();
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                CompressionQuality = 320 * 320
            });

            bitmapData = System.IO.File.ReadAllBytes(file.Path);
            Bitmap bitmap = BitmapFactory.DecodeByteArray(bitmapData, 0, bitmapData.Length);
            FotoParada.SetImageBitmap(bitmap);
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}