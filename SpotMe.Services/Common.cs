using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMe.Services
{
    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }

    public class AlbumsResponse
    {
        public string href { get; set; }
        public List<Item> items { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string album_type { get; set; }
        public string uri { get; set; }
        public string name { get; set; }
        public List<Artist> artists { get; set; }
        public List<Image> images { get; set; }
        public ExternalUrls external_urls { get; set; }
    }

    public class Image
    {
        public int? height { get; set; }
        public int? width { get; set; }
        public string url { get; set; }
    }

    public class Artist
    {
        public string id { get; set; }
        public string href { get; set; }
        public string name { get; set; }
    }

    public class ExternalUrls
    {
        public string spotify { get; set; }
    }
}
