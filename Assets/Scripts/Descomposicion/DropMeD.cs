using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMeD : MonoBehaviour, IDropHandler
{
    int conx = 0;
    int cony = 0;
    int conh = 0;
    int con = 0;
    float x = -275f;
    float y = 140f;
    public List<string> colores = new List<string>();
    instanciarD crear = new instanciarD();
	
	public void OnEnable ()
	{
		
	}
	
	public void OnDrop(PointerEventData data)
	{
        if (con < 15)
        {
            
            string col = GetDropString(data);
            if (conx < 5 && x < 175f)
            {
                conx++;
                x = x + 90f;
            }
            else
            {
                y = y - 110f;
                x = -185f;
                conx = 0;
            }
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
