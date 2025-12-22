using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class Animal : MonoBehaviour
{

    public AnimalStateMachine stateMachine;
    // The state that is bein excecuted at runtime
    public StateId excecutedState;

    private Vector3 _velocity;
    [SerializeField]
    private string _identification;
    private string _species;
    [SerializeField]
    private float _hungerLevel = 1000f;
    private bool _isAlive = true;

    private bool hasPrey;
    private bool isPreyDefeated;


    public Vector3 Velocity
    {
        get { return _velocity; }
        set { _velocity = value; }
    }

    public string Identification
    {
        get { return _identification; }
        set { _identification = value; }
    }

    public string Species
    {
        get { return _species; }
        set { _species = value; }
    }

    public float HungerLevel
    {
        get { return _hungerLevel; }
        set { _hungerLevel = value; }
    }

    public bool IsAlive
    {
        get { return _isAlive; }
        set { _isAlive = value; }
    }


    private void AnimalDeath(string id)
    {
        IsAlive = false;
        this.gameObject.SetActive(false);
    }

    private IEnumerator DecreaseHunger()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            _hungerLevel -= 10f;

            if (_hungerLevel <= 0f)
            {
                EventManager.current.onAnimalDeath += AnimalDeath;
                
                yield break;
            }
        }
    }

    private void Start()
    {
        StartCoroutine(DecreaseHunger());

        stateMachine = new AnimalStateMachine(this);
        stateMachine.StoreState(new Wander());
       
        stateMachine.ChangeState(excecutedState);


    }

    private void OnDestroy()
    {
        EventManager.current.onAnimalDeath -= AnimalDeath;
    }


    public void StartHunting()
    {
        Debug.Log("Animal is starting to hunt.");
        // Implement hunting behavior here
        hasPrey = true;
    }

    public bool HasPrey()
    {
        return hasPrey;
    }

    public void StartAttacking()
    {
        Debug.Log("Animal is starting to attack prey.");
        // Implement attacking behavior here
        isPreyDefeated = true;
    }

    public bool IsPreyDefeated()
    {
        return isPreyDefeated;
    }

    public void StartPatrolling()
    {
        Debug.Log("Animal is starting to patrol.");
        // Implement patrolling behavior here
    }

    public void StopHunting()
    {
        Debug.Log("Animal has stopped hunting.");
        // Implement stop hunting behavior here
        hasPrey = false;
    }

    public void StopAttacking()
    {
        Debug.Log("Animal has stopped attacking.");
        // Implement stop attacking behavior here
        isPreyDefeated = false;
    }

    public void StopPatrolling()
    {
        Debug.Log("Animal has stopped patrolling.");
        // Implement stop patrolling behavior here
    }
}
