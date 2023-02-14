using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class IdleState : IState<Bot>
{
    public void OnEnTer(Bot t)
    {
        t.IsAttacking = false;
        t.StopMoving();
        t.DelayTime.Start(()=> t.ChangeState(new PatronState()), Random.Range(2f, 3f));
    }

    public void OnExecute(Bot t)
    {
        t.DelayTime.Execute();
        // kiem tra xem co doi tuong tan cong khong? ...
        if (!t.IsMoving && t.CanAttack)
        {
            if (!t.IsAttacking)
            {
                Character target = t.FindTargetInRange();
                if (target != null && t.CanAttack && !target.IsDead)
                {
                    t.ChangeState(new AttackState());
                }
            }
        }
    }

    public void OnExit(Bot t)
    {
    }
}
