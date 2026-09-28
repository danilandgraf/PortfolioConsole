using PortfolioConsole.Interfaces;
using System.Linq;

namespace PortfolioConsole.Portfolio
{    
    public class PortfolioBase <T> where T : IAtivoFinanceiro
    {
        #region PROPRIEDADES

        public List<T> Ativos = new List<T>();
        public decimal ValorTotal {
            get
            {
                var valorTotal = CalcularValorTotalAtivos();                
                return valorTotal;
            }
        }
            

        #endregion

        #region CONSTRUTORES
        public PortfolioBase()
        {
        }
        #endregion

        #region METODOS        
        public void AdicionarAtivo(T ativo)
        {
            Ativos.Add(ativo);
        }             

        public decimal CalcularValorTotalAtivos()
        {
            var valorTotal = 0m;

            foreach (var ativo in Ativos)
            {
                valorTotal += ativo.ValorAtual;
            }

            return valorTotal;
        }              
        public decimal CalcularRentabilidadeMediaPonderada()
        {
            var valorTotal = Ativos.Sum(a => a.ValorAtual);

            if (valorTotal == 0)
            {
                return 0;
            }
            
            return Ativos.Sum(
                a => a.CalcularRentabilidade() * a.ValorAtual
                ) / valorTotal;
        }
             
        public IEnumerable<T> FiltrarPor(Func<T, bool> predicado)
        {
            if (predicado == null)
            {
                return Ativos;
            }

            List<T> ativosFiltrados = new List<T>();

            foreach (var ativo in Ativos)
            {                
                if (predicado(ativo))
                {
                    ativosFiltrados.Add(ativo);
                }
            }

            return ativosFiltrados;
        }
        #endregion
    }
}
