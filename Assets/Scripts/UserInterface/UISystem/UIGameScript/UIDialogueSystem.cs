using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogueSystem : MonoBehaviour
{
    private bool isInteractionOn;

    /// <summary>
    /// Interacts the with PNJ.
    /// </summary>
    /// <param name="pnjName">Name of the PNJ.</param>
    /// <returns></returns>
    public bool InteractWithPNJ(string pnjName)
    {
        if(GameObject.Find("PanelPNJContextBackground") == false)
        {
            #region TalkButtonBackground | TalkButton
            // TalkButtonBackground
            GameObject talkButtonBackground = new GameObject("TalkButtonBackground");
            talkButtonBackground.transform.SetParent(GameObject.Find("MenuCanvas").transform, true);

            talkButtonBackground.AddComponent<RectTransform>();
            talkButtonBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 6, Screen.height / 7);
            talkButtonBackground.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Screen.height / -4);

            talkButtonBackground.AddComponent<Image>();
            talkButtonBackground.GetComponent<Image>().color = new Color(255, 255, 255, 0f); // Button is transparency

            // TalkButton
            GameObject talkButton = new GameObject("TalkButton");
            talkButton.transform.SetParent(GameObject.Find("TalkButtonBackground").transform, true);

            talkButton.AddComponent<RectTransform>();
            talkButton.GetComponent<RectTransform>().sizeDelta = talkButtonBackground.GetComponent<RectTransform>().sizeDelta;
            talkButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

            talkButton.AddComponent<Button>();
            talkButton.GetComponent<Button>().onClick.AddListener(() => OnClick(pnjName));

            talkButton.AddComponent<Text>();
            talkButton.GetComponent<Text>().font = GameObject.Find("MenuCanvas").GetComponent<TextMonitoring>().GetArialTextFont;
            talkButton.GetComponent<Text>().color = new Color(255, 255, 255, 1f);
            talkButton.GetComponent<Text>().text = "Discuter";
            talkButton.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            talkButton.GetComponent<Text>().fontStyle = FontStyle.Bold;
            talkButton.GetComponent<Text>().resizeTextForBestFit = true;
            #endregion     
        }
        return isInteractionOn;
    }

    /// <summary>
    /// Called when [click].
    /// </summary>
    /// <param name="pnjName">Name of the PNJ.</param>
    private void OnClick(string pnjName)
    {
        isInteractionOn = true;
        DialoguePanel(pnjName);
    }

    /// <summary>
    /// Clicks the accepted.
    /// </summary>
    private void ClickAccepted()
    {
        GameObject.Find(this.transform.name).GetComponent<PNJQuestController>().IsQuestAccepted = true;
        Destroy(GameObject.Find("PanelPNJContextBackground"));
    }

    /// <summary>
    /// Clicks the refused.
    /// </summary>
    private void ClickRefused()
    {
        Destroy(GameObject.Find("PanelPNJContextBackground"));
    }

    /// <summary>
    /// Dialogues the panel.
    /// </summary>
    /// <param name="pnjName">Name of the PNJ.</param>
    void DialoguePanel(string pnjName) // prend en paramètre un string pnjText et peut etre pnjName
    {
        if(InteractWithPNJ(pnjName) == true)
        {
            if(GameObject.Find("PanelPNJContextBackground") == true)
            {
                Destroy(GameObject.Find("TalkButtonBackground")); // Destroy button "Discuter"
            }
            else
            {
                Destroy(GameObject.Find("TalkButtonBackground"));
            }

            #region PanelPNJContextBackground | PanelPNJContext
            // PanelPNJContextBackground
            GameObject panelPNJContextBackground = new GameObject("PanelPNJContextBackground");
            panelPNJContextBackground.transform.SetParent(GameObject.Find("MenuCanvas").transform, true);

            panelPNJContextBackground.AddComponent<RectTransform>();
            // faudra changer la taille de cette chose
            panelPNJContextBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 2, Screen.height / 2.5f);
            panelPNJContextBackground.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,
                (Screen.height / -2) + panelPNJContextBackground.GetComponent<RectTransform>().rect.height / 2);

            panelPNJContextBackground.AddComponent<Image>();
            panelPNJContextBackground.GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);

            // PanelPNJContext
            GameObject panelPNJContext = new GameObject("PanelPNJContext");
            panelPNJContext.transform.SetParent(GameObject.Find("PanelPNJContextBackground").transform, true);

            panelPNJContext.AddComponent<RectTransform>();
            panelPNJContext.GetComponent<RectTransform>().sizeDelta = 
                new Vector2((panelPNJContextBackground.GetComponent<RectTransform>().rect.width / 10) * 9,
                panelPNJContextBackground.GetComponent<RectTransform>().rect.height / 1.5f);
            panelPNJContext.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 
                (panelPNJContextBackground.GetComponent<RectTransform>().rect.height / 2) - panelPNJContextBackground.GetComponent<RectTransform>().rect.height / 3);

            panelPNJContext.AddComponent<Text>();
            panelPNJContext.GetComponent<Text>().font = GameObject.Find("MenuCanvas").GetComponent<TextMonitoring>().GetArialTextFont;
            panelPNJContext.GetComponent<Text>().color = new Color(0, 0, 0, 1f);

            Debug.Log(GameObject.Find(pnjName).GetComponent<PNJQuestController>().CurrentPNJQuestContext);

            panelPNJContext.GetComponent<Text>().text = GameObject.Find(pnjName).GetComponent<PNJQuestController>().CurrentPNJQuestContext;
            panelPNJContext.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
            panelPNJContext.GetComponent<Text>().fontStyle = FontStyle.Bold;
            panelPNJContext.GetComponent<Text>().resizeTextForBestFit = true;
            #endregion

            #region PanelPNJTextBackground | PanelPNJText
            // PanelPNJTextBackground
            GameObject panelPNJTextBackground = new GameObject("PanelPNJTextBackground");
            panelPNJTextBackground.transform.SetParent(GameObject.Find("PanelPNJContextBackground").transform, true);

            panelPNJTextBackground.AddComponent<RectTransform>();
            panelPNJTextBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 8, Screen.height / 10);
            panelPNJTextBackground.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 
                (panelPNJContextBackground.GetComponent<RectTransform>().rect.height / 2) + panelPNJTextBackground.GetComponent<RectTransform>().rect.height / 2);

            /// ne fonctionne pas comme je le veux pour le moment
            panelPNJTextBackground.AddComponent<Image>();
            panelPNJTextBackground.GetComponent<Image>().color = new Color(102, 204, 0, 0.6f);  //pb de couleur

            // PanelPNJText
            GameObject panelPNJText = new GameObject("PanelPNJText");
            panelPNJText.transform.SetParent(GameObject.Find("PanelPNJTextBackground").transform, true);

            panelPNJText.AddComponent<RectTransform>();
            panelPNJText.GetComponent<RectTransform>().sizeDelta = panelPNJTextBackground.GetComponent<RectTransform>().sizeDelta;
            panelPNJText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

            panelPNJText.AddComponent<Text>();
            panelPNJText.GetComponent<Text>().font = GameObject.Find("MenuCanvas").GetComponent<TextMonitoring>().GetArialTextFont;
            panelPNJText.GetComponent<Text>().color = new Color(0, 0, 0, 1f);
            panelPNJText.GetComponent<Text>().text = pnjName;
            panelPNJText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            panelPNJText.GetComponent<Text>().fontStyle = FontStyle.Bold;
            panelPNJText.GetComponent<Text>().resizeTextForBestFit = true;
            #endregion 

            #region AcceptedButtonBackground | AcceptedButton
            GameObject acceptedButtonBackground = new GameObject("AcceptedButtonBackground");
            acceptedButtonBackground.transform.SetParent(GameObject.Find("PanelPNJContextBackground").transform, true);
            
            // changer la taille du bouton
            acceptedButtonBackground.AddComponent<RectTransform>();
            acceptedButtonBackground.GetComponent<RectTransform>().sizeDelta = 
                new Vector2(panelPNJContextBackground.GetComponent<RectTransform>().rect.width / 4, 
                panelPNJContextBackground.GetComponent<RectTransform>().rect.height / 4);
            acceptedButtonBackground.GetComponent<RectTransform>().anchoredPosition = 
                new Vector2((panelPNJContextBackground.GetComponent<RectTransform>().rect.width / -3),
                (panelPNJContextBackground.GetComponent<RectTransform>().rect.height / -2) + acceptedButtonBackground.GetComponent<RectTransform>().rect.height / 2);

            acceptedButtonBackground.AddComponent<Image>();
            acceptedButtonBackground.GetComponent<Image>().color = new Color(153, 255, 51, 0.6f);

            GameObject acceptedButton = new GameObject("AcceptedButton");
            acceptedButton.transform.SetParent(GameObject.Find("AcceptedButtonBackground").transform, true);

            acceptedButton.AddComponent<RectTransform>();
            acceptedButton.GetComponent<RectTransform>().sizeDelta = acceptedButtonBackground.GetComponent<RectTransform>().sizeDelta;
            acceptedButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

            acceptedButton.AddComponent<Button>();
            acceptedButton.GetComponent<Button>().onClick.AddListener(() => ClickAccepted());

            acceptedButton.AddComponent<Text>();
            acceptedButton.GetComponent<Text>().font = GameObject.Find("MenuCanvas").GetComponent<TextMonitoring>().GetArialTextFont;
            acceptedButton.GetComponent<Text>().color = new Color(0, 0, 0, 1f);
            acceptedButton.GetComponent<Text>().text = "Accepter";
            acceptedButton.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            acceptedButton.GetComponent<Text>().fontStyle = FontStyle.Bold;
            acceptedButton.GetComponent<Text>().resizeTextForBestFit = true;
            #endregion

            #region RefusedButtonBackground | RefusedButton
            GameObject refusedButtonBackground = new GameObject("RefusedButtonBackground");
            refusedButtonBackground.transform.SetParent(GameObject.Find("PanelPNJContextBackground").transform, true);

            // changer la taille du bouton
            refusedButtonBackground.AddComponent<RectTransform>();
            refusedButtonBackground.GetComponent<RectTransform>().sizeDelta =
                new Vector2(panelPNJContextBackground.GetComponent<RectTransform>().rect.width / 4,
                panelPNJContextBackground.GetComponent<RectTransform>().rect.height / 4);
            refusedButtonBackground.GetComponent<RectTransform>().anchoredPosition =
                new Vector2((panelPNJContextBackground.GetComponent<RectTransform>().rect.width / 3),
                (panelPNJContextBackground.GetComponent<RectTransform>().rect.height / -2) + refusedButtonBackground.GetComponent<RectTransform>().rect.height / 2);

            refusedButtonBackground.AddComponent<Image>();
            refusedButtonBackground.GetComponent<Image>().color = new Color(153, 255, 51, 0.6f);

            GameObject refusedButton = new GameObject("RefusedButton");
            refusedButton.transform.SetParent(GameObject.Find("RefusedButtonBackground").transform, true);

            refusedButton.AddComponent<RectTransform>();
            refusedButton.GetComponent<RectTransform>().sizeDelta = refusedButtonBackground.GetComponent<RectTransform>().sizeDelta;
            refusedButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

            refusedButton.AddComponent<Button>();
            refusedButton.GetComponent<Button>().onClick.AddListener(() => ClickRefused());

            refusedButton.AddComponent<Text>();
            refusedButton.GetComponent<Text>().font = GameObject.Find("MenuCanvas").GetComponent<TextMonitoring>().GetArialTextFont;
            refusedButton.GetComponent<Text>().color = new Color(0, 0, 0, 1f);
            refusedButton.GetComponent<Text>().text = "Refuser";
            refusedButton.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            refusedButton.GetComponent<Text>().fontStyle = FontStyle.Bold;
            refusedButton.GetComponent<Text>().resizeTextForBestFit = true;
            #endregion
        }
    }
}
