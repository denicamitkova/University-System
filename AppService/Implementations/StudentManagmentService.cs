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
    public class StudentManagmentService
    {
        private StudentSystemDBContext ctx = new StudentSystemDBContext(); //извикваме си контекста

        public List<StudentDTO> Get() //функция, която да ни връща всички записи 
        {
            List<StudentDTO> studentsDTO = new List<StudentDTO>();

            // foreach (var item in ctx.Students.ToList())
            // {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.StudentRepository.Get())
                {
                    studentsDTO.Add(new StudentDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        BirthDate = item.BirthDate,
                        Age = item.Age,
                        Egn = item.Egn,
                        FacultyNumber = item.FacultyNumber,
                        Major = item.Major
                    }); //цикъла ни извежда всички резултати и ги пълни в List
                }
                return studentsDTO;
            } //finally method Get
        }

            public StudentDTO GetById(int id)
            {
                StudentDTO studentDTO = new StudentDTO();

                //Student item = ctx.Students.Find(id);

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Student student = unitOfWork.StudentRepository.GetByID(id);

                    if (student != null)
                    {
                        studentDTO.Id = student.Id;
                        studentDTO.Name = student.Name;
                        studentDTO.BirthDate = student.BirthDate;
                        studentDTO.Age = student.Age;
                        studentDTO.Egn = student.Egn;
                        studentDTO.FacultyNumber = student.FacultyNumber;
                        studentDTO.Major = student.Major;
                    }
                }

                return studentDTO;
            }

            public bool Save(StudentDTO studentDTO)
            {
                Student Student = new Student
                {
                    Name = studentDTO.Name,
                    BirthDate = studentDTO.BirthDate,
                    Age = studentDTO.Age,
                    Egn = studentDTO.Egn,
                    FacultyNumber = studentDTO.FacultyNumber,
                    Major = studentDTO.Major
                };
                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        unitOfWork.StudentRepository.Insert(Student);
                        unitOfWork.Save();
                    }
                    //ctx.Students.Add(student);
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
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        Student student = unitOfWork.StudentRepository.GetByID(id);
                        unitOfWork.StudentRepository.Delete(student);
                        unitOfWork.Save();

                    }
                    //Student student = ctx.Students.Find(id);
                    //ctx.Students.Remove(student);
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
