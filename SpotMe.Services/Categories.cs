using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMe.Services
{
    public class CategoriesResponse
    {
        public Categories categories { get; set; }
    }

    public class Categories
    {
        public string href { get; set; }
        public List<CategoryItem> items { get; set; }
    }

    public class CategoryItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public string href { get; set; }
        public List<Image> icons { get; set; }
    }
}
