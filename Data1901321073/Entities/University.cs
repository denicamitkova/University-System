using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data1901321073.Entities
{
   public class University : Base
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        [Required]
        [StringLength(20)]
        public string Street { get; set; }

        public short StreetNumber { get; set; }

        public DateTime BuildIn { get; set; }

        public int NumberStudents { get; set; }

        public int WorldRanking { get; set; }
    }
}
