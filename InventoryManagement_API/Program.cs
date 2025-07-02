using Inventory_LIB.Models;
using Inventory_LIB.Repositories.Base;
using Inventory_LIB.Repositories.Child;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InventoryContext>();
// Add services to the container.
builder.Services.AddTransient<IUnitOFWork, UnitOfWork>();
builder.Services.AddTransient<InventoryContext>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
