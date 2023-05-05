using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridCellCollision : MonoBehaviour
{
    private int counter = 0;
    private float collisionTime = 0f;

    public List<Color> colors;



    SpriteRenderer renderReference;

    [System.Serializable]
    public class CollisionEvent : UnityEvent<Collider2D> { }

    [System.Serializable]
    public class CollisionDurationEvent : UnityEvent<float> { }

    [SerializeField] private string targetTag = "CollidingObject";
    [SerializeField] private float colorChangeDelay = 2f;
    [SerializeField] public CollisionEvent onCollisionEnterEvent;
    [SerializeField] public CollisionEvent onCollisionExitEvent;
    [SerializeField] public CollisionDurationEvent onCollisionDurationEvent;

    void Start()
    {
        renderReference = GetComponent<SpriteRenderer>();

        if (colors != null && colors.Count > 0)
        {
            renderReference.color = colors[counter];
        }
        else
        {
            Debug.LogWarning("The colors list is empty or not initialized.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            onCollisionEnterEvent.Invoke(collision);
            collisionTime = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            collisionTime += Time.deltaTime;
            onCollisionDurationEvent.Invoke(collisionTime);

            if (collisionTime >= colorChangeDelay)
            {
                if (colors != null && colors.Count > 0)
                {
                    if (counter < colors.Count - 1)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }

                    renderReference.color = colors[counter];
                }
                else
                {
                    Debug.LogWarning("The colors list is empty or not initialized.");
                }

                collisionTime = 0f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Debug.Log("Exit collision");
            onCollisionExitEvent.Invoke(collision);
            collisionTime = 0f;
        }
    }
}
