using System;

namespace testeLocaliza.Domain.Exceptions
{
    public class ZeroNaoTemDivisor : Exception
    {
        public ZeroNaoTemDivisor() : base("Zero não possui Divisores")
        {
               
        }
    }
}
