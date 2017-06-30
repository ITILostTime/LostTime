using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour
{
    //public GameObject camera;
    public GameObject target;
    private Transform cameraPosition;
    private Transform targetPlayer;
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        if(cameraPosition == null)
        {
            cameraPosition = GameObject.Find("CameraPosition").transform;
            targetPlayer = GameObject.Find("CameraTarget").transform;
        }
        transform.position = Vector3.Lerp(transform.position, cameraPosition.position, 0.1f);
        direction = targetPlayer.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);
    }
}
