using Pokemon.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Models
{
    public class Treinador : IEntidade
    {
        public int Id { get; set; }

        public DateTime DataCadastro { get; private set; } = DateTime.Now;

        public string Nome { get; set; } = String.Empty;

        public Pokemon Pokemon { get; set; }
    }
}
