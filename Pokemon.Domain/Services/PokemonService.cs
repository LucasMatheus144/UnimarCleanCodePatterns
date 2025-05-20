using Pokemon.Domain.Repository;
using Pokemon.Domain.Models;

namespace Pokemon.Domain.Services
{
    public class PokemonService
    {
        private readonly IRepository repositorio;
        private ValidatorService service;

        public PokemonService(IRepository repos,
            ValidatorService servico)
        {
            this.repositorio = repos;
            this.service = servico;
        }

       public List<Models.Pokemon> AllPokemons()
       {
            return repositorio.Consultar<Models.Pokemon>().ToList();
       }

        public Models.Pokemon ListarPorId(int id)
        {
            return repositorio.ConsultarPorId<Models.Pokemon>(id);
        }

        public bool Cadastra(Models.Pokemon pokemon, out List<MensagemErro> msg)
        {
            if (service.ValidaModelos(pokemon, out msg))
            {
                repositorio.Add(pokemon);
                return true;
            }

            return false;
            
        }

        public bool Atualiza(Models.Pokemon pokemon, out List<MensagemErro> msg)
        {
            if (service.ValidaModelos(pokemon, out msg))
            {
                repositorio.Update(pokemon);
                return true;
            }
            return false;
        }

        public bool Deletar(int id)
        {
            var encontra = ListarPorId(id);

            if (encontra == null)
            {
                return false;
            }
            repositorio.Delete(encontra);
            return true;
             
        }
    }
}
