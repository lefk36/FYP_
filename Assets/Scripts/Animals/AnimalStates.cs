using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StateId
{
    Wander,
    Search,
    Death,
    Fight,
    Flee,
    Marking
}

public interface AnimalStates
{



    StateId GetId();

    void StartState(Animal predator);
    void Currentstate(Animal predator);
    void NextState(Animal predator);



}