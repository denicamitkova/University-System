using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class UniversityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public short StreetNumber { get; set; }
        public DateTime BuildIn { get; set; }
        public int NumberStudents { get; set; }
        public int WorldRanking { get; set; }
    }
}
