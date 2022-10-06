using Microsoft.Extensions.Configuration;
using System.Data.Common;
using Todo_App.Repository;
using Volo.Abp.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages().Services.AddSingleton<ITaskRepo, TaskRepo>().AddMvc();

//).AddMvc().AddRazorPagesOptions(options => {
//      options.RootDirectory = "/Privacy",{ ""};
//  });


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
