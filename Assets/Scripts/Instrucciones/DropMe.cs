using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler
{
    int con = 0;
    float x = -300f;
    float y = 160f;
    public List<string> instrucciones = new List<string>();
    instanciar crear = new instanciar();
	
	public void OnEnable ()
	{

	}
	
	public void OnDrop(PointerEventData data)
	{
        if (con < 20)
        {

            string instru = GetDropString(data);
            if (x < 200f)
            {
                x = x + 100f;
            }
            else
            {
                y = y - 100f;
                x = -200f;
            }
            crear.Crear(x, y, instru);
            instrucciones.Add(instru);
            con++;
        }
        else {

        }
		
		
	}

    private string GetDropString(PointerEventData data)
    {
        var originalObj = data.pointerDrag;
        if (originalObj == null)
            return null;

        var dragMe = originalObj.GetComponent<DragMe>();
        if (dragMe == null)
            return null;

        string instru = dragMe.instruction;
        if (instru == null)
            return null;

        return instru;
    }
}
