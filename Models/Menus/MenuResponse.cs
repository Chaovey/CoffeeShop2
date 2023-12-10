using CoffeeShop2.Contracts;
namespace CoffeeShop2.Models.Menus
{
    public class MenuResponse : IResponse
    {
        public string? Id { get; set; } = default;
        public string menuCode { get; set; } = default!;
        public string? Name { get; set; } = default;
        public string? Description { get; set; } = default;
        public double Price { get; set; } = default;
    }
}
