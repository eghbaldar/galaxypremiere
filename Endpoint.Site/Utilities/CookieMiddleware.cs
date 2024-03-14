using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Common.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace Endpoint.Site.Utilities
{
    public class CookieMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;
        public CookieMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;            
        }

        public async Task Invoke(HttpContext context)
        {

            if (context.User.Identity.IsAuthenticated)
            {
                if(!context.Session.Keys.Contains("UserSession") || !context.Session.TryGetValue("UserSession:user-id", out _))
                {
                    context.Session.SetString("UserSession:user-id", ClaimUtility.GetUserId(context.User as ClaimsPrincipal).ToString());
                    context.Session.SetString("UserSession:user-nickname", ClaimUtility.GetUserFullname(context.User as ClaimsPrincipal));

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<IUserInformationFacade>();

                        var retrieve = dbContext.GetUsersInformationServiceService.Execute
                         (new galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation.RequestGetUsersInformationServiceDto
                         {
                             UsersId = long.Parse(context.Session.GetString("UserSession:user-id")),
                         });
                        if (retrieve != null)
                        {
                            context.Session.SetString("UserSession:user-username", retrieve.Username);
                            if (string.IsNullOrEmpty(retrieve.Photo))
                                context.Session.SetString("UserSession:user-privateheadshot", GeneralConstants.PublicHeadshot);
                            else
                                context.Session.SetString("UserSession:user-privateheadshot", $"/SiteTemplate/innerpages/images/user-headshot/{retrieve.Photo}-thumb.jpg");
                        }
                    }
                }
            }

            await _next(context);
        }
    }
}
