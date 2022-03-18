using AppService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UniversityController : Controller
    {
        // GET: University
        public ActionResult Index()
        {
            List<UniversityVM> universitiesVM = new List<UniversityVM>(); //списък с всички университети

            using(SOAPService.Service1Client service = new SOAPService.Service1Client()) //извикваме си сървиса
            {
                foreach (var item in service.GetUniversities())
                {
                    universitiesVM.Add(new UniversityVM(item));
                }
            }

            return View(universitiesVM);
        }

        
        public ActionResult Create(UniversityVM universityVM)
        {
            try
            {
                if (ModelState.IsValid) //валидация още в самия front-end, тъй като преминаваме от front-end към back-end 
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        UniversityDTO universityDTO = new UniversityDTO
                        {
                            Name = universityVM.Name,
                            City = universityVM.City,
                            Street = universityVM.Street,
                            StreetNumber = universityVM.StreetNumber,
                            BuildIn = universityVM.BuildIn,
                            NumberStudents = universityVM.NumberStudents,
                            WorldRanking = universityVM.WorldRanking
                        };
                        service.PostUniversity(universityDTO);

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
            using(SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteUniversity(id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            UniversityVM universityVM = new UniversityVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var universityDTO = service.GetUniversityById(id);
                universityVM = new UniversityVM(universityDTO);
            }

            return View(universityVM);
        }
    }
}