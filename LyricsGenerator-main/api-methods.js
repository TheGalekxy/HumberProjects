// Client ID : 15c9505af3c14c3181c558aa482d3a65
// Client Secret : 3eede4feb57b4701b168ddbc7ed7bd6d

// https://api.musixmatch.com/ws/1.1/
// http://api.musixmatch.com/ws/1.1/track.search?q_artist=justin bieber&page_size=3&page=1&s_track_rating=desc
// 859a318b4ae7b2bd0dc918bfd0b15c26

let redirect_uri = "http://localhost/api-final/index.php";
let uri = encodeURI(redirect_uri);
let client_id = "15c9505af3c14c3181c558aa482d3a65";
let encoded_id = btoa(client_id);
let client_secret = "3eede4feb57b4701b168ddbc7ed7bd6d";
let encoded_secret = btoa(client_secret);
let totalEncoded = btoa(client_id + ":" + client_secret);

function authorize() {
    let url = `https://accounts.spotify.com/authorize?client_id=${client_id}&response_type=code&redirect_uri=${uri}&show_dialog=false`
    window.location.href = url;
}

// https://stackoverflow.com/questions/35325370/how-do-i-post-a-x-www-form-urlencoded-request-using-fetch
function fetchToken(token) {

    fetch('https://accounts.spotify.com/api/token', {
        method: 'post',
        mode: 'cors',
        headers: {
            "Content-Type": 'application/x-www-form-urlencoded',
            "Authorization": `Basic ${totalEncoded}`
        },
        body: new URLSearchParams({
            "grant_type":'authorization_code',
            "code": `${token}`,
            "redirect_uri": `${uri}`
        })
    })
        .then(response => response.json())
        .then(function(data) {
            if (data.access_token) {
                localStorage.setItem("AccessToken", data.access_token);
                localStorage.setItem("RefreshToken", data.refresh_token);
            } else {
            }
            // return data.access_token;
        })
        // console.log(data);
}

function getSpotifyTrack(trackID) {
    fetch(`https://api.spotify.com/v1/tracks/${trackID}`, {
        method: 'get',
        mode: 'cors',
        headers: {
            "Authorization": `Bearer ${localStorage.getItem("AccessToken")}`
        }
    })
        .then(response => response.json())
        .then(function(data) {
            // console.log(data);
            let output = document.getElementsByClassName("output");
            output[0].innerHTML = data.name;

            
            let finalData = data
            return finalData;
        });
}

function searchSpotify(search) {
    fetch(`https://api.spotify.com/v1/search?q=${search}&type=track&market=US&limit=30&offset=5`, {
        method: 'get',
        mode: 'cors',
        headers: {
            "Authorization": `Bearer ${localStorage.getItem("AccessToken")}`
        }
    })
        .then(response => response.json())
        .then(function(data) {
            // console.log(data.tracks.items);
            let newTable = `<tr>
                                    <th>Song Name</th>
                                    <th>Song Artist</th>
                                    <th></th>
                                </tr>`;
            data.tracks.items.forEach(element => {
                // console.log("Song:", element.name, "Artist:", element.artists[0].name, "Song ID:", element.id);
                // console.log(element.artists[0].name);
                // console.log(element.id);
                let output = document.getElementsByClassName("output");
                newTable += `<tr>
                                    <td>${element.name}</td>
                                    <td>${element.artists[0].name}</td>
                                    <td>
                                        <form action="./lyrics.php" method="post">
                                            <input type="hidden" name="songid" value="${element.name}">
                                            <input type="hidden" name="artist" value="${element.artists[0].name}">
                                            <input type="submit" class="button" name="submit" value="This One!">
                                        </form>
                                    </td>
                                </tr>`
                output[0].innerHTML = newTable;
            });
        });
}

function getMusicMatchTrack(artist, song) {
    fetch(`https://cors-access-allow.herokuapp.com/http://api.musixmatch.com/ws/1.1/track.search?q_track=${song}&q_artist=${artist}&page_size=3&page=1&s_track_rating=desc&apikey=859a318b4ae7b2bd0dc918bfd0b15c26`, {
        method: 'get',
        mode: 'cors',
    })
        .then(response => response.json())
        .then(function(data) {
            // console.log(data.message.body.track_list[0].track.track_id);
            // console.log(artist, song);
            // console.log(data);
            getMusicMatchTrackLyrics(data.message.body.track_list[0].track.track_id);

        
        });
}

function getMusicMatchTrackLyrics(trackID) {
    fetch(`https://cors-access-allow.herokuapp.com/http://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id=${trackID}&apikey=859a318b4ae7b2bd0dc918bfd0b15c26`, {
        method: 'get',
        mode: 'cors',
    })
        .then(response => response.json())
        .then(function(data) {
            // console.log(data.message.body.lyrics.lyrics_body);
            // console.log(data);
            let output = document.getElementsByClassName("output");
            output[0].innerHTML = data.message.body.lyrics.lyrics_body;

        });
}
