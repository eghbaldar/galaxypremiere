namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileFavoriteMovies
{
    public class GetUserProfileFavoriteMoviesServiceDto
    {
        public Guid Id { get; set; }
        public string ImdbLink { get; set; } // a link of IMDb Movie
        public DateTime InsertDate { get; set; }
    }
}
