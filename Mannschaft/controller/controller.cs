using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mannschaft
{
    public class controller
    {
        #region Eigenschaften
        private List<Mannschaft> _Mannschafts1;
        private List<Person> _personen;

        #endregion

        #region Accessoren
        public List<Mannschaft> Mannschafts1 { get => _Mannschafts1; set => _Mannschafts1 = value; }
        public List<Person> Personen { get => _personen; set => _personen = value; }

        #endregion

        #region Konstruktoren
        public controller()
        {
            Mannschafts1 = new List<Mannschaft>();
            Personen = new List<Person>();

        }
        #endregion

        #region Worker

        #endregion
    }
}