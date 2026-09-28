using PortfolioConsole.Interfaces;

namespace PortfolioConsole.Entities
{
    public class Acao : IAtivoFinanceiro, IGeradorDeRenda, IAtivoNegociavel
    {
        #region PROPRIEDADES
        public string Nome { get; set; } = string.Empty; 
        public int Quantidade { get; set; }  
        public decimal PrecoMedioCompra { get; set; } 
        public decimal PrecoMercado { get; set; } 
        public decimal DividendosRecebidos { get; set; } 
        public decimal DividendoPorAcao { get; set; } 
        public string Periodicidade { get; set; } = string.Empty; 
        public decimal VariacaoDiaria { get; set; } 
        public decimal ValorInvestido
        {
            get
            {
                return Quantidade * PrecoMedioCompra;
            }
        }
        public decimal ValorAtual
        {
            get
            {
                return Quantidade * PrecoMercado;
            }
        }
        #endregion

        #region CONSTRUTORES E METODOS
                
        public Acao() { }
                
        public Acao(
            string nome, 
            int quantidade, 
            decimal precoMedioCompra, 
            decimal precoMercado, 
            decimal dividendosRecebidos, 
            decimal dividendoPorAcao, 
            string periodicidade, 
            decimal variacaoDiaria)
        {
            Nome = nome;
            Quantidade = quantidade;
            PrecoMedioCompra = precoMedioCompra;
            PrecoMercado = precoMercado;
            DividendosRecebidos = dividendosRecebidos;
            DividendoPorAcao = dividendoPorAcao;
            Periodicidade = periodicidade;
            VariacaoDiaria = variacaoDiaria;
        }
        public decimal CalcularRentabilidade()
        {
            var total = (ValorAtual + DividendosRecebidos) - ValorInvestido;

            var rentabilidade = (total / ValorInvestido) * 100m;

            return rentabilidade;
        }

        public decimal CalcularRendaPeriodica()
        {
            var rendaPeriodica = Quantidade * DividendoPorAcao;

            return rendaPeriodica;
        }
        #endregion
    }
}
