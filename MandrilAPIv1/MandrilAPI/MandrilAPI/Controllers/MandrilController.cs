using MandrilAPI.Helpers;
using MandrilAPI.Models;
using MandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MandrilController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Mandril>> GetMandriles()
    {
        return Ok(MandrilDataStore.Current.Mandriles);
    }

    [HttpGet("{mandrilId}")]
    public ActionResult<Mandril> GetMandril(int mandrilId)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
            return NotFound(Mensajes.Mandril.NotFound);

        return Ok(mandril);

    }

    [HttpPost]
    public ActionResult<Mandril> PostMandril(MandrilInsert mandrilInsert)
    {
        var maxMandrilId = MandrilDataStore.Current.Mandriles.Max(x => x.Id);

        var mandrilNuevo = new Mandril() {
            Id = maxMandrilId + 1,
            Nombre = mandrilInsert.Nombre,
            Apellido = mandrilInsert.Apellido
        };

        MandrilDataStore.Current.Mandriles.Add(mandrilNuevo);

        return CreatedAtAction(nameof(GetMandril),
            new { mandrilId = mandrilNuevo.Id },
            mandrilNuevo
        );
    }

    [HttpPut("{mandrilId}")]
    public ActionResult<Mandril> PutMandril([FromRoute] int mandrilId, [FromBody] MandrilInsert mandrilInsert)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
            return NotFound(Mensajes.Mandril.NotFound);

        mandril.Nombre = mandrilInsert.Nombre;
        mandril.Apellido = mandrilInsert.Apellido;

        return NoContent();

    }

    [HttpDelete("{mandrilId}")]
    public ActionResult<Mandril> DeleteMandril(int mandrilId)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
            return NotFound(Mensajes.Mandril.NotFound);

        MandrilDataStore.Current.Mandriles.Remove(mandril);

        return NoContent();

    }

}
