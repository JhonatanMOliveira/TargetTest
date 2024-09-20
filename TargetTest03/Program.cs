//3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora de todos os dias de um ano, faça um programa, na linguagem que desejar, que calcule e retorne:

//-O menor valor de faturamento ocorrido em um dia do ano;
//-O maior valor de faturamento ocorrido em um dia do ano;
//-Número de dias no ano em que o valor de faturamento diário foi superior à média anual.

//a) Considerar o vetor já carregado com as informações de valor de faturamento.

//b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média.

//c) Utilize o algoritmo mais veloz que puder definir.

class Program
{
    static void Main()
    {
        double[] faturamentoDiario = {
            1500, 2000, 0, 3000, 2500, 0, 4000, 0, 3500, 5000,
            0, 3200, 0, 1800, 0, 0, 3600
        };

        double menorFaturamento = ObterMenorFaturamento(faturamentoDiario);
        double maiorFaturamento = ObterMaiorFaturamento(faturamentoDiario);
        double mediaFaturamento = CalcularMediaFaturamento(faturamentoDiario);
        int diasAcimaMedia = ContarDiasAcimaMedia(faturamentoDiario, mediaFaturamento);

        Console.WriteLine($"Menor Faturamento: {menorFaturamento}");
        Console.WriteLine($"Maior Faturamento: {maiorFaturamento}");
        Console.WriteLine($"Dias acima da média: {diasAcimaMedia}");
    }

    static double ObterMenorFaturamento(double[] faturamento)
    {
        double menor = double.MaxValue;

        foreach (var valor in faturamento)
        {
            if (valor > 0 && valor < menor)
            {
                menor = valor;
            }
        }

        return menor;
    }

    static double ObterMaiorFaturamento(double[] faturamento)
    {
        double maior = double.MinValue;

        foreach (var valor in faturamento)
        {
            if (valor > maior)
            {
                maior = valor;
            }
        }

        return maior;
    }

    static double CalcularMediaFaturamento(double[] faturamento)
    {
        double total = 0;
        int diasComFaturamento = 0;

        foreach (var valor in faturamento)
        {
            if (valor > 0)
            {
                total += valor;
                diasComFaturamento++;
            }
        }

        return diasComFaturamento > 0 ? total / diasComFaturamento : 0;
    }

    static int ContarDiasAcimaMedia(double[] faturamento, double media)
    {
        int contador = 0;

        foreach (var valor in faturamento)
        {
            if (valor > media)
            {
                contador++;
            }
        }

        return contador;
    }
}
