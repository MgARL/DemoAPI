using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IssueDBContext _dbContext;
        public IssueController(IssueDBContext context) => _dbContext = context;

        [HttpGet]
        public async Task<IEnumerable<Issue>> GetIssue()
        {
            return await _dbContext.Issues.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _dbContext.Issues.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _dbContext.Issues.AddAsync(issue);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = issue.Id}, issue);
        }
    }
}
