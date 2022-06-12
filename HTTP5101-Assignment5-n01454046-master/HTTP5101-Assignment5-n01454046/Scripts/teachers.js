// USING EXAMPLE CODE FROM CHRISTINES BLOG PROJECT

// AJAX for teacher update can go in here!
// This file is connected to the project via Shared/_Layout.cshtml


function UpdateTeacher(id) {

	//goal: send a request which looks like this:
	//POST : http://localhost:55077/api/TeacherData/UpdateTeacher;
    // POST : /Teacher/Update/{id}
	//with POST data of teachername, teacheremployeenumber, etc.

	console.log(id);

	var URL = "http://localhost:55077/Teacher/Update/" + id;

	console.log(URL);

	var rq = new XMLHttpRequest();
	// where is this request sent to?
	// is the method GET or POST?
	// what should we do with the response?

	// Selecting the values inputed into the form
	var TeacherFname = document.getElementById('TeacherFname').value;
	var TeacherLname = document.getElementById('TeacherLname').value;
	var TeacherEmployeeNumber = document.getElementById('TeacherEmployeeNumber').value;

	// Selecting the elements that the values are being put into
	var TeacherFnameElement = document.getElementById('TeacherFname');
	var TeacherLnameElement = document.getElementById('TeacherLname');
	var TeacherEmployeeNumberElement = document.getElementById('TeacherEmployeeNumber');

	var FnameBool = false;
	var LnameBool = false;
	var EmployeeNumberBool = false;

	// Checking if teacher first name is inputed
	if (TeacherFname === "" || TeacherFname === null) {
		TeacherFnameElement.style.background = "red";
		TeacherFnameElement.focus();
		console.log("Teacherfname");
		FnameBool = false;
		return false;
	} else {
		TeacherFnameElement.style.background = "";
		FnameBool = true;
    }

	// Checking to see if teacher last name is inputed
	if (TeacherLname === "" || TeacherLname === null) {
		TeacherLnameElement.style.background = "red";
		TeacherLnameElement.focus();
		console.log("TeacherLname");
		LnameBool = false;
		return false;
	} else {
		TeacherLnameElement.style.background = "";
		LnameBool = true;
    }

	// Checking to see if the teacher employee number is inputed
	if (TeacherEmployeeNumber === "" || TeacherEmployeeNumber === null) {
		TeacherEmployeeNumberElement.style.background = "red";
		TeacherEmployeeNumberElement.focus();
		console.log("EmployeeNumber");
		EmployeeNumberBool = false;
		return false;
	} else {
		TeacherEmployeeNumberElement.style.background = "";
		EmployeeNumberBool = true;
	}

	// If they're all inputed run the rest of the ajax
	if (FnameBool === true && LnameBool === true && EmployeeNumberBool === true) {

		console.log("ALL TRUE")

		var TeacherData = {
			"TeacherFname": TeacherFname,
			"TeacherLname": TeacherLname,
			"TeacherEmployeeNumber": TeacherEmployeeNumber,
		};




		rq.open("POST", URL, true);
		rq.setRequestHeader("Content-Type", "application/json");
		rq.onreadystatechange = function () {
			//ready state should be 4 AND status should be 200
			if (rq.readyState == 4 && rq.status == 200) {
				//request is successful and the request is finished

				//nothing to render, the method returns nothing.

			}

		}
		//POST information sent through the .send() method
		rq.send(JSON.stringify(TeacherData));



		// Being trying to get the page to redirect to the show view but it either doesn't redirect or it redirects but doesn't have the updated information yet because of the need for a hot reload...

		window.location.href = 'http://localhost:55077/Teacher/Show/' + id;
		// location.replace = 'http://localhost:55077/Teacher/Show/' + id;
		// window.location.replace = 'http://localhost:55077/Teacher/Show/' + id;
		// return View(SelectedTeacher);
	}
}
