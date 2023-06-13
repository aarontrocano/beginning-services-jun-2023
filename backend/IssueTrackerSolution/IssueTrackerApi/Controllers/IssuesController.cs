using IssueTrackerApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace IssueTrackerApi.Controllers;

public class IssuesController : ControllerBase
{

    [HttpGet("/open-issues")]
    public async Task<ActionResult> GetOpenIssues()
    {
        return Ok("Open Issues will be here.");
    }

    [HttpPost("/open-issues")]

    public async Task<ActionResult> AddAnIssue([FromBody] IssueCreateRequest request)
    {
        // Validate it, if invalid, return a 400.
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // If it's good, create an issueresponse
        // Save it to the database
        // end them a copy of it.

        var response = new IssueCreateResponse
        {
            Id = Guid.NewGuid(),
            Issue = request.Issue,
            From = request.From,
            CreatedAt = DateTime.UtcNow,

        };

        return Ok(response);
    }
}
