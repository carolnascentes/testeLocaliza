using System;

namespace testeLocaliza.Domain.Exceptions
{
    public class NaoExisteDivisores : Exception
    {
        public NaoExisteDivisores() : base("Não foram encontrados divisores para o número informado")
        {

        }
    }
}
