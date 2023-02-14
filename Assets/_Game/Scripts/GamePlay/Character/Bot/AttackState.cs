using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Bot>
{
    public void OnEnTer(Bot t)
    {
        t.StopMoving();
        if (!t.IsMoving)
        {
            t.OnAttack();
        }
        if (t.CanAttack)
        {
            t.DelayTime.Start(
                () =>
                {
                    t.Throw();
                    t.DelayTime.Start(
                    () =>
                    {
                        t.ChangeState(new IdleState());
                    }, Character.TIME_DELAY_ATTACK);
                }, Character.TIME_DELAY_ATTACK
            );
        }
    }

    public void OnExecute(Bot t)
    {
        t.DelayTime.Execute();   
    }

    public void OnExit(Bot t)
    {
        t.DelayTime.Cancel();
    }
}
