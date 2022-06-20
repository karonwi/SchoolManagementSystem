using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public virtual User User { get; set; }  
        public virtual Address Address { get; set; }
    }
}
