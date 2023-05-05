using UnityEngine;

public class Wander : MonoBehaviour, AnimalStates 
{
    public float speed = 2.0f;
    public float directionChangeInterval = 1.0f;

    private float _directionChangeTimer;
    private Vector2 _movementDirection;
    private Camera _camera;
    private float _objectRadius;


    public StateId GetId()
    {
        return StateId.Wander;
    }

    public void StartState(Animal animal)
    {
        _movementDirection = Random.insideUnitCircle.normalized;
        _directionChangeTimer = directionChangeInterval;

        _camera = Camera.main;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        _objectRadius = spriteRenderer.bounds.extents.magnitude;
    }

    public void Currentstate(Animal animal)
    {
        _directionChangeTimer -= Time.deltaTime;

        if (_directionChangeTimer < 0)
        {
            _movementDirection = Random.insideUnitCircle.normalized;
            _directionChangeTimer = directionChangeInterval;
        }

        Vector3 newPosition = transform.position + (Vector3)(_movementDirection * speed * Time.deltaTime);

        Vector3 viewportPosition = _camera.WorldToViewportPoint(newPosition);
        viewportPosition.x = Mathf.Clamp01(viewportPosition.x);
        viewportPosition.y = Mathf.Clamp01(viewportPosition.y);

        Vector3 clampedPosition = _camera.ViewportToWorldPoint(viewportPosition);
        clampedPosition.z = transform.position.z;

        float distanceFromCamera = transform.position.z - _camera.transform.position.z;
        float maxDistance = Mathf.Min(_camera.orthographicSize, _camera.aspect * _camera.orthographicSize);
        float maxClampedRadius = maxDistance - _objectRadius;
        clampedPosition = _camera.transform.position + Vector3.ClampMagnitude(clampedPosition - _camera.transform.position, maxClampedRadius);
        clampedPosition.z = transform.position.z;

        transform.position = clampedPosition;
    }


    public void NextState(Animal animal)
    {

    }

    private void Start()
    {
      
    }

    private void Update()
    {
       
    }
}
