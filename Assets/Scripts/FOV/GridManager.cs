using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab; // Prefab for the tile object
    private int gridSize = 2; // Number of tiles in each row/column
    private float tileSize; // Size of each tile
    private Vector2 screenDimensions; // Dimensions of the screen

    void Start()
    {
        screenDimensions = new Vector2(Screen.width, Screen.height);
        tileSize = screenDimensions.x / gridSize;

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector2 tilePosition = new Vector2(x * tileSize, y * tileSize);
                GameObject tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity);
                tile.transform.localScale = new Vector2(tileSize, tileSize);

                // Draw debug lines
                Vector2 topLeft = new Vector2(x * tileSize, y * tileSize);
                Vector2 topRight = new Vector2((x + 1) * tileSize, y * tileSize);
                Vector2 bottomLeft = new Vector2(x * tileSize, (y + 1) * tileSize);
                Vector2 bottomRight = new Vector2((x + 1) * tileSize, (y + 1) * tileSize);

                Debug.DrawLine(topLeft, topRight, Color.white, Mathf.Infinity);
                Debug.DrawLine(topRight, bottomRight, Color.white, Mathf.Infinity);
                Debug.DrawLine(bottomRight, bottomLeft, Color.white, Mathf.Infinity);
                Debug.DrawLine(bottomLeft, topLeft, Color.white, Mathf.Infinity);
            }
        }
    }
}
