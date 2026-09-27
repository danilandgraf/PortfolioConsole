using PortfolioConsole.Interfaces;

namespace PortfolioConsole.Entities
{
    public class FundoInvestimento : IAtivoFinanceiro, IGeradorDeRenda
    {
        #region PROPRIEDADES
        public string Nome { get; set; } = string.Empty; //Fundo Multimercado XP
        public int QuantidadeCotas { get; set; } //100
        public decimal ValorCotaCompra { get; set; } //$80,00
        public decimal ValorCotaAtual { get; set; } //$84,20
        // Taxa: atributos específicos dentro de cada classe concreta preserva a coesão da classe sem poluir a interface base.
        public decimal TaxaAdministracao { get; set; } //1,20%
        public decimal RendimentoPorCota { get; set; } //$0,50
        public string Periodicidade { get; set; } = string.Empty;//Mensal 
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
