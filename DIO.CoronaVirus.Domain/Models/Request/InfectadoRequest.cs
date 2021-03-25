using System;

namespace DIO.CoronaVirus.Domain.Models.Request
{
    public class InfectadoRequest
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
