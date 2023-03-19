using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 5f;
    private float _direction = 1f;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime, 0f, 0f);

        if (Mathf.Abs(transform.position.x - _startPosition.x) > distance)
        {
            _direction *= -1f;
        }
    }
}