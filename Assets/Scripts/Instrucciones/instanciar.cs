using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciar : MonoBehaviour {
    int con = 0;

    List<GameObject> invocar = new List<GameObject>();
    GameObject instrucciones;

    private void Start()
    {

    }
    /*Funcion que instancia con la ayuda de los parametros "x":posicion en x, "y":posicion en y, 
      "instruccion":nombre de la instruccion a instanciar*/
    public void Crear(float x, float y, string instruction) {
        instrucciones = GameObject.Find("Instrucciones");
        if (instruction == "adelante")
        {
            invocar.Add(Instantiate(Resources.Load("Prefabs/Instrucciones/Adelante")) as GameObject);
        }
        else if (instruction == "izquierda")
        {
            invocar.Add(Instantiate(Resources.Load("Prefabs/Instrucciones/GirarDerecha")) as GameObject);
        }
        else if (instruction == "derecha") {
            invocar.Add(Instantiate(Resources.Load("Prefabs/Instrucciones/GirarIzquierda")) as GameObject);
        }
        
        /*En esta parte del codigo se indica donde sera instanciado el objeto nuevo, junto con su posicion
         en este*/
        invocar[con].transform.parent    = GameObject.Find("Instrucciones").transform;
        invocar[con].transform.localPosition = instrucciones.GetComponent<RectTransform>().anchoredPosition3D;
        invocar[con].transform.position += new Vector3(x, y, 0) * 1.783441790744985f;
        invocar[con].transform.localScale = new Vector3(1f, 1f, 1f);

        con++;
    }
}
