using DIO.CoronaVirus.Domain.Entitites;
using System;
using System.Collections.Generic;

namespace DIO.CoronaVirus.Domain.Repositories
{
    public interface IInfectadoRepository
    {
        Infectado Adicionar(Infectado infectado);
        IList<Infectado> Adicionar(IList<Infectado> infectados);
        Infectado Atualizar(Infectado infectado);
        void Atualizar(IList<Infectado> infectados);
        void Deletar(Guid ID);
        void Deletar(IList<Guid> IDs);
        IList<Infectado> Buscar();
        Infectado Buscar(Guid ID);
    }
}
