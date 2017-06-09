using UnityEngine;
using System.Collections;

public class CameraPositionTemp : MonoBehaviour {

    public GameObject _rightJoystick;

    private Vector3 initial;
    private float rotationDelta;
    private float translateDelta;
    private float resetDelta;

    private float inputH;
    private float inputV;

    // Use this for initialization
    void Start ()
    {
        _rightJoystick = GameObject.Find("RightJoystickStick");
        rotationDelta = 50;
        translateDelta = 0.1f;
        resetDelta = 0.1f;
        initial = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        InputH = _rightJoystick.GetComponent<UIVirtualRightJoystick>().GetRightHorizontalPosition();
        InputV = _rightJoystick.GetComponent<UIVirtualRightJoystick>().GetRightVercitalPosition();
        //  Debug.Log(string.Format("{0},  {1}", InputH, InputV));

        //rotation (left and right)
        transform.RotateAround(transform.parent.position, Vector3.up, -InputH * rotationDelta * Time.deltaTime);
        
        //translation (up an down)
        transform.Translate(Vector3.up* InputV * translateDelta, Space.World);

        //reset position
        if (InputV == 0 
            && InputH == 0
            && transform.localPosition != initial) transform.localPosition = Vector3.MoveTowards(transform.localPosition,initial, resetDelta);
    }

    public float InputH { get { return inputH; } set { inputH = Mathf.Clamp(value, -1.0f, 1.0f); } }

    public float InputV { get { return inputV; } set { inputV = Mathf.Clamp(value, -1.0f, 1.0f); } }

}
//Vector3.down = rotation de la camera vers la droite
//Vector3.up = rotation vers la gauche.
//transform.RotateAround(Vector3.zero, Vector3.down, 30 * Time.deltaTime);
