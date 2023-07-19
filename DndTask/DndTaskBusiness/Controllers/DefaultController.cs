using DndTaskBusiness.Services;
using Microsoft.AspNetCore.Mvc;

namespace DndTaskBusiness.Controllers;

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