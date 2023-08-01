using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProjectRepo : Repo, IRepo<Project, int, bool>
    {
        public bool Create(Project obj)
        {
            db.Projects.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exp = db.Projects.Find(id);
            db.Projects.Remove(exp);
            return db.SaveChanges() > 0;
        }

        public List<Project> Get()
        {
            return db.Projects.ToList();
        }

        public Project Get(int id)
        {
            return db.Projects.Find(id);
        }

        public bool Update(Project obj)
        {
            var exp = db.Projects.Find(obj.Id);
            exp.Status = obj.Status;
            exp.Title = obj.Title;

            return db.SaveChanges() > 0;

        }
    }
}
