using UnityEngine;

//public class TileColorChanger : MonoBehaviour
//{
//    public GridManager grid;
//    public string colliderTag;
//    public Color newColor;
//    public float delay;

//    private float timer;

//    //private void Update()
//    //{
//    //    if (timer >= delay)
//    //    {
            
//    //        Destroy(this);
//    //    }
//    //    else
//    //    {
//    //        timer += Time.deltaTime;
//    //    }
//    //}

//    private void ChangeTileColors()
//    {
//        foreach (GameObject tileObject in grid.tiles)
//        {
//            if (tileObject.CompareTag(colliderTag))
//            {
//                tileObject.GetComponent<SpriteRenderer>().color = newColor;
//            }
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        Debug.Log("Collision detected");
//        ChangeTileColors();
//    }

//}
