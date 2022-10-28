using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TodoAPIMediatr.Helpers;
using TodoAPIMediatr.Interfaces;
using TodoAPIMediatr.Repository;

var builder = WebApplication.CreateBuilder(args);

// adding MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoList") ?? throw new InvalidOperationException("Connection string 'TodoList' not found.")));
// builder.Services.AddTransient<IRepository, TodoItemRepository>();
// DI container
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IRepository, TodoItemRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();

builder.Services.AddEndpointsApiExplorer();

// options for documenting the object model and customizing the UI.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API with MediatR",
        Description = "An ASP.NET Core Web API for managing ToDo items",

    });
    // Set the comments path for the Swagger JSON and UI.
    // e.g. for POST metod: Creates a TodoItem
    // var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});

//builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
