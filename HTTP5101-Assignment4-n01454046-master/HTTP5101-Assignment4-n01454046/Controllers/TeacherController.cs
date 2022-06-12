using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTTP5101_Assignment4_n01454046.Models;
using System.Web.Http.Cors; // To Implement Cors Properly


namespace HTTP5101_Assignment4_n01454046.Controllers
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

        // GET : /Author/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }

        // POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        // GET : /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        // POST : /Teacher/Create
        [HttpPost]
        // [Route("/Teacher/Create/{TeacherFname}/{TeacherLname}/{TeacherEmployeeNumber}")]
        // Enabling Cors for the Add Teacher Method
        // [EnableCors(origins: "*", methods: "*", headers: "*")]
        public ActionResult Create(string TeacherFname, string TeacherLname, string TeacherEmployeeNumber)
        {
            // Identify if this method is running
            // Identify the inputs provided from the form

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.TeacherEmployeeNumber = TeacherEmployeeNumber;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }
    }
}