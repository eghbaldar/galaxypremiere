using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using System.Text.RegularExpressions;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationUsername
{
    public class StatusUpdateUsersInformationUsernameServiceDto
    {
        public byte Status { get; set; }
    }
    public class UpdateUsersInformationUsernameService : IUpdateUsersInformationAccountTypeService
    {
        private readonly IDataBaseContext _context;
        public UpdateUsersInformationUsernameService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<StatusUpdateUsersInformationUsernameServiceDto> Execute(RequestUpdateUsersInformationUsernameServiceDto req)
        {
            var user = _context.Users.Where(u => u.Id == req.userId).FirstOrDefault();
            if (user != null)
            {
                // check duplicated username
                if (CheckUsername(req.username))
                {
                    return new ResultDto<StatusUpdateUsersInformationUsernameServiceDto>
                    {
                        Data = new StatusUpdateUsersInformationUsernameServiceDto
                        {
                            Status = 0, // error
                        },
                        IsSuccess = false,
                        Message = $"Desired 'USERNAME' ({req.username}) was already reserved!"
                    };
                }
                // end
                var userInfo = _context
                  .UsersInformation
                  .Where(u => u.UsersId == req.userId).FirstOrDefault();
                if (userInfo == null) // Create for first time! (INSERT)
                {
                    Domain.Entities.Users.UsersInformation userUsername
                        = new Domain.Entities.Users.UsersInformation();
                    userUsername.UsersId = req.userId;
                    userUsername.Username = req.username;
                    _context.UsersInformation.Add(userUsername);
                    _context.SaveChanges();

                    return new ResultDto<StatusUpdateUsersInformationUsernameServiceDto>
                    {
                        Data = new StatusUpdateUsersInformationUsernameServiceDto
                        {
                            Status = 1, // success
                        },
                        IsSuccess = true,
                        Message = "Information has just been update successfully.1"
                    };
                }
                else // The user already existed (UPDATE)
                {
                    userInfo.Username = req.username;
                    _context.SaveChanges();
                    return new ResultDto<StatusUpdateUsersInformationUsernameServiceDto>
                    {
                        Data = new StatusUpdateUsersInformationUsernameServiceDto
                        {
                            Status = 1, // success
                        },
                        IsSuccess = true,
                        Message = "Information has just been update successfully.2"
                    };
                }
            }
            else
            {
                return new ResultDto<StatusUpdateUsersInformationUsernameServiceDto>
                {
                    Data = new StatusUpdateUsersInformationUsernameServiceDto
                    {
                        Status = 2, // error
                    },
                    IsSuccess = false,
                    Message = "The user does not exist."
                };
            }
        }
        private bool CheckUsername(string username)
        {
            // check empty and nullable
            if (username == null || username.Trim() == "") return true;
            // check number of characters
            if (username.Length > 50) return true;
            // check the first character
            if ("qwertyuiopasdfghjklzxcvbnm".IndexOf(username.Substring(0, 1)) == -1) return true;            
            // check space
            if (username.IndexOf(' ') != -1) return true;
            //Invalid character(s) found.
            var match = Regex.Match(username, "^[a-zA-Z0-9 ]*$", RegexOptions.IgnoreCase);
            if(!match.Success) { return true; }
            // check duplicated username
            var check = _context
                  .UsersInformation
                  .Where(u => u.Username == username)
                  .Any();
            return check;
        }
    }
}
