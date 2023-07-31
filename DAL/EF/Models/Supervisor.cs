using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Supervisor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Project> Projects { get; set; }

        public Supervisor()
        {
            Projects = new List<Project>();
        }
    }
}
