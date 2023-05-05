using UnityEngine;

[ExecuteAlways]
public class GridManager : MonoBehaviour
{
    public int rows = 4;
    public  int columns = 4;
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Transform gridParent;
    [SerializeField] private Camera mainCamera;

    private GameObject[,] grid;

    private void Awake()
    {
        if (cellPrefab == null || gridParent == null || mainCamera == null)
        {
            Debug.LogError("GridManager: cellPrefab, mainCamera, and gridParent must be assigned in the Inspector.");
            return;
        }
    }

    public void SpawnGrid()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        if (grid != null)
        {
            foreach (GameObject cell in grid)
            {
                DestroyImmediate(cell);
            }
        }

        grid = new GameObject[rows, columns];

        float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float cellWidth = cameraWidth / columns;
        float cellHeight = cameraHeight / rows;

        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject cell = Instantiate(cellPrefab, gridParent);
                cell.transform.localScale = new Vector3(cellWidth, cellHeight, 1);
                cell.transform.position = bottomLeft + new Vector3(j * cellWidth + cellWidth / 2, i * cellHeight + cellHeight / 2, 0);
                grid[i, j] = cell;
            }
        }
    }

    public void UpdateGridSize(int newRow, int newColumn)
    {
        rows = newRow;
        columns = newColumn;
        CreateGrid();
    }
}
