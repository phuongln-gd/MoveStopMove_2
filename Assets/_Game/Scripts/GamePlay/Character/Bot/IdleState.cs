using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class IdleState : IState<Bot>
{
    public void OnEnTer(Bot t)
    {
        t.StopMoving();
        t.DelayTime.Start(()=> t.ChangeState(new PatronState()), Random.Range(0f, 2f));
    }

    public void OnExecute(Bot t)
    {
        t.DelayTime.Execute();
        // kiem tra xem co doi tuong tan cong khong? ...
    }

    public void OnExit(Bot t)
    {
    }
}
