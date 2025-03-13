namespace JobBoard.Dtos
{
    public class EditJobPostDTO
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public EditJobPostDTO()
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