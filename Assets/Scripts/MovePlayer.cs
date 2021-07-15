using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed;
    public Transform camera;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 cameraForwardXoZ = Vector3.Scale(camera.forward, new Vector3(1, 0, 1));
        Vector3 moveDirection = (cameraForwardXoZ * moveZ + camera.right * moveX).normalized;
        rigidbody.velocity =moveDirection * moveSpeed + Vector3.up * rigidbody.velocity.y;
    }
}
