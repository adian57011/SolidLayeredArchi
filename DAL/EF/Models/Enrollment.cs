using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        [ForeignKey("Projects")]
        public int P_Id { get; set; }

        [ForeignKey("Members")]
        public int M_Id { get; set; }

        public virtual Member Members { get; set; }
        public virtual Project Projects { get; set; }
    }
}
