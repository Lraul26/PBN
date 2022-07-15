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
    [Activity(Label = "BusActivity")]
    public class BusActivity : Activity
    {
        ListView lvbus;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityPrincipal);

            lvbus = FindViewById<ListView>(Resource.Id.lvbus);
            lvbus.Adapter = new AdapterBus(this, Global.Autobuces);

            lvbus.ItemClick += Lvbus_ItemClick;
        }

        private void Lvbus_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent i = new Intent(this, typeof(DetalleBusActivity));
            AutoBuces bus = Global.Autobuces[e.Position];
            i.PutExtra("id", bus.IdAutoBus);
            StartActivity(i);
        }
    }
}