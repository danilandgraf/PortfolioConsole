namespace PortfolioConsole.Interfaces
{
    //Interface base: comum a todosos Ativos Financeiros
    //Interface Segregation Principle (ISP): cada ativo financeiro pode ter métodos específicos, mas todos compartilham a interface base IAtivoFinanceiro.
    public interface IAtivoFinanceiro
    {
        string Nome { get; }
        decimal ValorInvestido { get; }
        decimal ValorAtual { get; }
        public decimal CalcularRentabilidade();
    }
}
