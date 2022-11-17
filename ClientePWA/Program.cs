var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/Home/Login", "");
});
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapRazorPages());
app.UseHttpsRedirection();
app.Run();
