using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class DragD : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");

        this.transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");

        this.transform.position = eventData.position;
        
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");

        this.transform.position = eventData.position;
    }

    void Update() {
        Vector3 pos = transform.position;
        pos.z = 461;
        transform.position = pos;
    }
}
