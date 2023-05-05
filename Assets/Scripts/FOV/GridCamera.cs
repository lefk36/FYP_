using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCamera : MonoBehaviour
{
    //public GridManager grid;

    //private Camera cam;

    //private void Awake()
    //{
    //    cam = GetComponent<Camera>();
    //}

    //private void Start()
    //{
    //    ResizeCamera();
    //}

    //private void ResizeCamera()
    //{
    //    float screenHeight = Screen.height;
    //    float gridHeight = grid.transform.localScale.y * grid.GetGridHeight();
    //    float gridWidth = grid.transform.localScale.x * grid.GetGridWidth();

    //    float targetSize = Mathf.Max(gridHeight, gridWidth) / 2f;

    //    cam.orthographicSize = targetSize;
    //    cam.transform.position = new Vector3(gridWidth / 2f, gridHeight / 2f, -10f);
    //    cam.aspect = 1f;
    //}
}
