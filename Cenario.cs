using UnityEngine;
using System.Collections;

public class Cenario : MonoBehaviour {
    void Start()
    {
        transform.parent = GameObject.Find("Canvas").transform;
        transform.localScale = new Vector3(783, 382, 98);
        transform.localPosition = new Vector3(0, 978, -10);
    }

    void FixedUpdate()
    {
        transform.Translate(-Vector3.up * Time.fixedDeltaTime * 2);

        if (transform.position.y < -990)
            DestroyImmediate(this);
    }
}
