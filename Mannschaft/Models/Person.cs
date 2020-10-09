using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaft
{
    public abstract class Person : Mannschaft
    {
        #region Eigenschaften
        private string _name;
        private int _alter;
        private string _Herkunft;

        #endregion

        #region Accessoren/Modifier
        public string Name { get => _name; set => _name = value; }
        public string Herkunft { get => _Herkunft; set => _Herkunft = value; }
        public int alter { get => _alter; set => _alter = value; }

        #endregion

        #region Konstruktor
        public Person() : base()
        {
            this.Name = "Mueller";
            this.alter = 23;
            this.Herkunft = "Deutschland";

        }
        public Person(string v1, int v2, string v3, int id,string Team, string sportart) : base(id, Team, sportart)
        {
            this.ID = id;
            this.Name = v1;
            this.alter = v2;
            this.Herkunft = v3;
            this.Mannschaftname = Team;
            this.Sportart = sportart;
           


        }
        public Person(Person value) : base(value)
        {
            this.Name = value.Name;
            this.alter = value.alter;
            this.Herkunft = value.Herkunft;


        }
        #endregion

        #region Worker
        /// <summary>
        /// 
        /// </summary>
        public void persönlichendaten()
        {
            Console.WriteLine("Name:         " + Name);
            Console.WriteLine("Herkunft:     " + Herkunft);
            Console.WriteLine("Alter: " + alter);
            Console.ReadLine();

        }

        public abstract int CompareByName(Person value);


        #endregion
    }
}
