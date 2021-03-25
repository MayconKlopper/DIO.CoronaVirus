using DIO.CoronaVirus.Domain.Entitites;
using DIO.CoronaVirus.Domain.Repositories;
using DIO.CoronaVirus.ExternalService.Mongo.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DIO.CoronaVirus.ExternalService.Mongo.Repositories
{
    public class InfectadoRepository : IInfectadoRepository
    {
        private readonly MongoContext mongoContext;
        private readonly IMongoCollection<Infectado> infectadoCollection;

        public InfectadoRepository(MongoContext mongoContext)
        {
            this.mongoContext = mongoContext;
            this.infectadoCollection = this.mongoContext.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        public Infectado Adicionar(Infectado infectado)
        {
            infectado.ID = Guid.NewGuid();
            this.infectadoCollection.InsertOne(infectado);

            return infectado;
        }

        public IList<Infectado> Adicionar(IList<Infectado> infectados)
        {
            foreach (var infectado in infectados)
            {
                infectado.ID = Guid.NewGuid();
            }
            this.infectadoCollection.InsertMany(infectados);

            return infectados;
        }

        public Infectado Atualizar(Infectado infectado)
        {
            this.infectadoCollection.ReplaceOne(x => x.ID.Equals(infectado.ID), infectado);

            return infectado;
        }

        public void Atualizar(IList<Infectado> infectados)
        {
            var filter = Builders<Infectado>.Filter.Eq("ID", infectados.Select(x => x.ID));
            var update = Builders<Infectado>.Update.Set("Sexo", infectados.Select(x => x.Sexo))
                                                   .Set("DataNascimento", infectados.Select(x => x.DataNascimento))
                                                   .Set("Nome", infectados.Select(x => x.Nome));

            this.infectadoCollection.UpdateMany(filter, update);
        }

        public IList<Infectado> Buscar()
        {
            var entities = this.infectadoCollection.Find(Builders<Infectado>.Filter.Empty)
                                                   .ToList();

            return entities;
        }

        public Infectado Buscar(Guid ID)
        {
            var entity = this.infectadoCollection.Find(x => x.ID.Equals(ID))
                                                 .FirstOrDefault();

            return entity;
        }

        public void Deletar(Guid ID)
        {
            this.infectadoCollection.DeleteOne(x => x.ID.Equals(ID));
        }

        public void Deletar(IList<Guid> IDs)
        {
            this.infectadoCollection.DeleteMany(x => IDs.Contains(x.ID));
        }
    }
}
