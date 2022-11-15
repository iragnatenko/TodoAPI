using BlazorAppTodoAPI.Interfaces;
using BlazorAppTodoAPI.Models;
using BlazorAppTodoAPI.Services;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<DatabaseContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoList") ?? throw new InvalidOperationException("Connection string 'TodoList' not found.")));

var todoServiceConfigSection = builder.Configuration.GetSection(nameof(TodoItemServiceConfig));
var todoServiceConfig = todoServiceConfigSection.Get<TodoItemServiceConfig>();
builder.Services.AddSingleton(todoServiceConfig);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ITodoItemService, TodoItemService>();

builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
