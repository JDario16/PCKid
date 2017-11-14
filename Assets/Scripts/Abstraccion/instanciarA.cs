using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciarA : MonoBehaviour
{
    int con = 0;

    List<GameObject> invocar = new List<GameObject>();
    GameObject animales;
    string box;

    private void Start()
    {

    }
    /*Funcion que instancia con la ayuda de los parametros "x":posicion en x, "y":posicion en y, 
      "animal":nombre del animal a instanciar, "caja":En donde se hara el drop*/
    public void CrearA(float x, float y, string animal, string caja)
    {


        Debug.Log("Estoy aqui");
        if (caja == "omnivoro")
        {
            Debug.Log("Estoy aqui");
            box = "omnivoro";
            animales = GameObject.Find(box);
            invocar.Add(Instantiate(Resources.Load(string.Concat("Prefabs/Abstraccion/", animal))) as GameObject);
        }
        else if (caja == "carnivoro")
        {
            box = "carnivoro";
            animales = GameObject.Find(box);
            invocar.Add(Instantiate(Resources.Load(string.Concat("Prefabs/Abstraccion/", animal))) as GameObject);
        }
        else if (caja == "vegetariano")
        {
            box = "vegetariano";
            animales = GameObject.Find(box);
            invocar.Add(Instantiate(Resources.Load(string.Concat("Prefabs/Abstraccion/", animal))) as GameObject);
        }


        /*En esta parte del codigo se indica donde sera instanciado el objeto nuevo, donde con caja
         se puede determinar el padre correspondiente y darle una posicion en este.*/
        invocar[con].transform.parent = GameObject.Find(box).transform;
        Debug.Log(animales.GetComponent<RectTransform>().anchoredPosition);
        invocar[con].transform.localPosition = animales.GetComponent<RectTransform>().anchoredPosition3D;
        invocar[con].transform.position += new Vector3(x, y, 0) * 1;
        invocar[con].transform.localScale = new Vector3(1f, 1f, 1f);

        con++;
    }

}
