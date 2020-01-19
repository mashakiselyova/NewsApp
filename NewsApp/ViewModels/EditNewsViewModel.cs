﻿using Microsoft.AspNetCore.Mvc.Rendering;
using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.ViewModels
{
    public class EditNewsViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
    }
}
