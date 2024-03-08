using System.ComponentModel.DataAnnotations;
using static GatitosAPI.Models.Habilidad;

namespace GatitosAPI.Models;

public class HabilidadInsert
{
    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; } = string.Empty;
    public EPotencia Potencia { get; set; }
}
