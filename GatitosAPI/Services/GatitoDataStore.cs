using GatitosAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;

namespace GatitosAPI.Service
{
    public class GatitoDataStore
    {
        public List<Gatito>? Gatitos { get; set; }

        public static GatitoDataStore Current { get; } = new GatitoDataStore();

        private GatitoDataStore()
        {
            Gatitos = new List<Gatito>();

            Gatitos.Add(new Gatito
            {
                Id = 1,
                Nombre = "Jere",
                Apellido = "Ferrari",
                Habilidades = new List<Habilidad>
                {
                    new Habilidad { Id = 1, Nombre = "Dormir", Potencia = Habilidad.EPotencia.Moderado },
                    new Habilidad { Id = 2, Nombre = "Comer", Potencia = Habilidad.EPotencia.Moderado }
                }
            });

            Gatitos.Add(new Gatito
            {
                Id = 2,
                Nombre = "Yuumi",
                Apellido = "Carvani",
                Habilidades = new List<Habilidad>
                {
                    new Habilidad { Id = 3, Nombre = "Engordar", Potencia = Habilidad.EPotencia.Extremo },
                    new Habilidad { Id = 4, Nombre = "Arañar", Potencia = Habilidad.EPotencia.Intenso },
                    new Habilidad { Id = 5, Nombre = "Charmear", Potencia = Habilidad.EPotencia.RePotente }
                }
            });
            Gatitos.Add(new Gatito
            {
                Id = 3,
                Nombre = "Tisha",
                Apellido = "Galati",
                Habilidades = new List<Habilidad>
                {
                    new Habilidad { Id = 6, Nombre = "Enojarse", Potencia = Habilidad.EPotencia.RePotente },
                    
                    new Habilidad { Id = 7, Nombre = "Morder", Potencia = Habilidad.EPotencia.Extremo }
                }
            });
        }

        public Gatito BuscarGatito(int gatitoId)
        {
            var gatito = Current.Gatitos.FirstOrDefault(z=> z.Id == gatitoId);
            
            return gatito;
        
        }


        public Habilidad BuscarHabilidad(int habilidadId, Gatito gatito)
        {
            var habilidad = gatito.Habilidades?.FirstOrDefault(x=>x.Id == habilidadId);

            return habilidad;
        }

        public Habilidad BuscarExistenciaHabilidad(int habilidadId, Gatito gatito, string habilidadNombre)
        {
            var habilidad = gatito.Habilidades?.FirstOrDefault(x=>x.Id != habilidadId && x.Nombre == habilidadNombre);

            return habilidad;
        }

        
    }
}
