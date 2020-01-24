using NewsApp.Models;
using System.Collections.Generic;

namespace NewsApp.ViewModels
{
    public class NewsViewModel
    {
        public List<Article> Articles { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
