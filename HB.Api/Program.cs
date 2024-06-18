using HB.Core.GuidFactory;
using HB.Core.MomentFactory;
using HB.Core.UseCases.Item.AddItemToShop;
using HB.Core.UseCases.Item.GetItems;
using HB.Core.UseCases.Shop.AddShop;
using HB.Core.UseCases.Shop.GetAllShop;
using HB.Core.UseCases.User.GetAllUsers;
using HB.Core.UseCases.User.RegisterUser;
using HB.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("postgres");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<HwContext>(options
    => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
builder.Services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
builder.Services.AddScoped<IMomentFactory, MomentFactory>();
builder.Services.AddScoped<IGuidFactory, GuidFactory>();
builder.Services.AddScoped<IAddItemToShopUseCase, AddItemToShopUseCase>();
builder.Services.AddScoped<IAddShopUseCase, AddShopUseCase>();
builder.Services.AddScoped<IGetAllShopsUseCase, GetAllShopsUseCase>();
builder.Services.AddScoped<IGetItemsUseCase, GetItemsUseCase>();
var app = builder.Build();

//app.Services.GetRequiredService<HwContext>().Database.Migrate();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
