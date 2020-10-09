using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Mannschaft
{
    public class Global : HttpApplication
    {

        static private controller _verwalter;

        public static controller Verwalter { get => _verwalter; set => _verwalter = value; }

        void Application_Start(object sender, EventArgs e)
        {
            // Code, der beim Anwendungsstart ausgeführt wird

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            /*
            Verwalter = new controller();

      
            Fussballspieler Spieler3 = new Fussballspieler("Verteidiger", "2", "Fussball", "Gesund", "Ramos", 21, "Schweiz",2, "Real Madrid", "Fussball", "11");
            Fussballspieler Spieler4 = new Fussballspieler("Stuermer", "7", "Fussball", "Gesund", "Varan", 19, "Frankreich", 3, "Real Madrid", "Fussball", "24");
            Fussballspieler Spieler5 = new Fussballspieler("Mittelfeld", "5", "Fussball", "Gesund", "Isco", 28, "Spanien", 4, "Real Madrid", "Fussball", "24");
            Fussballspieler Spieler6 = new Fussballspieler("Verteidiger", "3", "Fussball", "Verletzt", "Khalid", 23, "Frankreich", 4, "Real Madrid", "Fussball", "1");
            Physiotherapeut therapeut = new Physiotherapeut(100, "Peter", 40, "Frankreich",2, "Real Madrid","Fußball");
            Trainer trainer1 = new Trainer(50000, "Zidan", 54, "Spanien", 1,"Real Madrid","Fußball");


            Mannschaft M1 = new Mannschaft(1,"Real Madrid","Fußball");
          
          
            M1.Personen.Add(Spieler3);
            M1.Personen.Add(Spieler4);
            M1.Personen.Add(Spieler5);
            M1.Personen.Add(Spieler6);
            M1.Personen.Add(therapeut);
            M1.Personen.Add(trainer1);


            
            M1.SpielerG.Add(Spieler3);
            M1.SpielerG.Add(Spieler4);
            M1.SpielerG.Add(Spieler5);
            M1.SpielerG.Add(Spieler6);


           
            Verwalter.Personen.Add(Spieler3);
            Verwalter.Personen.Add(Spieler4);
            Verwalter.Personen.Add(Spieler5);
            Verwalter.Personen.Add(Spieler6);
            Verwalter.Personen.Add(therapeut);
            Verwalter.Personen.Add(trainer1);
            */
        }
    }
}