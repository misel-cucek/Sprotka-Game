using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f; // speed of movement
    public float distance = 5f; // distance to move before reversing direction
    private Rigidbody2D _rb; // reference to the object's Rigidbody2D component
    private Vector2 _startPosition; // starting position of the object

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // get the reference to the Rigidbody2D component
        _startPosition = _rb.position; // get the starting position of the object
    }

    private void FixedUpdate()
    {
        // calculate the new position based on time, distance, and the ping pong function
        float pingPong = Mathf.PingPong(Time.time * speed, distance) - distance / 2f;
        Vector2 movement = new Vector2(pingPong, 0);
        _rb.MovePosition(_startPosition + movement);
    }
}