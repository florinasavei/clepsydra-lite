using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ClepsydraLite.API
{
    /// <summary>
    /// Configures the Swagger generation options.
    /// </summary>
    /// <remarks>This allows API grouping to define a Swagger document per API GroupName after the
    /// <see cref="IApiDescriptionGroupCollectionProvider"/> service has been resolved from the service container.</remarks>
    /// Example inspired by https://github.com/microsoft/aspnet-api-versioning
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiDescriptionGroupCollectionProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiDescriptionGroupCollectionProvider">provider</see> used to generate Swagger documents.</param>
        public ConfigureSwaggerOptions(IApiDescriptionGroupCollectionProvider provider) => _provider = provider;

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API group name
            foreach (var description in _provider.ApiDescriptionGroups.Items.OrderBy(t => t.GroupName))
            {
                var groupDescription =
                    !string.IsNullOrEmpty(description.GroupName) ? description.GroupName : "UnGrouped";

                options.SwaggerDoc($"{groupDescription}", CreateInfoForApiVersion(groupDescription));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(string groupName)
        {
            var info = new OpenApiInfo()
            {
                Title = $"Clepsydra API: {groupName}",
                // Version = description.ApiVersion.ToString(),
                Description = $"Clepsydra API for {groupName}",
            };

            return info;
        }
    }
}
