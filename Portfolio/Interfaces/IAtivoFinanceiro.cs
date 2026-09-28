namespace PortfolioConsole.Interfaces
{    
    public interface IAtivoFinanceiro
    {
        string Nome { get; }
        decimal ValorInvestido { get; }
        decimal ValorAtual { get; }
        public decimal CalcularRentabilidade();
    }
}
