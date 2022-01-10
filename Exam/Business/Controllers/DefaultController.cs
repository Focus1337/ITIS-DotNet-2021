using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers;

[ApiController]
[Route("[action]")]
public class DefaultController : ControllerBase
{
    [HttpPost]
    public IActionResult CalculateCharacterProperties(
        [FromBody] CharacterModel characterModel,
        [FromServices] ICharacterCalculator characterCalculator) =>
        new JsonResult(characterCalculator.CalculateCharacter(characterModel));
}