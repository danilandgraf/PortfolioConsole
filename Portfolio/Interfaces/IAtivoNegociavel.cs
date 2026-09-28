namespace PortfolioConsole.Interfaces
{    
    public interface IAtivoNegociavel
    {
        decimal PrecoMercado { get; }
        decimal VariacaoDiaria { get; }
    }
}
