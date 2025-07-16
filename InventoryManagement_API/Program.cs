using Inventory_LIB.Models;
using Inventory_LIB.Repositories.Base;
using Inventory_LIB.Repositories.Child;
using InventoryManagement_API.Security;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InventoryContext>();
builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<InventoryContext>();
// Add services to the container.
builder.Services.AddTransient<IUnitOFWork, UnitOfWork>();
builder.Services.AddTransient<InventoryContext>();
builder.Services.AddTransient<ITokenManager, TokenManager>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
