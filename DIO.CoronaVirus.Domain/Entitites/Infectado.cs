using DIO.CoronaVirus.Domain.Models.Request;
using MongoDB.Driver.GeoJsonObjectModel;
using System;

namespace DIO.CoronaVirus.Domain.Entitites
{
    public class Infectado
    {
        public Infectado(Guid ID, string nome, DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            this.ID = ID;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }

        #region Operator Overloads

        public static implicit operator Infectado(InfectadoRequest model)
        {
            var entity = new Infectado(model.ID, model.Nome, model.DataNascimento, model.Sexo, model.Latitude, model.Longitude);

            return entity;
        }

        #endregion
    }
}
