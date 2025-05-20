using Pokemon.Domain.Interface;
using Pokemon.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Models
{
    public class Pokemon : IEntidade
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = String.Empty;

        public TipoPokemon Tipo { get; set; }

        private int _nivel = new Random().Next(250, 3000);

        public int Nivel
        {
            get => this.Nivel;
            private set => _nivel = value; 
        }
    }
}
