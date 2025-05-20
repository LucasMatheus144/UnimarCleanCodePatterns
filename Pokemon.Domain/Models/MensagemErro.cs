using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Models
{
    public class MensagemErro
    {
      
        public string Propriedade { get; set; }

        public string Mensagem { get; set; }

        public MensagemErro(string propriedade, string mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;
        }
    }
}
