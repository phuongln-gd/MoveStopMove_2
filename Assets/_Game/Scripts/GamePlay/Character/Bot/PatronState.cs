using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronState : IState<Bot>
{
    public void OnEnTer(Bot t)
    {
        Vector3 randPoint = LevelManager.Instance.CurrentLevel.RandomPoint();
        t.SetDestination(randPoint);
        t.IsMoving = true;
        t.DelayTime.Start(() => t.ChangeState(new IdleState()), 2.5f);
    }

    public void OnExecute(Bot t)
    {
        t.DelayTime.Execute();
        if (t.IsDestination)
        {
            t.ChangeState(new IdleState());
        }
    }

    public void OnExit(Bot t)
    {
    }
}
