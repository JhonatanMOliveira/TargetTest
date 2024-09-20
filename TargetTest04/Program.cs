//4) Banco de dados

//Uma empresa solicitou a você um aplicativo para manutenção de um cadastro de clientes. Após a reunião de definição dos requisitos, as conclusões foram as seguintes:

//-Um cliente pode ter um número ilimitado de telefones;
//-Cada telefone de cliente tem um tipo, por exemplo: comercial, residencial, celular, etc. O sistema deve permitir cadastrar novos tipos de telefone;
//-A princípio, é necessário saber apenas em qual estado brasileiro cada cliente se encontra. O sistema deve permitir cadastrar novos estados;

//Você ficou responsável pela parte da estrutura de banco de dados que será usada pelo aplicativo. Assim sendo:

//-Proponha um modelo lógico para o banco de dados que vai atender a aplicação. Desenhe as tabelas necessárias, os campos de cada uma e marque com setas os relacionamentos existentes entre as tabelas;
//-Aponte os campos que são chave primária (PK) e chave estrangeira (FK);
//-Faça uma busca utilizando comando SQL que traga o código, a razão social e o(s) telefone(s) de todos os clientes do estado de São Paulo (código “SP”);

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            AdicionarDados(context);
            ConsultarClientesEmSaoPaulo(context);
        }
    }

    static void AdicionarDados(AppDbContext context)
    {
        var sp = new Estado { Nome = "São Paulo", Sigla = "SP" };
        var rj = new Estado { Nome = "Rio de Janeiro", Sigla = "RJ" };

        context.Estados.Add(sp);
        context.Estados.Add(rj);
        context.SaveChanges();

        var cliente1 = new Cliente { RazaoSocial = "Cliente A", EstadoID = sp.EstadoID };
        var cliente2 = new Cliente { RazaoSocial = "Cliente B", EstadoID = sp.EstadoID };

        cliente1.Telefones.Add(new Telefone { Numero = "11987654321", Tipo = "Celular" });
        cliente1.Telefones.Add(new Telefone { Numero = "1134567890", Tipo = "Comercial" });
        cliente2.Telefones.Add(new Telefone { Numero = "21987654321", Tipo = "Residencial" });

        context.Clientes.Add(cliente1);
        context.Clientes.Add(cliente2);
        context.SaveChanges();
    }

    static void ConsultarClientesEmSaoPaulo(AppDbContext context)
    {
        var resultado = from c in context.Clientes
                        join e in context.Estados on c.EstadoID equals e.EstadoID
                        join t in context.Telefones on c.ClienteID equals t.ClienteID
                        where e.Sigla == "SP"
                        select new
                        {
                            c.ClienteID,
                            c.RazaoSocial,
                            Telefone = t.Numero
                        };

        Console.WriteLine("Clientes do estado de São Paulo:");
        foreach (var item in resultado)
        {
            Console.WriteLine($"ClienteID: {item.ClienteID}, RazaoSocial: {item.RazaoSocial}, Telefone: {item.Telefone}");
        }
    }
}
