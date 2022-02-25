using System;
using System.Collections;
using Bogus;
using Bogus.DataSets;
using Features.Clientes;
using Xunit;

namespace Features.Tests
{
    [CollectionDefinition(nameof(ClienteTestsBogusCollection))]
    public class ClienteTestsBogusCollection : ICollectionFixture<ClienteTestsFixture>
    {
    }

    public class ClienteTestsBogusFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            //var email = new Faker().Internet.Email("maria", "lopes", "live");
            //var clientefaker = new Faker<Cliente>();
            //clientefaker.RuleFor(c => c.Nome, (f, c) => f.Name.FirstName());

            var cliente = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(f => new Cliente(
                    Guid.NewGuid(),
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    f.Date.Past(80, DateTime.Now.AddYears(-18)),
                    "",
                    true,
                    DateTime.Now))
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLowerInvariant(), "live"));
            return cliente;
        }

        public Cliente GerarClienteInvalido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                "hengtan-live.com",
                true,
                DateTime.Now);
            return cliente;
        }

        public void Dispose()
        {
        }
    }
}