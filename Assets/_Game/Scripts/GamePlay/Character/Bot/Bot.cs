using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Character
{
    private IState<Bot> currentState;
    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    public override void OnInit()
    {
        base.OnInit();
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
    }

    public void ChangeState(IState<Bot> newState)
    {
        if(currentState != newState)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnTer(this);
        }
    }
}
