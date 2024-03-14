using static galaxypremiere.Application.Services.UsersPosts.Queries.GetUsersPosts.GetUsersPostsService;

namespace galaxypremiere.Application.Services.UsersPosts.Queries.GetUsersPosts
{
    public class GetUsersPostsServiceDto
    {
        public Guid PostId { get; set; }
        public string Post { get; set; }
        public long UsersId { get; set; } // page owner's Id
        public string OwnerNickname { get; set; } // based on "UsersId"
        public long From { get; set; } // who is posted
        public string FromNickname { get; set; } // based on "From"        
        public DateTime InsertDate { get; set; }
        public string OwnerUsername { get; set; }
        public string FromUsername { get; set; }
        public string OwnerHeadshot { get; set; }
        public string FromHeadshot { get; set; }
        public ResultGetPostPhotosByPostIdDto resultGetPostPhotosByPostIdDto { get; set; }
        public ResultGetPostCommentsByPostIdDto resultGetPostCommentsByPostIdDto { get; set; }
        public bool Liked { get; set; } // whether this post is liked by the logged user or not.
        public string CountLikes { get; set; }
        public string CountComments { get; set; }
    }
}
