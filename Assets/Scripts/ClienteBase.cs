using UnityEngine;

public class ClienteBase : MonoBehaviour
{
    public string Nome { get; set; }
    public string Pedido { get; set; }
    public string Status { get; set; }
    public int Decisao { get; set; }

    Randomizador rdm = new Randomizador();
    private void Start()
    {
        Nome = rdm.NomeCliente();
        Pedido = rdm.NomePedido();
        Status = "Na Fila";
    }
}