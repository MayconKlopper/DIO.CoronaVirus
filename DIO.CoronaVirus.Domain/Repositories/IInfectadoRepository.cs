using DIO.CoronaVirus.Domain.Entitites;
using System;
using System.Collections.Generic;

namespace DIO.CoronaVirus.Domain.Repositories
{
    public interface IInfectadoRepository
    {
        void Adicionar(Infectado infectado);
        void Adicionar(IList<Infectado> infectados);
        Infectado Atualizar(Infectado infectado);
        void Atualizar(IList<Infectado> infectados);
        void Deletar(Guid ID);
        void Deletar(IList<Guid> IDs);
        IList<Infectado> Buscar();
        Infectado Buscar(Guid ID);
    }
}
