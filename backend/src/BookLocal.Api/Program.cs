using BookLocal.Application.Businesses.Interfaces;
using BookLocal.Infrastructure.Businesses;
using BookLocal.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBusinessService, BusinessService>();


builder.Services.AddDbContext<BookLocalDbContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("BookLocal")
));


builder.Services.AddControllers();


var app = builder.Build();
app.MapControllers();

// app.UseHttpsRedirection();

app.Run();
