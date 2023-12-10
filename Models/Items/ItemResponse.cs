﻿using CoffeeShop2.Contracts;

namespace CoffeeShop2.Models.Items
{
    public class ItemResponse : IResponse
    {
        public string? Id { get; set; } = default;
        public string itemCode { get; set; } = default!;
        public string? Name { get; set; } = default;
        public string? Description { get; set; } = default;
        public string? size { get; set; } = default;
    }
}
