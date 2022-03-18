using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data1901321073.Entities
{
    public class Student : Base
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public short Age { get; set; }

        [Required]
        [StringLength(20)]
        public string Egn { get; set; }

        [Required]
        public int FacultyNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string Major { get; set; }
    }
}
