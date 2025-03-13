namespace JobBoard.Dtos
{
    public class AddJobPostDTO
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public AddJobPostDTO()
        {
            if (Title == null)
            {
                Title = "";
            }
            if (Description == null)
            {
                Description = "";
            }
        }
    }
}