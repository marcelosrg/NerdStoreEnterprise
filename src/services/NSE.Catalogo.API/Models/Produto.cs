﻿using NSE.Core.DomainObjects;

namespace NSE.Catalogo.API.Models
{
    public class Produto : Entity
    {
        public string Name { get; set; }

        public  string Descripition { get; set; }

        public bool Active { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Image { get; set; }

        public int StockQuantity { get; set; }

    }
}
