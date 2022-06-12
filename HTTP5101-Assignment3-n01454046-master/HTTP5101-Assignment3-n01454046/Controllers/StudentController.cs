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
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Student/List
        public ActionResult List()
        {
            // Instantiating the StudentDataController
            StudentDataController controller = new StudentDataController();

            // Using the information returned from the ListStudents Method
            IEnumerable<Student> Students = controller.ListStudents();

            // Sending the information returned to the View
            return View(Students);
        }

        // GET: /Student/Show/{id}
        public ActionResult Show(int id)
        {
            // Instantiating the StudentDataController
            StudentDataController controller = new StudentDataController();

            // Using the information returned from the FindStudent Method
            Student NewStudent = controller.FindStudent(id);

            // Sending the information returned to the View
            return View(NewStudent);
        }
    }
}