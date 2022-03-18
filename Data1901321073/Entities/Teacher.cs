using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data1901321073.Entities
{
    public class Teacher : Base
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        [Required]
        [StringLength(20)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Subject { get; set; }

        public short ExperienceYear { get; set; }

        [StringLength(20)]
        public string Address { get; set; }
    }
}
