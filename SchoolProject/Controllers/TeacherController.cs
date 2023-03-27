using BlogAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult list()
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            Teacher teacherData = teacherDataController.ListTeachers();
            
            // ViewBag.Teacher = teacherData.ListTeachers();
            return View(teacherData);
        }

        public ActionResult show()
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            Teacher teacherData = teacherDataController.ShowTeacher();
            return View(teacherData);
        }
    }
}