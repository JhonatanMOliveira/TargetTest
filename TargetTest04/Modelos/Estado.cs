﻿public class Estado
{
    public int EstadoID { get; set; }
    public string Nome { get; set; }
    public string Sigla { get; set; }
    public List<Cliente> Clientes { get; set; } = new List<Cliente>();
}
