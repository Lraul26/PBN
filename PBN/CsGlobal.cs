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
    internal class CsGlobal
    {
        public static List<AutoBuces> Autobuces = new List<AutoBuces>()
        {
            new AutoBuces (1,106),
            new AutoBuces (2,210),
            new AutoBuces (3,103),
            new AutoBuces (4,112),
            new AutoBuces (5,120),
            new AutoBuces (6,110),
            new AutoBuces (7,114)
        };

        public static List<Parada> Paradas = new List<Parada>()
        {
            new Parada (1,"Donde fue el Hospital velz paiz"),
            new Parada (2,"Dicegsa"),
            new Parada (3,"Centro comercial nejapa"),
            new Parada (4,"Hospital bertha calderon"),
            new Parada (5,"El zumen"),
            new Parada (6,"Julio Martinez"),
            new Parada (7,"Rotonda el Periodista"),
            new Parada (8,"Enel central")
        };

        public static List<BusParada> busparada = new List<BusParada>()
        {
            //106//
            new BusParada (1,1,1),
            new BusParada (2,1,2),
            new BusParada (3,1,3),
            new BusParada (4,1,4),
            new BusParada (5,1,5),
            new BusParada (6,1,6),
            new BusParada (7,1,7),
            new BusParada (8,1,8),
            //123//
            new BusParada (9,2,1),
            new BusParada (10,2,2),
            new BusParada (11,2,3),
            new BusParada (12,2,4),
            new BusParada (13,2,5),
            new BusParada (14,2,6),
            new BusParada (15,2,7),
            new BusParada (16,2,8),
             //103//
            new BusParada (17,3,1),
            new BusParada (18,3,2),
            new BusParada (19,3,3),
            new BusParada (20,3,4),
            new BusParada (21,3,5),
            new BusParada (22,3,6),
            new BusParada (23,3,7),
            new BusParada (24,3,8),
             //112//
            new BusParada (25,4,1),
            new BusParada (26,4,2),
            new BusParada (27,4,3),
            new BusParada (28,4,4),
            new BusParada (29,4,5),
             //120//
            new BusParada (30,5,1),
            new BusParada (31,5,2),
            new BusParada (32,5,3),
            new BusParada (33,5,4),
            new BusParada (34,5,5),
            new BusParada (35,5,6),
            new BusParada (36,5,7),
            new BusParada (37,5,8),
             //110//
            new BusParada (38,6,1),
            new BusParada (39,6,2),
            new BusParada (40,6,3),
            new BusParada (41,6,4),
            new BusParada (42,6,5),
            new BusParada (43,6,6),
            new BusParada (44,6,7),
            new BusParada (45,6,8),
            //114//
            new BusParada (46,7,1),
            new BusParada (47,7,2),
            new BusParada (48,7,3),
            new BusParada (49,7,4),
            new BusParada (50,7,5),
            new BusParada (51,7,6),
            new BusParada (52,7,7),
            new BusParada (53,7,8)
        };

    }
    public class AutoBuces
    {
        int idAutoBus;
        int numeroAuntoBus;

        public AutoBuces(int idAutoBus, int numeroAuntoBus)
        {
            this.IdAutoBus = idAutoBus;
            this.NumeroAuntoBus = numeroAuntoBus;
        }

        public int IdAutoBus { get => idAutoBus; set => idAutoBus = value; }
        public int NumeroAuntoBus { get => numeroAuntoBus; set => numeroAuntoBus = value; }
    }
    public class Parada
    {
        int idPar;
        string nombrePar;

        public Parada(int idPar, string nombrePar)
        {
            this.IdPar = idPar;
            this.NombrePar = nombrePar;
        }

        public int IdPar { get => idPar; set => idPar = value; }
        public string NombrePar { get => nombrePar; set => nombrePar = value; }
    }

    public class BusParada
    {
        int idBusParada;
        int idBus;
        int idParada;

        public BusParada(int idBusParada, int idBus, int idParada)
        {
            this.IdBusParada = idBusParada;
            this.IdBus = idBus;
            this.IdParada = idParada;
        }

        public int IdBusParada { get => idBusParada; set => idBusParada = value; }
        public int IdBus { get => idBus; set => idBus = value; }
        public int IdParada { get => idParada; set => idParada = value; }
    }
}