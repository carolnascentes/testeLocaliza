using Xunit;
using testeLocaliza.Domain;

namespace testeLocaliza.Tests
{
    public class FuncoesDivisoresTests
    {
        [Theory]
        [InlineData(0)]
        public void TestaDivisores(int numero)
        {
            var funcoes = new Funcoes();

            var divisor = funcoes.ObtemDivisores(numero);

            Assert.NotNull(divisor.Excecao);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        public void TestaDivisores1(int numero)
        {
            var funcoes = new Funcoes();

            var divisor = funcoes.ObtemDivisores(numero);

            Assert.Single(divisor.Data);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(-2)]
        [InlineData(int.MaxValue)]
        [InlineData(-int.MaxValue)]
        public void TestaDivisores2(int numero)
        {
            var funcoes = new Funcoes();

            var divisor = funcoes.ObtemDivisores(numero);

            Assert.Equal(2, divisor.Data.Count);
        }

        [Theory]
        [InlineData(500)]
        [InlineData(-500)]
        public void TestaDivisores500(int numero)
        {
            //46.3 sec
            var funcoes = new Funcoes();

            var divisor = funcoes.ObtemDivisores(numero);

            Assert.Equal(12, divisor.Data.Count);
        }

        [Theory]
        [InlineData(5000)]
        [InlineData(-5000)]
        [InlineData(1287333)]
        [InlineData(-1287333)]
        public void TestaDivisores5000(int numero)
        {
            var funcoes = new Funcoes();

            var divisor = funcoes.ObtemDivisores(numero);

            Assert.Equal(20, divisor.Data.Count);
        }

        [Theory]
        [InlineData(1287333234)]
        [InlineData(-1287333234)]
        public void TestaDivisores1287333234(int numero)
        {
            //27,9
            var funcoes = new Funcoes();

            var divisor = funcoes.ObtemDivisores(numero);

            Assert.Equal(48, divisor.Data.Count);
        }
    }
}
