using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControlCharacter : MonoBehaviour {
	//Declaraciones

	public float velocidad, movX=1/100, movY=0, despla = 10;
    private bool izquierda = false, arriba = false, abajo = false, derecha = true;
    private int cont = 0;
    private int totalSec = 0;
    private int i = 0;
    private int seg = 100;
    private GameObject[] objects = new GameObject[4];
    private List<string> cadenas;

    public void Start()
    {
        StartCoroutine(moving());
       
    }

    void Update()
    {
        
    }

    /*void getObjects()
    {
        while (cont< GameObject.Find("Instruccion1").GetComponent<DropMe>().instrucciones.Count) {
            cadenas.Add(GameObject.Find("Instruccion1").GetComponent<DropMe>().instrucciones[cont]);
            Debug.Log(GameObject.Find("Instruccion1").GetComponent<DropMe>().instrucciones.Count);
            cont++;
        }
    }*/

    IEnumerator moving() {

        List<string> movimientos = GameObject.Find("Instruccion1").GetComponent<DropMe>().instrucciones;
        
        //getObjects();
        cont = 0;


        while (cont < movimientos.Count)
        {
            Debug.Log(movimientos[cont]);
            //Debug.Log(cadenas[cont]);
            
            if (movimientos[cont] == "derecha")
            {
                Debug.Log("Hola");
                if (abajo == true)
                {
                    izquierda = true;
                    abajo = false;
                }
                if (izquierda == true)
                {
                    arriba = true;
                    izquierda = false;
                }
                if (arriba == true)
                {
                    derecha = true;
                    arriba = false;
                }
                if (derecha == true)
                {
                    abajo = true;
                    derecha = false;
                }

            }
            else if (movimientos[cont] == "izquierda")
            {
                if (abajo == true)
                {
                    derecha = true;
                    abajo = false;
                }
                if (derecha == true)
                {
                    arriba = true;
                    derecha = false;
                }
                if (arriba == true)
                {
                    izquierda = true;
                    arriba = false;
                }
                if (izquierda == true)
                {
                    abajo = true;
                    izquierda = false;
                }
            } else if (movimientos[cont] == "adelante")
            {
                for (int i = 0; i < seg; i++)
                {
                    //transform.position += new Vector3(movX / 100, movY / 100, 0);
                    
                    
                    Debug.Log("Moviendo");
                    if (abajo == true)
                    {
                        transform.position += Vector3.down;
                    }
                    if (derecha == true)
                    {
                        transform.position += Vector3.right;
                    }
                    if (arriba == true)
                    {
                        transform.position += Vector3.up;
                    }
                    if (izquierda == true)
                    {
                        transform.position += Vector3.right;
                    }
                    yield return new WaitForSeconds(0.01f);
                }
            }

            cont++;
        }
    }

}
