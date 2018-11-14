﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JacobClient.Models
{
    public class Cart
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public bool IsControlEnabled { get; set; } = true;
    }
}