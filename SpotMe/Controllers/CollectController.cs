using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpotMe.Web.Models;
using SpotMe.Services;


namespace SpotMe.Web.Controllers
{
    public class CollectController : Controller
    {
        private ISpotifyService _spotifyService;

        public CollectController(ISpotifyService spotifyService)
        {
            this._spotifyService = spotifyService;
        }

        // GET: Collect
        public ActionResult Index()
        {
            // Get new releases
            var albums = _spotifyService.GetNewReleases();

            // Get categories
            var categories = _spotifyService.GetCategories();
            var categorySelectItems = new List<SelectListItem>();

            foreach (var category in categories.items)
            {
                categorySelectItems.Add(new SelectListItem
                {
                    Value = category.id,
                    Text = category.name
                });
            }

            // Get genres
            var genres = _spotifyService.GetGenres();
            var genreSelectListItems = new List<SelectListItem>();

            foreach (var genre in genres)
            {
                genreSelectListItems.Add(new SelectListItem
                {
                    Value = genre,
                    Text = genre
                });
            }
            
            return View(new CollectViewModel
            {
                NewReleases = albums,
                Categories = categorySelectItems,
                Genres = genreSelectListItems
            });
        }

       
    }
}
