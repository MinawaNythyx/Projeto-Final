using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientesMovimento : MonoBehaviour
{
    public float velocidadeX, velocidadeY;
    public float move, stop, moveSlow;
    float maxX, minX, maxY, minY;
    GameObject player;
    GameObject go;
    Vector3 direction;
    AudioSource audio;
    private void Start()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
        go = GameObject.Find("Spawn");
        StartCoroutine(AutoStress(45));
        player = GameObject.Find("Spawn");
        velocidadeX = stop;
        velocidadeY = stop;
        direction = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        move = 2.5f;
        stop = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        PosicaoFila(this.gameObject.GetComponent<ClienteBase>().Status);
        Moving();
    }
    #region Movimentos
    public void Movimento()
    {
        if (transform.position.x < minX)
        {
            velocidadeX = move;
        }
        else if (transform.position.x > maxX)
        {
            velocidadeX = -move;
        }
        else
        {
            velocidadeX = stop;
        }
        if (transform.position.y > maxY)
        {
            velocidadeY = -move;
        }
        else if (transform.position.y < minY)
        {
            velocidadeY = move;
        }
        else
        {
            velocidadeY = stop;
        }
    }
    public void PosicaoFila(string status)
    {
        int posicao = go.GetComponent<ControladorDoJogo>().PosicaoFila(this.gameObject);
        if (status == "Na Fila")
        {
            maxY = 2.1f;
            minY = 1.9f;
            if (posicao == 0)
            {
                maxX = -5.4f;
                minX = -5.6f;
            }
            else if (posicao == 1)
            {
                maxX = -6.4f;
                minX = -6.6f;
            }
            else if (posicao == 2)
            {
                maxX = -7.4f;
                minX = -7.6f;
            }
            else if (posicao == 3)
            {
                maxX = -8.4f;
                minX = -8.6f;
            }
        }
        else if (status == "Atendido")
        {
            maxX = -5.9f;
            minX = -6.1f;
            maxY = -0.4f;
            minY = -0.6f;
        }
        Movimento();
    }
    void Moving()
    {
        direction.x += velocidadeX * Time.deltaTime;
        direction.y += velocidadeY * Time.deltaTime;
        transform.position = direction;
    }
    public void Servico()
    {
        maxX = 3.1f;
        minX = 2.9f;
        maxY = 0.1f;
        minY = -0.1f;
    }
    public void Corte()
    {
        maxX = -0.9f;
        minX = -1.1f;
        maxY = -3.4f;
        minY = -3.6f;
    }
    public void ManiPedi()
    {
        maxX = 6.1f;
        minX = 5.9f;
        maxY = -3.9f;
        minY = -4.1f;
    }
    void Depilacao()
    {
        maxX = 5.1f;
        minX = 4.9f;
        maxY = 3.1f;
        minY = 2.9f;
    }
    #endregion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            #region Corte
            case "Corte":
                if (ControladorDoJogo.ReturnPedido(this.gameObject) == "Corte de Cabelo")
                {
                    if (collision.gameObject.GetComponent<Atendimento>().ReturnAtendendo() == "Vazio")
                    {
                        collision.gameObject.GetComponent<Atendimento>().ChangeAtendendo("Ocupado");
                        StartCoroutine(TempoDeEspera(collision.gameObject));
                    }
                    else
                    {
                        Debug.Log(collision.gameObject.GetComponent<Atendimento>().ReturnAtendendo());
                        ControladorDoJogo.ChangeStatus(this.gameObject, "Volta Atendimento");
                        Servico();
                    }
                }
                else
                {
                    ControladorDoJogo.ChangeStatus(this.gameObject, "Volta Atendimento");
                    Servico();
                }
                break;
            #endregion
            #region Depilação
            case "Depilacao":
                if (ControladorDoJogo.ReturnPedido(this.gameObject) == "Depilação")
                {
                    if (collision.gameObject.GetComponent<Atendimento>().ReturnAtendendo() == "Vazio")
                    {
                        collision.gameObject.GetComponent<Atendimento>().ChangeAtendendo("Ocupado");
                        StartCoroutine(TempoDeEspera(collision.gameObject));
                    }
                    else
                    {
                        Debug.Log(collision.gameObject.GetComponent<Atendimento>().ReturnAtendendo());
                        ControladorDoJogo.ChangeStatus(this.gameObject, "Volta Atendimento");
                        Servico();
                    }
                }
                else
                {
                    ControladorDoJogo.ChangeStatus(this.gameObject, "Volta Atendimento");
                    Servico();
                }
                break;
            #endregion
            #region Manicure
            case "Manicure":
                if (ControladorDoJogo.ReturnPedido(this.gameObject) == "Manicure")
                {
                    if (collision.gameObject.GetComponent<Atendimento>().ReturnAtendendo() == "Vazio")
                    {
                        collision.gameObject.GetComponent<Atendimento>().ChangeAtendendo("Ocupado");
                        StartCoroutine(TempoDeEspera(collision.gameObject));
                    }
                    else
                    {
                        Debug.Log(collision.gameObject.GetComponent<Atendimento>().ReturnAtendendo());
                        ControladorDoJogo.ChangeStatus(this.gameObject, "Volta Atendimento");
                        Servico();
                    }
                }
                else
                {
                    ControladorDoJogo.ChangeStatus(this.gameObject, "Volta Atendimento");
                    Servico();
                }
                break;
                #endregion
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Serviço")
        {
            string status = this.gameObject.GetComponent<ClienteBase>().Status;
            switch (status)
            {
                case "Para Serviço":
                    this.gameObject.GetComponent<ClienteBase>().Status = "Em Atendimento";
                    int choice = this.gameObject.GetComponent<ClienteBase>().Decisao;
                    if (choice == 1)
                    {
                        Corte();
                    }
                    else if (choice == 2)
                    {
                        ManiPedi();
                    }
                    else if (choice == 3)
                    {
                        Depilacao();
                    }
                    break;
                case "Na Fila":
                    this.gameObject.GetComponent<ClienteBase>().Status = "Atendido";
                    StartCoroutine(NaFila());
                    break;
                case "Volta Atendimento":
                    this.gameObject.GetComponent<ClienteBase>().Status = "Atendido";
                    StartCoroutine(NaFila());
                    break;
            }
        }
    }
    public void AutoRetur()
    {
        StartCoroutine(AutoReturn());
    }
    IEnumerator TempoDeEspera(GameObject go)
    {
        yield return new WaitForSeconds(9f);
        audio.Play();
        yield return new WaitForSeconds(1f);
        ControladorDoJogo.RemoveCliente(this.gameObject);
        player.GetComponent<JogaPlayerdor>().Dinheiro += 10;
        go.GetComponent<Atendimento>().ChangeAtendendo("Vazio");
        Destroy(this.gameObject);
    }
    IEnumerator NaFila()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<ClienteBase>().Status = "Na Fila";
    }
    IEnumerator AutoReturn()
    {
        yield return new WaitForSeconds(5);
        if(this.gameObject.GetComponent<ClienteBase>().Status == "Atendido")
        {
            this.gameObject.GetComponent<ClienteBase>().Status = "Na Fila";
        }
    }
    IEnumerator AutoStress(float time)
    {
        yield return new WaitForSeconds(time);
        if(this.gameObject.GetComponent<ClienteBase>().Status == "Na Fila" || this.gameObject.GetComponent<ClienteBase>().Status == "Atendido")
        {
            ControladorDoJogo.RemoveCliente(this.gameObject);
            player.GetComponent<JogaPlayerdor>().Vidas -= 1;
            player.GetComponent<JogaPlayerdor>().Dinheiro -= 20;
            Destroy(this.gameObject);
        }
        else
        {
            float time2;
            if(time <= 0)
            {
                time2 = 0;
            }
            else
            {
                time2 = time - 15;
            }
            StartCoroutine(AutoStress(time2));
        }
    }
}