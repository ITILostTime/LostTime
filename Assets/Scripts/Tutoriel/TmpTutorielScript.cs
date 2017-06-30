using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TmpTutorielScript : MonoBehaviour {

    private GameObject _userInterface;

    private bool _BlackPanelAnimation;
    private float _blackPanelAnimSpeed = 1;

    private float _animation = 0f;
    private bool _FirstStepPanelanimationText;

    private float _JoysticksDiscoverAnimation = 0f;
    private bool _JoysticksDiscoverAnimationText;

    private float _RightJoysticksDiscoverAnimation = 0f;
    private bool _RightJoysticksDiscoverAnimationText;

    private float _seeFireAnimation = 0f;
    private bool _seeFireAnimationText;

    private float _breakHorlogeAnimationSpeed = 10;
    private float _count = 10;

    private bool _GoOutSideAnimationText;
    private float _gooutsideanimation = 0f;

    public float step = 0;

    private void Start()
    {
        _userInterface = GameObject.Find("Canvas");

        if(PlayerPrefs.HasKey("TutorielComplete") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("BlackPanel", _userInterface, true, _userInterface.GetComponent<RectTransform>().rect.width,
            _userInterface.GetComponent<RectTransform>().rect.height, 0, 0, Color.black);

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("FirstWakeUpText", GameObject.Find("BlackPanel"), true,
                _userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height / 2, 0, 0, "", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(_userInterface.GetComponent<RectTransform>().rect.height / 30)), Color.white);
            _userInterface.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("FirstWakeUpText", "Wake Up Astrid. It's time! \r\n\r\n\r\n\r\n\r\n\r\n --Touch to continue--", "Reveille toi Astrid. C'est l'heure ! \r\n\r\n\r\n\r\n\r\n\r\n --Touchez pour continuer--");
            GameObject.Find("FirstWakeUpText").AddComponent<Button>();
            GameObject.Find("FirstWakeUpText").GetComponent<Button>().onClick.AddListener(() => TimeToWork());

            PlayerPrefs.SetInt("TutorielComplete", 1);
        }
        
    }

    private void TimeToWork()
    {

        Destroy(GameObject.Find("FirstWakeUpText"));
        _BlackPanelAnimation = true;

    }

    private void Update()
    {
        if(GameObject.Find("BlackPanel") == true && _BlackPanelAnimation == true)
        {
            GameObject.Find("BlackPanel").GetComponent<Image>().color = new Color(0, 0, 0, _blackPanelAnimSpeed);
            _blackPanelAnimSpeed -= 0.01f;
            if(_blackPanelAnimSpeed <= 0 )
            {
                Destroy(GameObject.Find("BlackPanel"));
                firstStep();
            }
        }

        if(_FirstStepPanelanimationText == true)
        {
            _animation += Time.deltaTime;
            if(_animation > 1)
            {
                _FirstStepPanelanimationText = false;
                Destroy(GameObject.Find("FirstStepPanel"));
                LeftJoysticksDiscover();
            }
        }

        if (_JoysticksDiscoverAnimationText == true)
        {
            _JoysticksDiscoverAnimation += Time.deltaTime;
            if (_JoysticksDiscoverAnimation > 1)
            {
                _JoysticksDiscoverAnimationText = false;
                Destroy(GameObject.Find("JoysticksDiscoverPanel"));
                GameObject.Find("BackGroundLeftInterface").GetComponent<Image>().color = new Color(255f, 255f, 255f, 1f);
            }
        }

        if (_RightJoysticksDiscoverAnimationText == true)
        {
            _RightJoysticksDiscoverAnimation += Time.deltaTime;
            if (_RightJoysticksDiscoverAnimation > 1)
            {
                _RightJoysticksDiscoverAnimationText = false;
                Destroy(GameObject.Find("RightJoysticksDiscoverPanel"));
                GameObject.Find("BackGroundRightInterface").GetComponent<Image>().color = new Color(255f, 255f, 255f, 1f);
            }
        }

        if (_seeFireAnimationText == true)
        {
            _seeFireAnimation += Time.deltaTime;
            if (_seeFireAnimation > 1)
            {
                _seeFireAnimationText = false;
                Destroy(GameObject.Find("SeeFire"));
                
            }
        }

        if (_GoOutSideAnimationText == true)
        {
            _gooutsideanimation += Time.deltaTime;
            if (_gooutsideanimation > 1)
            {
                _GoOutSideAnimationText = false;
                Destroy(GameObject.Find("GoOutSide"));

            }
        }

        if (step == 1)
        {
            step = 1.5f;
            GameObject.Find("BackGroundLeftInterface").GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
            RightJoystickDiscover();
        }

        if (step == 2)
        {
            step = 2.5f;
            GameObject.Find("BackGroundRightInterface").GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
            goToWatchFire();
        }

        if(step == 3)
        {
            if(_count != 90)
            {
                GameObject.Find("Horloge").transform.Rotate(_breakHorlogeAnimationSpeed, 0, 0);
                _count += 10;
            }
            else
            {
                step = 3.5f;
                PutLetterOnMap();
            }
            
            
            
        }

    }

    private void firstStep()
    {
        if(GameObject.Find("FirstStepPanel") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("FirstStepPanel", _userInterface, true, _userInterface.GetComponent<RectTransform>().rect.width,
              _userInterface.GetComponent<RectTransform>().rect.height, 0, 0, new Color(0, 0, 0, 0.5f));

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("TutorialText", GameObject.Find("FirstStepPanel"), true,
                _userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height / 2, 0, 0, "", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(_userInterface.GetComponent<RectTransform>().rect.height / 15)), Color.white);
            _userInterface.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("TutorialText", "--  Tutorial  --", "--  Tutorial  --");
            _FirstStepPanelanimationText = true;
        }
       
    }

    private void LeftJoysticksDiscover()
    {
        if (GameObject.Find("JoysticksDiscoverPanel") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("JoysticksDiscoverPanel", _userInterface, true, _userInterface.GetComponent<RectTransform>().rect.width,
           _userInterface.GetComponent<RectTransform>().rect.height, 0, 0, new Color(0, 0, 0, 0.5f));

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("JoysticksDiscoverText", GameObject.Find("JoysticksDiscoverPanel"), true,
                _userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height / 2, 0, 0, "", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(_userInterface.GetComponent<RectTransform>().rect.height / 15)), Color.white);
            _userInterface.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("JoysticksDiscoverText", "--  Use Your Left Hand on the left area  --\r\n--  to move Astrid  --", "--  Utlisez votre main gauche sur la surface de gauche  --\r\n--  pour déplacer Astrid  --");
            _JoysticksDiscoverAnimationText = true;
        }
            
    }

    private void RightJoystickDiscover()
    {
        if (GameObject.Find("JoysticksDiscoverPanel") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("RightJoysticksDiscoverPanel", _userInterface, true, _userInterface.GetComponent<RectTransform>().rect.width,
            _userInterface.GetComponent<RectTransform>().rect.height, 0, 0, new Color(0, 0, 0, 0.5f));

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("RightJoysticksDiscoverText", GameObject.Find("RightJoysticksDiscoverPanel"), true,
                _userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height / 2, 0, 0, "", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(_userInterface.GetComponent<RectTransform>().rect.height / 15)), Color.white);
            _userInterface.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("RightJoysticksDiscoverText", "--  Use Your Right Hand on the right area  --\r\n--  to move the camera  --", "--  Utlisez votre main droite sur la surface de droite  --\r\n--  pour déplacer la caméra  --");
            _RightJoysticksDiscoverAnimationText = true;
        }
        
    }

    private void goToWatchFire()
    {
        if (GameObject.Find("JoysticksDiscoverPanel") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SeeFire", _userInterface, true, _userInterface.GetComponent<RectTransform>().rect.width,
            _userInterface.GetComponent<RectTransform>().rect.height, 0, 0, new Color(0, 0, 0, 0.5f));

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SeeFireText", GameObject.Find("SeeFire"), true,
                _userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height / 2, 0, 0, "", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(_userInterface.GetComponent<RectTransform>().rect.height / 15)), Color.white);
            _userInterface.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("SeeFireText", "--  Go to the boiler  --", "-- Aller à la chaudière  --");
            _seeFireAnimationText = true;
        }
        
    }


    public void PutLetterOnMap()
    {
        GameObject.Find("letter").GetComponent<LetterScript>().putLetterenabled();
    }


    public void CreateLetter()
    {
        if(GameObject.Find("letterTextbackGround") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("letterTextbackGround", _userInterface, true, _userInterface.GetComponent<RectTransform>().rect.width / 1.5f, _userInterface.GetComponent<RectTransform>().rect.height,
              0, 0, _userInterface.GetComponent<ImageMonitoring>().GetBackGround5);

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("letterText", GameObject.Find("letterTextbackGround"), true, _userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height / 2,
                0, 0, "", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(_userInterface.GetComponent<RectTransform>().rect.height / 20)), Color.black);
            _userInterface.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("letterText",
                "Clumsy person that you are! The clock which you have just broken was not that a simple antiquity. It is an artefact controlling the time. Now, the City is condemned to live again the same day as long as you will not have assembled all the fragments...You have to find how to repair your damages. Visit the watchmakers' guild's master, he will help you.",
                "Maladroite que tu es ! L’horloge que tu viens de briser n’était pas qu’une simple antiquité. Il s’agit d’un artefact contrôlant le temps. Maintenant, la Ville est condamnée à revivre la même journée tant que tu n’auras pas réassemblé tous les fragments... A toi de trouver comment réparer tes dégats. Vas voir le maître de la Guilde des horlogers, il t'aidera.");
            GameObject.Find("letterText").AddComponent<Button>();
            GameObject.Find("letterText").GetComponent<Button>().onClick.AddListener(() => leaveLetter());

        }
        
    }

    private void leaveLetter()
    {
        Destroy(GameObject.Find("letterTextbackGround"));
        if(step != 4 && PlayerPrefs.HasKey("GoOutSide") == false)
        {
            PlayerPrefs.SetInt("GoOutSide", 1);
            goOutSide();
            step = 4;
        }
    }

    private void goOutSide()
    {
        if (GameObject.Find("JoysticksDiscoverPanel") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("GoOutSide", _userInterface, true, _userInterface.GetComponent<RectTransform>().rect.width,
            _userInterface.GetComponent<RectTransform>().rect.height, 0, 0, new Color(0, 0, 0, 0.5f));

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("GoOutSidetext", GameObject.Find("GoOutSide"), true,
                _userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height / 2, 0, 0, "", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(_userInterface.GetComponent<RectTransform>().rect.height / 15)), Color.white);
            _userInterface.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("GoOutSidetext", "--  Go to the city  --", "-- Aller en ville  --");
            _GoOutSideAnimationText = true;
        }
    }

    public float getSetTutorialStep
    {
        get { return step; }
        set { step = value; }
    }
}
