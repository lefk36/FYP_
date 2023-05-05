using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public int mark = 0; 
    private bool visited = false; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!visited)
        {
            visited = true;

            // Hide the waypoint object
            gameObject.SetActive(false);
        }
    }
}
