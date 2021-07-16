using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform camera;
    public CapsuleCollider capsule;
    public float groundedThreshold;
    public float jumpSpeed;
    public float moveSpeed;
    private Rigidbody rigidbody;
    public float rotationSpeed;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        var moveDirection = GetDirection();
        rigidbody.velocity = moveDirection * moveSpeed + Vector3.up * rigidbody.velocity.y;

        ApplyRootRotation(moveDirection);

        HandleJump();
    }

    private void HandleJump()
    {
        Ray ray = new Ray();
        ray.origin = transform.position + Vector3.up * groundedThreshold / 2;
        ray.direction = Vector3.down;
        bool grounded = false;

        float maxDistance = groundedThreshold;
        if (Physics.Raycast(ray, maxDistance))
        {
            grounded = true;
            if (Input.GetButtonUp("Jump"))
            {
                rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
            }
        }

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxDistance, grounded ? Color.green : Color.red);
    }

    private void ApplyRootRotation(Vector3 moveDirection)
    {
        if (moveDirection.magnitude < 10e-3f)
            return;

        var newRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }

    private Vector3 GetDirection()
    {
        var moveX = Input.GetAxis("Horizontal");
        var moveZ = Input.GetAxis("Vertical");

        var cameraForwardXoZ = Vector3.Scale(camera.forward, new Vector3(1, 0, 1));
        var moveDirection = (cameraForwardXoZ * moveZ + camera.right * moveX).normalized;
        return moveDirection;
    }
}