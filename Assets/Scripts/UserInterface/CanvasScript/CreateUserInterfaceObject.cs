using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateUserInterfaceObject : MonoBehaviour {
    

    public void CreateGameObjectImage(string GameObjectName, GameObject GameObjectParent, bool isAnchoredToParent, float SizeDeltaX, float SizeDeltaY, 
        float AnchoredPositionX, float AnchoredPositionY, Color BackGroundColor)
    {
        GameObject gameobject = new GameObject(GameObjectName);
        gameobject.AddComponent<RectTransform>();
        gameobject.transform.SetParent(GameObjectParent.transform, isAnchoredToParent);
        gameobject.GetComponent<RectTransform>().sizeDelta = new Vector2(SizeDeltaX, SizeDeltaY);
        gameobject.GetComponent<RectTransform>().anchoredPosition = new Vector2(AnchoredPositionX, AnchoredPositionY);
        Image X = gameobject.AddComponent<Image>();
        X.color = BackGroundColor;
    }

    public void CreateEmptyGameObject(string GameObjectName, GameObject GameObjectParent, bool isAnchoredToParent, float SizeDeltaX, float SizeDeltaY,
        float AnchoredPositionX, float AnchoredPositionY)
    {
        GameObject gameobject = new GameObject(GameObjectName);
        gameobject.AddComponent<RectTransform>();
        gameobject.transform.SetParent(GameObjectParent.transform, isAnchoredToParent);
        gameobject.GetComponent<RectTransform>().sizeDelta = new Vector2(SizeDeltaX, SizeDeltaY);
        gameobject.GetComponent<RectTransform>().anchoredPosition = new Vector2(AnchoredPositionX, AnchoredPositionY);
    }

    public void CreateGameObjectImageSprite(string GameObjectName, GameObject GameObjectParent, bool isAnchoredToParent, float SizeDeltaX, float SizeDeltaY, 
        float AnchoredPositionX, float AnchoredPositionY, Sprite Image)
    {
        GameObject gameobject = new GameObject(GameObjectName);
        gameobject.AddComponent<RectTransform>();
        gameobject.transform.SetParent(GameObjectParent.transform, isAnchoredToParent);
        gameobject.GetComponent<RectTransform>().sizeDelta = new Vector2(SizeDeltaX, SizeDeltaY);
        gameobject.GetComponent<RectTransform>().anchoredPosition = new Vector2(AnchoredPositionX, AnchoredPositionY);
        gameobject.AddComponent<Image>();
        gameobject.GetComponent<Image>().sprite = Image;
    }

    public void CreateGameObjectButtonWithText(string GameObjectName, GameObject GameObjectParent, bool isAnchoredToParent, float SizeDeltaX, float SizeDeltaY,
        float AnchoredPositionX, float AnchoredPositionY, string text, Font font, TextAnchor textAnchor, FontStyle fontStyle, int FontSize, Color TextColor)
    {
        GameObject gameobject = new GameObject(GameObjectName);
        gameobject.AddComponent<Button>();
        gameobject.AddComponent<RectTransform>();
        gameobject.transform.SetParent(GameObjectParent.transform, isAnchoredToParent);
        gameobject.GetComponent<RectTransform>().sizeDelta = new Vector2(SizeDeltaX, SizeDeltaY);
        gameobject.GetComponent<RectTransform>().anchoredPosition = new Vector2(AnchoredPositionX, AnchoredPositionY);
        gameobject.AddComponent<Text>();
        gameobject.GetComponent<Text>().text = text;
        gameobject.GetComponent<Text>().font = font;
        gameobject.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
        gameobject.GetComponent<Text>().alignment = textAnchor;
        gameobject.GetComponent<Text>().fontStyle = fontStyle;
        gameobject.GetComponent<Text>().fontSize = FontSize;
        gameobject.GetComponent<Text>().color = TextColor;
    }

    public void CreateGameObjectTextZone(string GameObjectName, GameObject GameObjectParent, bool isAnchoredToParent, float SizeDeltaX, float SizeDeltaY, 
        float AnchoredPositionX, float AnchoredPositionY, string text, Font font, TextAnchor textAnchor, 
        FontStyle fontStyle, int FontSize, Color TextColor)
    {
        GameObject gameobject = new GameObject(GameObjectName);
        gameobject.AddComponent<RectTransform>();
        gameobject.transform.SetParent(GameObjectParent.transform, isAnchoredToParent);
        gameobject.GetComponent<RectTransform>().sizeDelta = new Vector2(SizeDeltaX, SizeDeltaY);
        gameobject.GetComponent<RectTransform>().anchoredPosition = new Vector2(AnchoredPositionX, AnchoredPositionY);
        gameobject.AddComponent<Text>();
        gameobject.GetComponent<Text>().text = text;
        gameobject.GetComponent<Text>().font = font;
        gameobject.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
        gameobject.GetComponent<Text>().alignment = textAnchor;
        gameobject.GetComponent<Text>().fontStyle = fontStyle;
        gameobject.GetComponent<Text>().fontSize = FontSize;
        gameobject.GetComponent<Text>().color = TextColor;
    }
}
