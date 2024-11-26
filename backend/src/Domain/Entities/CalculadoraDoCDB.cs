using CalculadoraCDB.Domain.Utils;

namespace CalculadoraCDB.Domain.Entities
{
    public class CalculadoraDoCDB
    {
        public CalculadoraDoCDB(decimal valorInicial, int meses)
        {
            ValorInicial = valorInicial;
            Meses = meses;
        }

        public decimal ValorInicial { get; private set; }
        public int Meses { get; private set; }

        public decimal CalcularValorBruto()
        {
            decimal valorBruto = ValorInicial;

            for (int i = 0; i < Meses; i++)
            {
                valorBruto *= (1 + (Constantes.CDI * Constantes.TAXA_BANCARIA));
            }

            return valorBruto;
        }

        public decimal CalcularValorLiquido()
        {
            decimal valorBruto = CalcularValorBruto();
            decimal rendimento = valorBruto - ValorInicial;
            decimal imposto = rendimento * ObterTaxaImposto();
            return valorBruto - imposto;
        }

        public decimal ObterTaxaImposto()
        {
            if (Meses <= 6) return 0.225m;
            if (Meses <= 12) return 0.20m;
            if (Meses <= 24) return 0.175m;
            return 0.15m;
        }


    }
}
