using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTTP5101_Assignment5_n01454046.Models;
using System.Web.Http.Cors; // To Implement Cors Properly


namespace HTTP5101_Assignment5_n01454046.Controllers
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

        // GET : /Teacher/Add
        public ActionResult Add()
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

        // GET : /Teacher/Update/{id}
        /// <summary>
        ///     Routes to a dynamically generated "Teacher Update" Page. Gathers information from the database.
        /// </summary>
        /// <param name="id"> ID of the Teacher </param>
        /// <returns> A dynamic "Update Teacher" webpage which provides the current information of the Teacher and asks the user for new information as part of a form. </returns>
        /// <example> GET : /Teacher/Update/{id} </example>
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);


            return View(SelectedTeacher);
        }


        /// <summary>
        /// Receives a POST request contraining information about an existing teacher in the system, with new values. Conveys this information to the API, and redirects to the "Teacher Show" page of our updated Teacher.
        /// </summary>
        /// <param name="id"> ID of the Teacher to update </param>
        /// <param name="TeacherFname"> The updated first name of the Teacher </param>
        /// <param name="TeacherLname"> The updated last name of the Teacher </param>
        /// <param name="TeacherEmployeeNumber"> The updated employee number of the Teacher.  </param>
        /// <returns> A dynamic webpage which provides the current information of the Teacher </returns>
        /// <example> 
        ///     POST : /Teacher/Update/{id} 
        ///     FORM DATA / POST DATA / REQUEST BODY
        ///     {
        ///     "TeacherFname":"Adam",
        ///     "TeacherLname":"Galek",
        ///     "TeacherEmployeeNumber":"n1666",
        ///     }
        /// </example>
        [HttpPost]
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, string TeacherEmployeeNumber)
        {
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TeacherFname = TeacherFname;
            TeacherInfo.TeacherLname = TeacherLname;
            TeacherInfo.TeacherEmployeeNumber = TeacherEmployeeNumber;

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeacherInfo);


            return RedirectToAction("Show/" + id);
        }
    }
}