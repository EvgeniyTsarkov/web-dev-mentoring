﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Localization;
using NorthwindWebsite.Core.ApplicationSettings;

namespace NorthwindWebsite.Configuration;

public static class MiddlewareConfiguration
{
    public static void AddMiddlewareConfiguration(
        this WebApplication app, AppSettings appSettings, Serilog.ILogger logger)
    {
        //Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.ConfigureErrorHandling(logger);

            // The default HSTS value is 30 days. You may want to change this for production scenarios,
            // see https://aka.ms/aspnetcore-hsts.

            app.UseHsts();
        }
        else
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(appSettings.Localization.Default)
        });

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    }
}
