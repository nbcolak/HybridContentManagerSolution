using HybridContentManager.Contexts;
using HybridContentManager.Repos;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SqlDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));

builder.Services.AddSingleton<IMongoClient, MongoClient>(s =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDbCon")));
        
builder.Services.AddScoped<IMongoDatabase>(s =>
    s.GetService<IMongoClient>().GetDatabase("BookDb"));

//for sql server
//builder.Services.AddScoped<IBookRepository, SqlBookRepository>();  
//builder.Services.AddScoped<BookRepositoryAdapter>(); 

//for mongodb
builder.Services.AddScoped<IBookRepository, MongoBookRepository>();  
builder.Services.AddScoped<BookRepositoryAdapter>(); 

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

