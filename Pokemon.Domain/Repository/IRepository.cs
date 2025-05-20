using Pokemon.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Repository
{
    public interface IRepository
    {
        void Add(object model);

        void Update(object model);

        void Delete(object model);

        T ConsultarPorId<T>(int iD);

        IQueryable<T> Consultar<T>();

        List<T> ConsultarPorTipo<T>(TipoPokemon tipo);
    }
}
