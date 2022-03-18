using AppService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<StudentVM> studentsVM = new List<StudentVM>(); //списък с всички университети

            using (SOAPService.Service1Client service = new SOAPService.Service1Client()) //извикваме си сървиса
            {
                foreach (var item in service.GetStudents())
                {
                  studentsVM.Add(new StudentVM(item));
                }
            }
            return View(studentsVM);
        }

        public ActionResult Create(StudentVM studentVM)
        {
            try
            {
                if (ModelState.IsValid) //валидация още в самия front-end, тъй като преминаваме от front-end към back-end 
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        StudentDTO studentDTO = new StudentDTO
                        {
                            Name = studentVM.Name,
                            BirthDate = studentVM.BirthDate,
                            Age = studentVM.Age,
                            Egn = studentVM.Egn,
                            FacultyNumber = studentVM.FacultyNumber,
                            Major = studentVM.Major
                        };
                        service.PostStudent(studentDTO);

                        return RedirectToAction("Index");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteStudent(id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            StudentVM studentVM = new StudentVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var studentDTO = service.GetStudentById(id);
                studentVM = new StudentVM(studentDTO);
            }

            return View(studentVM);
        }

    }
}