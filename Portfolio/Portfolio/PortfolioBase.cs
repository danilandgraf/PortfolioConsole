using PortfolioConsole.Interfaces;
using System.Linq;

namespace PortfolioConsole.Portfolio
{
    //Generic com restricao (constraint) de IAtivoFinanceiro
    //A restrição garante ao compilador que qualquer tipo passado como T terá todas as propriedades e métodos de IAtivoFinanceiro
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

        #region CONSTRUTORS
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

        // Professor
        // Realizar cálculo de forma polimórfica, utilizando apenas os membros definidos por IAtivoFinanceiro
        // Ela respeita integralmente o polimorfismo da interface IAtivoFinanceiro sem necessitar de if ou switch para checar os tipos concretos
        public decimal CalcularRentabilidadeMediaPonderada()
        {
            var valorTotal = Ativos.Sum(a => a.ValorAtual);

            if (valorTotal == 0)
            {
                return 0;
            }

            //.Sum() é um método de extensão do LINQ
            return Ativos.Sum(
                a => a.CalcularRentabilidade() * a.ValorAtual
                ) / valorTotal;
        }

        // Filtro: é um delegate (um ponteiro para uma função/regra).
        // "Me passe uma regra que recebe um objeto do tipo T e responde true ou false".
        public IEnumerable<T> FiltrarPor(Func<T, bool> predicado)
        {
            if (predicado == null)
            {
                return Ativos;
            }

            List<T> ativosFiltrados = new List<T>();

            foreach (var ativo in Ativos)
            {
                // Se a condição for verdadeira para o ativo, adiciona à lista filtrada
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
