using Microsoft.AspNetCore.Mvc;
using GatitosAPI.Models;
using GatitosAPI.Service;

namespace GatitosAPI.Controllers;
[ApiController]
[Route("api/gatito/{gatitoId}/[controller]")]
public class HabilidadController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Gatito>> GetHabilidades(int gatitoId)
    {
        var gatito = GatitoDataStore.Current.Gatitos?.FirstOrDefault(z=> z.Id == gatitoId);
        if(gatito == null)
        {
            return NotFound("El gatito solicitado no existe");

        }
        return Ok(gatito.Habilidades);
    } 

    [HttpGet("{habilidadId}")]
    public ActionResult<Gatito> GetHabilidad(int gatitoId, int habilidadId)
    {
        var gatito = GatitoDataStore.Current.Gatitos?.FirstOrDefault(z=> z.Id == gatitoId);
        if(gatito == null)
        {
            return NotFound("El gatito solicitado no existe");

        }
        var habilidad = gatito.Habilidades?.FirstOrDefault(x => x.Id == habilidadId);
        if(habilidad == null)
        {
            return NotFound("La habilidad solicitada no existr");

        }
        return Ok(habilidad);
    }

    // [HttpPost]
    // public ActionResult<Gatito> PostHabilidad(GatitoInsert gatitoInsert)
    // {
        
    // }
    // [HttpPut("{gatitoId}")]
    // public ActionResult<Gatito> PutHabilidad([FromRoute]int gatitoId, [FromBody]GatitoInsert gatitoInsert)
    // {
        
    // }

    // [HttpDelete("{gatitoId}")]
    // public ActionResult<Gatito> DeleteHabilidad([FromRoute]int gatitoId)
    // {
        
    // }
}
