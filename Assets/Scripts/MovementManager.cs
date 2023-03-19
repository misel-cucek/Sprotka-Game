using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public Rigidbody2D controller;
    public float speed = 10000.0f;
    public int collisionCount = 0;
    public Vector3 respawn = new(20.28f, 17.538f, 0.0f);

    private void Start()
    {
        controller = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        var direction = new Vector3(horizontalInput, verticalInput, 0.0f);

        Move(direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Win"))
        {
            transform.position = respawn;
            gameObject.SetActive(true);
            collisionCount = 0;
        }

        // check if the collision is with an object tagged "obstacle"
        if (!collision.gameObject.CompareTag("Enemy")) return;
        collisionCount++;

        // check if the collision count has reached the limit
        if (collisionCount >= 3)
        {
            // disable the player object and show the end game object
            gameObject.SetActive(false);
        }
        else
        {
            // move the player to the respawn position
            transform.position = respawn;
            gameObject.SetActive(true);
            collisionCount = 0;
        }
    }

    private void Move(Vector3 direction)
    {
        controller.velocity = direction * 2;
    }
}