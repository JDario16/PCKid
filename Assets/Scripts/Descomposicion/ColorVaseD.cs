using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ColorVaseD : MonoBehaviour {


    private Vector4 red = new Vector4(1f, 0f, 0f, 1f);
    private Vector4 yellow = new Vector4(0f, 1f, 0f, 1f);
    private Vector4 blue = new Vector4(0f, 0f, 1f, 1f);
    
    private Vector4 cal = new Vector4(0f, 0f, 0f, 0f);
    GameObject Vaso;
    private int con = 0;
    private GameObject fondo;

    public void coloring() {

        Vaso = GameObject.Find("Vaso");
        Color check = Vaso.GetComponent<Image>().color;
        fondo = GameObject.Find("Fondo");
        List<string> colours = GameObject.Find("Recipientes").GetComponent<DropMeD>().colores;
        while (con<colours.Count) {
            if (colours[con] == "red")
            {
                //if (con == 0)
                    cal = red + cal;
                //else cal = (red + cal) / 2;
            }
            else if (colours[con] == "yellow")
            {
                //if (con == 0)
                    cal = yellow + cal;
                //else cal = (yellow + cal) / 2;
            }
            else if (colours[con] == "blue"){
                //if (con == 0)
                    cal = blue + cal;
                //else cal = (blue + cal) / 2;
            }
            con++;
        }
        
        cal = cal/colours.Count; 
        fondo.GetComponent<SpriteRenderer>().color = RybToRgb(cal[0],cal[1],cal[2],cal[3]);
        cal = new Vector4(0f,0f,0f,0f);
        con = 0;
    }

    private Vector4 RybToRgb(float iRed, float iYellow, float iBlue, float iAlpha) {
        float iWhite = Math.Min(iRed,Math.Min(iYellow,iBlue));

        iRed -= iWhite;
        iYellow -= iWhite;
        iBlue -= iWhite;

        float iMaxYellow = Math.Max(iRed,Math.Max(iYellow, iBlue));

        float iGreen = Math.Min(iYellow, iBlue);

        iYellow -= iGreen;
        iBlue -= iGreen;

        if (iBlue > 0 && iGreen > 0)
        {
            iBlue *= 2.0f;
            iGreen *= 2.0f;
        }

        // Redistribute the remaining yellow.
        iRed += iYellow;
        iGreen += iYellow;

        // Normalize to values.
        var iMaxGreen = Math.Max(iRed, Math.Max(iGreen, iBlue));

        if (iMaxGreen > 0)
        {
            float iN = iMaxYellow / iMaxGreen;

            iRed *= iN;
            iGreen *= iN;
            iBlue *= iN;
        }

        // Add the white back in.
        iRed += iWhite;
        iGreen += iWhite;
        iBlue += iWhite;




        return new Vector4(iRed, iGreen, iBlue, iAlpha)*2f;
    }

}
