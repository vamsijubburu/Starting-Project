using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InvokeWebAPIEF.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InvokeWebAPIEFContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InvokeWebAPIEFContext")));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
