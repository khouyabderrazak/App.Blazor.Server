using Gestion_Projet_App.Areas.Identity;
using Gestion_Projet_App.Data;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Entity;
using Gestion_Projet_App.Services;
using Gestion_Tache_App.Services;
using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Radzen;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Gestion_Projet_AppContextConnection") ?? throw new InvalidOperationException("Connection string 'Gestion_Projet_AppContextConnection' not found.");

builder.Services.AddDbContextFactory<Gestion_Projet_AppContext>(options => {
    options.UseSqlServer(connectionString);
  //  options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Gestion_Projet_AppContext>().AddDefaultTokenProviders(); 
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddRadzenComponents();
builder.Services.AddMatBlazor();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<ICollaborateurService,CollaborateurService>();
builder.Services.AddScoped<IProjetService,ProjetService>();
builder.Services.AddScoped<ITacheService,TacheService>();
builder.Services.AddScoped<ITacheCollaborateursService,TacheCollaborateursService>();
builder.Services.AddScoped<IClientService,ClientService>();
builder.Services.AddScoped<IEquipeService,EquipeService>();
builder.Services.AddScoped<IEquipeCollaborateurService,EquipeCollaborateurService>();
builder.Services.AddScoped<IAcceuilService,AcceuilService>();
builder.Services.AddSingleton<IEmailSender,EmailSender>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IProjetEquipeServie,ProjetEquipeServie>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddMatToaster(config =>
{
    config.Position = MatToastPosition.TopCenter;
    config.PreventDuplicates = true;
    config.NewestOnTop = true;
    config.ShowCloseButton = true;
    config.MaximumOpacity = 95;
    config.VisibleStateDuration = 3000;
});

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

app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
