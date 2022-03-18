using AppService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            List<TeacherVM> teachersVM = new List<TeacherVM>(); //списък с всички университети

            using (SOAPService.Service1Client service = new SOAPService.Service1Client()) //извикваме си сървиса
            {
                foreach (var item in service.GetTeachers())
                {
                    teachersVM.Add(new TeacherVM(item));
                }
            }

            return View(teachersVM);
        }

        
        public ActionResult Create(TeacherVM teacherVM)
        {
            try
            {
                if (ModelState.IsValid) //валидация още в самия front-end, тъй като преминаваме от front-end към back-end 
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        TeacherDTO teacherDTO = new TeacherDTO
                        {
                            Name = teacherVM.Name,
                            BirthDate = teacherVM.BirthDate,
                            Age = teacherVM.Age,
                            Email = teacherVM.Email,
                            Subject = teacherVM.Subject,
                            ExperienceYear = teacherVM.ExperienceYear,
                            Address = teacherVM.Address
                        };
                        service.PostTeacher(teacherDTO);

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
                service.DeleteTeacher(id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            TeacherVM teacherVM = new TeacherVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var teacherDTO = service.GetTeacherById(id);
                teacherVM = new TeacherVM(teacherDTO);
            }

            return View(teacherVM);
        }
    }
}