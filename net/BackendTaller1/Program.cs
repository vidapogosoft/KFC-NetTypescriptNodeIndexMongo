using BackendTaller1.Interfaces;
using BackendTaller1.Services;

var builder = WebApplication.CreateBuilder(args);

string AllowOrigins = "appweb";

builder.Services.AddCors(options =>
{

    options.AddPolicy(name: AllowOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:52958/").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IOrders, SOrders>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
