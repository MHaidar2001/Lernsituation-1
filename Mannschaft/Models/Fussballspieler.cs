
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaft
{
    public class Fussballspieler : Spieler
    {
        #region Eigenschaften
        private string _Position;
        private string _Ruekennummer;

        #endregion

        #region Accessoren/Modifier
        public string Position { get => _Position; set => _Position = value; }
        public string Ruekennummer1 { get => _Ruekennummer; set => _Ruekennummer = value; }

        #endregion

        #region Konstruktor
        public Fussballspieler() : base()
        {
            Position = "Verteidiger";
            Ruekennummer1 = "4";

        }

        public Fussballspieler(string v1, string v2, string sportart, string Status, string name, int GD, string herkunft,int id, string team, string a) : base(sportart, Status, name, GD, herkunft,id, team, a)
        {
           this.Position = v1;
            this.Ruekennummer1 = v2;
            this.Sportart = sportart;
            this.Status = Status;
            this.Name = name;
            this.alter = GD;
            this.Herkunft = herkunft;
            this.ID = id;
            this.Mannschaftname = team;
            this.Anzahl = a;

        }
        public Fussballspieler(Fussballspieler value) : base(value)
        {
            Position = value.Position;
            Ruekennummer1 = value.Ruekennummer1;
        }


        #endregion

        #region Worker
        /// <summary>
        /// Der FussballSpieler bekommt neue Position
        /// </summary>
        /// <returns>Gibt den Neuen Position zurück</returns>
        public string Positionaendern()
        {
            string alt = this.Position;
            this.Position = "linksVerteidiger";
            Console.WriteLine("Der FussballSpieler mit den Ruekennummer " + this.Ruekennummer1 + " ist nicht mehr " + alt + " sonder der ist " + Position);
            Console.ReadLine();
            return Position;
        }

        public override void Trainieren()
        {
            Console.WriteLine("Der FussballSpieler Trainiert");
        }

        public override int CompareBySpiele(Spieler value)
        {
           /* if (this.Anzahl > value.Anzahl)
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
            zahl = this.Name.CompareTo(value.Name);

            return zahl;
        }

        #endregion
    }
}
