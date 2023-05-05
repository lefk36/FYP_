using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager current;


    // Start is called before the first frame update
    private void Awake()
    {
        current = this;
    }

    public event Action<string> onPredatorMarking;
    public void PredatorMarking(string id)
    {
        if (onPredatorMarking != null)
        {
            onPredatorMarking(id);
        }
    }

    public event Action<string> onAnimalDeath;
    public void AnimalDeath(string id)
    {
        if (onAnimalDeath != null)
        {
            onAnimalDeath(id);
        }
    }

    public event Action onEngageFight;
    public void EngageFight()
    {
        if (onEngageFight != null)
        {
            onEngageFight();
        }
    }

    public event Action onPreyDevoured;
    public void DevourPrey()
    {
        if (onPreyDevoured != null)
        {
            onPreyDevoured();
        }
    }

    public event Action onReplenishHunger;
    public void ReplenishHunger()
    {
        if (onReplenishHunger != null)
        {
            onReplenishHunger();
        }
    }

}
