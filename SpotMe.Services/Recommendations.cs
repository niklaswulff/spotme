using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMe.Services
{
    public class RecommendationsResponse
    {
        public List<Track> tracks { get; set; }

    }

    public class Track
    {
        public string id { get; set; }
        public string name { get; set; }
        public string href { get; set; }
        public List<Artist> artists { get; set; }
        public int duration_ms { get; set; }
        public ExternalUrls external_urls { get; set; }

        public string Duration => TimeSpan.FromMilliseconds(this.duration_ms).ToString(@"mm\:ss");
    }

}
