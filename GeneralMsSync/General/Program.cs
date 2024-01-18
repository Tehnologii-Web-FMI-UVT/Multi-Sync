using ChurchManagementSystem.Jwt;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Setup Jwt auth
//JwtAuthHelper.SetupApplicationJwtAuthentication(builder.Configuration, builder.Services);

//Setup data layer
DataLayer.DependecyInjectionHelper.Setup(builder.Services);

//Setup utils
ChurchManagementSystem.Utils.DependencyInjectionHelper.Setup(builder.Services);

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
});

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "CMS API", Version = "v1" });
    });

    //Setup logging
    builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
    builder.Logging.AddConsole();
    builder.Logging.AddDebug();
}
else
{

}

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CMS API V1");
    });
}
else
{

}

app.UseStaticFiles();
//app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();

app.UseMvc(routes =>
{
    routes.MapRoute(
       name: "api",
       template: "/api/{controller}/{action}");

    routes.MapRoute(
        name: "default",
        template: "{*url}",
        defaults: new { controller = "App", action = "Index" });
});

app.Run();
