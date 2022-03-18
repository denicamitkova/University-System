using AppService.DTOs;
using AppService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        private UniversityManagmentService universityService = new UniversityManagmentService();
        public List<UniversityDTO> GetUniversities()
        {
            return universityService.Get();
        }

        public string PostUniversity(UniversityDTO universityDTO)
        {
            if (!universityService.Save(universityDTO))
            {
                return "University is not saved!";
            }
            else
            {
                return "University is saved!";
            }
        }
        public string PutUniversity(UniversityDTO universityDTO)
        {
            throw new NotImplementedException();
        }

        public string DeleteUniversity(int id)
        {
            if (!universityService.Delete(id))
            {
                return "University is not deleted!";
            }
            else
            {
                return "University is deleted!";
            }
        }

        public StudentDTO GetStudentById(int id)
        {
            return studentService.GetById(id);
        }

        public TeacherDTO GetTeacherById(int id)
        {
            return teacherService.GetById(id);
        }

        public UniversityDTO GetUniversityById(int id)
        {
            return universityService.GetById(id);
        }

        private StudentManagmentService studentService = new StudentManagmentService();
        public List<StudentDTO> GetStudents()
        {
            return studentService.Get();
        }

        public string PostStudent(StudentDTO studentDTO)
        {
            if (!studentService.Save(studentDTO))
                return "Student is not saved!";

            return "Student is saved!";
        }

        public string DeleteStudent(int id)
        {
            if (!studentService.Delete(id))
                return "Student is not deleted!";

            return "Student is deleted!";
        }

        private TeacherManagmentService teacherService = new TeacherManagmentService();
        public List<TeacherDTO> GetTeachers()
        {
            return teacherService.Get();
        }

        public string PostTeacher(TeacherDTO teacherDTO)
        {
            if (!teacherService.Save(teacherDTO))
                return "Teacher is not saved!";

            return "Teacher is saved!";
        }

        public string DeleteTeacher(int id)
        {
            if (!teacherService.Delete(id))
                return "Teacher is not deleted!";

            return "Teacher is deleted!";
        }
    }
}
