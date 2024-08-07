﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Levelbuild.CodingChallenge.Api.Odata
{
    public class EnableQueryFiler : IOperationFilter
    {
        static List<OpenApiParameter> s_Parameters = new List<(string Name, string Description)>()
        {
            ( "$top", "The max number of records."),
            ( "$skip", "The number of records to skip."),
            ( "$filter", "A function that must evaluate to true for a record to be returned."),
            ( "$select", "Specifies a subset of properties to return. Use a comma separated list."),
            ( "$orderby", "Determines what values are used to order a collection of records.")
        }.Select(pair => new OpenApiParameter
        {
            Name = pair.Name,
            Required = false,
            Schema = new OpenApiSchema { Type = "String" },
            In = ParameterLocation.Query,
            Description = pair.Description,

        }).ToList();

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.ActionDescriptor.EndpointMetadata.Any(em => em is Microsoft.AspNetCore.OData.Query.EnableQueryAttribute))
            {

                operation.Parameters ??= new List<OpenApiParameter>();
                foreach (var item in s_Parameters)
                    operation.Parameters.Add(item);
            }
        }
    }
}
