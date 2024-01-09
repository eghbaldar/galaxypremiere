using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileCompanies
{
    public class PostUserProfileCompaniesService : IPostUserProfileCompaniesService
    {
        private readonly IDataBaseContext _context;
        public PostUserProfileCompaniesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostUserProfileCompaniesServiceDto req)
        {
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var profile = _context.UsersCompanies.Where(e => e.UsersId == req.UsersId).ToList();

                if (req.info == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "Something went wrong."
                    };
                }
                if ((req.info.Length) <= 10)
                {
                    Dictionary<string, string> resultHiddenId_and_Value = new Dictionary<string, string>();
                    foreach (var anyInfo in req.info)
                    {
                        UsersCompanies usersCompany = new UsersCompanies();
                        var info = anyInfo.ToString().Split("|");
                        // check the acceptable input as a guid
                        // the following code will be checking the GUID ID according to the original its format:00000000-0000-0000-0000-000000000000
                        // why must we check the format of the GUID ID?
                        // if the structure of the ID matches with GUID format, it means the record is added newly by a new form unless the record has already been added and needs to be updated
                        Guid guidOutput;
                        bool isValid = Guid.TryParse(info[0].ToString(), out guidOutput);
                        // end checking ...

                        // add a case that was not added to the list before!
                        if (!isValid)
                        {
                            if (!String.IsNullOrEmpty(info[1].ToString().Trim()) // Company Name
                                &&
                                !String.IsNullOrEmpty(info[2].ToString().Trim()) // Position:  // Such as 'CEO','Digital Artist',...
                                &&
                                !String.IsNullOrEmpty(info[3].ToString().Trim()) // DateTime From
                                &&
                                !String.IsNullOrEmpty(info[4].ToString().Trim()) // DateTime To
                                &&
                                int.Parse(info[1].ToString()) != 0) // Country Id
                            {
                                usersCompany.UsersId = req.UsersId;
                                //info[0].ToString()=>Hidden ID
                                usersCompany.CountryId = int.Parse(info[1].ToString());
                                usersCompany.Name = info[2].ToString();
                                usersCompany.Position = info[3].ToString();
                                usersCompany.From = Convert.ToDateTime(info[4].ToString());
                                usersCompany.To = Convert.ToDateTime(info[5].ToString());
                                usersCompany.Address1 = info[6].ToString();
                                usersCompany.Address2 = info[7].ToString();
                                usersCompany.City = info[8].ToString();
                                usersCompany.State = info[9].ToString();
                                usersCompany.PostalCode = info[10].ToString();
                                usersCompany.Phone = info[11].ToString();
                                usersCompany.RecoveryEmail = info[12].ToString();
                                usersCompany.Website = info[13].ToString();
                                usersCompany.Facebook = info[14].ToString();
                                usersCompany.Instagram = info[15].ToString();
                                usersCompany.Twitter = info[16].ToString();
                                usersCompany.Stage32 = info[17].ToString();
                                usersCompany.Youtube = info[18].ToString();
                                usersCompany.Linkden = info[19].ToString();
                                usersCompany.Vimeo = info[20].ToString();
                                usersCompany.Imdb = info[21].ToString();

                                _context.UsersCompanies.Add(usersCompany);
                                resultHiddenId_and_Value.Add(info[22].ToString(), usersCompany.Id.ToString()); // key=> Hidden-Control-Name    value=> Stored-ID
                                _context.SaveChanges();
                            }
                        }
                        else //update
                        {
                            if (!String.IsNullOrEmpty(info[1].ToString().Trim()) // Company Name
                                &&
                                !String.IsNullOrEmpty(info[2].ToString().Trim()) // Position:  // Such as 'CEO','Digital Artist',...
                                &&
                                !String.IsNullOrEmpty(info[3].ToString().Trim()) // DateTime From
                                &&
                                !String.IsNullOrEmpty(info[4].ToString().Trim()) // DateTime To
                                &&
                                int.Parse(info[1].ToString()) != 0) // Country Id
                            {
                                var company = profile.Where(p => p.Id == Guid.Parse(info[0].ToString())).First();
                                company.UsersId = req.UsersId;
                                //info[0].ToString()=>Hidden ID
                                company.CountryId = int.Parse(info[1].ToString());
                                company.Name = info[2].ToString();
                                company.Position = info[3].ToString();
                                company.From = Convert.ToDateTime(info[4].ToString());
                                company.To = Convert.ToDateTime(info[5].ToString());
                                company.Address1 = info[6].ToString();
                                company.Address2 = info[7].ToString();
                                company.City = info[8].ToString();
                                company.State = info[9].ToString();
                                company.PostalCode = info[10].ToString();
                                company.Phone = info[11].ToString();
                                company.RecoveryEmail = info[12].ToString();
                                company.Website = info[13].ToString();
                                company.Facebook = info[14].ToString();
                                company.Instagram = info[15].ToString();
                                company.Twitter = info[16].ToString();
                                company.Stage32 = info[17].ToString();
                                company.Youtube = info[18].ToString();
                                company.Linkden = info[19].ToString();
                                company.Vimeo = info[20].ToString();
                                company.Imdb = info[21].ToString();

                                string[] hiddenId = info[22].ToString().Split("_");
                                // if the link has a problem (couldn't have been able to fetch data) we have to return a static value ("false") and then check this value on the client side to show an appropriate message to the client
                                resultHiddenId_and_Value.Add(hiddenId[1], "false");
                                //resultHiddenId_and_Value.Add(info[22].ToString(), usersCompany.Id.ToString()); // key=> Hidden-Control-Name    value=> Stored-ID
                                _context.SaveChanges();
                            }
                        }
                    }
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = string.Join(Environment.NewLine, resultHiddenId_and_Value),
                    };
                }
                else
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "Only 10 companiess are allowed."
                    };
                }
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The user does not exist."
                };
            }
        }
    }
}
