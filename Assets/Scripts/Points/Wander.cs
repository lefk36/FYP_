using UnityEngine;

public class Wander : MonoBehaviour
{
    public float speed = 2.0f;
    public float directionChangeInterval = 1.0f;

    private float _directionChangeTimer;
    private Vector2 _movementDirection;

    private void Start()
    {
        _movementDirection = Random.insideUnitCircle.normalized;
        _directionChangeTimer = directionChangeInterval;
    }

    private void Update()
    {
        _directionChangeTimer -= Time.deltaTime;

        if (_directionChangeTimer < 0)
        {
            _movementDirection = Random.insideUnitCircle.normalized;
            _directionChangeTimer = directionChangeInterval;
        }

        transform.position += (Vector3)(_movementDirection * speed * Time.deltaTime);
    }
}