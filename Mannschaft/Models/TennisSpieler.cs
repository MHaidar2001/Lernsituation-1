
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaft
{
    public class TennisSpieler : Spieler
    {
        #region Eigenschaften
        private string _sponsor;

        #endregion

        #region Accessoren/Modifier
        public string Sponsor { get => _sponsor; set => _sponsor = value; }

        #endregion

        #region Konstruktor
        public TennisSpieler() : base()
        {
            Sponsor = "Nike";


        }

        public TennisSpieler(string v1, string Sportart, string Status, string name, int GD, string herkunft,int id, string team,string sport, string a) : base(Sportart, Status, name, GD, herkunft,id, team, a)
        {
            Sponsor = v1;

        }
        public TennisSpieler(TennisSpieler value) : base(value)
        {
            Sponsor = value.Sponsor;
        }

        #endregion

        #region Worker
        public void Sponsorwechseln()
        {
            string alt = this.Sponsor;
            this.Sponsor = "Adidas";
            Console.WriteLine("Der TennisSpieler" + " wird nicht mehr von " + alt + " gesponsort" + " der wird jetzt von " + this.Sponsor);
            Console.ReadLine();
        }
        /// <summary>
        /// Der Spieler Trainiert.
        /// </summary>
        public override void Trainieren()
        {
            Console.WriteLine("Der TennisSpieler Trainiert");
        }

       public override int CompareBySpiele(Spieler value)
        {
          /*   if (this.Anzahl > value.Anzahl)
            {
                return 1;
            }
            else if (this.Anzahl < value.Anzahl)
            {
                return -1;
            }
            else
            {
                
            }*/return 0;
        }

        public override int CompareByName(Person value)
        {
            int zahl = 0;
            zahl = string.Compare(this.Name, value.Name);

            return zahl;
        }
        #endregion
    }
}
