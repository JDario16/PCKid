using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMeD : MonoBehaviour, IDropHandler
{
    int con = 0;
    /*Las variables "x" y "y" sirven para dar una posicion inicial al objeto cuando
     es instanciado por el metodo CrearA*/
    float x = -275f;
    float y = 140f;
    public List<string> colores = new List<string>();
    instanciarD crear = new instanciarD();
	
	public void OnEnable ()
	{
		
	}
	
	public void OnDrop(PointerEventData data)
	{
        /*La siguiente condición indica cuantos objetos podran hacer drop y ser instanciados,
         aqui mismo se indica la posicion de cada nuevo objeto*/
        if (con < 15)
        {
            
            string col = GetDropString(data);
            if (x < 175f)
            {
                x = x + 90f;
            }
            else
            {
                y = y - 110f;
                x = -185f;
            }
            //Funcion que ayuda a instanciar los valores que se le es dado al drop
            crear.CrearD(x, y, col);
            colores.Add(col);

            con++;
        }
        else {

        }
		
		
	}
	
	private Sprite GetDropSprite(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;
		
		var dragMe = originalObj.GetComponent<DragMeD>();
		if (dragMe == null)
			return null;
		
		var srcImage = originalObj.GetComponent<Image>();
		if (srcImage == null)
			return null;
		
		return srcImage.sprite;
	}

    //Funcion que sirve para obtener el nombre del objeto que viene del drag
    private string GetDropString(PointerEventData data)
    {
        var originalObj = data.pointerDrag;
        if (originalObj == null)
            return null;

        var dragMe = originalObj.GetComponent<DragMeD>();
        if (dragMe == null)
            return null;

        string cool = dragMe.clr;
        if (cool == null)
            return null;

        return cool;
    }
}
