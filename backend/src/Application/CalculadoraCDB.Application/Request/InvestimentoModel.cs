using System.ComponentModel.DataAnnotations;

namespace CalculadoraCDB.Application.Request
{
    public class InvestimentoModel
    {
        [Range(0, int.MaxValue, ErrorMessage = "Informe um valor monetário positivo")]
        public decimal Valor { get; set; }


        [Range(2, int.MaxValue, ErrorMessage = "Meses deve ser maior que um")]
        public int Mes {  get; set; }
    }
}
