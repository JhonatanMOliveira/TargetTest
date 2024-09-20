public class Telefone
{
    public int TelefoneID { get; set; }
    public string Numero { get; set; }
    public string Tipo { get; set; }
    public int ClienteID { get; set; }
    public Cliente Cliente { get; set; }
}
