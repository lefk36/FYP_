using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public int mark = 0; // The mark assigned to this waypoint
    private bool visited = false; // Whether the waypoint has been visited or not

    // This function is called when the player collides with the waypoint
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
