using Android.App;
using Android.Content;
using Android.Graphics;
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
    internal class AdapterParada : BaseAdapter
    {
  
        Activity context;
        List<Parada> lista;

        public AdapterParada(Activity context, List<Parada> lista)
        {
            this.context = context;
            this.lista = lista;
        }

        public override int Count => lista.Count();

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
            //elemento devuelto
            var item = lista[position];
            //Definimos el formato fila
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
            TextView parada = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            parada.Text = item.NombrePar;
            parada.SetTextColor(Color.LightGray);

            TextView cantidad = view.FindViewById<TextView>(Android.Resource.Id.Text2);
            cantidad.Text = "Cabtidad de Buces " + Global.Autobuces.Where(x => x.IdAutoBus == item.Idbus).Count().ToString();
            cantidad.SetTextColor(Color.White);
            return view;
        }
    }
}