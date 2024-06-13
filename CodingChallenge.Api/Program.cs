using Levelbuild.CodingChallenge.Api;
using Levelbuild.CodingChallenge.Data.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddOData(opt =>
{
    opt.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100);
    opt.AddRouteComponents("odata", GetEdmModel());
});

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<CustomerEntryModel>("Customers");
    builder.EntitySet<UserEntryModel>("Users");
    return builder.GetEdmModel();
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=> c.OperationFilter<EnableQueryFiler>());

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MapControllerRoute(
    name: "default",
    pattern: "/api/{controller=Home}/{action=Index}/{id?}"
);

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();