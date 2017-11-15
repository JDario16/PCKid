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
    private Color vaseColor;
    GameObject Vaso;
    private int con = 0;
    private GameObject fondo;

    /*Funcion que suma los colores ingresados y los promedia para despues colorear el vaso*/
    public void coloring() {
        Debug.Log("Press");
        Vaso = GameObject.Find("Vaso");
        Color check = Vaso.GetComponent<Image>().color;
        fondo = GameObject.Find("Fondo");
        List<string> colours = GameObject.Find("Recipientes").GetComponent<DropMeD>().colores;
        while (con<colours.Count) {
            if (colours[con] == "red")
            {
                    cal = red + cal;
            }
            else if (colours[con] == "yellow")
            {
                    cal = yellow + cal;
            }
            else if (colours[con] == "blue"){
                    cal = blue + cal;
            }
            con++;
        }
        
        cal = cal/colours.Count;
        fondo.GetComponent<SpriteRenderer>().color = RybToRgb(cal[0],cal[1],cal[2],cal[3]);
        vaseColor = RybToRgb(cal[0], cal[1], cal[2], cal[3]);
        Debug.Log(vaseColor);
        Debug.Log(GameObject.Find("Vaso").GetComponent<Image>().color);
        if (vaseColor == GameObject.Find("Vaso").GetComponent<Image>().color) {
            Debug.Log("Aqui estoy");
            GameObject.Find("CameraGameOver").GetComponent<CameraGameOver>().CameraChange(1);
        } else{
            Debug.Log("Aqui estoy mal");
            GameObject.Find("CameraGameOver").GetComponent<CameraGameOver>().CameraChange(0);
        }
        cal = new Vector4(0f,0f,0f,0f);
        con = 0;
    }
    /*Funcion que transforma el estandar rgb a ryb para poder cumplir asi el sistema de coloreamiento
     * Given a RYB color, calculate the RGB color.  This code was taken from:
	 * 
	 * @param iRed     The current red value.
	 * @param iYellow  The current yellow value.
	 * @param iBlue    The current blue value.
	 * 
	 * http://www.insanit.net/tag/rgb-to-ryb/
	 * 
	 * Author: Arah J. Leonard
	 * Copyright 01AUG09
	 * Distributed under the LGPL - http://www.gnu.org/copyleft/lesser.html
	 * ALSO distributed under the The MIT License from the Open Source Initiative (OSI) - 
	 * http://www.opensource.org/licenses/mit-license.php
	 * You may use EITHER of these licenses to work with / distribute this source code.
	 * Enjoy!
     */
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




        return new Vector4(iRed, iGreen, iBlue, iAlpha/2)*2f;
    }

}
