using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CameraTargetBehaviour : MonoBehaviour
{
    public VirtualRightJoystick rightJoystick;
    public VirtualLeftJoystick leftJoystick;
    private float verticalInput;
    private float horizontalInput;
    private Vector3 initialPos;
    private Vector3 astridPos;

    // Use this for initialization
    void Start()
    {
        initialPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //inputs
        verticalInput = rightJoystick.RightVertical();
        horizontalInput = rightJoystick.RightHorizontal();

        //Y Axis
        if (verticalInput > 0.5 && transform.localPosition.y <=8.5)
        {
            transform.Translate(Vector3.up * (4 * Time.deltaTime));
        }

        if (verticalInput < -0.5 && transform.localPosition.y >= 1.5)
        {
            transform.Translate(Vector3.down * (4 * Time.deltaTime));
        }

        //X Axis
        astridPos = GameObject.Find("AstridPlayer").transform.position;

        if (horizontalInput > 0.5)
        {
            transform.RotateAround(astridPos, Vector3.up, 30 * Time.deltaTime);
        }

        if (horizontalInput < -0.5)
        {
            transform.RotateAround(astridPos, Vector3.down, 30 * Time.deltaTime);
        }

        //Reset position on moving
        if (leftJoystick.LeftHorizontal() != 0.0f
           || leftJoystick.LeftVertical() != 0.0f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialPos, 30 * Time.deltaTime);
        }
        //Debug.Log(leftJoystick.LeftHorizontal());
        //Debug.Log(leftJoystick.LeftVertical());
    }
}
