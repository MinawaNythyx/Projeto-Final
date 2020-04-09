using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDoJogo : MonoBehaviour
{
    static List<GameObject> listaCliente;
    [SerializeField]
    GameObject[] clientes = new GameObject[10];
    GameObject selecionado, menu;
    [SerializeField]
    GameObject menuEscolhas;
    GameObject player;
    float velX, velY;
    string nome, status;
    public string pedido;
    private void Start()
    {
        player = GameObject.Find("Spawn");
        listaCliente = new List<GameObject>();
        StartCoroutine(AutoSpawn());
    }

    private void Update()
    {
        Click();
        GetStatus();
        WinOrLose();
    }
    void GetStatus()
    {
        if (selecionado != null)
        {
            nome = selecionado.GetComponent<ClienteBase>().Nome;
            pedido = selecionado.GetComponent<ClienteBase>().Pedido;
            status = selecionado.GetComponent<ClienteBase>().Status;
            velX = selecionado.GetComponent<ClientesMovimento>().velocidadeX;
            velY = selecionado.GetComponent<ClientesMovimento>().velocidadeY;
        }
    }
    void WinOrLose()
    {
        if (player.GetComponent<JogaPlayerdor>().Vidas < 1)
        {
            SceneManager.LoadScene("Derrota");
        }
        else if(player.GetComponent<ContadorDePadoru>().Padoru == player.GetComponent<ContadorDePadoru>().TotalPadoru && listaCliente.Count == 0)
        {
            if(player.GetComponent<JogaPlayerdor>().Dinheiro <= 0)
            {
                SceneManager.LoadScene("Derrota");
            }
            else
            {
                Debug.Log("You Win");
                SceneManager.LoadScene("Vitoria");
            }
        }
    }
    public int PosicaoFila(GameObject go)
    {
        int index = 3;
        foreach(GameObject gameobj in listaCliente)
        {
            if(gameobj == go)
            {
                index = listaCliente.IndexOf(gameobj);
                break;
            }
        }
        return index;
    }
    #region Estaticos
    public static string ReturnStatus(GameObject go)
    {
        return go.GetComponent<ClienteBase>().Status;
    }
    public static string ReturnPedido(GameObject go)
    {
        return go.GetComponent<ClienteBase>().Pedido;
    }
    public static void ChangeStatus(GameObject go, string status)
    {
        go.GetComponent<ClienteBase>().Status = status;
    }
    public static void RemoveCliente(GameObject select)
    {
        listaCliente.Remove(select);
    }
    public void Cabelo()
    {
        if (selecionado != null)
        {
            if (status == "Atendido")
            {
                selecionado.GetComponent<ClienteBase>().Status = "Para Serviço";
                selecionado.GetComponent<ClientesMovimento>().Servico();
                selecionado.GetComponent<ClienteBase>().Decisao = 1;
            }
        }
    }
    public void Manicure()
    {
        if (selecionado != null)
        {
            if (status == "Atendido")
            {
                selecionado.GetComponent<ClienteBase>().Status = "Para Serviço";
                selecionado.GetComponent<ClientesMovimento>().Servico();
                selecionado.GetComponent<ClienteBase>().Decisao = 2;
            }
        }
    }
    public void Depilacao()
    {
        if (selecionado != null)
        {
            if (status == "Atendido")
            {
                selecionado.GetComponent<ClienteBase>().Status = "Para Serviço";
                selecionado.GetComponent<ClientesMovimento>().Servico();
                selecionado.GetComponent<ClienteBase>().Decisao = 3;
            }
        }
    }
    #endregion
    public void Click()
    {
        #region Clicks
        if (Input.GetMouseButtonDown(0))
        {
            if(ZaWarudo.pause == false)
            {
                Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
                if (hit.collider != null && hit.collider.tag == "Cliente")
                {
                    if (selecionado != null && selecionado.GetComponent<ClienteBase>().Status == "Atendido")
                    {
                        Destroy(menu);
                        selecionado.GetComponent<ClienteBase>().Status = "Na Fila";
                    }
                    selecionado = hit.collider.gameObject;
                    selecionado.GetComponent<ClientesMovimento>().AutoRetur();
                    if (selecionado.GetComponent<ClienteBase>().Status == "Na Fila")
                    {
                        ChangeStatus(selecionado, "Atendido");
                        menu = Instantiate(menuEscolhas);
                    }
                }
                else
                {
                    if (selecionado != null)
                    {
                        StartCoroutine(WastingTime());
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCliente();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            if (selecionado == null)
            {

            }
            else
            {
                Debug.Log(nome);
                Debug.Log(pedido);
                Debug.Log(status);
            }
        }
        #endregion
    }
    #region Spawn
    public void SpawnCliente()
    {
        if (listaCliente.Count < 4)
        {
            if(player.GetComponent<ContadorDePadoru>().Padoru < player.GetComponent<ContadorDePadoru>().TotalPadoru)
            {
                listaCliente.Add(Instantiate(clientes[0], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity));
                player.GetComponent<ContadorDePadoru>().Padoru++;
            }
        }
    }
    public void Destroy()
    {
        Destroy(menu);
    }
    public void BackFila()
    {
        ChangeStatus(selecionado, "Na Fila");
    }
    IEnumerator AutoSpawn()
    {
        yield return new WaitForSeconds(4f);
        SpawnCliente();
        StartCoroutine(AutoSpawn());
    }
    IEnumerator WastingTime()
    {
        yield return new WaitForSeconds(0.3f);
        if (selecionado.GetComponent<ClienteBase>().Status == "Atendido")
        {
            ChangeStatus(selecionado, "Na Fila");
            Destroy(menu);
        }
    }
    #endregion
}