using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;
    private float yaw;
    private float pitch;
    public Transform player;
    public Vector3 cameraOffset;

    void Start()
    {

    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivityX;
        pitch -= Input.GetAxis("Mouse Y") * sensitivityY;

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        transform.position = player.position;
        transform.position += transform.TransformDirection(cameraOffset);
    }
}
