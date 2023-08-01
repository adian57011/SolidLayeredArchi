using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EnrollmentRepo : Repo, IRepo<Enrollment, int, bool>
    {
        public bool Create(Enrollment obj)
        {
            db.Enrollments.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = db.Enrollments.Find(id);
            db.Enrollments.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Enrollment> Get()
        {
            return db.Enrollments.ToList();
        }

        public Enrollment Get(int id)
        {
            return db.Enrollments.Find(id);
        }

        public bool Update(Enrollment obj)
        {
            var ex = db.Enrollments.Find(obj.Id);
            ex.M_Id = obj.M_Id;
            ex.P_Id = obj.P_Id;

            return db.SaveChanges() > 0;
        }
    }
}
