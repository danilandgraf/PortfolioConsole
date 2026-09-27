namespace PortfolioConsole.Interfaces
{
    //Interface para ativos especificos: que distribuem rendimentos periódicos
    public interface IGeradorDeRenda
    {        
        string Periodicidade { get; }
        public decimal CalcularRendaPeriodica();
    }
}
