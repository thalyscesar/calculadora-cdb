

using CalculadoraCDB.Application.Request;
using CalculadoraCDB.Application.Response;
using CalculadoraCDB.Domain.Entities;
using CalculadoraCDB.Domain.Services.Interfaces;

namespace CalculadoraCDB.Domain.Services
{
    public class CDBService : ICDBService
    {
        public CDBResponseModel ObterValoresCDB(InvestimentoModel model)
        {
            var calculadoraCDB = new CalculadoraDoCDB(model.Valor, model.Mes);
            var valorLiquido = Math.Round(calculadoraCDB.CalcularValorLiquido(),3);
            var valorBruto = Math.Round(calculadoraCDB.CalcularValorBruto(),3);
            return new CDBResponseModel { ValorBruto =  valorBruto, ValorLiquido = valorLiquido };

        }
    }
}
