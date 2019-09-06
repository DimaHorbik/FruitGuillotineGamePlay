using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Repairs : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Damage.hp <= 100)
        {
            Damage.hp = Damage.hp + 5;
            Debug.Log(Damage.hp);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}
