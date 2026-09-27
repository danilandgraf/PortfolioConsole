using System.Globalization;
using PortfolioConsole.Entities;
using PortfolioConsole.Interfaces;
using PortfolioConsole.Portfolio;
using PortfolioConsole.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
        // ( => ) Expression-Bodid Member: uma "propriedade readonly" onde o valor é calculado em tempo de execução toda vez que é acessado

        var portfolio = new PortfolioBase<IAtivoFinanceiro>();

        var acao = new Acao(
            nome: "PETR4",
            quantidade: 100,
            precoMedioCompra: 30.00m,
            precoMercado: 32.50m,
            dividendosRecebidos: 100.00m,
            dividendoPorAcao: 0.80m,
            periodicidade: "Trimestral",
            variacaoDiaria: 1.25m
            );

        portfolio.AdicionarAtivo(acao);

        var tituloRendafixa = new TituloRendaFixa(
            nome: "CDB Prefixado 10% a.a.",
            dataAplicacao: DateTime.Today.AddDays(-180), 
            taxaAnual: 10.0m,
            dataVencimento: DateTime.Today.AddDays(10),
            valorInvestido: 1000.00m);
        
        portfolio.AdicionarAtivo(tituloRendafixa);

        var fundoInvestimento = new FundoInvestimento(
            nome: "Fundo Multimercado XP",
            quantidadeCotas: 100, 
            valorCotaCompra: 80.00m,
            valorCotaAtual: 84.20m,
            taxaAdministracao: 1.20m,
            rendimentoPorCota: 0.50m,
            periodicidade:  "Mensal");

        portfolio.AdicionarAtivo(fundoInvestimento);

        GeradorRelatorio.ImprimirRelatorioGeral(portfolio);

        Console.ReadKey();
    }
}