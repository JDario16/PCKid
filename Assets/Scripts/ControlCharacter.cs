using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControlCharacter : MonoBehaviour {
	//Declaraciones
	public float velocidad, movX=100.0f, movY=0.0f;
    private bool izquierda = false, arriba = false, abajo = false, derecha = true;
    private int cont = 0;
    private int concat = 1;
    private GameObject[] objects = new GameObject[4];
    private string[] cadenas = new string[4];
   
    /*// Use this for initialization
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
	}*/
    public void movimiento() {
        List<string> movimientos = GameObject.Find("Instruccion1").GetComponent<DropMe>().instrucciones;
        getObjects();
        cont = 0;
        while (cont < movimientos.Count) {
            if (movimientos[cont] == "adelante")
            {
                transform.Translate(movX, movY, 479.1f);
                Debug.Log("Moviendo");
            }
            else if (movimientos[cont] == "derecha")
            {
                if (abajo==true)
                {
                    movX = -100.0f;
                    movY = 0.0f;

                    izquierda = true;
                    abajo = false;
                }
                if (izquierda == true) {

                    movX = 0.0f;
                    movY = 100.0f;

                    arriba = true;
                    izquierda = false;
                }
                if (arriba == true)
                {
                    movX = 100.0f;
                    movY = 0.0f;

                    derecha = true;
                    arriba = false;
                }
                if (derecha == true) {
                    movX = 0.0f;
                    movY = -100.0f;

                    abajo = true;
                    derecha = false;
                }
                
            }
            else if(movimientos[cont]=="izquierda"){
                if (abajo == true)
                {
                    movX = 100.0f;
                    movY = 0.0f;

                    derecha = true;
                    abajo = false;
                }
                if (derecha == true)
                {

                    movX = 0.0f;
                    movY = 100.0f;

                    arriba = true;
                    derecha = false;
                }
                if (arriba == true)
                {
                    movX = -100.0f;
                    movY = 0.0f;

                    izquierda = true;
                    arriba = false;
                }
                if (izquierda == true)
                {
                    movX = 0.0f;
                    movY = -100.0f;

                    abajo = true;
                    izquierda = false;
                }
            }
            Debug.Log(cadenas[cont]);
            cont++;
        }
    }

    void getObjects()
    {
        while (cont< GameObject.Find("Instruccion1").GetComponent<DropMe>().instrucciones.Count) {
            Debug.Log("Estoy aqui");
            cadenas[cont] = GameObject.Find("Instruccion1").GetComponent<DropMe>().instrucciones[cont];
            Debug.Log(GameObject.Find("Instruccion1").GetComponent<DropMe>().instrucciones.Count);
            cont++;
        }
    }
}
