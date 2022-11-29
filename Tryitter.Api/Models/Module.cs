using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Api.Models
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}
