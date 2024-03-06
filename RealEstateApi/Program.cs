using RealEstate.Business.Abstract;
using RealEstate.Business.Concrete;
using RealEstate.Data.Abstract;
using RealEstate.Data.Concrete.DapperContext;
using RealEstate.Data.IRepositroy;
using RealEstate.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();

builder.Services.AddTransient(typeof(IDapperRepository<>), typeof(DapperRepository<>));
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryDal, DpCategoryDal>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductDal, DpProductDal>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
