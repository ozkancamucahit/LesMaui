using MobilOyku.API.Library.DataAccess;
using MobilOyku.API.Library.Internal.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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
