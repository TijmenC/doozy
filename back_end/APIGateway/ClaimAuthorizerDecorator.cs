using Microsoft.Extensions.DependencyInjection;
using Ocelot.Authorisation;
using Ocelot.DownstreamRouteFinder.UrlMatcher;
using Ocelot.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APIGateway
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection DecorateClaimAuthoriser(this IServiceCollection services)
        {
            var serviceDescriptor = services.First(x => x.ServiceType == typeof(IClaimsAuthoriser));
            services.Remove(serviceDescriptor);

            var newServiceDescriptor = new ServiceDescriptor(serviceDescriptor.ImplementationType, serviceDescriptor.ImplementationType, serviceDescriptor.Lifetime);
            services.Add(newServiceDescriptor);

            services.AddTransient<IClaimsAuthoriser, ClaimAuthorizerDecorator>();

            return services;
        }
    }
    public class ClaimAuthorizerDecorator : IClaimsAuthoriser
    {
        private readonly ClaimsAuthoriser _authoriser;

        public ClaimAuthorizerDecorator(ClaimsAuthoriser authoriser)
        {
            _authoriser = authoriser;
        }

        public Response<bool> Authorise(ClaimsPrincipal claimsPrincipal, Dictionary<string, string> routeClaimsRequirement, List<PlaceholderNameAndValue> urlPathPlaceholderNameAndValues)
        {
            var newRouteClaimsRequirement = new Dictionary<string, string>();
            foreach (var kvp in routeClaimsRequirement)
            {
                if (kvp.Key.StartsWith("http$//"))
                {
                    var key = kvp.Key.Replace("http$//", "http://");
                    newRouteClaimsRequirement.Add(key, kvp.Value);
                }
                else
                {
                    newRouteClaimsRequirement.Add(kvp.Key, kvp.Value);
                }
            }

            return _authoriser.Authorise(claimsPrincipal, newRouteClaimsRequirement, urlPathPlaceholderNameAndValues);
        }
    }
}
