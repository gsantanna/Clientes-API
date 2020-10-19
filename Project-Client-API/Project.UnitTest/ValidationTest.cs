using Project.Domain.Entities;
using Project.Domain.Validations;
using System;
using Xunit;

namespace Project.UnitTest
{
    public class ValidationTest
    {
        [Fact]
        public void DeveValidarCPF()
        {
            var validation = new ClienteValidation().Validate(new Cliente(21, "Teste Nome", "48192605027", 35, new DateTime(2010 - 9 - 19)));

            Assert.True(validation.IsValid);
        }

        [Fact]
        public void DeveValidarCPFErrado()
        {
            var validation = new ClienteValidation().Validate(new Cliente(21, "Teste Nome", "03298406740", 35, new DateTime(2010 - 9 - 19)));

            Assert.False(validation.IsValid);
        }
    }
}
