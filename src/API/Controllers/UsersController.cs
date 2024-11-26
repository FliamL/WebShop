using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Webshop.API.Entities;

namespace Webshop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Identity.Application")]
public class UsersController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    public UsersController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser()
    {
        // Get the currently authenticated user's ID from the claims principal
        var userId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (userId == null)
        {
            return Unauthorized(new { message = "User is not authenticated." });
        }

        // Fetch the user from the database
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound(new { message = "User not found." });
        }

        // Return user details (sanitize as needed)
        return Ok(new
        {
            user.Id,
            user.UserName,
            user.Email
        });
    }
}
