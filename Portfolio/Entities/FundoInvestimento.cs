using PortfolioConsole.Interfaces;

namespace PortfolioConsole.Entities
{
    public class FundoInvestimento : IAtivoFinanceiro, IGeradorDeRenda
    {
        #region PROPRIEDADES
        public string Nome { get; set; } = string.Empty; 
        public int QuantidadeCotas { get; set; } 
        public decimal ValorCotaCompra { get; set; } 
        public decimal ValorCotaAtual { get; set; } 
        
        public decimal TaxaAdministracao { get; set; } 
        public decimal RendimentoPorCota { get; set; } 
        public string Periodicidade { get; set; } = string.Empty;
        public decimal ValorInvestido
        {
            get
            {
                return QuantidadeCotas * ValorCotaCompra;
            }
        }
        public decimal ValorAtual
        {
            get
            {
                return QuantidadeCotas * ValorCotaAtual;
            }
        }


        #endregion

        #region CONSTRUTORES E METODOS
        public FundoInvestimento()
        {
        }

        public FundoInvestimento(
            string nome,
            int quantidadeCotas,
            decimal valorCotaCompra,
            decimal valorCotaAtual,
            decimal taxaAdministracao,
            decimal rendimentoPorCota,
            string periodicidade)
        {
            Nome = nome;
            QuantidadeCotas = quantidadeCotas;
            ValorCotaCompra = valorCotaCompra;
            ValorCotaAtual = valorCotaAtual;
            TaxaAdministracao = taxaAdministracao;
            RendimentoPorCota = rendimentoPorCota;
            Periodicidade = periodicidade;
        }

        public decimal CalcularRendaPeriodica()
        {
            var rendaPeriodica = QuantidadeCotas * RendimentoPorCota;

            return rendaPeriodica;
        }

        public decimal CalcularRentabilidade()
        {  

            var rentabilidade = ((ValorCotaAtual - ValorCotaCompra) / ValorCotaCompra) * 100;
            
            return rentabilidade;
        }
        #endregion
    }
}
