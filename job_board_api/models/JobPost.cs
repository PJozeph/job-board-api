using System.Text.Json.Serialization;

namespace JobBoard.Models
{
    public class JobPost
    {
        
        public int Id { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

        public JobPost()
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