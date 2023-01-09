using BlazorWasmAuthenticationAndAuthorization.Server.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => 
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = true;
    //o.TokenValidationParameters = new TokenValidationParameters
    //{
    //    ValidateIssuerSigningKey = true,
    //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtAuthenticationManager.JWT_SECURITY_KEY)),
    //    ValidateIssuer = false,
    //    ValidateAudience = false
    //};
});
builder.Services.AddSingleton<UserAccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}
//using (new NetworkConnection("\\\\192.168.1.162\\Images\\Photos2", sourceCredentials))
//{
//    app.UseFileServer(new FileServerOptions()
//    {
//        FileProvider = new PhysicalFileProvider(
//            Path.Combine("\\\\192.168.1.162\\Images\\Photos2")),
//        RequestPath = new PathString("/Photos2"),
//        EnableDirectoryBrowsing = true
//    });

//}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();




//Please See This StackOverflow for network Connection 

//https://stackoverflow.com/questions/69952083/asp-net-core-blazor-images-files-on-network-share-work-for-1-minute-then-sto
