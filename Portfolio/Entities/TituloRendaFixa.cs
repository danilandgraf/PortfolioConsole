using PortfolioConsole.Interfaces;

namespace PortfolioConsole.Entities
{
    public class TituloRendaFixa : IAtivoFinanceiro, IAtivoComVencimento
    {
        #region PROPRIEDADES
                
        public string Nome { get; set; } = string.Empty; 
        public DateTime DataAplicacao { get; set; }      
        public decimal TaxaAnual { get; set; } 
        public DateTime DataVencimento { get; set; } 
        public decimal ValorInvestido { get; set; } 
        public decimal ValorAtual 
        {
            get 
            {
                decimal percentualRentabilidade = CalcularRentabilidade();
                decimal lucro = ValorInvestido * (percentualRentabilidade / 100m);
                return ValorInvestido + lucro;
            }
        }
        #endregion

        #region CONSTRUTORES E METODOS
        public TituloRendaFixa()
        {
        }

        public TituloRendaFixa(
            string nome, 
            DateTime dataAplicacao, 
            decimal valorInvestido, 
            decimal taxaAnual, 
            DateTime dataVencimento)
        {
            Nome = nome;
            DataAplicacao = dataAplicacao;
            ValorInvestido = valorInvestido;
            TaxaAnual = taxaAnual;
            DataVencimento = dataVencimento;
        }        
        public decimal CalcularRentabilidade()
        {
            int diasDecorridos = (DateTime.Today - DataAplicacao.Date).Days;         
                        
            var rentabilidade = TaxaAnual * (diasDecorridos / 365m);

            return rentabilidade;
        }

        public int DiasParaVencimento()
        {
            var diasParaVencimento = (DataVencimento.Date - DateTime.Today).Days;

            return diasParaVencimento;            
        }
        #endregion
    }
}
