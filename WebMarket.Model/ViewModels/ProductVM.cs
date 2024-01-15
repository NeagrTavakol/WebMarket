﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMarket.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> CoverTypeList { get;set; }
    }
}
