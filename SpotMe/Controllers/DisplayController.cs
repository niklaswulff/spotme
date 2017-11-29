using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpotMe.Services;

namespace SpotMe.Controllers
{
    public class DisplayController : Controller
    {
        private readonly ISpotifyService _spotifyService;

        public DisplayController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }


        [HttpPost]
        public ActionResult BySeeds(DisplayBySeedsViewModel displayByCategoryViewModel)
        {
            var recommendations = _spotifyService.GetRecommendations(displayByCategoryViewModel.SelectedGenre,
                displayByCategoryViewModel.Artist);

            return View("Index", new DisplayRecommendationsViewModel {Items = recommendations});
        }
        
    }

    public class DisplayRecommendationsViewModel
    {
        public List<Track> Items { get; set; }
    }

    public class DisplayBySeedsViewModel
    {
        public List<string> SelectedGenre { get; set; }
        public string Artist { get; set; }
    }
}
