using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers();

builder.Services.AddSwaggerDocument(config =>
{
	config.PostProcess = (doc =>
	{
		doc.Info.Title = "All Hotels Api";
		doc.Info.Version = "1.0.13";
	});
});

builder.Services.AddSingleton<IHotelService,HotelManager>();
builder.Services.AddSingleton<IHotelRepository,HotelRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}
app.UseOpenApi();

app.UseSwaggerUi3();

app.MapControllers();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
