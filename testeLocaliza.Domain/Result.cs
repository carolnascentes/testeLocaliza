using System;

namespace testeLocaliza.Domain
{
    public class Result<T>
    {
        public T Data { get; set; }
        public Exception Excecao { get; set; }

        public Result(T data, Exception exception = null)
        {
            Data = data;
            Excecao = exception;
        }
    }
}
