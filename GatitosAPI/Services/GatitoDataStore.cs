using GatitosAPI.Models;

namespace GatitosAPI.Service;

public class GatitoDataStore
{
 public List<Gatito>? Gatitos {get; set;}

 public static GatitoDataStore? Current {get;}

 private GatitoDataStore()
        {
            Gatitos = new List<Gatito>();
            {
                new Gatito
                {
                    Id = 1,
                    Nombre = "Jere",
                    Habilidades = new List<Habilidad>
                    {
                        new Habilidad { Id = 1, Nombre = "Dormir", Potencia = Habilidad.EPotencia.Moderado },
                        new Habilidad { Id = 2, Nombre = "Comer", Potencia = Habilidad.EPotencia.Moderado }
                    }
                };

                new Gatito
                {
                    Id = 2,
                    Nombre = "Yuumi",
                    Habilidades = new List<Habilidad>
                    {
                        new Habilidad { Id = 3, Nombre = "Engordar", Potencia = Habilidad.EPotencia.Extremo },
                        new Habilidad { Id = 4, Nombre = "Arañar", Potencia = Habilidad.EPotencia.Intenso },
                        new Habilidad { Id = 5, Nombre = "Charmear", Potencia = Habilidad.EPotencia.RePotente }
                    }
                };

            }

        }
}
