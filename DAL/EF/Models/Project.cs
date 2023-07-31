using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Project
    {
        public int Id
        {
            get; set;
        }
        public string Title
        {
            get; set;
        }

        public string Status { get; set; }

        [ForeignKey("Supervisors")]
        public int S_Id { get; set; }

        public virtual Supervisor Supervisors { get; set; }

        public List<Enrollment> Enrollments { get; set; }

        public Project()
        {
            Enrollments = new List<Enrollment>();
        }
    }
}
