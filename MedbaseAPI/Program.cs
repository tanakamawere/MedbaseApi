using MedbaseAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//Setting up the database context
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultApiConnection"));
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Questions
//Get All Questions
app.MapGet("/questions", async (DataContext context) => await context.Questions.ToListAsync());
//Return questions on topic
app.MapGet("/questions/{topic}/{number}", async (DataContext context, int topic, int number) => await context.Questions.Where(x => x.TopicId == topic).OrderBy(p => Guid.NewGuid()).Take(number).ToListAsync());
//Return a single question
app.MapGet("/questions/select/{id}", async (DataContext context, int id) => await context.Questions.FindAsync(id));
//Return all questions on a given topic
app.MapGet("/questions/{topic}", async (DataContext context, int topic) => await context.Questions.Where(x => x.TopicId == topic).OrderBy(p => p.Id).ToListAsync());


//Articles
app.MapGet("/articles", async (DataContext context) => await context.Articles.ToListAsync());
app.MapGet("/articles/{id}", async (DataContext context, int id) => await context.Articles.FindAsync(id));
app.MapGet("/articles/select/{number}", async (DataContext context, int number) => await context.Articles.OrderByDescending(p => p.Id).Take(number).ToListAsync());

app.Run();