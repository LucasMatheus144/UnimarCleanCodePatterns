using Pokemon.Domain.DTO;
using Pokemon.Domain.Models;
using Pokemon.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Services
{
    public class TreinadorService
    {
        private readonly IRepository repositorio;
        private readonly ValidatorService service;
        private readonly PokemonService pokemonService;
        public TreinadorService(PokemonService pokemonService,
            IRepository repository,
            ValidatorService service)
        {
            this.pokemonService = pokemonService;
            this.repositorio = repository;
            this.service = service;
        }

        public List<Treinador> AllTreinadores()
        {
            return repositorio.Consultar<Treinador>().ToList();
        }

        public Treinador IdListarTreinador(int id)
        {
            return repositorio.ConsultarPorId<Treinador>(id);
        }

        public bool Cadastra(VinculoTreinadorPokemon obj, out List<MensagemErro> msg)
        {
            var treinador = new Treinador()
            {
                Nome = obj.Nome,
                Pokemon = pokemonService.ListarPorId(obj.IdPokemon)
            };

            if (service.ValidaModelos(treinador, out msg))
            {
                repositorio.Add(treinador);
                return true;
            }
            return false;
        }

        public bool Editar(VinculoTreinadorPokemon obj , out List<MensagemErro> msg)
        {
            var treinadorEditado = IdListarTreinador(obj.Id);

            if( treinadorEditado != null)
            {
                treinadorEditado.Nome = obj.Nome;
                treinadorEditado.Pokemon = pokemonService.ListarPorId(obj.IdPokemon);
                if (service.ValidaModelos(treinadorEditado, out msg))
                {
                    repositorio.Update(treinadorEditado);
                    return true;
                }
            }

            msg = new List<MensagemErro>();
            msg.Add(new MensagemErro("Id", "Não foi possivel alterar o treinador"));
            return false;
        }

        public bool Deletar(int id)
        {
            var encontra = IdListarTreinador(id);
            if (encontra != null)
            {
                repositorio.Delete(encontra);
                return true;
            }
            return false;
        }
    }
}
