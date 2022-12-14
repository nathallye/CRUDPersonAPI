var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Data.Repository.Context.DatabaseContext>();

builder.Services.AddScoped<Data.Interface.IPersonRepository, Data.Repository.PersonRepository>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyRuleCors",
        policy =>
        {
            policy.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();

        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyRuleCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
