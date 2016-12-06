using UnityEngine;
using System.Collections;

public class AlterarTiro : MonoBehaviour {

    Rigidbody2D rb;
    int esteTiro;

    void Start()
    {
        InvokeRepeating("Rando", 1, 2);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -1);
        if (this.gameObject.tag == "TiroModificado1")
            esteTiro = 1;
        else if (this.gameObject.tag == "TiroModificado2")
            esteTiro = 2;
    }

    void Rando()
    {
        rb.velocity = new Vector2(Random.Range(-1, 2), rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "Player")
        {
            outro.GetComponent<Player>().SetTiro(esteTiro);
            Destroy(this.gameObject, 0.1f);
            Debug.Log("MudouTiro");
        }
    }
}
