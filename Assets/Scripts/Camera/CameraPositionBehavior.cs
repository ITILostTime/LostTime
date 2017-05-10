using UnityEngine;
using System.Collections;

public class CameraPositionBehavior : MonoBehaviour
{
    public VirtualRightJoystick rightJoystick;
    public VirtualLeftJoystick leftJoystick;
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
        horizontalInput = rightJoystick.RightHorizontal();
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
        // Try something to test Unity Cloud Build
        // And to do this I had 2 lines of comment
        if (leftJoystick.LeftHorizontal() != 0
            || leftJoystick.LeftVertical() != 0)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialPos, 30 * Time.deltaTime);
        }
    }
}
