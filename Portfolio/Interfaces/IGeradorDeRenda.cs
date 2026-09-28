namespace PortfolioConsole.Interfaces
{    
    public interface IGeradorDeRenda
    {        
        string Periodicidade { get; }
        public decimal CalcularRendaPeriodica();
    }
}
