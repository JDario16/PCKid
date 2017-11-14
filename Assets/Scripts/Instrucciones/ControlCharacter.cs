using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControlCharacter : MonoBehaviour {
	public float velocidad;
    private bool izquierda = false, arriba = false, abajo = false, derecha = true;
    private int cont = 0;
    private int seg = 100;

    public void Start()
    {
        StartCoroutine(moving());
       
    }
    /*Funcion que lee las instrucciones ingresadas y las ejecuta una vez presionado el boton de inicio*/
    IEnumerator moving() {

        List<string> movimientos = GameObject.Find("Instrucciones").GetComponent<DropMe>().instrucciones;
        cont = 0;

        while (cont < movimientos.Count)
        {
            
            if (movimientos[cont] == "derecha")
            {
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
                /*For que ayuda a que el personaje se mueva de forma fluida gracias al delay que ofrece*/
                for (int i = 0; i < seg; i++)
                {
                    if (abajo)
                    {
                        transform.position += Vector3.down;
                    }else
                    if (derecha)
                    {
                        transform.position += Vector3.right;
                    }else
                    if (arriba)
                    {
                        transform.position += Vector3.up;
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
