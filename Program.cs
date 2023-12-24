using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Task_15.Models.Context;
using Task_15.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Task_15DbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"));
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
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/pricing/delete/{id}",
    defaults: new { controller = "Pricing", action = "Delete" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/pricing/update/{id}",
    defaults: new { controller = "Pricing", action = "Update" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/pricing/create",
    defaults: new { controller = "Pricing", action = "Create" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/pricing",
    defaults: new { controller = "Pricing", action = "Index" });
//contact info
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/contactinfo/delete/{id}",
    defaults: new { controller = "Contact", action = "DeleteContact" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/contactinfo/update/{id}",
    defaults: new { controller = "Contact", action = "UpdateContact" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/contactinfo/create",
    defaults: new { controller = "Contact", action = "CreateContact" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/contactinfo",
    defaults: new { controller = "Contact", action = "Index" });
//contact

app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/contact/delete/{id}",
    defaults: new { controller = "Contact", action = "DeleteContact" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/contact/update/{id}",
    defaults: new { controller = "Contact", action = "UpdateContact" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/contact/create",
    defaults: new { controller = "Contact", action = "CreateContact" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/contact",
    defaults: new { controller = "Contact", action = "Index" });

//about header
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/aboutheader/details/{id}",
    defaults: new { controller = "AboutHeader", action = "Details" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/aboutheader/delete/{id}",
    defaults: new { controller = "AboutHeader", action = "DeleteAboutHeader" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/aboutheader/update/{id}",
    defaults: new { controller = "AboutHeader", action = "UpdateAboutHeader" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/aboutheader/create",
    defaults: new { controller = "AboutHeader", action = "CreateAboutHeader" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/aboutheader",
    defaults: new { controller = "AboutHeader", action = "Index" });
//about 
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/about/details/{id}",
    defaults: new { controller = "About", action = "Details" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/about/delete/{id}",
    defaults: new { controller = "About", action = "DeleteAbout" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/about/update/{id}",
    defaults: new { controller = "About", action = "UpdateAbout" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/about/create",
    defaults: new { controller = "About", action = "CreateAbout" });
app.MapAreaControllerRoute(
     name: "areas",
    areaName: "admin",
    pattern: "admin/about",
    defaults: new { controller = "About", action = "Index" });
//product
app.MapAreaControllerRoute(
    name: "areas",
    areaName: "admin",
    pattern: "admin/product/details/{id}",
    defaults: new { controller = "Product", action = "Details" }
);

app.MapAreaControllerRoute(
    name: "areas",
    areaName: "admin",
    pattern: "admin/product/create",
    defaults: new { controller = "Product", action = "CreateProduct" }
);
app.MapAreaControllerRoute(
    name: "areas",
    areaName: "admin",
    pattern: "admin/product/delete/{id}",
    defaults: new { controller = "Product", action = "DeleteProduct" }
);
app.MapAreaControllerRoute(
    name: "areas",
    areaName: "admin",
    pattern: "admin/product/update/{id}",
    defaults: new { controller = "Product", action = "UpdateProduct" }
);

app.MapAreaControllerRoute(
    name: "areas",
    areaName: "admin",
    pattern: "admin/product",
    defaults: new { controller = "Product", action = "Index" }
);
//admin
app.MapAreaControllerRoute(
    name: "areas",
    areaName: "admin",
    pattern: "admin",
    defaults: new { controller = "Dashboard", action = "Index" }
);
//ui 
app.MapControllerRoute(
       name: "pricing",
    pattern: "pricing",
    defaults: new { controller = "Pricing", Action = "Index" }

    );
app.MapControllerRoute(
    name: "contact",
    pattern: "contact",
    defaults: new { controller = "Contact", Action = "Index" });
app.MapControllerRoute(

    name:"about",
    pattern:"about",
    defaults: new {controller="About" , action= "Index" }

    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
