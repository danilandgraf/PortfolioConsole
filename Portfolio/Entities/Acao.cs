using PortfolioConsole.Interfaces;

namespace PortfolioConsole.Entities
{
    public class Acao : IAtivoFinanceiro, IGeradorDeRenda, IAtivoNegociavel
    {
        #region PROPRIEDADES
        public string Nome { get; set; } = string.Empty; //PETR4
        public int Quantidade { get; set; } //100 //Particular 
        public decimal PrecoMedioCompra { get; set; } //$30,00
        public decimal PrecoMercado { get; set; } //$32,50 //Particular 
        public decimal DividendosRecebidos { get; set; } //$100,00
        public decimal DividendoPorAcao { get; set; } //$0,80
        public string Periodicidade { get; set; } = string.Empty; //Trimestral
        public decimal VariacaoDiaria { get; set; } //1,25%
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

        //Construtor Padrão (Vazio): Permite criar a classe sem passar nenhuma informação inicial.
        //Por padrão, quando você não escreve nenhum construtor na sua classe, o compilador do C# cria o public Acao() { } de graça nos bastidores.
        //No entanto, no momento em que você cria qualquer construtor com parâmetros, o C# remove esse construtor padrão automático.
        //Frameworks de banco de dados (EF Core), bibliotecas de JSON (System.Text.Json) e APIs exigem obrigatoriamente um construtor vazio para conseguir ler os dados do banco ou da rede e preencher as propriedades automaticamente.
        public Acao() { }

        //Construtor Parametrizado: Obriga quem está criando o objeto a fornecer todas as informações necessárias de uma só vez.
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
