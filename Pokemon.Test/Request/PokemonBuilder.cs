using Bogus;
using Pokemon.Domain.ValuesObject;

namespace Pokemon.Test.Request
{
    public class PokemonBuilder
    {
        public Domain.Models.Pokemon Builder()
        {
            // dotnet add package Bogus
            var fake = new Faker();

            var request = new Pokemon.Domain.Models.Pokemon
            {
                Nome = fake.Name.FirstName(),
                Tipo = (TipoPokemon)fake.Random.Int(1, 12),
            };

            //new Faker<Pokemon.Domain.Models.Pokemon>()
            //    .RuleFor(x => x.Nome, fake.Name.FirstName())
            //    .RuleFor(x => x.Tipo, fake.PickRandom<TipoPokemon>());

            return request;
        }
    }
}

// utilizando o bogus