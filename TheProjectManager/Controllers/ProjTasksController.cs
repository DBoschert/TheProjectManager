using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheProjectManager.Data;
using TheProjectManager.Models;

namespace TheProjectManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjTasksController : ControllerBase
    {
        private readonly ProjectManagerContext _context;

        public ProjTasksController(ProjectManagerContext context)
        {
            _context = context;
        }

        // GET: api/ProjTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjTask>>> GetTasks()
        {
          if (_context.ProjTasks == null)
          {
              return NotFound();
          }
            return await _context.ProjTasks.ToListAsync();
        }

        // GET: api/ProjTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjTask>> GetProjTask(int id)
        {
          if (_context.ProjTasks == null)
          {
              return NotFound();
          }
            var projTask = await _context.ProjTasks.FindAsync(id);

            if (projTask == null)
            {
                return NotFound();
            }

            return projTask;
        }

        //PUT: api/ProjTasks/InProgess/id
        [HttpPut("inprogress/{id}")]
        public async Task<IActionResult> StatusSetToInProgress(int id, ProjTask projTask)
        {
            projTask.Status = "In Progress";
            return await PutProjTask(id, projTask);
        }

        //PUT: api/ProjTasks/Completed/id
        [HttpPut("completed/{id}")]
        public async Task<IActionResult> StatusSetToCompleted(int id, ProjTask projTask)
        {
            projTask.Status = "Completed";
            return await PutProjTask(id, projTask);
        }

        // PUT: api/ProjTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjTask(int id, ProjTask projTask)
        {
            if (id != projTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(projTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProjTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjTask>> PostProjTask(ProjTask projTask)
        {
          if (_context.ProjTasks == null)
          {
              return Problem("Entity set 'ProjectManagerContext.Tasks'  is null.");
          }
            _context.ProjTasks.Add(projTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjTask", new { id = projTask.Id }, projTask);
        }

        // DELETE: api/ProjTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjTask(int id)
        {
            if (_context.ProjTasks == null)
            {
                return NotFound();
            }
            var projTask = await _context.ProjTasks.FindAsync(id);
            if (projTask == null)
            {
                return NotFound();
            }

            _context.ProjTasks.Remove(projTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjTaskExists(int id)
        {
            return (_context.ProjTasks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
