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
        gameObject.SetActive(false);
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

}
