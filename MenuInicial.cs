using UnityEngine;
using System.Collections;

public class MenuInicial : MonoBehaviour {

    public void GameIniciar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Fase1");
    }
}
