using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour {
	//Declaraciones
	public float velocidad;
    private bool izquierda = false, arriba = false, abajo = false, derecha = true;
    private int cont = 0, movX, movY;
    private GameObject[] objects = new GameObject[4];
    private string[] cadenas = new string[4];
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Arriba
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

		if (Input.GetKey(KeyCode.W)) {
			//transform.Translate (new Vector2 (GetComponent<Rigidbody2D>	().velocity.x, velocidad));
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>	().velocity.x, velocidad);
		} 

		//Abajo
		if(Input.GetKey(KeyCode.S)){
			//transform.Translate (new Vector2 (GetComponent<Rigidbody2D>	().velocity.x, -velocidad));
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>	().velocity.x, -velocidad);
		} 
		//Derecha
		if(Input.GetKey(KeyCode.D)){
			//transform.Translate (new Vector2 (velocidad, GetComponent<Rigidbody2D>	().velocity.y));
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocidad, GetComponent<Rigidbody2D>	().velocity.y);
		} 
		//Izquierda
		if(Input.GetKey(KeyCode.A)){
			//transform.Translate (new Vector2 (-velocidad, GetComponent<Rigidbody2D>	().velocity.y));
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-velocidad, GetComponent<Rigidbody2D>	().velocity.y);
		} 
	}
    private void movimiento() {
        cont = 0;

        while (cont < 4) {
            if (cadenas[cont] == "adelante")
            {

            }
            else if (cadenas[cont] == "derecha")
            {

            }
            else if(cadenas[cont]=="izquierda"){
               
            }
        }
    }

    void getObjects()
    {
        while (cont<4) {
            objects[cont] = GameObject.Find("Instruccion"+(cont+1));
            cadenas[cont] = objects[cont].GetComponent<DropMe>().test;
        }
    }
}
