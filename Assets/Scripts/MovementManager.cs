using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10.0f;
    public float rotationSpeed = 5.0f;
    public int lives = 3;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        Move(direction);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!hit.gameObject.CompareTag("Wall")) return;

        lives--;
        Vector3 reverseDirection = -controller.velocity.normalized;
        Move(reverseDirection);
    }

    public void Move(Vector3 direction)
    {
        Vector3 movement = direction * speed * Time.deltaTime;

        controller.Move(movement);

        if (movement.magnitude > 0.0f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}