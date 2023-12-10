﻿using CoffeeShop2.Contracts;

namespace CoffeeShop2.Models.OrderItems
{
    public class OrderItemUpdateReq : IUpdateRep
    {
        public string Id { get; set; } = default!;
        public string orderItemKey { get; set; } = default!;
        public int quantity { get; set; } = default;
        public string orderId { get; set; } = default!;  // foreign key
        public string itemId { get; set; } = default!;   // foreign key
    }
}
