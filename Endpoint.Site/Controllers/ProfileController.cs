using Endpoint.Site.Models.Porfile.GetInformationByUsername;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationAboutByUsername;
using Microsoft.AspNetCore.Mvc;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPositions;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContactByUsername;

namespace Endpoint.Site.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserInformationFacade _userInformationFacade;
        public ProfileController(IUserInformationFacade userInformationFacade)
        {
            _userInformationFacade = userInformationFacade;
        }
        [HttpGet]
        public IActionResult Index(string username)
        {
            ModelGetInformationByUsername modelGetInformationByUsername = new ModelGetInformationByUsername
            {
                ResultGetUsersInformationByUsernameServiceDto = _userInformationFacade.GetUsersInformationByUsernameService.Execute(new RequestUsersInformationByUsernameServiceDto
                {
                    Username = username
                })
            };
            return View(modelGetInformationByUsername);
        }
        [HttpGet]
        public IActionResult GetInfoAbout(string username)
        {
            return Json(_userInformationFacade.GetUsersInformationAboutByUsernameService.Execute(new RequestGetUsersInformationAboutByUsernameServiceDto
            {
                Username = username
            }));
        }
        [HttpGet]
        public IActionResult GetInfoPositions(string positions)
        {
            return Json(_userInformationFacade.GetUsersInformationPositionsService.Execute(new RequestGetUsersInformationPositionsServiceDto
            {
                Positions = positions,
            }));
        }
        [HttpGet]
        public IActionResult GetInfoContact(string username)
        {
            return Json(_userInformationFacade.GetUsersInformationContactByUsernameService.Execute(new RequestGetUsersInformationContactByUsernameServiceDto
            {
                Username = username
            }));
        }
    }
}
