using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PBN.proxibusnicweb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBN
{
    internal class AdapterParadas : BaseAdapter
    {
        Activity context;
        List<proxibusnicweb.ParadasWS> paradasWS;

        public AdapterParadas(Activity context, List<ParadasWS> paradasWS)
        {
            this.context = context;
            this.paradasWS = paradasWS;
        }

        public override int Count=> paradasWS.Count ;

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //Elemento devuelto
            var item = paradasWS[position];
            //Formato
            View view = convertView;

            if (view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);


            TextView txtDescripcion = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            txtDescripcion.Text = item.Descripcion;
            txtDescripcion.SetTextColor(Color.LightGray);

            
            TextView txtDescripcion2 = view.FindViewById<TextView>(Android.Resource.Id.Text2);
            txtDescripcion2.Text = "Lat: "+item.Latitud+" Long: "+item.Longitud;
            txtDescripcion2.SetTextColor(Color.LightGray);


            return view;



      

        }
    }
}