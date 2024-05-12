using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project.BL.Mappers.CartProductsm;
using Project.BL.Mappers.Carts;
using Project.BL.Mappers.Categories;
using Project.BL.Mappers.Images;
using Project.BL.Mappers.Mapper;
using Project.BL.Mappers.OrderItems;
using Project.BL.Mappers.Orders;
using Project.BL.Mappers.Products;
using Project.BL.Mappers.Users;
using Project.BL.Services.AuthService;
using Project.BL.Services.CartProductService;
using Project.BL.Services.CartService;
using Project.BL.Services.CategoryService;
using Project.BL.Services.OrderItemService;
using Project.BL.Services.OrderService;
using Project.BL.Services.ProductService;
using Project.BL.Services.UnitService;
using Project.DAL.Data;
using Project.DAL.Models;
using Project.DAL.Repositories.CartProduct;
using Project.DAL.Repositories.Carts;
using Project.DAL.Repositories.Categories;
using Project.DAL.Repositories.OrderItems;
using Project.DAL.Repositories.Orders;
using Project.DAL.Repositories.Products;
using Project.DAL.Repositories.Users;
using Project.DAL.UnitOfWork;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



// repository Services
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<ICartProductRepository, CartProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitRepository, UnitRepository>();
 


// mapper services
builder.Services.AddScoped<ICartProductMapper, CartProductMapper>();
builder.Services.AddScoped<ICartMapper, CartMapper>();
builder.Services.AddScoped<ICategoryMapper, CategoryMapper>();
builder.Services.AddScoped<IImageMapper, ImageMapper>();
builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<IOrderItemMapper, OrderItemMapper>();
builder.Services.AddScoped<IProductMapper, ProductMapper>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<IMapper, Mapper>();


// service services
builder.Services.AddScoped<ICartProductService, CartProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUnitService, UnitService>();


builder.Services.AddControllers();

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric=false;
    options.Password.RequireDigit=false;
    options.Password.RequireLowercase=false;
    options.Password.RequireUppercase=false;
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<APIContext>()
    .AddDefaultTokenProviders();


builder.Services.AddDbContext<APIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBSecretConnection")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "defaultSchema";
    options.DefaultChallengeScheme = "defaultSchema";
}).AddJwtBearer("defaultSchema", options =>
{
    var key = builder.Configuration.GetValue<string>("jwtSecretKey");
    var keyInBytes = Encoding.ASCII.GetBytes(key);
    var symmetricKey = new SymmetricSecurityKey(keyInBytes);

    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience=false,
        IssuerSigningKey = symmetricKey,
    };
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();