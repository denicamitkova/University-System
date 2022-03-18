using AppService.DTOs;
using Data1901321073.Context;
using Data1901321073.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Implementations
{
    public class UniversityManagmentService
    {
        private StudentSystemDBContext ctx = new StudentSystemDBContext(); //извикваме си контекста

        public List<UniversityDTO> Get() //функция, която да ни връща всички записи 
        {
            List<UniversityDTO> universitiesDTO = new List<UniversityDTO>();

            //foreach (var item in ctx.Universities.ToList())
            //{
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.UniversityRepository.Get())
                {
                    universitiesDTO.Add(new UniversityDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        City = item.City,
                        Street = item.Street,
                        StreetNumber = item.StreetNumber,
                        BuildIn = item.BuildIn,
                        NumberStudents = item.NumberStudents,
                        WorldRanking = item.WorldRanking
                    }); //цикъла ни извежда всички резултати и ги пълни в List
                }
                return universitiesDTO;
            } //finally method Get
        }

        public UniversityDTO GetById(int id)
        {
            UniversityDTO universityDTO = new UniversityDTO();

            //University item = ctx.Universities.Find(id);

            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                University university = unitOfWork.UniversityRepository.GetByID(id);

            if (university != null)
            {
                universityDTO.Id = university.Id;
                universityDTO.Name = university.Name;
                universityDTO.Street = university.Street;
                universityDTO.StreetNumber = university.StreetNumber;
                universityDTO.BuildIn = university.BuildIn;
                universityDTO.NumberStudents = university.NumberStudents;
                universityDTO.WorldRanking = university.WorldRanking;
            }
        }

            return universityDTO;
        }

        public bool Save(UniversityDTO universityDTO)
        {
            University University = new University
            {
                Name = universityDTO.Name,
                City = universityDTO.City,
                Street = universityDTO.Street,
                StreetNumber = universityDTO.StreetNumber,
                BuildIn = universityDTO.BuildIn,
                NumberStudents = universityDTO.NumberStudents,
                WorldRanking = universityDTO.WorldRanking
            };
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.UniversityRepository.Insert(University);
                    unitOfWork.Save();
                }
                //ctx.Universities.Add(university);
                //ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork())
                {
                    University university = unitOfWork.UniversityRepository.GetByID(id);
                    unitOfWork.UniversityRepository.Delete(university);
                    unitOfWork.Save();
                }
                //University university = ctx.Universities.Find(id);
                //ctx.Universities.Remove(university);
                //ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
