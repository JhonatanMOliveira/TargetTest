//5) Dois veículos, um carro e um caminhão, saem respectivamente de cidades opostas pela mesma rodovia. O carro, de Ribeirão Preto em direção a Barretos, a uma velocidade constante de 90 km/h, e o caminhão, de Barretos em direção a Ribeirão Preto, a uma velocidade constante de 80 km/h. Quando eles se cruzarem no percurso, qual estará mais próximo da cidade de Ribeirão Preto?

//a) Considerar a distância de 125km entre a cidade de Ribeirão Preto <-> Barretos.
//b) Considerar 3 pedágios como obstáculo e que o carro leva 5 minutos a mais para passar em cada um deles, pois ele não possui dispositivo de cobrança de pedágio.
//c)Explique como chegou no resultado.
class Program
{
    static void Main()
    {
        const double distanciaTotal = 125.0;
        const double velocidadeCarro = 90.0;
        const double velocidadeCaminhao = 80.0;
        const int numeroPedagios = 3;
        const double tempoPedagioMinutos = 5.0;

        double tempoPedagiosTotalHoras = (numeroPedagios * tempoPedagioMinutos) / 60.0;

        double tempoCarro = distanciaTotal / (velocidadeCarro + velocidadeCaminhao);
        double tempoTotalCarro = tempoCarro + tempoPedagiosTotalHoras;

        double distanciaPercorridaCarro = velocidadeCarro * tempoTotalCarro;
        double distanciaPercorridaCaminhao = velocidadeCaminhao * tempoCarro;

        double distanciaCarroDeRibeirao = distanciaTotal - distanciaPercorridaCarro;

        Console.WriteLine($"Distância do carro até Ribeirão Preto no ponto de encontro: {distanciaCarroDeRibeirao:F2} km");
        Console.WriteLine($"Distância do caminhão até Ribeirão Preto no ponto de encontro: {distanciaPercorridaCaminhao:F2} km");

        if (distanciaCarroDeRibeirao < distanciaPercorridaCaminhao)
        {
            Console.WriteLine("O carro está mais próximo de Ribeirão Preto.");
        }
        else if (distanciaCarroDeRibeirao > distanciaPercorridaCaminhao)
        {
            Console.WriteLine("O caminhão está mais próximo de Ribeirão Preto.");
        }
        else
        {
            Console.WriteLine("Ambos os veículos estão a mesma distância de Ribeirão Preto.");
        }
    }
}
