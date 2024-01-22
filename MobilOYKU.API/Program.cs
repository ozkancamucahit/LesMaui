using MobilOyku.API.Library.DataAccess;
using MobilOyku.API.Library.Internal.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.WebHost.UseUrls("http://192.168.1.90:5124", "http://localhost:5124");

builder.Services
	.AddTransient<ISQLDataAccess, SQLDataAccess>()
	.AddTransient<IUserData, UserData>()
	.AddTransient<IMemoData, MemoData>()
	.AddTransient<IPhotoData, PhotoData>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
