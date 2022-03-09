using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using spotifyapi.Models;
using spotifyapi.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace spotifyapi.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISpotifyAccountServices _spotifyAccountServices;
        private readonly IConfiguration _configuration;
        private readonly ISpotifyServices _spotifyServices;
       

        public HomeController(
            ISpotifyAccountServices spotifyAccountServices,
            IConfiguration configuration,
            ISpotifyServices spotifyServices)
        {
            _spotifyAccountServices = spotifyAccountServices;
            _configuration = configuration;
            _spotifyServices = spotifyServices;
        }

        public async Task<ActionResult> Index(string searchString)
        {
            var newReleases = await GetReleases();
            return View(newReleases);

            //var results = from r in newReleases
            //              select r;
            //ViewBag.value = 0;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    ViewBag.value = 1;
            //    return results.Where(s => s.Name!.Contains(searchString));
            //}


            //return Enumerable.Empty<Release>();
            ////    results = results.Where(s => s.Name!.Contains(searchString));
            ////}
            //return View();
            //return View(await results.To);

        }
        public async Task<IEnumerable<Release>> Test(string searchString)
        {
            var newReleases = await GetReleases();

            var results = from r in newReleases
                          select r;
           
                ViewBag.value = 0;
                if (!String.IsNullOrEmpty(searchString))
                {
                    ViewBag.value = 1;
                    return results.Where(s => s.Name!.Contains(searchString));
                }
             //Debug.Write(ex);
                return Enumerable.Empty<Release>();
           
            //    results = results.Where(s => s.Name!.Contains(searchString));
            //}
            //return View();
            //return View(await results.To);
            //// return View(newReleases);
        }

        private async Task<IEnumerable<Release>> GetReleases()
        {
            try
            {
                var token = await _spotifyAccountServices.GetToken(
                    _configuration["Spotify:ClientId"],
                    _configuration["Spotify:ClientSecret"]);

                var newReleases = await _spotifyServices.GetNewReleases("US", 20, token);

                return newReleases;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<Release>();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
