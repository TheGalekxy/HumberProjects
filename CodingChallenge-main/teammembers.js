window.onload = (event) => {

    getEmployees();

    function getEmployees() {
        fetch(`http://sandbox.bittsdevelopment.com/code1/fetchemployees.php `)
            .then(response => response.json())
            .then(function(data) {
                // console.log(data);
                // for each key/value pair in data
                for (const key in data) {
                    // if the data object has the key property
                    if (Object.hasOwnProperty.call(data, key)) {
                        
                        //do this
                        let element = data[key];
                        let employeeId = element["employeeid"];
                        let firstName = element["employeefname"];
                        let lastName = element["employeelname"];
                        let bio = element["employeebio"];
                        let featured = element["employeeisfeatured"];
                        let roles = element["roles"];
                        let hasPicture = element["employeehaspic"];
                        console.log(element);
                        
                        // create an employee card with the retrieved information
                        createEmployeeCard(employeeId, firstName, lastName, bio, featured, roles, hasPicture);
                    };
                };
            });
    };

    function createEmployeeCard(employeeId, firstName, lastName, employeeBio, isfeatured, roles, hasPicture) {
        // creating the card element
        let card = document.createElement("div");
        card.classList.add("card");

        // creating the image element
        let image = document.createElement("img");
        // if the employee has an image, get their image from the api
        if (hasPicture === "1") {
            image.src = `http://sandbox.bittsdevelopment.com/code1/employeepics/${employeeId}.jpg`;
        } else {
            // otherwise, use this picture
            image.src = `https://www.freeiconspng.com/thumbs/person-icon/clipart--person-icon--cliparts-15.png`;
        }
        image.alt = `Picture of ${firstName} ${lastName}`;

        // creating the span element which holds the "featured" icon
        let featured = document.createElement("span");
        featured.classList.add("featured");
        featured.innerHTML = "&#128081;";

        // creating the container element which will hold the employees title, bio, and associated tags
        let container = document.createElement("div");
        container.classList.add("container");

        // creating the title element
        let title = document.createElement("h4");
        title.innerHTML = `${firstName} ${lastName}`;

        // creating the bio element
        let bio = document.createElement("p");
        bio.innerHTML = `${employeeBio}`;

        // creating the tags element
        let tags = document.createElement("div");
        tags.classList.add("tags");
        for (const key in roles) {
            if (Object.hasOwnProperty.call(roles, key)) {
                const element = roles[key];
                // console.log(element, "role");
                let p = document.createElement("p");
                p.classList.add(`color${element["roleid"]}`);
                p.innerHTML = `${element["rolename"]}`;

                // change the background color of the p element to be equal to the colour provided by the api
                p.style.backgroundColor =`${element["rolecolor"]}`;

                // if the background color is too light, change the text color to black
                if (element["roleid"] === "3" || `${element["roleid"]}` === "2") {
                    p.style.color =`black`;
                };
                tags.appendChild(p);
                // tags.innerHTML += `<p classname="color${element["roleid"]}">${element["rolename"]}</p>`;
            };
        };

        // adding the title, bio, and tags to the container div that holds them
        container.appendChild(title);
        container.appendChild(bio);
        container.appendChild(tags);

        // adding the image, featured span, and container div to the card.
        card.appendChild(image);
        // if employee is featured append the feature icon
        if (isfeatured === "1") {
            card.appendChild(featured);
        }
        card.appendChild(container);

        // selecting the cardContainer in the html and adding the card to it
        let cardContainer = document.getElementById("cardContainer")
        cardContainer.appendChild(card);

    };
};
