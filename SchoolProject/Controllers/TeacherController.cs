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

        TeacherDataController teacherDataController = new TeacherDataController();
        
        public ActionResult list()
        {
            //TeacherDataController teacherDataController = new TeacherDataController();
            Teacher teacherData = teacherDataController.ListTeachers();
            
            // ViewBag.Teacher = teacherData.ListTeachers();
            return View(teacherData);
        }

        public ActionResult show(int? teacherid)
        {
            Teacher teacherData = teacherDataController.ListTeachers();

            // check if teacher id is null or if id value is valid
            int numberOfTeachers = teacherData.TeacherNames.Count();
            if (teacherid == null || teacherid < 1 || teacherid > numberOfTeachers)
            {
                return View("error");
            }

            //TeacherDataController teacherDataController = new TeacherDataController();
            teacherData = teacherDataController.ShowTeacher(teacherid);
            return View(teacherData);
        }

        public ActionResult error()
        {
            Teacher teacherData = teacherDataController.ListTeachers();
            int numberOfTeachers = teacherData.TeacherNames.Count();
            return View(teacherData);
        }
    }
}