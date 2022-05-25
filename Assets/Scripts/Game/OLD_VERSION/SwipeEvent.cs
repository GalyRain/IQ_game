using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeEvent : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.delta;
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            if (delta.x > 0) Debug.Log("Swipe Right");
            else  Debug.Log("Swipe Left");
        }
        else
        {
            if (delta.y > 0) Debug.Log("Swipe Up");
            else  Debug.Log("Swipe Down");
        }
    }

    public void OnDrag(PointerEventData eventData) {}
}