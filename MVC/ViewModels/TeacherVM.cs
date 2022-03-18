using AppService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class TeacherVM
    {
        public int Id { get; set; }

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

        public TeacherVM() { } // празен конструктор, който не приема никакви параметри

        public TeacherVM(TeacherDTO teacherDTO)
        {
            Id = teacherDTO.Id;
            Name = teacherDTO.Name;
            BirthDate = teacherDTO.BirthDate;
            Age = teacherDTO.Age;
            Email = teacherDTO.Email;
            Subject = teacherDTO.Subject;
            ExperienceYear = teacherDTO.ExperienceYear;
            Address = teacherDTO.Address;
        }
    }
}