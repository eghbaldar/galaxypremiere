using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Common.Constants;
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

                context.Session.SetString("Session_Nickname", ClaimUtility.GetUserFullname(context.User as ClaimsPrincipal));

                if (string.IsNullOrEmpty(GeneralConstants.Nickname)) GeneralConstants.Nickname = ClaimUtility.GetUserFullname(context.User as ClaimsPrincipal);
                if (GeneralConstants.UserId == 0) GeneralConstants.UserId = (long)ClaimUtility.GetUserId(context.User as ClaimsPrincipal);

                if (string.IsNullOrEmpty(GeneralConstants.Username))
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<IUserInformationFacade>();

                        var retrieve = dbContext.GetUsersInformationServiceService.Execute
                         (new galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation.RequestGetUsersInformationServiceDto
                         {
                             UsersId = GeneralConstants.UserId,
                         });
                        if (retrieve != null)
                        {
                            GeneralConstants.Username = retrieve.Username;
                            if (string.IsNullOrEmpty(retrieve.Photo))
                                GeneralConstants.PrivateHeadshot = GeneralConstants.PublicHeadshot;
                            else
                                GeneralConstants.PrivateHeadshot = $"/SiteTemplate/innerpages/images/user-headshot/{retrieve.Photo}-thumb.jpg";
                        }
                    }
            }

            await _next(context);
        }
    }
}
