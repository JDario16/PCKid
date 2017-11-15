using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verificar : MonoBehaviour {
    private string[] omnivoros;
    private string[] carnivoros;
    private string[] vegetarianos;
    private List<string> omnivoro;
    private List<string> carnivoro;
    private List<string> vegetariano;
    private int ver;

    // Use this for initialization
    void Start () {
        omnivoros = new string[] {"Cerdo","Oso","Perro","Caracol","raton"};
        carnivoros = new string[] {"Gato", "Serpiente", "Leon", "zorro" };
        vegetarianos = new string[] {"Oveja","Vaca","Conejo","Caballo","Jirafa","Hipopotamo"};
        ver = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void check() {
        omnivoro = GameObject.Find("omnivoro").GetComponent<DropMeA>().animales;
        carnivoro = GameObject.Find("carnivoro").GetComponent<DropMeA>().animales;
        vegetariano = GameObject.Find("vegetariano").GetComponent<DropMeA>().animales;

        if (omnivoros.Length == omnivoro.Count){
            for (int i = 0; i < omnivoros.Length; i++) {
                ver = 0;
                for (int j = 0; j < omnivoros.Length; j++) {
                    if (omnivoros[i] == omnivoro[j]) {
                        ver = 1;
                    }

                }
                if (ver == 0) {
                    GameObject.Find("CameraGameOver").GetComponent<CameraGameOver>().CameraChange(0);
                    return;
                }
            }
        }else {
            GameObject.Find("CameraGameOver").GetComponent<CameraGameOver>().CameraChange(0);
            return;
        }

        if (carnivoro.Count==carnivoros.Length) {
            for (int i = 0; i < carnivoros.Length; i++)
            {
                ver = 0;
                for (int j = 0; j < carnivoros.Length; j++)
                {
                    if (carnivoros[i] == carnivoro[j])
                    {
                        ver = 1;
                    }

                }
                if (ver == 0)
                {
                    GameObject.Find("CameraGameOver").GetComponent<CameraGameOver>().CameraChange(0);
                    return;
                }
            }
        } else {
            GameObject.Find("CameraGameOver").GetComponent<CameraGameOver>().CameraChange(0);
            return;
        }

        if (vegetariano.Count==vegetarianos.Length) {
            for (int i = 0; i < vegetarianos.Length; i++)
            {
                ver = 0;
                for (int j = 0; j < vegetarianos.Length; j++)
                {
                    if (vegetarianos[i] == vegetariano[j])
                    {
                        ver = 1;
                    }

                }
                if (ver == 0)
                {
                    GameObject.Find("CameraGameOver").GetComponent<CameraGameOver>().CameraChange(0);
                    return;
                }
            }
        }
        else {
            GameObject.Find("CameraGameOver").GetComponent<CameraGameOver>().CameraChange(0);
            return;
        }

        GameObject.Find("CameraGameOver").GetComponent<CameraGameOver>().CameraChange(1);
    }
}
