/* LAB 8 - SHIPPING FORM */
//Order Shipping object (for extra EXTRA challenge)
var shipInfo = {
	cid: 0,
	name: "",
	pc: "",
	speed: "",
	cost: 0
};

window.onload = function() {
	// Selecting the whole form element
	var formHandle = document.forms.form_ship;
	// selecting the thank you message
	var thankYou = document.getElementById("thanks_msg");
	// Selecting the selection box
	var selectBox = formHandle.f_speed;

	// Adding a function to the form to activate when it is submitted
	formHandle.onsubmit = processForm;

	// Adding a function to the select box when the value is changed
	selectBox.onchange = selectValue;

	function selectValue() {

			// Retreiving the # value and text content of the selectbox selection
			var deliveryValue = selectBox.value;
			var deliveryFull = selectBox.options[selectBox.selectedIndex].text;

			// Setting the values in the object to be those equal to the ones retrieved from the select box
			shipInfo.speed = deliveryFull;
			shipInfo.cost = deliveryValue;
	
			// Selecting the span for the delivery type and changing the innerhtml to be equal to the speed property in the shipinfo object
			var speedSpan = document.getElementById("thanksSpeed");
			speedSpan.innerHTML = shipInfo.speed;
			// Selecting the span for the delivery cost and changing the innerhtml to be equal to the cost property in the shipinfo object
			var costSpan = document.getElementById("thanksCost");
			costSpan.innerHTML = shipInfo.cost;
		}

	function processForm(){
		
		// Selecting elements in the form
		var nameElement = formHandle.f_Name;
		var customerElement = formHandle.f_Id;
		var postalElement = formHandle.f_pc;

		// Retrieving the value of the elements of the form
		var nameValue = formHandle.f_Name.value;
		var customerValue = formHandle.f_Id.value;
		var postalValue = formHandle.f_pc.value;
	
		// Setting the shipInfo object properties to be equal to the value of the elements in the form
		shipInfo.cid = customerValue;
		shipInfo.name = nameValue;
		shipInfo.pc = postalValue;
		console.log(shipInfo, "Object");

		// setting the deliveryValue to be equal to the selection in the selectbox
		var deliveryValue = selectBox.value;
		
		// Checking to see if the checkbox value is 0
		if(deliveryValue == 0){ 
			// if it is, change the background of the checkbox to red
			selectBox.style.background = "red";
			// And move the mouse to the checkbox
			selectBox.focus();
			// And prevent the form from being submitted
			return false;
		}

		// Check to see if a name has been inputed
		if(nameValue === "" || nameValue === null){ 
			nameElement.style.background = "red";
			nameElement.focus();
			return false;
		}

		// Check to see if a the customer id has been inputed
		if(customerValue === "" || customerValue === null){ 
			customerElement.style.background = "red";
			customerElement.focus();
			return false;
		}

		// Check to see if the postal code has been inputed
		if(postalValue === "" || postalValue === null){ 
			postalElement.style.background = "red";
			postalElement.focus();
			return false;
		}

		// If all the checks pass, hide the form
		formHandle.style.display = "none";
		// and display the thank you message
		thankYou.style.display = "block";

		// Select elements from the thank you message and see their innerhtml to be equal to the values set in the shipinfo object
		var customerSpan = document.getElementById("thanksCustomer");
		customerSpan.innerHTML = `${shipInfo.name} (Customer # ${shipInfo.cid})`;
		var postalSpan = document.getElementById("thanksPC");
		postalSpan.innerHTML = shipInfo.pc;


		
		return false;
	}

	
}