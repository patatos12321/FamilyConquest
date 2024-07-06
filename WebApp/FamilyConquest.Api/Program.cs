using FamilyConquest.Common.Models;
using FamilyConquest.Common.Repositories;
using LiteDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions((jo) => { jo.JsonSerializerOptions.IncludeFields = true; });
builder.Services.AddSingleton(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddSingleton(sp => new LiteDatabase(sp.GetRequiredService<IConfiguration>()["DatabasePath"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Migrate(app);

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

static void Migrate(WebApplication app)
{
    var playerRepo = app.Services.GetRequiredService<IRepository<Player>>();
    if (!playerRepo.GetAll().Any(p => p.IsBot))
    {
        playerRepo.Save(new Player() { IsBot = true, Username = "Jean-Jacques", HashedPassword = Guid.NewGuid().ToString() });
    }
}