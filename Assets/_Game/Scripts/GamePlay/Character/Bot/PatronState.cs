using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronState : IState<Bot>
{
    public void OnEnTer(Bot t)
    {
        Vector3 randPoint = LevelManager.Instance.CurrentLevel.RandomPoint();
        t.SetDestination(randPoint);
        t.CounterTime.Start(() => t.ChangeState(new IdleState()), 3f);
    }

    public void OnExecute(Bot t)
    {
        t.CounterTime.Execute();
        if (t.IsDestination)
        {
            t.ChangeState(new IdleState());
        }
    }

    public void OnExit(Bot t)
    {
    }
}
