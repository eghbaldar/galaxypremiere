using galaxypremiere.Common;
using galaxypremiere.Common.DTOs;
using System.Net;

namespace galaxypremiere.Application.Services.Metags.Queries.GetMetagsInfoByLink
{
    public class GetMetagsInfoByLinkService : IGetMetagsInfoByLinkService
    {
        public ResultDto Execute(string link, string domain)
        {
            // Check the link itself
            UrlValidation urlValidation = new UrlValidation(link, domain);
            if (!urlValidation.CheckUrlStructure())
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The link is invalid.",
                };
            }
            // Check the Imdb link
            if (!urlValidation.MatchUrlWithDomain())
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The link is invalid.",
                };
            }
            // Check the validation of IMDb link materials
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(link);
                myRequest.Method = "GET";
                WebResponse myResponse = myRequest.GetResponse();
                string result = "";
                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                result = sr.ReadToEnd();
                sr.Close();
                myResponse.Close();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = result,
                };
            }
            catch (WebException ex)
            {// there is no material in the link - it seems the user entered a bad link
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse resp = ex.Response as HttpWebResponse;
                    if (resp != null && resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return new ResultDto
                        {
                            IsSuccess = false,
                            Message = "There is no movie in the link, check your link out.",
                        };
                    }
                }
                else
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    };
                }
            }
            return new ResultDto
            {
                IsSuccess = false,
                Message = "There is no movie in the link, check your link out.",
            };
        }
    }
}
