using System;
using System.Linq;
using testeLocaliza.Domain;

namespace testeLocaliza
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um número");

            var valor = Console.ReadLine();

            if (!int.TryParse(valor, out int numero))
            {
                Console.WriteLine("Número Inválido");
                return;
            }

            var funcoes = new Funcoes();

            var result = funcoes.ObtemDivisores(numero);

            if (result.Excecao != null)
                Console.WriteLine(result.Excecao.Message);

            if (result.Data == null || !result.Data.Any())
            {
                Console.WriteLine("Não foram encontrados Divisores");
                return;
            }

            var resultPrimos = funcoes.ObtemDivisoresPrimos(result.Data);

            if (result.Excecao != null)
                Console.WriteLine(resultPrimos.Excecao.Message);

            Console.WriteLine($"Divisores: {string.Join(';', result.Data)}");

            if (resultPrimos.Data == null || !resultPrimos.Data.Any())
            {
                Console.WriteLine("Não foram encontrados Divisores Primos");
                return;
            }

            Console.WriteLine($"DivisoresPrimos: {string.Join(';', resultPrimos.Data)}");

            Console.ReadKey();
        }
    }
}
