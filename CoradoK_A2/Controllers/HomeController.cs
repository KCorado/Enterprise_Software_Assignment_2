using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoradoK_A2.Models;
using System.Linq;

namespace CoradoK_A2.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.Service1Client wcfService = new ServiceReference1.Service1Client();

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult RsvpForm(GuestResponse std, string attendance)
        {
            if (ModelState.IsValid && !String.IsNullOrWhiteSpace(attendance))
            {
                Student student = new Student();
                student.StudentId = std.StudentId;
                student.Name = std.Name;
                student.Email = std.Email;
                student.Phone = std.Phone;
                student.TechnicalInterest = std.Interest.ToString();
                student.SocialNetworkInterest = std.SocialNetworkInterest;
                student.AcceptRegret = attendance;

                wcfService.AddStudentAsync(student.StudentId.GetValueOrDefault(), student.Name, student.Email,
                    student.Phone, student.TechnicalInterest, student.SocialNetworkInterest, student.AcceptRegret);

                return View("Thanks", student);


            }
            else
            {
                // there is a validation error
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            List<Student> lstResponses = new List<Student>();

            //call the wcf service operation and get data
            // .Result is needed because regular sync operation methods could not 
            //  be found during progress in the assignment 
            var lst = wcfService.GetAllGoingAsync().Result;

            //get the data for all students who will attend
            foreach (var item in lst)
            {
                
                Student std = new Student();
                std.StudentId = item.StudentId;
                std.Name = item.Name;
                std.Email = item.Email;
                std.Phone = item.Phone;
                std.TechnicalInterest = item.TechnicalInterest;
                std.SocialNetworkInterest = item.SocialNetworkInterest;
                lstResponses.Add(std);

            }

            return View(lstResponses);

        }

        //Access to admin view, which allows access to admin controls such as 
        //  checking all students, student accept reponse list, and search by student
        public ViewResult AdminPage()
        {
            return View();
        }
        
        public ViewResult ListAllStudents()
        {
            List<Student> lstStudents = new List<Student>();

            //call the wcf service operation and get data
            // .Result is needed because regular sync operation methods could not 
            //  be found during progress in the assignment 
            var lst = wcfService.GetAllStudentsAsync().Result;

            //get the data for all students who will attend
            foreach (var item in lst)
            {

                Student std = new Student();
                std.StudentId = item.StudentId;
                std.Name = item.Name;
                std.Email = item.Email;
                std.Phone = item.Phone;
                std.TechnicalInterest = item.TechnicalInterest;
                std.SocialNetworkInterest = item.SocialNetworkInterest;
                std.AcceptRegret = item.AcceptRegret;
                lstStudents.Add(std);

            }

            return View(lstStudents);
        }
        
        public ViewResult SearchStudent(int targetStudentId)
        {
            //call the wcf service operation and get data
            // .Result is needed because regular sync operation methods could not 
            //  be found during progress in the assignment 
            var std = wcfService.GetGoingByIdAsync(targetStudentId).Result;

            Student targetStudent = new Student();
            targetStudent.StudentId = std.StudentId;
            targetStudent.Name = std.Name;
            targetStudent.Email = std.Email;
            targetStudent.Phone = std.Phone;
            targetStudent.TechnicalInterest = std.TechnicalInterest;
            targetStudent.SocialNetworkInterest = std.SocialNetworkInterest;
            targetStudent.AcceptRegret = std.AcceptRegret;
            

            return View(targetStudent);
        }
        

    }
}
