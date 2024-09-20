public class Cliente
{
    public int ClienteID { get; set; }
    public string RazaoSocial { get; set; }
    public int EstadoID { get; set; }
    public Estado Estado { get; set; }
    public List<Telefone> Telefones { get; set; } = new List<Telefone>();
}
