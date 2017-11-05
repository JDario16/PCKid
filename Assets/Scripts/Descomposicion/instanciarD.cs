using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciarD : MonoBehaviour {
    int con = 0;

    List<GameObject> invocar = new List<GameObject>();
    GameObject instrucciones;

    private void Start()
    {

    }

    public void CrearD(float x, float y, string color2) {
        instrucciones = GameObject.Find("Instrucciones");
        if (color2 == "red")
        {
            invocar.Add(Instantiate(Resources.Load("Prefabs/Descomposicion/RedBox")) as GameObject);
        }
        else if (color2 == "blue")
        {
            invocar.Add(Instantiate(Resources.Load("Prefabs/Descomposicion/BlueBox")) as GameObject);
        }
        else if (color2 == "yellow") {
            invocar.Add(Instantiate(Resources.Load("Prefabs/Descomposicion/YellowBox")) as GameObject);
        }
        
        invocar[con].transform.parent    = GameObject.Find("Instrucciones").transform;
        Debug.Log(instrucciones.GetComponent<RectTransform>().anchoredPosition);
        invocar[con].transform.localPosition = instrucciones.GetComponent<RectTransform>().anchoredPosition3D;
        invocar[con].transform.position += new Vector3(x, y, 0) * 1.783441790744985f;
        invocar[con].transform.localScale = new Vector3(1f, 1f, 1f);

        con++;
    }
}
