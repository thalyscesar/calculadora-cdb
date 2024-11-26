using CalculadoraCDB.Domain.Entities;
using System.ComponentModel;

namespace CalculadoraCDB.Tests
{
    public class CalculadoraCDBTest
    {
        [Fact]
        [Trait("Valores", "CalcularValoresCDB")]
        public void CalcularValorBruto_DeveRetornarValorEsperado()
        {
           // Arrange
           var calculadoraCDB = new CalculadoraDoCDB(600, 6);

           // Act 
           var valorBruto = calculadoraCDB.CalcularValorBruto();

           // Assert
           Assert.Equal(635.853m, Math.Round(valorBruto,3));

        }

        [Fact]
        [Trait("Valores", "CalcularValoresCDB")]
        public void CalcularValorLiquidoDeveRetornarValorEsperado()
        {
            // Arrange
            var calculadoraCDB = new CalculadoraDoCDB(800, 6);

            // Act 
            var valorLiquido = Math.Round(calculadoraCDB.CalcularValorLiquido(), 3);

            // Assert
            Assert.Equal(837.049M, valorLiquido);
        }

        [Fact]
        [Trait("Imposto", "ObterImpostosParaCadaEpoca")]
        public void RetornarTaxaImpostoAte6MesesDeveRetornarAliquotaCorreta()
        {
            // Arrange
            var calculadoraCDB = new CalculadoraDoCDB(600, 5);

            // Act 
            var imposto = calculadoraCDB.ObterTaxaImposto();

            // Assert
            Assert.Equal(0.225M, imposto);

        }

        [Fact]
        [Trait("Imposto", "ObterImpostosParaCadaEpoca")]
        public void RetornarTaxaImpostoAte12MesesDeveRetornarAliquotaCorreta()
        {
            // Arrange
            var calculadoraCDB = new CalculadoraDoCDB(600, 11);

            // Act 
            var imposto = calculadoraCDB.ObterTaxaImposto();

            // Assert
            Assert.Equal(0.20M, imposto);
        }

        [Fact]
        [Trait("Imposto", "ObterImpostosParaCadaEpoca")]
        public void RetornarTaxaImpostoAte24MesesDeveRetornarAliquotaCorreta()
        {
            // Arrange
            var calculadoraCDB = new CalculadoraDoCDB(600, 15);

            // Act 
            var imposto = calculadoraCDB.ObterTaxaImposto();

            // Assert
            Assert.Equal(0.175M, imposto);
        }


        [Fact]
        [Trait("Imposto", "ObterImpostosParaCadaEpoca")]
        [Description("RetornarTaxaImpostoAcimade24MesesDeveRetornarAliquotaCorreta")]
        public void RetornarTaxaImpostoAcimade24MesesDeveRetornarAliquotaCorreta()
        {
            // Arrange
            var calculadoraCDB = new CalculadoraDoCDB(600, 29);

            // Act 
            var imposto = calculadoraCDB.ObterTaxaImposto();

            // Assert
            Assert.Equal(0.15M, imposto);
        }



    }
}