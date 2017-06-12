using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public GameObject _leftJoystick;
    public CharaAnimCtrl animCtrl;
    public float speed;
    private Rigidbody playerRigidbody;           
    private NavMeshObstacle playerObstacle;

    // Use this for initialization
    void Start()
    {
        _leftJoystick = GameObject.Find("LeftJoystickPanel");
        speed = 4.0f;

        //playerRigidbody = gameObject.AddComponent<Rigidbody>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.mass = 150;
        playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        
        animCtrl = GetComponent<CharaAnimCtrl>();
        playerObstacle = GetComponent<NavMeshObstacle>();

        setAstridPosition();
        
        SetPlayerObstacle();
    }

    private void setAstridPosition()
    {
        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateOne")
        {
            GameObject.Find("AstridPlayer").transform.position = new Vector3(PlayerPrefs.GetFloat("CurrentAstridPositionX"), PlayerPrefs.GetFloat("CurrentAstridPositionY"), PlayerPrefs.GetFloat("CurrentAstridPositionZ"));
            this.transform.rotation = new Quaternion(PlayerPrefs.GetFloat("CurrentAstridRotationX"), PlayerPrefs.GetFloat("CurrentAstridRotationY"), PlayerPrefs.GetFloat("CurrentAstridRotationZ"), 0.0f);
        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateTwo")
        {
            this.transform.position = new Vector3(PlayerPrefs.GetFloat("CurrentAstridPositionX"), PlayerPrefs.GetFloat("CurrentAstridPositionY"), PlayerPrefs.GetFloat("CurrentAstridPositionZ"));
            this.transform.rotation = new Quaternion(PlayerPrefs.GetFloat("CurrentAstridRotationX"), PlayerPrefs.GetFloat("CurrentAstridRotationY"), PlayerPrefs.GetFloat("CurrentAstridRotationZ"), 0.0f);
        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateThree")
        {
            this.transform.position = new Vector3(PlayerPrefs.GetFloat("CurrentAstridPositionX"), PlayerPrefs.GetFloat("CurrentAstridPositionY"), PlayerPrefs.GetFloat("CurrentAstridPositionZ"));
            this.transform.rotation = new Quaternion(PlayerPrefs.GetFloat("CurrentAstridRotationX"), PlayerPrefs.GetFloat("CurrentAstridRotationY"), PlayerPrefs.GetFloat("CurrentAstridRotationZ"), 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Send to the animator
        animCtrl.InputH = _leftJoystick.GetComponent<UIVirtualLeftJoystick>().GetLeftHorizontalPosition();
        animCtrl.InputV = _leftJoystick.GetComponent<UIVirtualLeftJoystick>().GetLeftVercitalPosition();
   
        animCtrl.WalkMode = WalkMode.running;

        //Movement
        Vector3 move = new Vector3();
        move.z = _leftJoystick.GetComponent<UIVirtualLeftJoystick>().GetLeftVercitalPosition() * Time.deltaTime * speed;
        transform.Translate(move, Space.Self);

        //Return Astrid when she move backward
        if(_leftJoystick.GetComponent<UIVirtualLeftJoystick>().GetLeftVercitalPosition() < 0)
        {
            PlayerMoveBackward();
        }

        //Debug.Log(move.z);

        //Rotation   
        PlayerRotation(_leftJoystick.GetComponent<UIVirtualLeftJoystick>().GetLeftHorizontalPosition());
        //Debug.Log(string.Format("H: {0}, V : {1}, LJS : {2}", leftJoystick.LeftHorizontal(), leftJoystick.LeftVertical(), leftJoystick.IsLeftJoystickUsed));
    }

    //initialize and sets property of the NavMeshObstacle
    private void SetPlayerObstacle()
    {
        playerObstacle.radius = 1;
        playerObstacle.carving = true;
        playerObstacle.carvingMoveThreshold = 0.1f;
        playerObstacle.carvingTimeToStationary = 0.2f;
        playerObstacle.carveOnlyStationary = true;
    }

    /// <summary>
    /// Rotation when we touch right or left on the x Axis
    /// </summary>
    /// <param name="xAxis"></param>
    private void PlayerRotation(float xAxis)
    {
        transform.Rotate(Vector3.up, Time.deltaTime * xAxis * 120);       
    }

    /// <summary>
    /// Rotate Astrid when we touch down 
    /// </summary>
    private void PlayerMoveBackward()
    {
        transform.Rotate(Vector3.down, Time.deltaTime * speed * 180);
    }
}

