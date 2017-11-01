using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ColorVaseD : MonoBehaviour {


    private Color red = new Vector4(1f, 0f, 0f, 1f);
    private Color blue = new Vector4(0f, 0f, 1f, 1f);
    private Color yellow = new Vector4(1f, 1f, 0f, 1f);
    private Color cal = new Vector4(0f, 0f, 0f, 0f);
    GameObject Vaso;
    private int con = 0;
    private List<string> cadenas;
    private GameObject fondo;

    public void coloring() {

        Vaso = GameObject.Find("Vaso");
        Color check = Vaso.GetComponent<Image>().color;
        fondo = GameObject.Find("Fondo");
        List<string> colours = GameObject.Find("Recipientes").GetComponent<DropMeD>().colores;
        while (con<colours.Count) {
            if (colours[con] == "red")
            {
                if (con == 0)
                    cal = red + cal;
                else cal = (red + cal) / 2;
            }
            else if (colours[con] == "yellow")
            {
                if (con == 0)
                    cal = yellow + cal;
                else cal = (yellow + cal) / 2;
            }
            else if (colours[con] == "blue"){
                if (con == 0)
                    cal = blue + cal;
                else cal = (blue + cal) / 2;
            }
            Debug.Log(cal);
            
            con++;
        }


        fondo.GetComponent<SpriteRenderer>().color = cal;
        cal = new Vector4(0f,0f,0f,0f);
        con = 0;
    }

}
