//#### ASSIGNMENT 5 - STORE HOURS ####

window.onload = function () {
    
    // Selecting the area on the page to input the data from the txt file
    let showData = document.getElementById("schedTbl");
    
    //Selecting the radio buttons and giving them onclick functions to run.
    document.getElementById("routeRb1").onclick = getTextFile1;
    document.getElementById("routeRb2").onclick = getTextFile2;
    document.getElementById("routeRb3").onclick = getTextFile3;

    function getTextFile1() {

        // Creating a new request object
        let xhr = new XMLHttpRequest();

        // Setting a function to fire when the ready state changes
        xhr.onreadystatechange = function() {
            // Checking to make sure the file is retrieved
            if (xhr.readyState === 4) {
                // Making sure the file retrieved is valid
                if (xhr.status === 200) {
                    showData.innerHTML = xhr.responseText;
                } else {
                    // Returning an alert and console log if there is an error
                    alert("Connection was unsuccessful");
                    console.log(xhr.status);
                }
            }
        }

        // Opening a connection the the server with a get method, file that we are retrieving, and making it synchronous.
        xhr.open("GET", "sched1.txt", true);

        // Sending the request to the server with a null value because we are not sending any file. 
        xhr.send(null);
    }

    function getTextFile2() {

        // Creating a new request object
        let xhr = new XMLHttpRequest();

        // Setting a function to fire when the ready state changes
        xhr.onreadystatechange = function() {
            // Checking to make sure the file is retrieved
            if (xhr.readyState === 4) {
                // Making sure the file retrieved is valid
                if (xhr.status === 200) {
                    showData.innerHTML = xhr.responseText;
                } else {
                    // Returning an alert and console log if there is an error
                    alert("Connection was unsuccessful");
                    console.log(xhr.status);
                }
            }
        }

        // Opening a connection the the server with a get method, file that we are retrieving, and making it synchronous.
        xhr.open("GET", "sched2.txt", true);

        // Sending the request to the server with a null value because we are not sending any file. 
        xhr.send(null);
    }

    function getTextFile3() {

        // Creating a new request object
        let xhr = new XMLHttpRequest();

        // Setting a function to fire when the ready state changes
        xhr.onreadystatechange = function() {
            // Checking to make sure the file is retrieved
            if (xhr.readyState === 4) {
                // Making sure the file retrieved is valid
                if (xhr.status === 200) {
                    showData.innerHTML = xhr.responseText;
                } else {
                    // Returning an alert and console log if there is an error
                    alert("Connection was unsuccessful");
                    console.log(xhr.status);
                }
            }
        }

        // Opening a connection the the server with a get method, file that we are retrieving, and making it synchronous.
        xhr.open("GET", "sched3.txt", true);

        // Sending the request to the server with a null value because we are not sending any file. 
        xhr.send(null);
    }

}
