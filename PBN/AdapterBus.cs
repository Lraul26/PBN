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
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text =  "Ruta " + item.NumeroAuntoBus.ToString();
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text =  "Cantidad de paradas " + CsGlobal.Parada.Where(x => x.Idbus == item.IdAutoBus).Count().ToString();
            return view;
        }
    }
}