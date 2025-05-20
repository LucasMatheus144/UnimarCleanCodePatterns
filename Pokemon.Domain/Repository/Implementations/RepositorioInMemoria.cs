using Pokemon.Domain.Interface;
using Pokemon.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Repository.Implementations
{
    public class RepositorioInMemoria : IRepository
    {
        private static int Id = 7;

        public static Dictionary<string, List<object>> Dados =
            new Dictionary<string, List<object>>();

        public IQueryable<T> Consultar<T>()
        {
            if (Dados.ContainsKey(typeof(T).Name))
            {
                return Dados[typeof(T).Name].Cast<T>().AsQueryable();
            }
           
            return new List<T>().AsQueryable();
            
        }

        public T ConsultarPorId<T>(int iD)
        {
            if (Dados.ContainsKey(typeof(T).Name))
            {
                return Dados[typeof(T).Name].Cast<T>().FirstOrDefault(x => x.GetType().GetProperty("Id").GetValue(x).Equals(iD));
            }
            
            return default;

            //var nomeEntidade = typeof(T).Name;
            //if (!Dados.ContainsKey(nomeEntidade))
            //    return default;
            //var entidade = Dados[nomeEntidade].
            //    FirstOrDefault(
            //        e => (e as IEntidade).Id == iD
            //    );
            //return (T)entidade;
        }

        public void Add(object model)
        {
            var nomeEntidade = model.GetType().Name;
            if (!Dados.ContainsKey(nomeEntidade))
                Dados.Add(nomeEntidade, new List<object>());
            Dados[nomeEntidade].Add(model);
            Id++;
        }

        public void Delete(object model)
        {
            var nomeEntidade = model.GetType().Name;
            if (Dados.ContainsKey(nomeEntidade))
            {
                var entidade = Dados[nomeEntidade].FirstOrDefault(e => e == model);
                if (entidade != null)
                {
                    Dados[nomeEntidade].Remove(entidade);
                }
            }
        }

        public void Update(object model)
        {
            var nomeEntidade = model.GetType().Name;
            if (Dados.ContainsKey(nomeEntidade))
            {
                var entidade = Dados[nomeEntidade].FirstOrDefault(e => e == model);
                if (entidade != null)
                {
                    Dados[nomeEntidade].Remove(entidade);
                    Dados[nomeEntidade].Add(model);
                }
            }
        }

        public List<T> ConsultarPorTipo<T>(TipoPokemon tipo)
        {
            if (Dados.ContainsKey(typeof(T).Name))
            {
                return Dados[typeof(T).Name].Cast<T>().Where(x => x.GetType().GetProperty("Tipo").GetValue(x).Equals(tipo)).ToList();
            }

            return new List<T>();
        }
    }
}
