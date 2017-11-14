using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMeA : MonoBehaviour, IDropHandler
{
    int con = 0;
    /*Las variables "x" y "y" sirven para dar una posicion inicial al objeto cuando
     es instanciado por el metodo CrearA*/
    float x = -242f;
    float y = 164f;
    /*La variable bloque sirve para obtener el nombre dado al objeto donde se hace el drop*/
    public string bloque;
    public List<string> animales = new List<string>();
    instanciarA crear = new instanciarA();

    public void OnEnable()
    {

    }

    public void OnDrop(PointerEventData data)
    {
        /*La siguiente condición indica cuantos objetos podran hacer drop y ser instanciados,
         aqui mismo se indica la posicion de cada nuevo objeto*/
        if (con < 16)
        {

            string animal = GetDropString(data);
            if (x < 158f)
            {
                x = x + 100f;
            }
            else
            {
                y = y - 100f;
                x = -142f;
            }
            //Funcion que ayuda a instanciar los valores que se le es dado al drop
            crear.CrearA(x, y, animal, bloque);
            animales.Add(animal);
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

        var dragMe = originalObj.GetComponent<DragMeA>();
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

        var dragMe = originalObj.GetComponent<DragMeA>();
        if (dragMe == null)
            return null;

        string instru = dragMe.animal;
        if (instru == null)
            return null;

        return instru;
    }
}
