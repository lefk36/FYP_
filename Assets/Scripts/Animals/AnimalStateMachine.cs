using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStateMachine 
{
    public AnimalStates[] m_states;
    public StateId currentState;
    public Animal animal;

    public AnimalStateMachine(Animal  animal)
    {
        this.animal = animal;
        int numOfStates = System.Enum.GetNames(typeof(StateId)).Length;
        m_states = new AnimalStates[numOfStates];
    }


    public void StoreState(AnimalStates m_state)
    {
        int index = (int)m_state.GetId();
        m_states[index] = m_state;
    }

    public AnimalStates GetState(StateId m_Id)
    {
        int index = (int)m_Id;
        return m_states[index];
    }

    public void Update()
    {
        GetState(currentState)?.Currentstate(animal);
    }

    public void ChangeState(StateId newState)
    {
        GetState(currentState)?.NextState(animal);
        currentState = newState;
        GetState(currentState)?.StartState(animal);
    }


}