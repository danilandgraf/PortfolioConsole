namespace PortfolioConsole.Interfaces
{
    //Interface para ativos especificos: que possuem prazo de validade
    public interface IAtivoComVencimento
    {
        DateTime DataVencimento { get; }
        public int DiasParaVencimento();
    }
}
