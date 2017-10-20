﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour {
    //Declaraciones
    public float velocidad, movX = 1f, movY = 0f;
    private bool izquierda = false, arriba = false, abajo = false, derecha = true;
    private int cont = 0;
    private int concat = 1;
    private int pasos = 0;
    private GameObject[] objects = new GameObject[4];
    private string[] cadenas = new string[4];
    private Rigidbody2D rgd2;
	//Use this for initialization
	void Start () {
        rgd2 = GetComponent<Rigidbody2D>();
	}
	/*
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
    public void Movimiento() {
        
        getObjects();
        cont = 0;
        while (cont < 4) {
            if (cadenas[cont] == "adelante")
            {
                while (pasos < 100) {
                    transform.position += new Vector3(movX, movY,0) ;
                    //rgd2.AddForce(Vector2.right * movX);
                    StartCoroutine(retardo());
                    Debug.Log("Moviendo");
                  pasos++;
                }
            }
            else if (cadenas[cont] == "derecha")
            {
                if (abajo==true)
                {
                    movX = -1f;
                    movY = 0f;

                    izquierda = true;
                    abajo = false;
                }
                if (izquierda == true) {

                    movX = 0f;
                    movY = 1f;

                    arriba = true;
                    izquierda = false;
                }
                if (arriba == true)
                {
                    movX = 1f;
                    movY = 0f;

                    derecha = true;
                    arriba = false;
                }
                if (derecha == true) {
                    movX = 0f;
                    movY = -1f;

                    abajo = true;
                    derecha = false;
                }
                
            }
            else if(cadenas[cont]=="izquierda"){
                if (abajo == true)
                {
                    movX = 1f;
                    movY = 0f;

                    derecha = true;
                    abajo = false;
                }
                if (derecha == true)
                {

                    movX = 0f;
                    movY = 1f;

                    arriba = true;
                    derecha = false;
                }
                if (arriba == true)
                {
                    movX = -1f;
                    movY = 0f;

                    izquierda = true;
                    arriba = false;
                }
                if (izquierda == true)
                {
                    movX = 0f;
                    movY = -1f;

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
        while (cont<4) {
            Debug.Log("Estoy aqui");
            objects[cont] = GameObject.Find("Instruccion"+concat.ToString());
            
            cadenas[cont] = objects[cont].GetComponent<DropMe>().test;
            Debug.Log(cadenas[cont]);
            cont++;
            concat++;
        }
    }

    IEnumerator retardo() {
        yield return new WaitForSeconds(1f);
        yield break;
    }
}
