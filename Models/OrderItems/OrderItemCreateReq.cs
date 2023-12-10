﻿using CoffeeShop2.Contracts;

namespace CoffeeShop2.Models.OrderItems
{
    public class OrderItemCreateReq : ICreateRep
    {
        public string orderItemKey { get; set; } = default!;
        public int quantity { get; set; } = default;
        public string orderId { get; set; } = default!; // foreign key
        public string itemId { get; set; } = default!; // foreign key
    }
}
