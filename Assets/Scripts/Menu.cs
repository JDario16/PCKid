using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void bMiniGame() {
        SceneManager.LoadScene("Scenes/Menu/SelectMiniGame");
    }

    public void bAbstraccion() {
        SceneManager.LoadScene("Scenes/Abstraccion/11");
    }

    public void bAlgoritmia()
    {
        SceneManager.LoadScene("Scenes/Instrucciones/11");
    }

    public void bDescomposicion()
    {
        SceneManager.LoadScene("Scenes/Descomposicion/11");
    }

    public void backButton() {
            SceneManager.LoadScene("Scenes/Menu/MainMenu");
    }
}
