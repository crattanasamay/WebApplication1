﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Clients;
using WebApplication1.Models;
using WebApplication1.Models.JikanAnimeApi;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJikanApiClient _jikanClient;
        private readonly IMyAnimeClient _myAnimeClient;
        private readonly AnimeMasterData _animeMasterData;

        public HomeController(ILogger<HomeController> logger,IMyAnimeClient myAnimeClient,IJikanApiClient jikanClient) 
        {
            _animeMasterData = new  AnimeMasterData();
            _myAnimeClient = myAnimeClient;
           _jikanClient = jikanClient;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        [Route("HomePageCarouselPartial")]
        public async Task<IActionResult> HomePageCarouselPartial()
        {
            try
            {
                JikanSeasonModel jikanSeasonModel = await _jikanClient.GetAnimeBySeason(_animeMasterData.currentSeason.ToString(), _animeMasterData.currentYear.ToString());
                List<Datum> animeSeasonList = _jikanClient.FilterAnime(jikanSeasonModel);
                return PartialView("_HomePageCarouselPartial",animeSeasonList);

            }
            catch (Exception e)
            {

                // throw exception for error either API / or Post Connection
            }

            return View();
        }

        [HttpPost]
        [Route("HomePageAnimeSeasonBanner")]
        public IActionResult HomePageAnimeSeasonBanner()
        {
            try
            {
                return PartialView("_HomePageAnimeSeasonBanner", _animeMasterData);
            }
            catch (Exception e)
            {

            }
            return PartialView();

        }
        public void OnGet()
        {

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}