using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciarP : MonoBehaviour {
    int con = 0;

    List<GameObject> invocar = new List<GameObject>();
    GameObject instrucciones;

    private void Start()
    {

    }

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
        
        invocar[con].transform.parent    = GameObject.Find("Instrucciones").transform;
        Debug.Log(instrucciones.GetComponent<RectTransform>().anchoredPosition);
        invocar[con].transform.localPosition = instrucciones.GetComponent<RectTransform>().anchoredPosition3D;
        invocar[con].transform.position += new Vector3(x, y, 0) * 1.783441790744985f;
        invocar[con].transform.localScale = new Vector3(1f, 1f, 1f);

        con++;
    }
}
