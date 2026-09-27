namespace PortfolioConsole.Interfaces
{
    //Interface para ativos especificos: que sofrem cotação de mercado
    public interface IAtivoNegociavel
    {
        decimal PrecoMercado { get; }
        decimal VariacaoDiaria { get; }
    }
}
