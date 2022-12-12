namespace Tryitter.Api.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Description { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
