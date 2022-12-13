namespace Tryitter.Api.DTOs
{
    public class StudentInput
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public int ModuleId { get; set; }
    }

    public class PostInput
    {
        public string? Description { get; set; }
        public int StudentId { get; set; }
    }
}
