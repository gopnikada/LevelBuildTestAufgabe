using Levelbuild.CodingChallenge.Api;
using Levelbuild.CodingChallenge.Api.Configuration;
using Levelbuild.CodingChallenge.Domain.Abstractions.Models;
using Levelbuild.CodingChallenge.Persistence.Abstractions.Builder;
using Levelbuild.CodingChallenge.Persistence.Context;
using Levelbuild.CodingChallenge.Persistence.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddOData(opt =>
{
    opt.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100);
    opt.AddRouteComponents("odata", GetEdmModel());
});

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<CustomerModel>("Customers");
    builder.EntitySet<UserModel>("Users");
    return builder.GetEdmModel();
}


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=> c.OperationFilter<EnableQueryFiler>());

DataBaseSettings dataBaseSettings = builder.
    Configuration.
    GetSection("DataBaseConnection").
    Get<DataBaseSettings>();

builder.Services.AddSingleton<ICodingChallengeDatabaseContextOptionsBuilder>(dataBaseSettings);

builder.Services.AddCodingChallengeDatabase(optionsBuilder =>
{
    optionsBuilder.ConnectionString = dataBaseSettings.ConnectionString;
});


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