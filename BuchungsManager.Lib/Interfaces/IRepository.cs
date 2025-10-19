using BuchungsManager.Lib.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchungsManager.Lib.Interfaces
{
    public interface IRepository
    {
        public bool Add(Buchungen buchungen);

        public bool Delete(Buchungen buchungen);    

        public bool Update(Buchungen buchungen);

        public List<Buchungen> GetAll();

        public bool Save();
    }
}
