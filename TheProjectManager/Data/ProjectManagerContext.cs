using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheProjectManager.Models;

namespace TheProjectManager.Data
{
    public class ProjectManagerContext : DbContext
    {
        public ProjectManagerContext (DbContextOptions<ProjectManagerContext> options)
            : base(options)
        {
        }

        public DbSet<TheProjectManager.Models.Project> Projects { get; set; } = default!;

        public DbSet<TheProjectManager.Models.Developer> Developers { get; set; } = default!;

        public DbSet<TheProjectManager.Models.ProjTask> ProjTasks { get; set; } = default!;
    }
}
