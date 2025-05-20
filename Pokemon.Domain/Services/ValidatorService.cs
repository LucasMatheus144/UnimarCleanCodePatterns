using Pokemon.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Services
{
    public class ValidatorService
    {

        public bool ValidaModelos<AllModels>(AllModels obj, out List<MensagemErro> msg)
        {
            var Result = new List<ValidationResult>();

            var IsValid = Validator.TryValidateObject(obj, new ValidationContext(obj), Result, true);

            msg = new List<MensagemErro>();

            if (!IsValid)
            {
                msg = Result
                    .Select(x => new MensagemErro(x.MemberNames.First(), TratarMsg(x.ErrorMessage)))
                    .ToList();
            }

            return IsValid;
        }


        public string TratarMsg(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return "Deu xabu ai";

            else if (msg.Contains("Is required")) return "So alguma coisa ai";

            return msg;
        }
    }
}
