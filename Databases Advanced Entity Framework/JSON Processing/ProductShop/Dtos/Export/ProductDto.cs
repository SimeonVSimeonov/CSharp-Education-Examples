﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.Export
{
    public class ProductDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        //Seller.FirstName Seller.LastName
        [JsonProperty(PropertyName = "seller")]
        public string Seller { get; set; }
    }
}
