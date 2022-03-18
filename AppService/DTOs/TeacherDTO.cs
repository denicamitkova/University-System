using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public short ExperienceYear { get; set; }
        public string Address { get; set; }
    }
}
