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

        public static List<Parada> Parada = new List<Parada>()
        {
            //106//
            new Parada (1,"Donde fue el Hospital velz paiz",1),
            new Parada (2,"Dicegsa",1),
            new Parada (3,"Centro comercial nejapa",1),
            new Parada (4,"Hospital bertha calderon",1),
            new Parada (5,"El zumen",1),
            new Parada (6,"Julio Martinez",1),
            new Parada (7,"Rotonda el Periodista",1),
            new Parada (8,"Enel central",1),
            //123//
            new Parada (9,"Donde fue el Hospital velz paiz",2),
            new Parada (10,"Dicegsa",2),
            new Parada (11,"Centro comercial nejapa",2),
            new Parada (12,"Hospital bertha calderon",2),
            new Parada (13,"El zumen",2),
            new Parada (14,"Julio Martinez",2),
            new Parada (15,"Rotonda el Periodista",2),
            new Parada (16,"Enel central",2),
             //103//
            new Parada (17,"Donde fue el Hospital velz paiz",3),
            new Parada (18,"Dicegsa",3),
            new Parada (19,"Centro comercial nejapa",3),
            new Parada (20,"Hospital bertha calderon",3),
            new Parada (21,"El zumen",3),
            new Parada (22,"Julio Martinez",3),
            new Parada (23,"Rotonda el Periodista",3),
            new Parada (24,"Enel central",3),
             //112//
            new Parada (25,"Donde fue el Hospital velz paiz",4),
            new Parada (26,"Dicegsa",4),
            new Parada (27,"Centro comercial nejapa",4),
            new Parada (28,"Hospital bertha calderon",4),
            new Parada (29,"El zumen",4),
             //120//
            new Parada (30,"Donde fue el Hospital velz paiz",5),
            new Parada (31,"Dicegsa",5),
            new Parada (32,"Centro comercial nejapa",5),
            new Parada (33,"Hospital bertha calderon",5),
            new Parada (34,"El zumen",5),
            new Parada (35,"Julio Martinez",5),
            new Parada (36,"Rotonda el Periodista",5),
            new Parada (37,"Enel central",5),
             //110//
            new Parada (38,"Donde fue el Hospital velz paiz",6),
            new Parada (39,"Dicegsa",6),
            new Parada (40,"Centro comercial nejapa",6),
            new Parada (41,"Hospital bertha calderon",6),
            new Parada (42,"El zumen",6),
            new Parada (43,"Julio Martinez",6),
            new Parada (44,"Rotonda el Periodista",6),
            new Parada (45,"Enel central",6),
            //114//
            new Parada (46,"Donde fue el Hospital velz paiz",7),
            new Parada (47,"Dicegsa",7),
            new Parada (48,"Centro comercial nejapa",7),
            new Parada (49,"Hospital bertha calderon",7),
            new Parada (50,"El zumen",7),
            new Parada (51,"Julio Martinez",7),
            new Parada (52,"Rotonda el Periodista",7),
            new Parada (53,"Enel central",7)
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
        int idbus;

        public Parada(int idPar, string nombrePar, int idbus)
        {
            this.IdPar = idPar;
            this.NombrePar = nombrePar;
            this.Idbus = idbus;
        }

        public int IdPar { get => idPar; set => idPar = value; }
        public string NombrePar { get => nombrePar; set => nombrePar = value; }
        public int Idbus { get => idbus; set => idbus = value; }
    }

    
}