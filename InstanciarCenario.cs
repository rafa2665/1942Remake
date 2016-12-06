using UnityEngine;
using System.Collections;

public class InstanciarCenario : MonoBehaviour {
    /*[SerializeField]
    Transform posic;*/
    [SerializeField]
    GameObject[] cenario;
	// Use this for initialization
	void Start () {
        Instantiate(cenario[Random.Range(0, 2)], new Vector3(0, 978, -10), Quaternion.identity);
        InvokeRepeating("Instanciar", 0, 4.7f);
	}

    void Instanciar()
    {
        Debug.Log("Instanciou");
        Instantiate(cenario[Random.Range(0, 2)]);
    }
}
