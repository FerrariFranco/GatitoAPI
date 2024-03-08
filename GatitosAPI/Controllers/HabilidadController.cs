using Microsoft.AspNetCore.Mvc;
using GatitosAPI.Models;
using GatitosAPI.Service;
using GatitosAPI.Helpers;

namespace GatitosAPI.Controllers;
[ApiController]
[Route("api/gatito/{gatitoId}/[controller]")]
public class HabilidadController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Habilidad>> GetHabilidades(int gatitoId)
    {
        var gatito = GatitoDataStore.Current.Gatitos?.FirstOrDefault(z=> z.Id == gatitoId);
        if(gatito == null)
        {
            return NotFound(Mensajes.Gatito.NotFound);

        }
        return Ok(gatito.Habilidades);
    } 

    [HttpGet("{habilidadId}")]
    public ActionResult<Habilidad> GetHabilidad(int gatitoId, int habilidadId)
    {
        var gatito = GatitoDataStore.Current.Gatitos?.FirstOrDefault(z=> z.Id == gatitoId);
        if(gatito == null)
        {
            return NotFound(Mensajes.Gatito.NotFound);

        }
        var habilidad = gatito.Habilidades?.FirstOrDefault(x => x.Id == habilidadId);
        if(habilidad == null)
        {
            return NotFound(Mensajes.Habilidad.NotFound);

        }
        return Ok(habilidad);
    }

    [HttpPost]
    public ActionResult<Habilidad> PostHabilidad(int gatitoId,HabilidadInsert habilidadInsert)
    {
        var gatito = GatitoDataStore.Current.Gatitos.FirstOrDefault(z=> z.Id == gatitoId);
        if(gatito == null)
        {
            return NotFound(Mensajes.Gatito.NotFound);

        }
        
        int maxHabilidad;

        if(gatito.Habilidades != null)
        {
            maxHabilidad = gatito.Habilidades.Max(z=> z.Id);
        }
        else
        {
            gatito.Habilidades = new List<Habilidad>();
            maxHabilidad = 0;
        }

        var habilidadExistente = GatitoDataStore.Current.BuscarExistenciaHabilidad(maxHabilidad, gatito, habilidadInsert.Nombre);
        
        if(habilidadExistente != null)
        {
            return BadRequest(Mensajes.Habilidad.NombreExistente);
        }
        
        var newHabilidad = new Habilidad()
        {
            Id = maxHabilidad + 1,
            Nombre = habilidadInsert.Nombre,
            Potencia = habilidadInsert.Potencia

        };

        gatito.Habilidades.Add(newHabilidad);

        return NoContent();


    }
    [HttpPut("{habilidadId}")]
    public ActionResult<Habilidad> PutHabilidad([FromRoute]int gatitoId, int habilidadId ,[FromBody]HabilidadInsert habilidadInsert)
    {
        var gatito = GatitoDataStore.Current.Gatitos.FirstOrDefault(z=> z.Id == gatitoId);
        if(gatito == null)
        {
            return NotFound(Mensajes.Gatito.NotFound);

        }
        var habilidad = GatitoDataStore.Current.BuscarHabilidad(habilidadId, gatito);
        if(habilidad == null)
        {
            return NotFound(Mensajes.Habilidad.NotFound);

        }
        var habilidadExistente = GatitoDataStore.Current.BuscarExistenciaHabilidad(habilidadId, gatito, habilidadInsert.Nombre);
        if(habilidadExistente != null)
        {
            return BadRequest(Mensajes.Habilidad.NombreExistente);
        }
        

        habilidad.Nombre = habilidadInsert.Nombre;
        habilidad.Potencia = habilidadInsert.Potencia;

        return NoContent();

    }

    [HttpDelete("{habilidadId}")]
    public ActionResult<Habilidad> DeleteHabilidad([FromRoute]int gatitoId, int habilidadId)
    {
        var gatito = GatitoDataStore.Current.BuscarGatito(gatitoId);
        if(gatito == null)
        {
            return NotFound(Mensajes.Gatito.NotFound);

        }

        var habilidad = gatito.Habilidades?.FirstOrDefault(x=>x.Id == habilidadId);
        if(habilidad == null)
        {
            return NotFound(Mensajes.Habilidad.NotFound);

        }
        gatito.Habilidades.Remove(habilidad);

        return NoContent();

    }



}
