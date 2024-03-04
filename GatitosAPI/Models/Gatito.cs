using System.Text.Json.Serialization;

namespace GatitosAPI.Models;

public class Gatito
{
   public int Id { get; set; }
   public string Nombre { get; set; } = string.Empty;
   public string Apellido { get; set; } = string.Empty;
   public List<Habilidad>? Habilidades {get; set;}

}
