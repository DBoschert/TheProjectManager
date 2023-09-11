using System.ComponentModel.DataAnnotations;

namespace TheProjectManager.Models
{
    public class Developer
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;       
    }
}
