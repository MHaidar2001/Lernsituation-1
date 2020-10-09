
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaft
{
    public class HandballSpieler : Spieler
    {
        #region Eigenschaften
        private string _Position;
        private string _Ruekennummer;
        #endregion

        #region Accessoren/Modifier
        public string Position { get => _Position; set => _Position = value; }
        public string Ruekennummer { get => _Ruekennummer; set => _Ruekennummer = value; }

        #endregion

        #region Konstruktor

        public HandballSpieler() : base()
        {
            Position = "Kreislaeufer";
            Ruekennummer = "7";

        }

        public HandballSpieler(string v1, string v2, string Sportart, string Status, string name, int GD, string herkunft, int id, string team, string sport, string a) : base(Sportart, Status, name, GD, herkunft,id, team, a)
        {
            Position = v1;
            Ruekennummer = v2;
        }
        public HandballSpieler(HandballSpieler value) : base()
        {
            Position = value.Position;
            Ruekennummer = value.Ruekennummer;
        }
        #endregion

        #region Worker
        public void laufen()
        {
            Console.WriteLine("Der HandballSpieler mit den Ruekennummer " + this.Ruekennummer + " laeuft gerade");
            Console.ReadLine();
        }
        public void status()
        {
            base.gesundheitzustand();

        }

        public override void Trainieren()
        {
            Console.WriteLine("Der HandballSpieler Trainiert");
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
            zahl = Name.CompareTo(value.Name);

            return zahl;
        }

        #endregion
    }
}
