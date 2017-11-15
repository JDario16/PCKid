using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour {
    public string minigame;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void restart() {
        SceneManager.LoadScene(string.Concat(string.Concat("Scenes/",minigame),"/11"));
    }

    public void next() {
        Debug.Log("Press");
        SceneManager.LoadScene("Scenes/Menu/SelectMiniGame");
    }

    public void salir() {
        SceneManager.LoadScene("Scenes/Menu/SelectMiniGame");
    }
}
