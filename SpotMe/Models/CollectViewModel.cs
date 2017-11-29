using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpotMe.Services;

namespace SpotMe.Web.Models
{
    public class CollectViewModel
    {
        public LatestReleaseResponse NewReleases { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public string SelectedCategory { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; }
        public string SelectedGenre { get; set; }
    }
}