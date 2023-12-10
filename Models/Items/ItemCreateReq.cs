using CoffeeShop2.Contracts;

namespace CoffeeShop2.Models.Items
{
    public class ItemCreateReq : ICreateRep
    {
        public string itemKey { get; set; } = default!;
        public string? Name { get; set; } = default;
        public string? Description { get; set; } = default;
        public string? size { get; set; } = default;
    }
}
