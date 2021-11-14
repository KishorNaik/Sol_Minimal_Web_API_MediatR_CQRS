using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sol_Demo.Data;
using Sol_Demo.Features.Command;
using Sol_Demo.Features.Queries;
using Sol_Demo.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddSingleton<ToDoRepository>();

var app = builder.Build();

var baseUrl = "/api/todo";

app.MapPost($"{baseUrl}/add", async ([FromBody] AddToDoItemCommand addToDoItemCommand,
                    [FromServices] IMediator mediatR) =>
                    {
                        var result = await mediatR.Send<bool>(addToDoItemCommand);

                        return Results.Ok(result);
                    });

app.MapGet($"{baseUrl}/list", async ([FromServices] IMediator mediatR) =>
{
    var toDoList = await mediatR.Send<List<ToDoModel>>(new GetAllToDoListQuery());

    if (toDoList?.Count >= 1)
    {
        return Results.Ok(toDoList);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet($"{baseUrl}/" + "{id:int}", async (
    int id,
    [FromServices] IMediator mediatR) =>
  {
      var toDoItem = await mediatR.Send<ToDoModel>(new GetToDoItemByIdQuery(id));

      if (toDoItem != null)
      {
          return Results.Ok(toDoItem);
      }
      else
      {
          return Results.NotFound();
      }
  });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();