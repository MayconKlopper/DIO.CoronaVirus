using DIO.CoronaVirus.Domain.Entitites;
using System;

namespace DIO.CoronaVirus.Domain.Models.Response
{
    public class InfectadoResponse
    {
        public InfectadoResponse(Guid ID, string nome, DateTime dataNascimento, string sexo, double? latitude, double? longitude)
        {
            this.ID = ID;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        #region Operator Overloads

        public static implicit operator InfectadoResponse(Infectado entity)
        {
            var model = new InfectadoResponse(entity.ID, entity.Nome, entity.DataNascimento, entity.Sexo, entity?.Localizacao.Latitude, entity?.Localizacao.Longitude);

            return model;
        }

        #endregion
    }
}
