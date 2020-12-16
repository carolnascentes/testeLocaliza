using Xunit;
using testeLocaliza.Domain;
using System.Collections.Generic;

namespace testeLocaliza.Tests
{
    public class FuncoesDivisoresPrimosTests
    {
        [Fact]
        public void TestaDivisoresVazio()
        {
            var funcoes = new Funcoes();

            var divisor = funcoes.ObtemDivisoresPrimos(new List<int>());

            Assert.NotNull(divisor.Excecao);
        }

        [Fact]
        public void TestaDivisores0()
        {
            var funcoes = new Funcoes();

            var divisor = funcoes.ObtemDivisoresPrimos(new List<int>() { 0 });

            Assert.Empty(divisor.Data);
        }

        [Fact]
        public void TestaDivisoresNull()
        {
            var funcoes = new Funcoes();

            var divisor = funcoes.ObtemDivisoresPrimos(null);

            Assert.NotNull(divisor.Excecao);
        }

        [Fact]
        public void TestaDivisoresPrimos2()
        {
            var listaDivisores = new List<int>() { 2, 1 };

            var funcoes = new Funcoes();
            var divisor = funcoes.ObtemDivisoresPrimos(listaDivisores);

            Assert.Single(divisor.Data);
        }

        [Fact]
        public void TestaDivisoresPrimos2Negativo()
        {
            var listaDivisores = new List<int>() { -2, -1 };

            var funcoes = new Funcoes();
            var divisor = funcoes.ObtemDivisoresPrimos(listaDivisores);

            Assert.Single(divisor.Data);
        }

        [Fact]
        public void TestaDivisoresPrimos2147483647()
        {
            var listaDivisores = new List<int>() { 2147483647, 1 };

            var funcoes = new Funcoes();
            var divisor = funcoes.ObtemDivisoresPrimos(listaDivisores);

            Assert.Single(divisor.Data);
        }

        [Fact]
        public void TestaDivisoresPrimos2147483647Neg()
        {
            var listaDivisores = new List<int>() { -2147483647, -1 };

            var funcoes = new Funcoes();
            var divisor = funcoes.ObtemDivisoresPrimos(listaDivisores);

            Assert.Single(divisor.Data);
        }

        [Fact]
        public void TestaDivisoresPrimos214748364()
        {
            var listaDivisores = RetornaDadosTeste.retornadivisores214748364;

            var funcoes = new Funcoes();
            var divisor = funcoes.ObtemDivisoresPrimos(listaDivisores);

            Assert.Equal(6, divisor.Data.Count);
        }

        [Fact]
        public void TestaDivisoresPrimos214748364Neg()
        {
            var listaDivisores = RetornaDadosTeste.retornadivisores214748364Neg;

            var funcoes = new Funcoes();
            var divisor = funcoes.ObtemDivisoresPrimos(listaDivisores);

            Assert.Equal(6, divisor.Data.Count);
        }
    }
}
