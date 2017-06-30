using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceAstridHouseContext : MonoBehaviour {

    private void Start()
    {
        GameObject Camera = new GameObject("Main Camera");
        Camera.transform.tag = "MainCamera";
        Camera.AddComponent<Camera>();
        Camera.GetComponent<Camera>().backgroundColor = new Color(0, 0, 0, 0);
        Camera.AddComponent<GUILayer>();
        Camera.AddComponent<FlareLayer>();
        Camera.AddComponent<AudioListener>();
        Camera.AddComponent<CameraBehavior>();

        GameObject FireLight = new GameObject("Sun");
        FireLight.transform.position = new Vector3(1.82f, 1.95f, -3.98f);
        FireLight.AddComponent<Light>();
        FireLight.GetComponent<Light>().range = 14.68f;
        FireLight.GetComponent<Light>().color = new Color(0.925f, 0.4475f, 0.1375f, 1f);
        FireLight.GetComponent<Light>().intensity = 1.11f;
        FireLight.GetComponent<Light>().bounceIntensity = 0.75f;

        GameObject ChambreMurSol = (GameObject)Instantiate(Resources.Load("AstridHouse/ChambresMursSol"));
        GameObject.Find("ChambresMursSol(Clone)").name = "ChambresMursSol";
        ChambreMurSol.transform.position = new Vector3(0, 0, 0);

        GameObject MiscAndDecor = (GameObject)Instantiate(Resources.Load("AstridHouse/MiscAndDecor"));
        GameObject.Find("MiscAndDecor(Clone)").name = "ChambresMursSol";
        MiscAndDecor.transform.position = new Vector3(3.26661f, 4.845532f, -2.241741f);
    }
}
