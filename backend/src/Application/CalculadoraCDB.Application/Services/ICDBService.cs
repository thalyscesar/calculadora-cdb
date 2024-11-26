using CalculadoraCDB.Application.Request;
using CalculadoraCDB.Application.Response;

namespace CalculadoraCDB.Domain.Services.Interfaces
{
    public interface ICDBService
    {
        CDBResponseModel ObterValoresCDB(InvestimentoModel model);
    }
}
