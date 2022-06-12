

function AddTeacher() {

    let teacherFname = document.getElementById('TeacherFname').value;
    let teacherLname = document.getElementById('TeacherLname').value;
    let TeacherEmployeeNumber = document.getElementById('TeacherEmployeeNumber').value

    let NewTeacher = {
        TeacherFname: teacherFname,
        TeacherLname: teacherLname,
        TeacherEmployeeNumber: TeacherEmployeeNumber
    }

    console.log(teacherFname, teacherLname, TeacherEmployeeNumber);
    console.log(NewTeacher);

    // Goal: send a request which looks like this:
    // https://localhost:44315/Teacher/Create

    // let URL = `https://localhost:44315/api/TeacherData/AddTeacher/${Teacher}`;
    let URL2 = `https://localhost:44315/Teacher/Create/${teacherFname}/${teacherLname}/${TeacherEmployeeNumber}`;
    let URL3 = `https://localhost:44315/api/TeacherData/AddTeacher/${NewTeacher}`;

    let request = new XMLHttpRequest();

    // Where is this request sent to?
    // Is the method GET or POST?
    // What should we do with the response?

    request.onreadystatechange = function() {
        // ready state should be 4 AND // Status should be 200
        if (request.readyState == 4 && request.status == 200) {
            // request is successful and the request is finished

            let teacherInfo = JSON.parse(request.responseText);

            console.log(teacherInfo, "teacherinfo");

        }
        request.readyState;
        request.status;
    }

    request.open("POST", URL2);
    request.send();
}


function DeleteTeacher() {

    let teacherId = document.getElementById('TeacherId').value;

    console.log(teacherId);

    // Goal: send a request which looks like this:
    // https://localhost:44315/api/TeacherData/DeleteTeacher/3


    let URL = `https://localhost:44315/api/TeacherData/DeleteTeacher/${teacherId}`;

    let request = new XMLHttpRequest();

    // Where is this request sent to?
    // Is the method GET or POST?
    // What should we do with the response?

    request.onreadystatechange = function() {
        // ready state should be 4 AND // Status should be 200
        if (request.readyState == 4 && request.status == 200) {
            // request is successful and the request is finished

            let teacherInfo = JSON.parse(request.responseText);

            console.log(teacherInfo, "teacherinfo");
            
        }
        request.readyState;
        request.status;
    }

    request.open("POST", URL);
    request.send();
}