using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUserInterfaceController : MonoBehaviour
{

    private float _AnimationPanelSpeed = 25f;
    private float _AnimationRotateSpeed = 2f;
    


    public bool VrtAnimToUserInterface(string GameObjectName, float finalePositionX, float finalePositionY, int sens)
    {
        GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition +=
            new Vector2(0, _AnimationPanelSpeed * sens);

        if (GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition.y <= finalePositionY)
        {
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition
                = new Vector2(finalePositionX, finalePositionY);
            return false;
        }
        return true;
    }

    public bool VrtAnimToDestroy(string GameObjectName, float finalePositionY, int sens)
    {
        GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition +=
            new Vector2(0, _AnimationPanelSpeed * sens);

        if (finalePositionY <= GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition.y)
        {
            Destroy(GameObject.Find(GameObjectName));
            return false;
        }
        return true;
    }

    public bool HztAnimToUserInterfaceRightToLeft(string GameObjectName, float finalePositionX, float finalePositionY, int sens)
    {
        GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition +=
            new Vector2(_AnimationPanelSpeed * sens, 0);

        if (GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition.x <= finalePositionX)
        {
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition
                = new Vector2(finalePositionX, finalePositionY);
            return false;
        }
        return true;
    }

    public bool HztAnimToDestroyLeftToRight(string GameObjectName, float finalePositionX, int sens)
    {
        GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition +=
            new Vector2(_AnimationPanelSpeed * sens, 0);

        if (finalePositionX <= GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition.x)
        {
            Destroy(GameObject.Find(GameObjectName));
            return false;
        }
        return true;
    }

    public bool HztAnimToUserInterfaceLeftToRight(string GameObjectName, float finalePositionX, float finalePositionY, int sens)
    {
        GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition +=
            new Vector2(_AnimationPanelSpeed * sens, 0);

        if (finalePositionX <= GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition.x)
        {
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition
                = new Vector2(finalePositionX, finalePositionY);
            return false;
        }
        return true;
    }

    public bool HztAnimToDestroyRightToLeft(string GameObjectName, float finalePositionX, int sens)
    {
        GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition +=
            new Vector2(_AnimationPanelSpeed * sens, 0);

        if (GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition.x <= finalePositionX)
        {
            Destroy(GameObject.Find(GameObjectName));
            return false;
        }
        return true;
    }

    public void RotationObjectOnAxe(string GameObjectName, float x, float AnimationRotateSpeedX, float y, float AnimationRotateSpeedY, float z, float AnimationRotateSpeedZ)
    {
        GameObject.Find(GameObjectName).GetComponent<RectTransform>().transform.Rotate(x * AnimationRotateSpeedX, y * AnimationRotateSpeedY, z * AnimationRotateSpeedZ);
    }
}
