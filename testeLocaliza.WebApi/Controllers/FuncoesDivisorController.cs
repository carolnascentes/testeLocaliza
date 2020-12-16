using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
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

                var gerouExcecao = ValidarRetorno(result, false);

                if (gerouExcecao != null)
                    return gerouExcecao;

                var resultPrimos = funcoes.ObtemDivisoresPrimos(result.Data);

                gerouExcecao = ValidarRetorno(resultPrimos, true);

                if (gerouExcecao != null)
                    return gerouExcecao;

                return Ok(new RetornaDadosModel(string.Join(';', result.Data), string.Join(';', resultPrimos.Data)));
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                return BadRequest("Erro interno. Favor tentar mais tarde");
            }
        }

        private BadRequestObjectResult ValidarRetorno(Result<List<int>> result, bool isPrimo)
        {
            if (result.Excecao != null)
            {
                return BadRequest(result.Excecao.Message);
            }

            if (result.Data == null || !result.Data.Any())
            {
                return BadRequest(isPrimo ? "Não foram encontrados Divisores Primos" : "Não foram encontrados Divisores");
            }

            return null;
        }
    }
}
