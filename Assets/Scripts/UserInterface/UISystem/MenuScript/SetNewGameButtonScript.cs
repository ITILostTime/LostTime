using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetNewGameButtonScript : MonoBehaviour, IPointerDownHandler
{
    public virtual void OnPointerDown(PointerEventData InventoryBag)
    {
        Destroy(GameObject.Find("InterfaceEvent"));
    }
}
