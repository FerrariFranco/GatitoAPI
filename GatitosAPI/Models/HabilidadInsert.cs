﻿using static GatitosAPI.Models.Habilidad;

namespace GatitosAPI.Models;

public class HabilidadInsert
{
    public string Nombre { get; set; } = string.Empty;

    public EPotencia Potencia { get; set; }
}