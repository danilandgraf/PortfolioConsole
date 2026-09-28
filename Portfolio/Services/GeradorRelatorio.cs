using System.Reflection;
using PortfolioConsole.Interfaces;
using PortfolioConsole.Portfolio;

namespace PortfolioConsole.Services
{
    public class GeradorRelatorio
    {        
        public static void ImprimirRelatorioGeral(PortfolioBase<IAtivoFinanceiro> portfolio)
        {
            // --- IMPRESSÃO FORMATADA ---
            Console.WriteLine(" ");

            // --- IMPRESSÃO PORTFOLIO DE INVESTIMENTOS---
            Console.WriteLine("=== Portfólio de Investimentos ===");
            Console.WriteLine(" ");
            Console.WriteLine($"Valor total: {portfolio.ValorTotal}");
            Console.WriteLine($"Rentabilidade média: {portfolio.CalcularRentabilidadeMediaPonderada()}%");
            Console.WriteLine(" ");

            // --- IMPRESSÃO RENDA PERIODICA TOTAL---
            Console.WriteLine("=== Renda Periódica Total ===");
            Console.WriteLine("(apenas ativos que implementam IGeradorDeRenda)");
            Console.WriteLine(" ");

            //Inspecao da Interface IGeradorDeRenda 
            decimal rendaTotal = 0m;
            foreach (var ativo in portfolio.Ativos)
            {
                if (ativo is IGeradorDeRenda geradorRenda)
                {
                    rendaTotal += geradorRenda.CalcularRendaPeriodica();
                }
            }
            Console.WriteLine($"Renda periódica: {rendaTotal}");
            Console.WriteLine(" ");

            // --- IMPRESSÃO ATIVOS PROXIMOS DO VENCIMENTO---
            Console.WriteLine("=== Ativos próximos do vencimento ===");
            Console.WriteLine("(próximos 180 dias)");
            Console.WriteLine(" ");

            //Inspecao do Método "DiasParaVencimento"
            foreach (var ativo in portfolio.Ativos)
            {
                MethodInfo metodoDiasParaVencimento = ativo.GetType().GetMethod("DiasParaVencimento");                
                
                if (metodoDiasParaVencimento != null)
                {
                    var dias = (int)metodoDiasParaVencimento.Invoke(ativo, null);            
                    if (dias >= 0 && dias <= 180)
                    {
                        Console.WriteLine($"- {ativo.Nome} -> vence em {dias} dias");
                    }
                }
            }
            Console.WriteLine(" ");

            // --- IMPRESSÃO RELATORIO DINAMICO---
            Console.WriteLine("=== Relatório Dinâmico (via Reflection) ===");
            Console.WriteLine(" ");

            foreach (var ativo in portfolio.Ativos)
            {                
                Type tipoAtivo = ativo.GetType();
                Console.WriteLine($"Tipo: {tipoAtivo.Name}");
                
                PropertyInfo[] propriedades = tipoAtivo.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo propriedade in propriedades)
                {
                    var value = propriedade.GetValue(ativo);

                    Console.WriteLine($"  {propriedade.Name}: {value}");
                }
                
                MethodInfo metodoRentabilidade = tipoAtivo.GetMethod("CalcularRentabilidade");
                if (metodoRentabilidade != null)
                {
                    decimal rentabilidade = (decimal)metodoRentabilidade.Invoke(ativo, null);
                    Console.WriteLine($"  Rentabilidade: {rentabilidade}%");
                }
                                
                var interfaces = tipoAtivo.GetInterfaces()
                    .Where(i => i != typeof(IAtivoFinanceiro))
                    .Select(i => i.Name);

                if (interfaces.Any())
                {
                    Console.WriteLine($"  -> Implementa: {string.Join(", ", interfaces)}");
                }

                Console.WriteLine(" ");
            }
        }
    }
}
