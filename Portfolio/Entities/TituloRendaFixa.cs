using PortfolioConsole.Interfaces;

namespace PortfolioConsole.Entities
{
    public class TituloRendaFixa : IAtivoFinanceiro, IAtivoComVencimento
    {
        #region PROPRIEDADES

        // Se instanciar classe usando construtor vazio, a propriedade ficará null se nao usar '= string.Empty;' (evitando NullReferenceException).
        public string Nome { get; set; } = string.Empty; //CDB Prefixado 10% a.a.
        public DateTime DataAplicacao { get; set; } // 01/01/2026        
        public decimal TaxaAnual { get; set; } //10% aa
        public DateTime DataVencimento { get; set; } // 15/08/2027
        public decimal ValorInvestido { get; set; } //$10000,00
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

            //Ao adicionar a sufixo m em 365m, o C# entende que a operação deve ser tratada como decimal, preservando as casas decimais.
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
