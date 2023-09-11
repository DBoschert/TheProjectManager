using System.ComponentModel.DataAnnotations;

namespace TheProjectManager.Models
{

    public class ProjTask
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public int DeveloperId { get; set; }
        public virtual Developer? Developer { get; set; }
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        public int EtaHours { get; set; }
        [StringLength(25)]
        public string Status { get; set; } = "NEW";

    }
}
