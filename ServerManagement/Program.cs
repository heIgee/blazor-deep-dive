using Microsoft.EntityFrameworkCore;
using ServerManagement.Components;
using ServerManagement.Data;
using ServerManagement.Models;
using static System.Console;

namespace ServerManagement;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents(); /// 

        // sql server
        builder.Services.AddDbContextFactory<ServerManagementContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("ServerManagement"));
        });

        // repository
        builder.Services.AddTransient<IServerEFCoreRepository, ServerEFCoreRepository>();

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
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode(); ///

        app.Run();
    }
}
