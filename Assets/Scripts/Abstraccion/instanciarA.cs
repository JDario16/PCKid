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

    public void CrearA(float x, float y, string animal, string caja)
    {
        if (caja == "omnivoro")
        {
            box = "cOmnivoros";
            animales = GameObject.Find(box);
            invocar.Add(Instantiate(Resources.Load(string.Concat("Prefabs/Abstraccion/", animal))) as GameObject);
        }
        else if (caja == "carnivoro")
        {
            box = "cCarnivoros";
            animales = GameObject.Find(box);
            invocar.Add(Instantiate(Resources.Load(string.Concat("Prefabs/Abstraccion/", animal))) as GameObject);
        }
        else if (caja == "vegetariano")
        {
            box = "cVegetarianos";
            animales = GameObject.Find(box);
            invocar.Add(Instantiate(Resources.Load(string.Concat("Prefabs/Abstraccion/", animal))) as GameObject);
        }



        invocar[con].transform.parent = GameObject.Find(box).transform;
        Debug.Log(animales.GetComponent<RectTransform>().anchoredPosition);
        invocar[con].transform.localPosition = animales.GetComponent<RectTransform>().anchoredPosition3D;
        invocar[con].transform.position += new Vector3(x, y, 0) * 1.783441790744985f;
        invocar[con].transform.localScale = new Vector3(1f, 1f, 1f);

        con++;
    }

}
