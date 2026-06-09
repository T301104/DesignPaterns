using UnityEngine;


public class StateMachine
{
    private IStateRunner owner;
    private IState currentState;

    public StateMachine (IStateRunner _owner)
    {
        owner = _owner;
        GameManager.OnMinionUpdate += Update;
        GameManager.OnFixedUpdate += FixedUpdate;
    }

    ~StateMachine()
    {
        GameManager.OnMinionUpdate -= Update;
        GameManager.OnFixedUpdate -= FixedUpdate;
    }

    public void Update()
    {
        currentState?.OnUpdate(owner);
    }

    public void FixedUpdate()
    {
       currentState?.OnFixedUpdate(owner);
    }

    public void SetState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnComplete(owner);
            currentState.onSwitch -= SetState;
        }

        newState.OnStart(owner);
        newState.onSwitch += SetState;

        currentState = newState;
    }
}

