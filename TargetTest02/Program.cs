// 2) Descubra a lógica e complete o próximo elemento:

//a) 1, 3, 5, 7, ___

//b) 2, 4, 8, 16, 32, 64, ____

//c) 0, 1, 4, 9, 16, 25, 36, ____

//d) 4, 16, 36, 64, ____

//e) 1, 1, 2, 3, 5, 8, ____

//f) 2,10, 12, 16, 17, 18, 19, ____



class Program
{
    static void Main()
    {
        var numeros = LerNumeros();

        if (numeros.Length < 2)
        {
            Console.WriteLine("Por favor, forneça pelo menos dois números.");
            return;
        }

        var proximoNumero = AdivinharProximoNumero(numeros);
        ExibirResultado(proximoNumero);
    }

    static int[] LerNumeros()
    {
        Console.WriteLine("Digite uma sequência de números separados por vírgula:");
        string input = Console.ReadLine();
        return input.Split(',')
                    .Select(int.Parse)
                    .ToArray();
    }

    static int? AdivinharProximoNumero(int[] seq)
    {
        if (SequênciaQuadrada(seq)) return CalcularProximoQuadrado(seq);
        if (SequênciaFibonacci(seq)) return CalcularProximoFibonacci(seq);
        if (SequênciaAritmetica(seq, out int diff)) return CalcularProximoAritmetico(seq, diff);
        if (SequênciaGeometrica(seq, out double ratio)) return CalcularProximoGeometrico(seq, ratio);

        return null;
    }

    static void ExibirResultado(int? proximoNumero)
    {
        if (proximoNumero.HasValue)
        {
            Console.WriteLine("Possível próximo número: " + proximoNumero.Value);
        }
        else
        {
            Console.WriteLine("Padrão não reconhecido.");
        }
    }

    static bool SequênciaQuadrada(int[] seq)
    {
        for (int i = 0; i < seq.Length; i++)
        {
            if (seq[i] != (2 * (i + 1)) * (2 * (i + 1)))
            {
                return false;
            }
        }
        return true;
    }

    static int? CalcularProximoQuadrado(int[] seq)
    {
        return (int)Math.Pow((seq.Length + 1) * 2, 2);
    }

    static bool SequênciaFibonacci(int[] seq)
    {
        if (seq.Length < 3) return false;
        for (int i = 2; i < seq.Length; i++)
        {
            if (seq[i] != seq[i - 1] + seq[i - 2])
            {
                return false;
            }
        }
        return true;
    }

    static int? CalcularProximoFibonacci(int[] seq)
    {
        return seq.Last() + seq[seq.Length - 2];
    }

    static bool SequênciaAritmetica(int[] seq, out int diff)
    {
        diff = seq[1] - seq[0];
        for (int i = 1; i < seq.Length - 1; i++)
        {
            if (seq[i + 1] - seq[i] != diff)
            {
                return false;
            }
        }
        return true;
    }

    static int? CalcularProximoAritmetico(int[] seq, int diff)
    {
        return seq.Last() + diff;
    }

    static bool SequênciaGeometrica(int[] seq, out double ratio)
    {
        ratio = (double)seq[1] / seq[0];
        for (int i = 1; i < seq.Length - 1; i++)
        {
            if ((double)seq[i + 1] / seq[i] != ratio)
            {
                return false;
            }
        }
        return true;
    }

    static int? CalcularProximoGeometrico(int[] seq, double ratio)
    {
        return (int)(seq.Last() * ratio);
    }
}
