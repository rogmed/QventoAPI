using QventoAPI;
using QventoAPI.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Vault
Vault.GetConnectionString();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Authorization for swagger in production
app.UseSwaggerAuthorized();

// Wrap this in app.Environment.IsDevelopment() if only for dev
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
