namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileEducations
{
    public class GetUserProfileEducationsServiceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // School, College, Institution or University Name
        public string Field { get; set; } // Computer Engineering, Cinema,....
        public DateTime From { get; set; } // starting date of education
        public DateTime To { get; set; } // ending date of education
        public DateTime InsertDate { get; set; }
    }
}
