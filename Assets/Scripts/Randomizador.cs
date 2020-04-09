using System;
public class Randomizador
{
    Random random = new Random();
    public string NomeCliente()
    {
        string[] listaNomes = new string[] { "Megumin", "Jeanne Darc alter", "Miyamoto Musashi", "Leonardo Da Vinci", "Kurisu Makise", "Taiga", "2B", "A2", "Illyasviel" };
        
        return listaNomes[random.Next(0, listaNomes.Length)];
    }

    public string NomePedido()
    {
        string[] listaPedidos = new string[] { "Corte de Cabelo", "Manicure", "Depilação" };
        return listaPedidos[random.Next(0, listaPedidos.Length)];
    }
}