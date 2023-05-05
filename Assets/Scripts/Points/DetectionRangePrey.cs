using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRangePrey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (transform.parent && transform.parent.gameObject != other.gameObject)
        {
            Debug.Log(transform.parent.gameObject.name + ": I can see " + other.gameObject.name);
        }
    }

}
