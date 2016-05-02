using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarHammer.Models;

namespace WarHammer.Models.Repositories
{
    public interface IArmyRepository
    {
        IQueryable<Army> Armies { get; }
        Army Save(Army army);
        Army Edit(Army army);
         void Remove(Army army);
    }
}
