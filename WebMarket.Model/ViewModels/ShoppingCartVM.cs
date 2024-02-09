using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Models;

namespace WebMarket.Model.ViewModels
{
    public class ShoppingCartVM
    {
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
