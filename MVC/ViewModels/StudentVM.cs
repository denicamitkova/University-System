using AppService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }

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

        public StudentVM() { } // празен конструктор, който не приема никакви параметри

        public StudentVM(StudentDTO studentDTO)
        {
            Id = studentDTO.Id;
            Name = studentDTO.Name;
            BirthDate = studentDTO.BirthDate;
            Age = studentDTO.Age;
            Egn = studentDTO.Egn;
            FacultyNumber = studentDTO.FacultyNumber;
            Major = studentDTO.Major;
        }
    }
}