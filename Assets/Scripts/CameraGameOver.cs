using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraGameOver : MonoBehaviour {

    public GameObject CameraGameOve;
    public GameObject CameraSucces;
    public GameObject BotonNext;
    public GameObject BotonSalir;
    public GameObject BotonRestart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CameraChange(int gameOver) {
        if (gameOver == 0) {
            CameraGameOve.SetActive(true);
            BotonSalir.SetActive(true);
            BotonRestart.SetActive(true);

        } else if (gameOver == 1) {
            CameraSucces.SetActive(true);
            BotonNext.SetActive(true);
            BotonSalir.SetActive(true);
        }
    }
}
