using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repos
{
    internal class SupervisorRepo : Repo, IRepo<Supervisor, int, bool>
    {
        public bool Create(Supervisor obj)
        {
            db.Supervisors.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = db.Supervisors.Find(id);
            db.Supervisors.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Supervisor> Get()
        {
            var data = db.Supervisors.ToList();
            return data;
        }

        public Supervisor Get(int id)
        {
            return db.Supervisors.Find(id);
        }

        public bool Update(Supervisor obj)
        {
            var ex = db.Supervisors.Find(obj.Id);

            ex.Name = obj.Name;

            return db.SaveChanges() > 0;

        }
    }
}
