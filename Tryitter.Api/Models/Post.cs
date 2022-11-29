using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Api.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Description { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
