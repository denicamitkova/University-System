using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public short Age { get; set; }
        public string Egn { get; set; }
        public int FacultyNumber { get; set; }
        public string Major { get; set; }
    }
}
