using BAL.Models;
using BAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BAL.Controllers;

[ApiController]
[Route("[action]")]
public class CharacterController
{
    [HttpPost]
    public IActionResult CalculateCharacter(Character character) => 
        new JsonResult(CharacterCalculator.Calculate(character));
}