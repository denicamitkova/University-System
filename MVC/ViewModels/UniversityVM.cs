using AppService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class UniversityVM
    {
        public int Id { get; set; }

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

        public UniversityVM() { } // празен конструктор, който не приема никакви параметри

        public UniversityVM(UniversityDTO universityDTO)
        {
            Id = universityDTO.Id;
            Name = universityDTO.Name;
            City = universityDTO.City;
            Street = universityDTO.Street;
            StreetNumber = universityDTO.StreetNumber;
            BuildIn = universityDTO.BuildIn;
            NumberStudents = universityDTO.NumberStudents;
            WorldRanking = universityDTO.WorldRanking;
        }
    }
}