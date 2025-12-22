using UnityEngine;

public class Wander : MonoBehaviour, AnimalStates
{
    public float speed = 2.0f;
    public float directionChangeInterval = 1.0f;

    private float _directionChangeTimer;
    private Vector2 _movementDirection;
    private Camera _camera;
    private float _objectRadius;
    private Animal _animal;
    private SpriteRenderer _spriteRenderer;


    public StateId GetId()
    {
        return StateId.Wander;
    }

    public void StartState(Animal animal)
    {
        _animal = animal;
        _spriteRenderer = _animal.GetComponent<SpriteRenderer>();

        _movementDirection = Random.insideUnitCircle.normalized;
        _directionChangeTimer = directionChangeInterval;

        _camera = Camera.main;
        _objectRadius = _spriteRenderer.bounds.extents.magnitude;
    }

    public void Currentstate(Animal animal)
    {
        _directionChangeTimer -= Time.deltaTime;

        if (_directionChangeTimer < 0)
        {
            _movementDirection = Random.insideUnitCircle.normalized;
            _directionChangeTimer = directionChangeInterval;
        }

        // Find the closest object with the "Prey" tag
        GameObject[] preyObjects = GameObject.FindGameObjectsWithTag("Prey");
        GameObject closestPreyObject = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject preyObject in preyObjects)
        {
            float distance = Vector3.Distance(animal.transform.position, preyObject.transform.position);
            if (distance < closestDistance)
            {
                closestPreyObject = preyObject;
                closestDistance = distance;
            }
        }

        if (closestPreyObject != null)
        {
            // Move towards the closest "Prey" object
            Vector3 newPosition = Vector3.MoveTowards(animal.transform.position, closestPreyObject.transform.position, speed * Time.deltaTime);
            animal.transform.position = newPosition;
        }

        Debug.Log("Wander state is active.");
    }

    public void NextState(Animal animal)
    {
        // No next state
    }
}
