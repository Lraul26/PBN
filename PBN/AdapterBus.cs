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
    internal class AdapterBus : BaseAdapter
    {
        Activity context;
        List<AutoBuces> lista;

        public AdapterBus(Activity context, List<AutoBuces> lista)
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
                view = context.LayoutInflater.Inflate(Resource.Layout.ItemBuslayout, null);
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.NumeroAuntoBus.ToString();
            return view;
        }
    }
}