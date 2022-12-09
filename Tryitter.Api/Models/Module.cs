using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tryitter.Api.Models
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        public string? Name { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}
