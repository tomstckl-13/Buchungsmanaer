using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchungsManager.Lib.Modell
{
    public class Buchungen
    {
        public string Id { get; set; }

        public string GastName { get; set; }

        public DateTime AnreiseDatum { get; set; }

        public double PreisProNacht { get; set; }

        public bool AllInklusiv { get; set; }

        public Buchungen(string gastName, DateTime anreiseDatum, double preisProNacht, bool allInlklusiv)
        {
            this.Id = Guid.NewGuid().ToString();
            this.GastName = gastName;
            this.AnreiseDatum = anreiseDatum;
            this.PreisProNacht = preisProNacht;
            this.AllInklusiv = allInlklusiv;
        }

        public Buchungen(string id, string gastName, DateTime anreiseDatum, double preisProNacht, bool allInlklusiv)
        {
            this.Id = id;
            this.GastName = gastName;
            this.AnreiseDatum = anreiseDatum;
            this.PreisProNacht = preisProNacht;
            this.AllInklusiv = allInlklusiv;
        }



    }
}
