
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaft
{
    public class Mannschaft
    {
        #region Eigenschaften
        private string _Mannschaftname;
        private int _ID;
        private string _Sportart;
        List<Person> _Personen = new List<Person>();
        List<Spieler> _SpielerG = new List<Spieler>();
        List<Mannschaft> _mannschaftL = new List<Mannschaft>();



        #endregion

        #region Accessoren/Modifier
        public List<Person> Personen { get => _Personen; set => _Personen = value; }
        public List<Spieler> SpielerG { get => _SpielerG; set => _SpielerG = value; }
        public List<Mannschaft> MannschaftL { get => _mannschaftL; set => _mannschaftL = value; }
        public int ID { get => _ID; set => _ID = value; }
        public string Sportart { get => _Sportart; set => _Sportart = value; }
        public string Mannschaftname { get => _Mannschaftname; set => _Mannschaftname = value; }

        #endregion

        #region Konstruktor
        public Mannschaft()
        {
            this.Mannschaftname = "FC Bonn";
            Personen = new List<Person>();
            SpielerG = new List<Spieler>();



        }

        public Mannschaft(int id,string name, string sportart)
        {
            this.ID = id;
            this.Sportart = sportart;
            this.Mannschaftname = name;
        }
        public Mannschaft(Mannschaft value)
        {
            this.Mannschaftname = value.Mannschaftname;
            this.ID = value.ID;
            this.Sportart = value.Sportart;

        }
        #endregion


        #region Worker



        public void Sortieren(int v1, int v2, int v3)
        {
            if (v1 == 1)
            {
                Bubblesort(v2, v3);
            }
            else
            {
                Selectionsort(v2, v3);
            }
        }


        public void Bubblesort(int auswahl, int a)
        {
            //Aufwärst
            if (auswahl == 1)
            {

                if (a == 1)
                {
                    //Nach Namen Sortieren 
                    for (int index1 = 0; index1 < Personen.Count; index1++)
                    {
                        for (int index = 0; index < Personen.Count - 1; index++)
                        {
                            if (this.Personen[index].CompareByName(this.Personen[index + 1]) > 0)
                            {
                                Person temp = Personen[index];

                                Personen[index] = Personen[index + 1];
                                Personen[index + 1] = temp;
                            }
                        }
                    }
                }
                else
                {
                    //Nach Spiele Sortieren 
                    for (int index1 = 0; index1 < SpielerG.Count; index1++)
                    {
                        for (int index = 0; index < SpielerG.Count - 1; index++)
                        {
                            if (this.SpielerG[index].CompareByName(this.SpielerG[index + 1]) > 0)
                            {
                                Spieler temp = SpielerG[index];

                                SpielerG[index] = SpielerG[index + 1];
                                SpielerG[index + 1] = temp;
                            }
                        }
                    }
                }
            }
            else//Abwärst
            {
                if (a == 1)//Nach Namen Sortieren 
                {
                    for (int index1 = 0; index1 < Personen.Count; index1++)
                    {
                        for (int index = 0; index < Personen.Count - 1; index++)
                        {
                            if (this.Personen[index].CompareByName(this.Personen[index + 1]) < 0)
                            {
                                Person temp = Personen[index];

                                Personen[index] = Personen[index + 1];
                                Personen[index + 1] = temp;
                            }
                        }
                    }
                }
                else
                {
                    //Nach Spiele Sortieren 
                    for (int index1 = 0; index1 < SpielerG.Count; index1++)
                    {
                        for (int index = 0; index < SpielerG.Count - 1; index++)
                        {
                            if (this.SpielerG[index].CompareByName(this.SpielerG[index + 1]) < 0)
                            {
                                Spieler temp = SpielerG[index];

                                SpielerG[index] = SpielerG[index + 1];
                                SpielerG[index + 1] = temp;
                            }
                        }
                    }
                }
            }

        }

        public void Selectionsort(int auswahl, int i)
        {
            if (auswahl == 1)
            {
                if (i == 1)
                {
                    Person temp;
                    int min;

                    for (int index = 0; index < Personen.Count - 1; index++)
                    {
                        min = index;
                        for (int index1 = index + 1; index1 < Personen.Count; index1++)
                        {
                            if (this.Personen[index1].CompareByName(Personen[min]) < 0)
                            {
                                min = index1;
                            }
                        }

                        temp = Personen[min];
                        Personen[min] = Personen[index];
                        Personen[index] = temp;

                    }
                }
                else
                {
                    Spieler temp;
                    int min;

                    for (int index = 0; index < SpielerG.Count - 1; index++)
                    {
                        min = index;
                        for (int index1 = index + 1; index1 < SpielerG.Count; index1++)
                        {
                            if (this.SpielerG[index1].CompareBySpiele(SpielerG[min]) < 0)
                            {
                                min = index1;
                            }
                        }

                        temp = SpielerG[min];
                        SpielerG[min] = SpielerG[index];
                        SpielerG[index] = temp;
                    }
                }
            }
            else
            {
                if (i == 2)
                {
                    Person temp;
                    int min;

                    for (int index = 0; index < Personen.Count - 1; index++)
                    {
                        min = index;
                        for (int index1 = index + 1; index1 < Personen.Count; index1++)
                        {
                            if (this.Personen[index1].CompareByName(Personen[min]) > 0)
                            {
                                min = index1;
                            }
                        }

                        temp = Personen[min];
                        Personen[min] = Personen[index];
                        Personen[index] = temp;

                    }
                }
                else
                {
                    Spieler temp;
                    int min;

                    for (int index = 0; index < SpielerG.Count - 1; index++)
                    {
                        min = index;
                        for (int index1 = index + 1; index1 < SpielerG.Count; index1++)
                        {
                            if (this.SpielerG[index1].CompareBySpiele(SpielerG[min]) > 0)
                            {
                                min = index1;
                            }
                        }

                        temp = SpielerG[min];
                        SpielerG[min] = SpielerG[index];
                        SpielerG[index] = temp;
                    }
                }
            }

        }
        #endregion

    }
}
