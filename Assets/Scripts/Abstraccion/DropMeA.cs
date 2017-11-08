using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMeA : MonoBehaviour, IDropHandler
{
    int con = 0;
    float x = -300f;
    float y = 160f;
    public string bloque;
    public List<string> animales = new List<string>();
    instanciarA crear = new instanciarA();
	
	public void OnEnable ()
	{

	}
	
	public void OnDrop(PointerEventData data)
	{
        if (con < 20)
        {

            string animal = GetDropString(data);
            if (x < 200f)
            {
                x = x + 100f;
            }
            else
            {
                y = y - 100f;
                x = -200f;
            }
            crear.CrearA(x, y, animal, bloque);
            animales.Add(animal);
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
