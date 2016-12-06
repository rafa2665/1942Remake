using UnityEngine;
using System.Collections;

public class Explosao : MonoBehaviour {
    public void DestruirExplosao()
    {
        Destroy(this.gameObject, 0.1f);
    }
}
