using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour {

    Rigidbody2D rb;
    [SerializeField]
    GameObject explosao, tiro, explosaoTiro, laser;
    [SerializeField]
    int vida, pontosGanhos;

    void Start()
    {
        transform.position = new Vector2(Random.Range(-8f, 9f), transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.up * -1;
    }

    void Update()
    {
        //Instantiate(laser, transform.position, Quaternion.identity);
        if (this.gameObject.name == "Boss")
            PlayerPrefs.SetInt("vidaBoss", vida);
        if (vida <= 0 && this.gameObject.name != "Boss")
        {
            GameObject.FindWithTag("Player").GetComponent<Player>().SetPontos(pontosGanhos);
            Instantiate(explosao, transform.position, Quaternion.identity);
            DestroyImmediate(this.gameObject);
        }
        if (transform.position.x > 8f)
            rb.velocity = new Vector2(-2, rb.velocity.y);
        else if(transform.position.x < -7f)
            rb.velocity = new Vector2(2, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "Limite" && this.gameObject.name != "Boss")
        {
            InvokeRepeating("IA", 0.5f, 2);
            Destroy(this.gameObject, 15);
        }

        else if (outro.gameObject.tag == "Tiro")
        {
            Instantiate(explosaoTiro, outro.gameObject.transform.position, outro.gameObject.transform.rotation);
            vida -= outro.GetComponent<Tiro>().GetDano();
            Destroy(outro.gameObject, 0.1f);
        }

        if (this.gameObject.name == "Boss" && outro.gameObject.tag == "Limite")
        {
            InvokeRepeating("IA", 0.5f, 2);
            Invoke("ZerarVelocidade", 3);
        }
    }

    void ZerarVelocidade()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
    }

    public void IA()
    {
        float randomizado = Random.Range(-2, 2);
        float velX = Mathf.MoveTowards(0, randomizado, 2);
        rb.velocity = new Vector2(velX, rb.velocity.y);
        GameObject tiroM = tiro;
        Instantiate(tiroM, transform.position, transform.rotation);
        tiroM.tag = "TiroInimigo";
    }
}
