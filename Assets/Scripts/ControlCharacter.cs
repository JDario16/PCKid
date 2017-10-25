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
                if (abajo)
                {
                    izquierda = true;
                    abajo = false;
                }else
                if (izquierda)
                {
                    arriba = true;
                    izquierda = false;
                }else
                if (arriba)
                {
                    derecha = true;
                    arriba = false;
                }else
                if (derecha)
                {
                    abajo = true;
                    derecha = false;
                }

            }
            else if (movimientos[cont] == "izquierda")
            {
                if (abajo)
                {
                    derecha = true;
                    abajo = false;
                }else
                if (derecha)
                {
                    arriba = true;
                    derecha = false;
                }else
                if (arriba)
                {
                    izquierda = true;
                    arriba = false;
                }else
                if (izquierda)
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
                    if (abajo)
                    {
                        Debug.Log("Bajando");
                        transform.position += Vector3.down;
                    }else
                    if (derecha)
                    {
                        transform.position += Vector3.right;
                    }else
                    if (arriba)
                    {
                        transform.position += Vector3.up;
                        Debug.Log("Aqui");
                    }else
                    if (izquierda)
                    {
                        transform.position += Vector3.left;
                    }
                    yield return new WaitForSeconds(0.01f);
                }
            }

            cont++;
        }
    }

}
