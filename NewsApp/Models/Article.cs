using System;
using System.Collections.Generic;

namespace NewsApp.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string Preview { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }

        public void SetPreview()
        {
            Preview = Text.Substring(0, 200);
        }
    }
}
