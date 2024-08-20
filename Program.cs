using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using JobWebApp.Data;


var builder = WebApplication.CreateBuilder(args);

//services propiedad del objeto WebApplicationBuilder 
builder.Services.AddDbContext<JobDbContext>(options =>

    options.UseMySql(
        //configuracion la cadena de conexion
        builder.Configuration.GetConnectionString("JobDbContext"),
        // llamamos a la clase que corresponde en este caso que es MySqlServerVersion y le pasamos la version
        new MySqlServerVersion(new Version(8, 0, 21)) 
    )
);

//utilizado porque estamos utilizando mvc
builder.Services.AddControllersWithViews();

// comprimimos a builder app que  y ejecutamos el build detro de la variable app
var app = builder.Build();




if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//corremos la app
app.Run();
