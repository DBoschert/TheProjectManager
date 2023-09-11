using System.ComponentModel.DataAnnotations;

namespace TheProjectManager.Models
{
    public class Project
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        [StringLength(25)]
        public string Status { get; set; } = "NEW";

    }
}
