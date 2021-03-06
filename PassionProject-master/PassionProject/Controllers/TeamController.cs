using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PassionProject.Models;
using PassionProject.Models.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace PassionProject.Controllers
{
    public class TeamController : Controller
    {

        //Http Client is the proper way to connect to a webapi
        //https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-5.0

        private JavaScriptSerializer jss = new JavaScriptSerializer();
        private static readonly HttpClient client;

        static TeamController()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };
            client = new HttpClient(handler);
            //change this to match your own local port number
            client.BaseAddress = new Uri("https://localhost:44325/api/");
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));


            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);

        }

        // GET: Team/List
        public ActionResult List()
        {
            string url = "teamsdata/getteams";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<TeamDto> SelectedTeams = response.Content.ReadAsAsync<IEnumerable<TeamDto>>().Result;
                return View(SelectedTeams);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Team/Details/5
        public ActionResult Details(int id)
        {
            ShowTeam ViewModel = new ShowTeam();
            string url = "teamsdata/findteam/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            //Can catch the status code (200 OK, 301 REDIRECT), etc.
            //Debug.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                //Put data into Team data transfer object
                TeamDto SelectedTeam = response.Content.ReadAsAsync<TeamDto>().Result;
                ViewModel.team = SelectedTeam;

                //We don't need to throw any errors if this is null
                //A team not having any players is not an issue.
                url = "teamsdata/getplayersforteam/" + id;
                response = client.GetAsync(url).Result;
                //Can catch the status code (200 OK, 301 REDIRECT), etc.
                //Debug.WriteLine(response.StatusCode);
                IEnumerable<PlayerDto> SelectedPlayers = response.Content.ReadAsAsync<IEnumerable<PlayerDto>>().Result;
                ViewModel.teamplayers = SelectedPlayers;

                return View(ViewModel);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(Team TeamInfo)
        {
            Debug.WriteLine(TeamInfo.TeamName);
            string url = "Teamsdata/addTeam";
            Debug.WriteLine(jss.Serialize(TeamInfo));
            HttpContent content = new StringContent(jss.Serialize(TeamInfo));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {

                int Teamid = response.Content.ReadAsAsync<int>().Result;
                return RedirectToAction("Details", new { id = Teamid });
            }
            else
            {
                return RedirectToAction("Error");
            }


        }



        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            UpdateTeam ViewModel = new UpdateTeam();

            string url = "teamsdata/findteam/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            //Can catch the status code (200 OK, 301 REDIRECT), etc.
            //Debug.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                //Put data into Sponsor data transfer object
                TeamDto SelectedTeam = response.Content.ReadAsAsync<TeamDto>().Result;
                ViewModel.team = SelectedTeam;

                //find teams that are sponsored by this sponsor
                url = "teamsdata/GetPlayersForTeam/" + id;
                response = client.GetAsync(url).Result;

                //Put data into Sponsor data transfer object
                IEnumerable<PlayerDto> SelectedPlayers = response.Content.ReadAsAsync<IEnumerable<PlayerDto>>().Result;
                ViewModel.allplayers = SelectedPlayers;

                return View(ViewModel);
            }
            else
            {
                return RedirectToAction("Error");

            }
        }


        // POST: Team/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(int id, Team TeamInfo)
        {
            Debug.WriteLine(TeamInfo.TeamName);
            string url = "teamsdata/updateteam/" + id;
            Debug.WriteLine(jss.Serialize(TeamInfo));
            HttpContent content = new StringContent(jss.Serialize(TeamInfo));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { id = id });
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Team/Delete/5
        [HttpGet]
        public ActionResult DeleteConfirm(int id)
        {
            string url = "teamsdata/findteam/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            //Can catch the status code (200 OK, 301 REDIRECT), etc.
            //Debug.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                //Put data into Team data transfer object
                TeamDto SelectedTeam = response.Content.ReadAsAsync<TeamDto>().Result;
                return View(SelectedTeam);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Team/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Delete(int id)
        {
            string url = "teamsdata/deleteteam/" + id;
            //post body is empty
            HttpContent content = new StringContent("");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            //Can catch the status code (200 OK, 301 REDIRECT), etc.
            //Debug.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}