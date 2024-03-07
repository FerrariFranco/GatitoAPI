using GatitosAPI.Models;
using GatitosAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace GatitosAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GatitoController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Gatito>> GetGatitos()
    {
        return Ok(GatitoDataStore.Current.Gatitos);
    } 

    [HttpGet("{gatitoId}")]
    public ActionResult<Gatito> GetGatito(int gatitoId)
    {
        var gatito = GatitoDataStore.Current.Gatitos.FirstOrDefault(z=> z.Id == gatitoId);
        if(gatito == null)
        {
            return NotFound("El gatito solicitado no exister");

        }
        else
        {
            return Ok(gatito);
        }
    }

    [HttpPost]
    public ActionResult<Gatito> PostGatito(GatitoInsert gatitoInsert)
    {
        var maxGatito = GatitoDataStore.Current.Gatitos.Max(z=> z.Id);
        var newGatito = new Gatito()
        {
            Id = maxGatito + 1,
            Nombre = gatitoInsert.Nombre,
            Apellido = gatitoInsert.Apellido,

        };
        GatitoDataStore.Current.Gatitos.Add(newGatito);
        return CreatedAtAction(nameof(GetGatito),
        new{gatitoId = newGatito.Id },
        newGatito
        );
        //return Ok(newGatito);
    }
    [HttpPut("{gatitoId}")]
    public ActionResult<Gatito> PutGatito([FromRoute]int gatitoId, [FromBody]GatitoInsert gatitoInsert)
    {
        var gatito = GatitoDataStore.Current.Gatitos.FirstOrDefault(z=> z.Id == gatitoId);
        if(gatito == null)
        {
            return NotFound("El gatito solicitado no exister");

        }
        gatito.Nombre = gatitoInsert.Nombre;
        gatito.Apellido = gatitoInsert.Apellido;

        return NoContent();
    }

    [HttpDelete("{gatitoId}")]
    public ActionResult<Gatito> DeleteGatito([FromRoute]int gatitoId)
    {
        var gatito = GatitoDataStore.Current.Gatitos.FirstOrDefault(z=> z.Id == gatitoId);
        if(gatito == null)
        {
            return NotFound("El gatito solicitado no exister");

        }
        GatitoDataStore.Current.Gatitos.Remove(gatito);
        return NoContent();
    }
}
