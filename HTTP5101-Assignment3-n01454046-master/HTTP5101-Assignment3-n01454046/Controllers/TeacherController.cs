using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTTP5101_Assignment3_n01454046.Models;

namespace HTTP5101_Assignment3_n01454046.Controllers
{

    // USING THE TEMPLATE FROM THE BLOGPROJECT IN-CLASS EXAMPLE BY CHRISTINE BITTLE
    // Information taken from Modules & Lecture Materials.
    // Accessed multiple times Nov 10th - present
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Teacher/List
        public ActionResult List()
        {
            // Instantiating the TeacherDataController
            TeacherDataController controller = new TeacherDataController();
            // Using the information returned from the ListTeachers Method
            IEnumerable<Teacher> Teachers = controller.ListTeachers();

            // Sending the information returned to the View
            return View(Teachers);
        }

        // GET: /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            // Instantiating the TeacherDataController
            TeacherDataController controller = new TeacherDataController();

            // Using the information returned from the ListTeachers Method
            // Teacher NewTeacher = controller.FindTeacher(id);
            Teacher ClassesTeacher = controller.ListTeacherClasses(id);

            // Sending the information returned to the View
            return View(ClassesTeacher);
        }

    }
}