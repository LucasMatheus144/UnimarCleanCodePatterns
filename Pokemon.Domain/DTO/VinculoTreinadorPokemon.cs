using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.DTO
{
    public class VinculoTreinadorPokemon
    {
        public int Id { get; set; }

        public DateTime DataCadastro { get; private set; } = DateTime.Now;

        public string Nome { get; set; } = String.Empty;

        public int IdPokemon { get; set; }
    }
}
