using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Supervisor,int,bool> SupervisorData()
        {
            return new SupervisorRepo();
        }

        public static IRepo<Member,int,bool> MemberData()
        {
            return new MemberRepo();
        }
        public static IRepo<Project,int,bool> ProjectData()
        {
            return new ProjectRepo();
        }
        public static IRepo<Enrollment,int,bool>EnrollmentData()
        {
            return new EnrollmentRepo();
        }
    }
}
