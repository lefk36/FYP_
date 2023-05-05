using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    private void Update()
    {
        Destroy(this.gameObject);
    }
}
