﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppSQL.DataBaseItems
{
    public class CartItem
    {
        public FoodItems Product { get; set; }
        public int Quantity { get; set; }
    }
}
