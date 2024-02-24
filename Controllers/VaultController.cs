using System.Security.Claims;
using api.Data;
using api.DTO;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VaultController : ControllerBase
{
  private readonly DataContext _dataContext;

  public VaultController(DataContext dataContext)
  {
    _dataContext = dataContext;
  }

  [HttpGet]
  public async Task<IEnumerable<Password>> GetPasswords()
  {
    var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

    var list = await _dataContext.Passwords.ToListAsync();
    var passwords = await _dataContext.Passwords.Where(x => x.UserId == userId).ToListAsync();

    return passwords;
  }

  [HttpPost("add-entry")]
  public async Task<ActionResult> AddPassword(PasswordDto passwordDto)
  {
    if (passwordDto.Website == "" || passwordDto.PasswordHash == "")
      return BadRequest("Details must not be empty");

    var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
    var entry = new Password(passwordDto.Website, passwordDto.PasswordHash, userId);

    await _dataContext.Passwords.AddAsync(entry);
    await _dataContext.SaveChangesAsync();

    return Ok();
  }
}
