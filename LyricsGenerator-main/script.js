window.onload = function () {
    "use strict";

    if (window.location.search.length > 0) {
        // console.log("THIS WORKS");
        handleRedirect();
    }

    function handleRedirect() {
        let AccessToken = getAccessToken();
        // console.log(AccessToken, "Access Token");
        fetchToken(AccessToken);
        console.log(localStorage.getItem("AccessToken"));
        console.log(localStorage.getItem("RefreshToken"));
    }

    function getAccessToken() {
        let queryString = window.location.search;
        let urlParams = new URLSearchParams(queryString);
        let code = urlParams.get('code');

        return code;
    }

    let authorizeButton = document.getElementsByClassName("authorize");
    // let track = document.getElementsByClassName("track");
    let output = document.getElementsByClassName("output");
    let search = document.getElementById("search");
    let links = document.getElementsByClassName("link");


    function getInput() {
        let searchInput = document.getElementById("myInput");
        let value = searchInput.value;
        return value;
    }

    function updateButtons() {
        let links = document.getElementsByClassName("link");
        console.log(links);
        let array = [...links];
        console.log(array);
        array.forEach(element => {
            // console.log(element.children[0].href.substring(element.children[0].href.lastIndexOf('/')+1));
            console.log(element.children[1].id, "id");
            let trackID = element.id;
            element.children[1]
        });
    }
    // console.log(track[0]);

    if (authorizeButton[0]) {
        authorizeButton[0].addEventListener("click", authorize);
    }
    // if (track[0]) {
    //     track[0].addEventListener("click", function () {
    //         // getSongID();
    //         getSpotifyTrack("5kTn07V96U8LyoQgz6DZzX");
    //     });
    // }
    if (search) {
        search.addEventListener("click", function () {
            let value = getInput();
            searchSpotify(value);
            // updateButtons();
        });
    }



    // output[0].innerHTML = getSpotifyTrack();
    
    // console.log(getSpotifyTrack(), "Test");

    
}