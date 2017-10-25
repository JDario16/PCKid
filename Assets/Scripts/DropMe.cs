using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string test;
	public Image containerImage;
	public Image receivingImage;
	private Color normalColor;
    public List<string> instrucciones = new List<string>();
	public Color highlightColor = Color.yellow;
	
	public void OnEnable ()
	{
		if (containerImage != null)
			normalColor = containerImage.color;
	}
	
	public void OnDrop(PointerEventData data)
	{
		//containerImage.color = normalColor;
		
		if (receivingImage == null)
			return;

        string instru = GetDropString(data);
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			receivingImage.overrideSprite = dropSprite;
        instrucciones.Add(instru);
        test = instru;
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
