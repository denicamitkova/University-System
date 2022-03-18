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
    public class TeacherManagmentService
    {
        private StudentSystemDBContext ctx = new StudentSystemDBContext(); //извикваме си контекста

        public List<TeacherDTO> Get() //функция, която да ни връща всички записи 
        {
            List<TeacherDTO> teachersDTO = new List<TeacherDTO>();

            //foreach (var item in ctx.Teachers.ToList())
            //{
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.TeacherRepository.Get())
                {

                    teachersDTO.Add(new TeacherDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        BirthDate = item.BirthDate,
                        Age = item.Age,
                        Email = item.Email,
                        Subject = item.Subject,
                        ExperienceYear = item.ExperienceYear,
                        Address = item.Address
                    }); //цикъла ни извежда всички резултати и ги пълни в List
                }
                return teachersDTO;
            } //finally method Get
        }

        public TeacherDTO GetById(int id)
        {
            TeacherDTO teacherDTO = new TeacherDTO();

            //Teacher item = ctx.Teachers.Find(id);
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Teacher teacher = unitOfWork.TeacherRepository.GetByID(id);

                if (teacher != null)
                {
                    teacherDTO.Id = teacher.Id;
                    teacherDTO.Name = teacher.Name;
                    teacherDTO.BirthDate = teacher.BirthDate;
                    teacherDTO.Age = teacher.Age;
                    teacherDTO.Email = teacher.Email;
                    teacherDTO.Subject = teacher.Subject;
                    teacherDTO.ExperienceYear = teacher.ExperienceYear;
                    teacherDTO.Address = teacher.Address;
                }
            }
            return teacherDTO;
        }

        public bool Save(TeacherDTO teacherDTO)
        {
            Teacher Teacher = new Teacher
            {
                Name = teacherDTO.Name,
                BirthDate = teacherDTO.BirthDate,
                Age = teacherDTO.Age,
                Email = teacherDTO.Email,
                Subject = teacherDTO.Subject,
                ExperienceYear = teacherDTO.ExperienceYear,
                Address = teacherDTO.Address
            };
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.TeacherRepository.Insert(Teacher);
                    unitOfWork.Save();
                }
                //ctx.Teachers.Add(Teacher);
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
                    Teacher teacher = unitOfWork.TeacherRepository.GetByID(id);
                    unitOfWork.TeacherRepository.Delete(teacher);
                    unitOfWork.Save();
                }
                //Teacher teacher = ctx.Teachers.Find(id);
                //ctx.Teachers.Remove(teacher);
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
