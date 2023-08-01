using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MemberRepo : Repo, IRepo<Member, int, bool>
    {
        public bool Create(Member obj)
        {
            db.Members.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exp = db.Members.Find(id);
            db.Members.Remove(exp);
            return db.SaveChanges() > 0;
        }

        public List<Member> Get()
        {
            var data = db.Members.ToList();
            return data;
        }

        public Member Get(int id)
        {
            return db.Members.Find(id);
        }

        public bool Update(Member obj)
        {
            var exp = db.Members.Find(obj.Id);

            exp.Name = obj.Name;

            return db.SaveChanges() > 0;
        }
    }
}
