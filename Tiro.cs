using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {
    [SerializeField]
    GameObject explosaoTiro;
    Rigidbody2D rb;
    [SerializeField]
    int dano;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (this.gameObject.tag == "TiroInimigo")
            rb.velocity = Vector2.up * -2;
        if (this.gameObject.tag == "Tiro")
            rb.velocity = Vector2.up * 2;
        Destroy(this.gameObject, 5);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "Tiro" || outro.gameObject.tag == "TiroInimigo")
        {
            Instantiate(explosaoTiro, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    public int GetDano()
    {
        return dano;
    }
}
