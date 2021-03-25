using System;

namespace DIO.CoronaVirus.Domain.Models.Request
{
    /// <summary>
    /// Modelo com os dados necessários para adicionar um infectado na base de dados
    /// </summary>
    public class InfectadoRequest
    {
        public Guid ID { get; set; }
        /// <summary>
        /// Nome do infectado
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Data de Nascimento do infectado
        /// </summary>
        public DateTime DataNascimento { get; set; }
        /// <summary>
        /// Sexo do Infectado
        /// </summary>
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
