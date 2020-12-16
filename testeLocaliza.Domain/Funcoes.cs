using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using testeLocaliza.Domain.Exceptions;

namespace testeLocaliza.Domain
{
    public class Funcoes
    {
        readonly MemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());
        
        /// <summary>
        /// Dado um número, é calculado os divisores desse número
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public Result<List<int>> ObtemDivisores(int numero)
        {
            if (numero == 0)
                return new Result<List<int>>(null, new ZeroNaoTemDivisor());

            return new Result<List<int>>(CalculaDivisores(numero));
        }

        /// <summary>
        /// Dado uma lista de divisores é retornado quais são primos
        /// </summary>
        /// <param name="divisores"></param>
        /// <returns></returns>
        public Result<List<int>> ObtemDivisoresPrimos(List<int> divisores)
        {
            if (divisores == null || divisores.Count == 0)
                return new Result<List<int>>(null, new NaoExisteDivisores());

            List<int> primos = new List<int>();

            foreach (var i in divisores)
            {
                var divisoresPrimos = CalculaDivisores(i);

                if (NumeroEhPrimo(divisoresPrimos))
                    primos.Add(i);
            }

            return new Result<List<int>>(primos);
        }

        private List<int> CalculaDivisores(int numero)
        {
            List<int> divisores = new List<int>();

            if (numero == 0 || _memoryCache.TryGetValue(numero, out divisores))
                return divisores;

            if (numero < 0)
            {
                divisores = CalculaDivisoresNumeroNegativo(numero);
            }
            else
            {
                divisores = CalculaDivisoresNumeroPositivo(numero);
            }

            return divisores;
        }

        private List<int> CalculaDivisoresNumeroPositivo(int numero)
        {
            List<int> divisores = new List<int>();

            for (int i = 1; i <= numero; i++)
            {
                if (numero % i == 0)
                    divisores.Add(i);

                if (i == int.MaxValue)
                    break;
            }

            IncluirCache(_memoryCache, numero, divisores);

            return divisores;
        }

        private List<int> CalculaDivisoresNumeroNegativo(int numero)
        {
            List<int> divisores = new List<int>();

            for (int i = numero; i <= -1; ++i)
            {
                if (numero % i == 0)
                    divisores.Add(i);
            }

            IncluirCache(_memoryCache, numero, divisores);

            return divisores;
        }

        private bool NumeroEhPrimo(List<int> divisores)
        {
            return divisores.Count == 2;
        }
        private static void IncluirCache(MemoryCache _memoryCache, int key, List<int> divisores)
        {
            var options = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(24));

            // Save data in cache.
            _memoryCache.Set(key, divisores, options);
        }
    }
}
