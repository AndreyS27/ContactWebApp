using Api.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<ContactStorage>();

builder.Services.AddCors(opt =>
opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000");
    })
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();
