using Moq;
using Pokemon.Domain.Repository;
using Pokemon.Domain.Services;
using Pokemon.Test.Request;
using System.ComponentModel.DataAnnotations;

namespace Pokemon.Test.Services
{
    public class PokemonTest
    {
        [Fact]
        public void SucessCadastra()
        {
            var criar = new PokemonBuilder();
            var pokemon = criar.Builder();
       
            var x = new List<ValidationResult>();

            var result = Validator.TryValidateObject(pokemon, new ValidationContext(pokemon), x, true);

            Assert.True(result);
        }

        [Fact]
        public void ErroCadastro()
        {
            var builder = new PokemonBuilder();
            var pokemon = builder.Builder();

            var x = new List<ValidationResult>();

            pokemon.Nome = string.Empty;
            var result = Validator.TryValidateObject(pokemon, new ValidationContext(pokemon), x, true);

            Assert.False(result);

        }
        // foi utilizado o dotnet add package Moq
        [Fact]
        public void SucessDeletar()
        {
            var builder = new PokemonBuilder();
            var pokemon = builder.Builder();

            var mockRepo = new Mock<IRepository>();
            var mockValidator = new Mock<ValidatorService>(); 

            var service = new PokemonService(mockRepo.Object, mockValidator.Object);

            var X = service.Deletar(pokemon.Id);

            Assert.True(X);

        }

        [Fact]
        public void ErroDeletar()
        {
            var builder = new PokemonBuilder();
            var pokemon = builder.Builder();

            var mockRepo = new Mock<IRepository>();
            var mockValidator = new Mock<ValidatorService>();

            pokemon.Id = 0;

            var service = new PokemonService(mockRepo.Object, mockValidator.Object);

            var X = service.Deletar(pokemon.Id);

            Assert.False(X);

        }
    }
}
