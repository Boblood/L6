using Demo_NMM.Basic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_NMM.Basic.DAL
{
    public interface IBreweryRepository : IDisposable
    {
        IEnumerable<Brewery> SelectAll();
        Brewery SelectByID(int id);
        void Insert(Brewery brewery);
        void Edit(Brewery brewery);
        void Delete(int id);
        void Save();
        int GetNextID();
    }
}
