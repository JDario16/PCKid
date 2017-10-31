using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    int conx = 0;
    int cony = 0;
    int conh = 0;
    int con = 0;
    float x = -100f;
    float y = 160f;
	public Image containerImage;
	public Image receivingImage;
	private Color normalColor;
    public List<string> instrucciones = new List<string>();
	public Color highlightColor = Color.yellow;
    instanciar crear = new instanciar();
	
	public void OnEnable ()
	{
		if (containerImage != null)
			normalColor = containerImage.color;
	}
	
	public void OnDrop(PointerEventData data)
	{
        if (con < 16)
        {
            if (receivingImage == null)
                return;

            string instru = GetDropString(data);
            if (conx < 6 && x < 200f)
            {
                conx++;
                x = x + 100f;
            }
            else if (conh < 1)
            {
                Debug.Log("estoy aqui");
                y = y - 100f;
                x = 0f;
                conh++;
                conx = 0;
            }
            else
            {
                y = y - 100f;
                x = -200f;
                conx = 0;
            }
            crear.Crear(x, y, instru);
            Sprite dropSprite = GetDropSprite(data);
            if (dropSprite != null)
                receivingImage.overrideSprite = dropSprite;
            instrucciones.Add(instru);

            con++;
        }
        else {

        }
		
		
	}

	public void OnPointerEnter(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			containerImage.color = highlightColor;
	}

	public void OnPointerExit(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		containerImage.color = normalColor;
	}
	
	private Sprite GetDropSprite(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;
		
		var dragMe = originalObj.GetComponent<DragMe>();
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

        var dragMe = originalObj.GetComponent<DragMe>();
        if (dragMe == null)
            return null;

        string instru = dragMe.instruction;
        if (instru == null)
            return null;

        return instru;
    }
}
