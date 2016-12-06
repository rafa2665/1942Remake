using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    bool morreu, jaMorreu;
    Rigidbody2D rb;
    [SerializeField]
    GameObject[] tiros;
    [SerializeField]
    GameObject explosao, explosaoTiro;
    [SerializeField]
    Transform[] armas;
    [SerializeField]
    int tiroAtual, vida, pontos;
    [SerializeField]
    UnityEngine.UI.Text pontosTXT, vidaTXT;

	void Start ()
    {
        jaMorreu = false;
        morreu = false;
        pontos = 0;
        vida = 500;
        tiroAtual = 0;
        rb = GetComponent<Rigidbody2D>();
	}
	void Update ()
    {
        Combate();
        pontosTXT.text = "Points: " + pontos.ToString();
        vidaTXT.text = "Lataria: " + vida.ToString();
	}

    void FixedUpdate()
    {
        Movimentacao();
    }

    void Movimentacao()
    {
        rb.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * 3, Input.GetAxisRaw("Vertical"));
    }

    void Combate()
    {
        if (!morreu)
        {
            if (Input.GetButtonDown("Fire1") && tiroAtual == 0)
            {
                Instantiate(tiros[0], armas[0].position, Quaternion.identity);
                Instantiate(tiros[0], armas[1].position, Quaternion.identity);
                tiros[0].tag = "Tiro";
            }
            else if (Input.GetButtonDown("Fire1") && tiroAtual == 1)
            {
                Instantiate(tiros[0], armas[0].position, Quaternion.identity);
                Instantiate(tiros[1], armas[1].position, Quaternion.identity);
                tiros[0].tag = "Tiro";
                tiros[1].tag = "Tiro";
            }
            else if (Input.GetButtonDown("Fire1") && tiroAtual == 2)
            {
                Instantiate(tiros[1], armas[0].position, Quaternion.identity);
                Instantiate(tiros[1], armas[1].position, Quaternion.identity);
                tiros[1].tag = "Tiro";
            }
        }

        if (vida <= 0)
        {
            morreu = true;
            if (!jaMorreu)
                Explodir();
            PlayerPrefs.SetInt("Pontuacao", pontos);
            vida = 0;
            Invoke("IrMenu", 5);
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "TiroInimigo")
        {
            Instantiate(explosaoTiro, outro.gameObject.transform.position, outro.gameObject.transform.rotation);
            vida -= outro.GetComponent<Tiro>().GetDano();
            Destroy(outro.gameObject);
        }

        else if (outro.gameObject.tag == "Inimigo")
        {
            vida -= 60;
            Instantiate(explosaoTiro, outro.gameObject.transform.position, outro.gameObject.transform.rotation);
            Instantiate(explosaoTiro, transform.position, outro.gameObject.transform.rotation);
            Destroy(outro.gameObject);
        }
    }

    void Explodir()
    {
        Instantiate(explosao, transform.position, Quaternion.identity);
        jaMorreu = true;
    }

    public void SetTiro(int tiro)
    {
        tiroAtual = tiro;
    }

    public void SetPontos(int pointSet)
    {
        pontos += pointSet;
    }

    public void IrMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
