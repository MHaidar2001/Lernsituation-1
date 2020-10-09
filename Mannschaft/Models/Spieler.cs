
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaft
{
    public abstract class Spieler : Person
    {
        #region Eigenschaften
        private string _Status;
        private string _anzahl;

        #endregion

        #region Accessoren/Modifier
        public string Status { get => _Status; set => _Status = value; }
        public string Anzahl { get => _anzahl; set => _anzahl = value; }

        #endregion

        #region Konstruktor
        public Spieler() : base()
        {
            this.Sportart = "";
            this.Status = "";
            this.Anzahl = "0";

        }
        public Spieler(string v1, string v2, string name, int GD, string herkunft,int id, string team, string a) : base(name, GD, herkunft,id, team,v1)
        {
            this.Sportart = v1;
            this.Status = v2;
            this.Anzahl = a;
            this.Name = name;
            this.alter = GD;
            this.Herkunft = herkunft;
            this.ID = id;
            this.Mannschaftname = team;
          
            
        }
        public Spieler(Spieler value) : base(value)
        {
            this.Sportart = value.Sportart;
            this.Status = value.Status;
            this.Anzahl = value.Anzahl;

        }
        #endregion

        #region Worker
        /// <summary>
        /// Über Prüft ob eine  Spieler gesund oder Verletzt ist.
        /// </summary>
        /// <returns> Der gubt den zustand des Spieler zurück </returns>
        public bool gesundheitzustand()
        {
            if (Status == "Gesund")
            {
                Console.WriteLine("Der Spieler ist Gesund");

                return true;
            }
            else
            {
                Console.WriteLine("Der Spieler ist Verletzt");

                return false;
            }

        }

        public abstract void Trainieren();


        public abstract int CompareBySpiele(Spieler value);
        public abstract override int CompareByName(Person value);


        #endregion
    }
}
