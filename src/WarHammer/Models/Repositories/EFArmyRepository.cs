using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace WarHammer.Models.Repositories
{
    public class EFArmyRepository : IArmyRepository
    {
        public EFArmyRepository(WarHammerContext connection = null)
        {
            if (connection == null)
            {
                this.db = new WarHammerContext();
            }
            else
            {
                this.db = connection;
            }
        }
        WarHammerContext db = new WarHammerContext();

        public IQueryable <Army> Armies
        { get { return db.Armies; } }

        public Army Save(Army army)
        {
            db.Armies.Add(army);
            db.SaveChanges();
            return army;
        }

        public Army Edit(Army army)
        {
            db.Entry(army).State = EntityState.Modified;
            db.SaveChanges();
            return army;
        }

        public void Remove(Army army)
        {
            db.Armies.Remove(army);
            db.SaveChanges();
        }
    }
}
