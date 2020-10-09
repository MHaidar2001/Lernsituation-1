
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaft
{
    public class Trainer : Person
    {
        #region Eigenschaften
        private int gehalt;

        #endregion

        #region Accessoren/Modifier
        public int Gehalt { get => gehalt; set => gehalt = value; }

        #endregion

        #region Konstruktor
        public Trainer() : base()
        {
            Gehalt = 100000;


        }

        public Trainer(int v1, string name, int GD, string herkunft,int id, string team, string sportart) : base(name, GD, herkunft,id, team, sportart)
        {
            Gehalt = v1;

        }
        public Trainer(Trainer value) : base(value)
        {
            Gehalt = value.Gehalt;
        }
        #endregion

        #region Worker
        public void Gehalterhoehung()
        {
            int alt = this.Gehalt;
            this.Gehalt = 200000;
            int neu = this.Gehalt - alt;
            this.Name = "Timo";
            Console.WriteLine("Der Trainer " + Name + " hat eine Gehalt erhoehung von " + neu + "Euro bekommen");
            Console.ReadLine();
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
