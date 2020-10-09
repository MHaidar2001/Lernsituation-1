
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaft
{
    public class Physiotherapeut : Person
    {
        #region Eigenschaften
        private int _gehalt;

        #endregion

        #region Accessoren/Modifier
        public int gehalt { get => _gehalt; set => _gehalt = value; }

        #endregion

        #region Konstruktor
        public Physiotherapeut() : base()
        {
            gehalt = 1000;


        }

        public Physiotherapeut(int v1, string n, int GD, string herkunft,int id, string team,string sportart) : base(n, GD, herkunft,id, team,sportart)
        {
            gehalt = v1;
            this.Sportart = Sportart;


        }
        public Physiotherapeut(Physiotherapeut value) : base(value)
        {
            gehalt = value.gehalt;
        }
        #endregion

        #region Worker
       

        public override int CompareByName(Person value)
        {
            int zahl = 0;
            zahl = this.Name.CompareTo(value.Name);

            return zahl;
        }
        #endregion
    }
}
