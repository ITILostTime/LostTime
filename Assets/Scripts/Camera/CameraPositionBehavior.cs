using UnityEngine;
using System.Collections;

public class CameraPositionBehavior : MonoBehaviour
{
    private GameObject _rightJoystick;
    private GameObject _leftJoystick;
    private float horizontalInput;
    private Vector3 initialPos;
    private Vector3 astridPos;

    // Use this for initialization
    void Start()
    {
        _rightJoystick = GameObject.Find("RightJoystickPanel");
        _leftJoystick = GameObject.Find("LeftJoystickPanel");
        initialPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = _rightJoystick.GetComponent<UIVirtualRightJoystick>().GetRightHorizontalPosition();
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
        if (_leftJoystick.GetComponent<UIVirtualLeftJoystick>().GetLeftHorizontalPosition() != 0
            || _leftJoystick.GetComponent<UIVirtualLeftJoystick>().GetLeftVercitalPosition() != 0)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialPos, 30 * Time.deltaTime);
        }
    }
}
