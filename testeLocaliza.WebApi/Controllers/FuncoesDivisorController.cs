using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Linq;
using testeLocaliza.Domain;
using testeLocaliza.WebApi.Models;

namespace testeLocaliza.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncoesDivisorController : ControllerBase
    {
        [HttpGet]
        [Route("Obter/{numero}")]
        public ActionResult Obter(int numero)
        {
            try
            {
                var funcoes = new Funcoes();

                var result = funcoes.ObtemDivisores(numero);

                if (result.Excecao != null)
                {
                    return BadRequest(result.Excecao.Message);
                }

                if (result.Data == null || !result.Data.Any())
                {
                    return BadRequest("Não foram encontrados Divisores");
                }

                var resultPrimos = funcoes.ObtemDivisoresPrimos(result.Data);

                if (resultPrimos.Excecao != null)
                {
                    return BadRequest(resultPrimos.Excecao.Message);
                }

                if (resultPrimos.Data == null || !resultPrimos.Data.Any())
                {
                    return BadRequest("Não foram encontrados Divisores Primos");
                }

                return Ok(new RetornaDadosModel(string.Join(';', result.Data), string.Join(';', resultPrimos.Data)));
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                return BadRequest("Erro interno. Favor tentar mais tarde");
            }
        }
    }
}
