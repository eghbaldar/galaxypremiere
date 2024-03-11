using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.Comments.Queries.GetCommentsBySectionId
{
    public interface IGetCommentsBySectionIdService
    {
        ResultDto<ResultGetCommentsBySectionIdServiceDto> Execute(RequestGetCommentsBySectionIdServiceDto req);
    }
}
