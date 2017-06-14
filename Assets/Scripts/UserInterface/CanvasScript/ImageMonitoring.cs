using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageMonitoring : MonoBehaviour {

    private GameObject _canvas;

    public Dictionary<string, Sprite> _BackGroundSprite;
    public Dictionary<string, Sprite> _LanguagesGear;
    public Dictionary<string, Sprite> _pub;
    public Dictionary<string, Sprite> _icon;
    public Dictionary<string, Sprite> _other;
    public Dictionary<string, Sprite> _arrow;


    private void Awake()
    {
        _canvas = GameObject.Find("MenuCanvas");

        _BackGroundSprite = new Dictionary<string, Sprite>();
        _LanguagesGear = new Dictionary<string, Sprite>();
        _pub = new Dictionary<string, Sprite>();
        _icon = new Dictionary<string, Sprite>();
        _other = new Dictionary<string, Sprite>();
        _arrow = new Dictionary<string, Sprite>();

        LoadSprite("Sprites/SpriteBackGround", _BackGroundSprite);
        LoadSprite("Sprites/SpriteIcon", _icon);
        LoadSprite("Sprites/SpriteOther", _other);
        LoadSprite("Sprites/SpritePub", _pub);
        LoadSprite("Sprites/SpriteLanguages", _LanguagesGear);
        LoadSprite("Sprites/SpriteSteampunkArrow", _arrow);

    }

    private void LoadSprite(string path, Dictionary<string, Sprite> Dictionnary)
    {
        Sprite[] sprite = Resources.LoadAll<Sprite>(path);

        foreach (Sprite s in sprite)
        {
            Dictionnary.Add(s.name, s);
            //Debug.Log(s.name);
        }
    }

    public Sprite GetSprite(string name, Dictionary<string, Sprite> dictionary)
    {
        if (dictionary.ContainsKey(name))
        {
            return (dictionary[name]);
        }

        Debug.LogError("Unrecognized Tile Type " + name);
        return null;
    }


    public void PutBackGroundImageOnGameObject(string GameObjectName, string GameObjectParentName, Sprite BackGround, 
        bool LeftLimitSprite, Sprite BackGroundLimitLeft,
        bool RightLimitSprite, Sprite BackGroundLimitRight,
        bool UpLimitSprite, Sprite BackGroundLimitUp,
        bool DownLimitSprite, Sprite BackGroundLimitDown, 
        float LimitSizeX, float LimitSizeY)
    {
        this.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName, GameObject.Find(GameObjectParentName), true,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height,
                    0, 0, BackGround);

        if(LeftLimitSprite == true)
        {
            this.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "LeftLimit", GameObject.Find(GameObjectParentName), true,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / LimitSizeX,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / LimitSizeY,
                    -(GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / 2) 
                    + (GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / 2) / LimitSizeX,
                    0, BackGroundLimitLeft);
        }

        if(RightLimitSprite == true)
        {
            this.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "RightLimit", GameObject.Find(GameObjectParentName), true,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / LimitSizeX,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / LimitSizeY,
                    (GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / 2
                    - (GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / 2) / LimitSizeX),
                    0, BackGroundLimitRight);
        }

        if(UpLimitSprite == true)
        {
            this.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "UpLimit", GameObject.Find(GameObjectParentName), true,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / LimitSizeX,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / LimitSizeY,
                    0, (GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / 2
                    - (GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / 2) / LimitSizeY),
                    BackGroundLimitUp);
        }

        if(DownLimitSprite == true)
        {
            this.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "DownLimit", GameObject.Find(GameObjectParentName), true,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / LimitSizeX,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / LimitSizeY,
                    0, -(GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / 2)
                    + (GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / 2) / LimitSizeY,
                    BackGroundLimitDown);
        }
    }
    

    public Sprite GetInventoryBagBackGround
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteBackGround_01", _canvas.GetComponent<ImageMonitoring>()._BackGroundSprite); }
    }

    public Sprite GetBackGround1
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteBackGround_02", _canvas.GetComponent<ImageMonitoring>()._BackGroundSprite); }
    }

    public Sprite GetBackGround2
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteBackGround_03", _canvas.GetComponent<ImageMonitoring>()._BackGroundSprite); }
    }

    public Sprite GetBackGround3//////////////////////////
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteBackGround_03", _canvas.GetComponent<ImageMonitoring>()._BackGroundSprite); }
    }

    public Sprite GetBackGround4/////////////////////////
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteBackGround_03", _canvas.GetComponent<ImageMonitoring>()._BackGroundSprite); }
    }

    public Sprite GetBackGround5//////////////////
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteBackGround_03", _canvas.GetComponent<ImageMonitoring>()._BackGroundSprite); }
    }

    public Sprite GetPub1
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpritePub_01", _canvas.GetComponent<ImageMonitoring>()._pub); }
    }

    public Sprite GetPub2
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpritePub_02", _canvas.GetComponent<ImageMonitoring>()._pub); }
    }

    public Sprite GetPub3
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpritePub_03", _canvas.GetComponent<ImageMonitoring>()._pub); }
    }

    public Sprite GetWoodBackGround
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteOther_01", _canvas.GetComponent<ImageMonitoring>()._other); }
    }

    public Sprite GetMetalCircle
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteOther_02", _canvas.GetComponent<ImageMonitoring>()._other); }
    }

    public Sprite GetMapPanel
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteOther_03", _canvas.GetComponent<ImageMonitoring>()._other); }
    }

    public Sprite GetDownArrow//////////////////
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteSteampunkArrow_01", _canvas.GetComponent<ImageMonitoring>()._arrow); }
    }

    public Sprite GetLeftArrow
    {
        get {  return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteSteampunkArrow_01", _canvas.GetComponent<ImageMonitoring>()._arrow); }
    }

   public Sprite GetRightArrow
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteSteampunkArrow_02", _canvas.GetComponent<ImageMonitoring>()._arrow); }
    }

    public Sprite GetKnob////////////////
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteSteampunkArrow_02", _canvas.GetComponent<ImageMonitoring>()._arrow); }
    }

    public Sprite GetMapButton
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_02", _canvas.GetComponent<ImageMonitoring>()._icon); }
    }

    public Sprite GetConfigButton
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_05", _canvas.GetComponent<ImageMonitoring>()._icon); }
    }

    public Sprite GetQuestButton
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_06", _canvas.GetComponent<ImageMonitoring>()._icon); }
    }

    public Sprite GetLeaveButton
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_03", _canvas.GetComponent<ImageMonitoring>()._icon); }
    }

    public Sprite GetBagButton
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_01", _canvas.GetComponent<ImageMonitoring>()._icon); }
    }

    public Sprite GetBlackGear
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_04", _canvas.GetComponent<ImageMonitoring>()._icon); }
    }

    public Sprite GetYellowGear///////////////////////////
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_04", _canvas.GetComponent<ImageMonitoring>()._icon); }
    }

    public Sprite GetFrenchFlag
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteLanguages_01", _canvas.GetComponent<ImageMonitoring>()._LanguagesGear); }
    }

    public Sprite GetEnglishFlag
    {
        get { return _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteLanguages_02", _canvas.GetComponent<ImageMonitoring>()._LanguagesGear); }
    }

}
