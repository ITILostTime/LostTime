using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetConfigureButtonScript : MonoBehaviour, IPointerDownHandler
{
    private GameObject _canvasMenu;
    private GameObject _configurePanel;

    private bool _configurePanelActivated;
    private bool _configurePanelAnimationOn;

    public bool ConfigurePanelActivated { get { return _configurePanelActivated; } set { _configurePanelActivated = value; } }
    public bool ConfigurePanelAnimationOn { get { return _configurePanelAnimationOn; } set { _configurePanelAnimationOn = value; } }

    private void Start()
    {
        _canvasMenu = GameObject.Find("MenuCanvas");
    }

    private void Update()
    {
        if (GameObject.Find("ConfigurePanel") == true && _configurePanelActivated == true && _configurePanelAnimationOn == true)
        {
            _configurePanelAnimationOn = _canvasMenu.GetComponent<AnimationUserInterfaceController>().HztAnimToUserInterfaceRightToLeft("ConfigurePanel",
                _canvasMenu.GetComponent<RectTransform>().rect.width / 2.7f, 0, -1);
        }
        else if (GameObject.Find("ConfigurePanel") == true && _configurePanelActivated == false && _configurePanelAnimationOn == true)
        {
            _configurePanelAnimationOn = _canvasMenu.GetComponent<AnimationUserInterfaceController>().HztAnimToDestroyLeftToRight("ConfigurePanel",
                _canvasMenu.GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("ConfigurePanel").GetComponent<RectTransform>().rect.width / 2,
                1);
        }
    }

    private void CheckOpenPanel()
    {
        if (GameObject.Find("LoadGamePanel") == true)
        {
            GameObject.Find("LoadGameButton").GetComponent<SetLoadGameButtonScript>().LoadGamePanelActivated = false;
            GameObject.Find("LoadGameButton").GetComponent<SetLoadGameButtonScript>().LoadGameAnimationOn = true;
        }

        if (GameObject.Find("NewGamePanel") == true)
        {
            GameObject.Find("NewGameButton").GetComponent<SetNewGameButtonScript>().NewGamePanelActivated = false;
            GameObject.Find("NewGameButton").GetComponent<SetNewGameButtonScript>().NewGameAnimationOn = true;
        }
    }

    public virtual void OnPointerDown(PointerEventData ConfigurePanel)
    {
        CheckOpenPanel();
        CreateConfigurePanel();
    }

    private void CreateConfigurePanel()
    {

        if (GameObject.Find("ConfigurePanel") == false)
        {
            _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("ConfigurePanel", _canvasMenu, true, _canvasMenu.GetComponent<RectTransform>().rect.width / 4,
            _canvasMenu.GetComponent<RectTransform>().rect.height, ((_canvasMenu.GetComponent<RectTransform>().rect.width / 2) + (_canvasMenu.GetComponent<RectTransform>().rect.width / 8)), 0);

            _configurePanel = GameObject.Find("ConfigurePanel");

            /////

            _configurePanel.AddComponent<Image>();

            ///////

            _configurePanelActivated = true;
            _configurePanelAnimationOn = true;
        }
        else
        {
            _configurePanelActivated = false;
            _configurePanelAnimationOn = true;
        }

    }

    private void IsShadowActivated()
    {

    }

}
