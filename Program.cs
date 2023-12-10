using CoffeeShop2.Contracts;
using CoffeeShop2.Models.Customers;
using CoffeeShop2.Models.Items;
using CoffeeShop2.Models.Menus;
using CoffeeShop2.Models.OrderItems;
using CoffeeShop2.Models.Orders;
using CoffeeShop2.Models.Payments;
using CoffeeShop2.Repo;
using CoffeeShop2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IDbContext, SqlContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sqlserver"));
});
builder.Services.AddTransient<IMenuRepo, MenuRepo>();
builder.Services.AddTransient<IMenuServer,MenuService>();
builder.Services.AddTransient<ICustomerRepo, CustomerRepo>();
builder.Services.AddTransient<ICustomerServer, CustomerServer>();
builder.Services.AddTransient<IOrderRepo,OrderRepo>();
builder.Services.AddTransient<IOrderServer,OrderServices>();
builder.Services.AddTransient<IPaymentRepo, PaymentRepo>();
builder.Services.AddTransient<IPaymentServer, PaymentServices>();
builder.Services.AddTransient<IItemRepo, ItemRepo>();
builder.Services.AddTransient<IItemServer, ItemServices>();
builder.Services.AddTransient<IOrderItemRepo, OrderItemRepo>();
builder.Services.AddTransient<IOrderItemServer, OrderItemServices>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
MapMenuEndpoints(app, "tbmenu");
MapCustomerEndpoints(app, "tbcustomer");
MapOrderEndpoints(app, "tborder");
MapPaymentEndpoints(app, "tbpayment");
MapItemEndpoints(app, "tbitem");
MapOrderItemEndpoints(app, "tborderitem");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
void MapMenuEndpoints(WebApplication app, string tag)
{
    app.MapPost("api/menu", (IMenuServer service, MenuCreateReq req) =>
    { return service.Create(req); }).WithTags(tag);
    app.MapGet("api/menu", (IMenuServer service) =>
    { return service.GetAll(); }).WithTags(tag);
    app.MapGet("api/menu/{key}", (IMenuServer service, string key) =>
    { return service.Read(key); }).WithTags(tag);
    app.MapPut("api/menu", (IMenuServer service, MenuUpdateReq req) =>
    { return service.Update(req); }).WithTags(tag);
    app.MapDelete("api/menu/{key}", (IMenuServer service, string key) =>
    { return service.Delete(key); }).WithTags(tag);
}
void MapCustomerEndpoints(WebApplication app, string tag)
{
    app.MapPost("api/customer", (ICustomerServer service, CustomerCreateReq req) =>
    { return service.Create(req); }).WithTags(tag);
    app.MapGet("api/customer", (ICustomerServer service) =>
    { return service.GetAll(); }).WithTags(tag);
    app.MapGet("api/customer/{key}", (ICustomerServer service, string key) =>
    { return service.Read(key); }).WithTags(tag);
    app.MapPut("api/customer", (ICustomerServer service, CustomerUpdateReq req) =>
    { return service.Update(req); }).WithTags(tag);
    app.MapDelete("api/customer/{key}", (ICustomerServer service, string key) =>
    { return service.Delete(key); }).WithTags(tag);
}
void MapOrderEndpoints(WebApplication app, string tag)
{
    app.MapPost("api/order", (IOrderServer service, OrderCreateReq req) =>
    { return service.Create(req); }).WithTags(tag);
    app.MapGet("api/order", (IOrderServer service) =>
    { return service.GetAll(); }).WithTags(tag);
    app.MapGet("api/order/{key}", (IOrderServer service, string key) =>
    { return service.Read(key); }).WithTags(tag);
    app.MapPut("api/order", (IOrderServer service, OrderUpdateReq req) =>
    { return service.Update(req); }).WithTags(tag);
    app.MapDelete("api/order/{key}", (IOrderServer service, string key) =>
    { return service.Delete(key); }).WithTags(tag);
}
void MapPaymentEndpoints(WebApplication app, string tag)
{
    app.MapPost("api/payment", (IPaymentServer service, PaymentCreateReq req) =>
    { return service.Create(req); }).WithTags(tag);
    app.MapGet("api/payment", (IPaymentServer service) =>
    { return service.GetAll(); }).WithTags(tag);
    app.MapGet("api/payment/{key}", (IPaymentServer service, string key) =>
    { return service.Read(key); }).WithTags(tag);
    app.MapPut("api/payment", (IPaymentServer service, PaymentUpdateReq req) =>
    { return service.Update(req); }).WithTags(tag);
    app.MapDelete("api/payment/{key}", (IPaymentServer service, string key) =>
    { return service.Delete(key); }).WithTags(tag);
}
void MapItemEndpoints(WebApplication app, string tag)
{
    app.MapPost("api/item", (IItemServer service, ItemCreateReq req) =>
    { return service.Create(req); }).WithTags(tag);
    app.MapGet("api/item", (IItemServer service) =>
    { return service.GetAll(); }).WithTags(tag);
    app.MapGet("api/item/{key}", (IItemServer service, string key) =>
    { return service.Read(key); }).WithTags(tag);
    app.MapPut("api/item", (IItemServer service, ItemUpdateReq req) =>
    { return service.Update(req); }).WithTags(tag);
    app.MapDelete("api/item/{key}", (IItemServer service, string key) =>
    { return service.Delete(key); }).WithTags(tag);
}
void MapOrderItemEndpoints(WebApplication app, string tag)
{
    app.MapPost("api/orderitem", (IOrderItemServer service, OrderItemCreateReq req) =>
    { return service.Create(req); }).WithTags(tag);
    app.MapGet("api/orderitem", (IOrderItemServer service) =>
    { return service.GetAll(); }).WithTags(tag);
    app.MapGet("api/orderitem/{key}", (IOrderItemServer service, string key) =>
    { return service.Read(key); }).WithTags(tag);
    app.MapPut("api/orderitem", (IOrderItemServer service, OrderItemUpdateReq req) =>
    { return service.Update(req); }).WithTags(tag);
    app.MapDelete("api/orderitem/{key}", (IOrderItemServer service, string key) =>
    { return service.Delete(key); }).WithTags(tag);
}